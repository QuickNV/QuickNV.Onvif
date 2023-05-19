using Newtonsoft.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Quick.Onvif.TestUI.Controls
{
    public partial class ObjectDisplayControl : UserControl
    {
        public Func<Task<object>> FirstValueAsyncFunc { get; set; }
        public Func<Task<object>> RefreshAsyncFunc { get; set; }

        private string currentView = "Tree";
        private object currentObject;

        public ObjectDisplayControl()
        {
            InitializeComponent();
        }
        
        private string object2xml(object obj)
        {
            var serializer = new XmlSerializer(obj.GetType());
            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, obj);
                return writer.ToString();
            }
        }

        private string xmlElementToString(XmlElement element, int level = 0)
        {
            var sb = new StringBuilder();
            var lastChildNode = element.LastChild;
            foreach (var child in element.ChildNodes)
            {
                if (child is XmlText xt)
                {
                    sb.Append(xt.Value);
                }
                else if (child is XmlElement xe)
                {
                    sb.Append($"{string.Empty.PadLeft(level * 4)}{xe.LocalName}: ");
                    if (xe.ChildNodes.Count != 1 || !(xe.FirstChild is XmlText))
                        sb.AppendLine();
                    sb.Append(xmlElementToString(xe, level + 1));
                    if (child != lastChildNode)
                        sb.AppendLine();
                }
                else if (child is XmlAttribute xa)
                {
                    sb.AppendLine($"{string.Empty.PadLeft(level * 4)}{xa.LocalName}: {xa.Value}");
                }
            }
            return sb.ToString();
        }

        private Control object2control(object obj)
        {
            switch (currentView)
            {
                case "XML":
                    return getTextBox(object2xml(obj));
                case "JSON":
                    return getTextBox(JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented));
                case "Tree":
                default:
                    {
                        var sc = new SplitContainer()
                        {
                            Dock = DockStyle.Fill
                        };
                        var treeView = new TreeView()
                        {
                            Dock = DockStyle.Fill,
                            HideSelection = false
                        };
                        sc.Panel1.Controls.Add(treeView);
                        var textBox = new TextBox()
                        {
                            Dock = DockStyle.Fill,
                            ReadOnly = true,
                            Multiline = true,
                            ScrollBars = ScrollBars.Vertical
                        };
                        sc.Panel2.Controls.Add(textBox);
                        treeView.AfterSelect += (sender, e) =>
                        {
                            var el = (XmlElement)e.Node.Tag;
                            if (el == null)
                                textBox.Text = null;
                            else
                                textBox.Text = xmlElementToString(el);
                        };

                        var xml = object2xml(obj);
                        var document = new XmlDocument();
                        document.LoadXml(xml);

                        
                        foreach (XmlNode node in document.ChildNodes)
                        {
                            var el = node as XmlElement;
                            if (el == null)
                                continue;
                            TreeNode treeNode = XmlElement2TreeNode(el);
                            treeNode.Text = node.Name;
                            treeView.Nodes.Add(treeNode);
                        }
                        treeView.ExpandAll();
                        return sc;
                    }
            }
        }

        private TreeNode XmlElement2TreeNode(XmlElement parentNode)
        {
            TreeNode treeNode = new TreeNode();
            treeNode.Tag = parentNode;
            foreach (XmlNode childNode in parentNode.ChildNodes)
            {
                var childEl = childNode as XmlElement;
                if (childEl == null)
                    continue;
                TreeNode childTreeNode = new TreeNode();
                if (childNode.ChildNodes.Count > 0)
                    childTreeNode = XmlElement2TreeNode(childEl);
                childTreeNode.Text = childNode.LocalName;
                treeNode.Nodes.Add(childTreeNode);
            }
            return treeNode;
        }

        private Control getTextBox(string message)
        {
            var txt = new TextBox()
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Text = message
            };
            return txt;
        }

        private void displayControl(Control control)
        {
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(control);
        }

        private void displayMessage(string message)
        {
            displayControl(getTextBox(message));
        }

        private void refreshView()
        {
            if (currentObject == null)
                return;
            var control = object2control(currentObject);
            displayControl(control);
        }

        private async Task refreshAsync()
        {
            if (RefreshAsyncFunc == null)
            {
                displayMessage("'RefreshAsyncFunc' is null.");
            }
            else
            {
                btnRefresh.Enabled = false;
                displayMessage("Refreshing...");
                try
                {
                    var obj = await RefreshAsyncFunc.Invoke();
                    currentObject = obj;
                    refreshView();
                }
                catch (Exception ex)
                {
                    displayMessage(ex.ToString());
                }
                btnRefresh.Enabled = true;
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await refreshAsync();
        }

        private async void ObjectDisplayControl_Load(object sender, EventArgs e)
        {
            cbView.SelectedIndex = 0;
            btnRefresh.Visible = RefreshAsyncFunc != null;
            if (FirstValueAsyncFunc != null)
            {
                currentObject = await FirstValueAsyncFunc.Invoke();
                refreshView();
                return;
            }
            if (RefreshAsyncFunc != null)
            {
                await refreshAsync();
                return;
            }
        }

        private void cbView_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentView = cbView.Text;
            refreshView();
        }
    }
}

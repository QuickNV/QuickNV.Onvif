using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quick.Onvif.TestUI
{
    public partial class ObjectDisplayControl : UserControl
    {
        public Func<Task<object>> FirstValueAsyncFunc { get; set; }
        public Func<Task<object>> RefreshAsyncFunc { get; set; }

        public ObjectDisplayControl()
        {
            InitializeComponent();
        }

        private string object2string(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

        private async Task refreshAsync()
        {
            if (RefreshAsyncFunc == null)
            {
                txtContent.Text = "'RefreshAsyncFunc' is null.";
            }
            else
            {
                btnRefresh.Enabled = false;
                txtContent.Text = "Refreshing...";
                try
                {
                    var obj = await RefreshAsyncFunc.Invoke();
                    txtContent.Text = object2string(obj);
                }
                catch (Exception ex)
                {
                    txtContent.Text = ex.ToString();
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
            if (FirstValueAsyncFunc != null)
            {
                txtContent.Text = object2string(await FirstValueAsyncFunc.Invoke());
                return;
            }
            if (RefreshAsyncFunc != null)
            {
                await refreshAsync();
                return;
            }
            Controls.Remove(tsMain);
        }
    }
}

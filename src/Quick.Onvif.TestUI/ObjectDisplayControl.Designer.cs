namespace Quick.Onvif.TestUI
{
    partial class ObjectDisplayControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectDisplayControl));
            tsMain = new ToolStrip();
            btnRefresh = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripLabel1 = new ToolStripLabel();
            cbView = new ToolStripComboBox();
            pnlContent = new Panel();
            tsMain.SuspendLayout();
            SuspendLayout();
            // 
            // tsMain
            // 
            tsMain.GripStyle = ToolStripGripStyle.Hidden;
            tsMain.ImageScalingSize = new Size(24, 24);
            tsMain.Items.AddRange(new ToolStripItem[] { btnRefresh, toolStripSeparator1, toolStripLabel1, cbView });
            tsMain.Location = new Point(0, 0);
            tsMain.Name = "tsMain";
            tsMain.Padding = new Padding(0, 0, 3, 0);
            tsMain.Size = new Size(826, 41);
            tsMain.TabIndex = 0;
            tsMain.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            btnRefresh.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnRefresh.Image = (Image)resources.GetObject("btnRefresh.Image");
            btnRefresh.ImageTransparentColor = Color.Magenta;
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(105, 35);
            btnRefresh.Text = "Refresh";
            btnRefresh.Click += btnRefresh_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 41);
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(75, 35);
            toolStripLabel1.Text = "View:";
            // 
            // cbView
            // 
            cbView.DropDownStyle = ComboBoxStyle.DropDownList;
            cbView.Items.AddRange(new object[] { "Tree", "JSON", "XML" });
            cbView.Name = "cbView";
            cbView.Size = new Size(121, 41);
            cbView.SelectedIndexChanged += cbView_SelectedIndexChanged;
            // 
            // pnlContent
            // 
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 41);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(826, 580);
            pnlContent.TabIndex = 1;
            // 
            // ObjectDisplayControl
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlContent);
            Controls.Add(tsMain);
            Margin = new Padding(4);
            Name = "ObjectDisplayControl";
            Size = new Size(826, 621);
            Load += ObjectDisplayControl_Load;
            tsMain.ResumeLayout(false);
            tsMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip tsMain;
        private ToolStripButton btnRefresh;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripComboBox cbView;
        private Panel pnlContent;
    }
}

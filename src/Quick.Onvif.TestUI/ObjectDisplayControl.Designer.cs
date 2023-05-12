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
            txtContent = new TextBox();
            tsMain.SuspendLayout();
            SuspendLayout();
            // 
            // tsMain
            // 
            tsMain.ImageScalingSize = new Size(24, 24);
            tsMain.Items.AddRange(new ToolStripItem[] { btnRefresh });
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
            // txtContent
            // 
            txtContent.Dock = DockStyle.Fill;
            txtContent.Location = new Point(0, 41);
            txtContent.Margin = new Padding(4, 4, 4, 4);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.ReadOnly = true;
            txtContent.ScrollBars = ScrollBars.Vertical;
            txtContent.Size = new Size(826, 580);
            txtContent.TabIndex = 1;
            // 
            // ObjectDisplayControl
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtContent);
            Controls.Add(tsMain);
            Margin = new Padding(4, 4, 4, 4);
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
        private TextBox txtContent;
    }
}

namespace Quick.Onvif.TestUI
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            btnLogin = new Button();
            nudRtspPort = new NumericUpDown();
            label6 = new Label();
            nudPort = new NumericUpDown();
            label1 = new Label();
            txtPassword = new TextBox();
            txtHost = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txtUserName = new TextBox();
            cbOverrideRtspPort = new CheckBox();
            cbHttps = new CheckBox();
            cbOverrideSnapshotPort = new CheckBox();
            nudSnapshotPort = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)nudRtspPort).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPort).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSnapshotPort).BeginInit();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(12, 382);
            btnLogin.Margin = new Padding(4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(276, 59);
            btnLogin.TabIndex = 100;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // nudRtspPort
            // 
            nudRtspPort.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nudRtspPort.Location = new Point(367, 283);
            nudRtspPort.Margin = new Padding(4);
            nudRtspPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            nudRtspPort.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
            nudRtspPort.Name = "nudRtspPort";
            nudRtspPort.Size = new Size(138, 38);
            nudRtspPort.TabIndex = 8;
            nudRtspPort.Value = new decimal(new int[] { 1, 0, 0, int.MinValue });
            nudRtspPort.Visible = false;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(367, 9);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(62, 31);
            label6.TabIndex = 21;
            label6.Text = "Port";
            // 
            // nudPort
            // 
            nudPort.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nudPort.Location = new Point(367, 45);
            nudPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            nudPort.Name = "nudPort";
            nudPort.Size = new Size(138, 38);
            nudPort.TabIndex = 3;
            nudPort.Value = new decimal(new int[] { 80, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(68, 31);
            label1.TabIndex = 12;
            label1.Text = "Host";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.Location = new Point(13, 198);
            txtPassword.Margin = new Padding(4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(491, 38);
            txtPassword.TabIndex = 5;
            // 
            // txtHost
            // 
            txtHost.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtHost.Location = new Point(13, 44);
            txtHost.Margin = new Padding(4);
            txtHost.Name = "txtHost";
            txtHost.Size = new Size(347, 38);
            txtHost.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 163);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(122, 31);
            label3.TabIndex = 16;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 86);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(135, 31);
            label2.TabIndex = 14;
            label2.Text = "UserName";
            // 
            // txtUserName
            // 
            txtUserName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUserName.Location = new Point(13, 121);
            txtUserName.Margin = new Padding(4);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(492, 38);
            txtUserName.TabIndex = 4;
            // 
            // cbOverrideRtspPort
            // 
            cbOverrideRtspPort.AutoSize = true;
            cbOverrideRtspPort.Location = new Point(13, 284);
            cbOverrideRtspPort.Name = "cbOverrideRtspPort";
            cbOverrideRtspPort.Size = new Size(267, 35);
            cbOverrideRtspPort.TabIndex = 7;
            cbOverrideRtspPort.Text = "Override RTSP Port";
            cbOverrideRtspPort.UseVisualStyleBackColor = true;
            cbOverrideRtspPort.CheckedChanged += cbOverrideRtspPort_CheckedChanged;
            // 
            // cbHttps
            // 
            cbHttps.AutoSize = true;
            cbHttps.Location = new Point(12, 243);
            cbHttps.Name = "cbHttps";
            cbHttps.Size = new Size(185, 35);
            cbHttps.TabIndex = 6;
            cbHttps.Text = "TLS (HTTPS)";
            cbHttps.UseVisualStyleBackColor = true;
            // 
            // cbOverrideSnapshotPort
            // 
            cbOverrideSnapshotPort.AutoSize = true;
            cbOverrideSnapshotPort.Location = new Point(13, 330);
            cbOverrideSnapshotPort.Name = "cbOverrideSnapshotPort";
            cbOverrideSnapshotPort.Size = new Size(315, 35);
            cbOverrideSnapshotPort.TabIndex = 101;
            cbOverrideSnapshotPort.Text = "Override Snapshot Port";
            cbOverrideSnapshotPort.UseVisualStyleBackColor = true;
            cbOverrideSnapshotPort.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // nudSnapshotPort
            // 
            nudSnapshotPort.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nudSnapshotPort.Location = new Point(367, 329);
            nudSnapshotPort.Margin = new Padding(4);
            nudSnapshotPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            nudSnapshotPort.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
            nudSnapshotPort.Name = "nudSnapshotPort";
            nudSnapshotPort.Size = new Size(138, 38);
            nudSnapshotPort.TabIndex = 102;
            nudSnapshotPort.Value = new decimal(new int[] { 1, 0, 0, int.MinValue });
            nudSnapshotPort.Visible = false;
            // 
            // LoginForm
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(516, 454);
            Controls.Add(cbOverrideSnapshotPort);
            Controls.Add(nudSnapshotPort);
            Controls.Add(cbHttps);
            Controls.Add(cbOverrideRtspPort);
            Controls.Add(nudRtspPort);
            Controls.Add(label6);
            Controls.Add(nudPort);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Controls.Add(txtHost);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtUserName);
            Controls.Add(btnLogin);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quick.Onvif.TestUI";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)nudRtspPort).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPort).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSnapshotPort).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnLogin;
        private NumericUpDown nudRtspPort;
        private Label label6;
        private NumericUpDown nudPort;
        private Label label1;
        private TextBox txtPassword;
        private TextBox txtHost;
        private Label label3;
        private Label label2;
        private TextBox txtUserName;
        private CheckBox cbOverrideRtspPort;
        private CheckBox cbHttps;
        private CheckBox cbOverrideSnapshotPort;
        private NumericUpDown nudSnapshotPort;
    }
}
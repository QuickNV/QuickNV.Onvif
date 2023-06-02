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
            label4 = new Label();
            cbCredentialType = new ComboBox();
            pnlCredentialType = new Panel();
            ((System.ComponentModel.ISupportInitialize)nudRtspPort).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPort).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSnapshotPort).BeginInit();
            pnlCredentialType.SuspendLayout();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(13, 459);
            btnLogin.Margin = new Padding(4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(493, 59);
            btnLogin.TabIndex = 100;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // nudRtspPort
            // 
            nudRtspPort.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nudRtspPort.Location = new Point(367, 367);
            nudRtspPort.Margin = new Padding(4);
            nudRtspPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            nudRtspPort.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
            nudRtspPort.Name = "nudRtspPort";
            nudRtspPort.Size = new Size(138, 38);
            nudRtspPort.TabIndex = 9;
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
            txtPassword.Location = new Point(2, 116);
            txtPassword.Margin = new Padding(4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(488, 38);
            txtPassword.TabIndex = 6;
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
            label3.Location = new Point(2, 81);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(122, 31);
            label3.TabIndex = 16;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(2, 4);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(135, 31);
            label2.TabIndex = 14;
            label2.Text = "UserName";
            // 
            // txtUserName
            // 
            txtUserName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUserName.Location = new Point(2, 39);
            txtUserName.Margin = new Padding(4);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(488, 38);
            txtUserName.TabIndex = 5;
            // 
            // cbOverrideRtspPort
            // 
            cbOverrideRtspPort.AutoSize = true;
            cbOverrideRtspPort.Location = new Point(13, 368);
            cbOverrideRtspPort.Name = "cbOverrideRtspPort";
            cbOverrideRtspPort.Size = new Size(267, 35);
            cbOverrideRtspPort.TabIndex = 8;
            cbOverrideRtspPort.Text = "Override RTSP Port";
            cbOverrideRtspPort.UseVisualStyleBackColor = true;
            cbOverrideRtspPort.CheckedChanged += cbOverrideRtspPort_CheckedChanged;
            // 
            // cbHttps
            // 
            cbHttps.AutoSize = true;
            cbHttps.Location = new Point(12, 327);
            cbHttps.Name = "cbHttps";
            cbHttps.Size = new Size(185, 35);
            cbHttps.TabIndex = 7;
            cbHttps.Text = "TLS (HTTPS)";
            cbHttps.UseVisualStyleBackColor = true;
            // 
            // cbOverrideSnapshotPort
            // 
            cbOverrideSnapshotPort.AutoSize = true;
            cbOverrideSnapshotPort.Location = new Point(13, 414);
            cbOverrideSnapshotPort.Name = "cbOverrideSnapshotPort";
            cbOverrideSnapshotPort.Size = new Size(315, 35);
            cbOverrideSnapshotPort.TabIndex = 10;
            cbOverrideSnapshotPort.Text = "Override Snapshot Port";
            cbOverrideSnapshotPort.UseVisualStyleBackColor = true;
            cbOverrideSnapshotPort.CheckedChanged += cbOverrideSnapshotPort_CheckedChanged;
            // 
            // nudSnapshotPort
            // 
            nudSnapshotPort.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nudSnapshotPort.Location = new Point(367, 413);
            nudSnapshotPort.Margin = new Padding(4);
            nudSnapshotPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            nudSnapshotPort.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
            nudSnapshotPort.Name = "nudSnapshotPort";
            nudSnapshotPort.Size = new Size(138, 38);
            nudSnapshotPort.TabIndex = 11;
            nudSnapshotPort.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 86);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(187, 31);
            label4.TabIndex = 14;
            label4.Text = "CredentialType";
            // 
            // cbCredentialType
            // 
            cbCredentialType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbCredentialType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCredentialType.FormattingEnabled = true;
            cbCredentialType.Items.AddRange(new object[] { "None", "Digest", "Basic" });
            cbCredentialType.Location = new Point(13, 120);
            cbCredentialType.Name = "cbCredentialType";
            cbCredentialType.Size = new Size(492, 39);
            cbCredentialType.TabIndex = 4;
            cbCredentialType.SelectedIndexChanged += cbCredentialType_SelectedIndexChanged;
            // 
            // pnlCredentialType
            // 
            pnlCredentialType.Controls.Add(label2);
            pnlCredentialType.Controls.Add(txtUserName);
            pnlCredentialType.Controls.Add(label3);
            pnlCredentialType.Controls.Add(txtPassword);
            pnlCredentialType.Location = new Point(13, 162);
            pnlCredentialType.Name = "pnlCredentialType";
            pnlCredentialType.Size = new Size(492, 159);
            pnlCredentialType.TabIndex = 5;
            // 
            // LoginForm
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(516, 536);
            Controls.Add(pnlCredentialType);
            Controls.Add(cbCredentialType);
            Controls.Add(cbOverrideSnapshotPort);
            Controls.Add(nudSnapshotPort);
            Controls.Add(cbHttps);
            Controls.Add(cbOverrideRtspPort);
            Controls.Add(nudRtspPort);
            Controls.Add(label6);
            Controls.Add(nudPort);
            Controls.Add(label1);
            Controls.Add(txtHost);
            Controls.Add(label4);
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
            pnlCredentialType.ResumeLayout(false);
            pnlCredentialType.PerformLayout();
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
        private Label label4;
        private ComboBox cbCredentialType;
        private Panel pnlCredentialType;
    }
}
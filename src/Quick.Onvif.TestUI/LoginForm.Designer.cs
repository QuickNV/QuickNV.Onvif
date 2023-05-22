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
            cbScheme = new ComboBox();
            label5 = new Label();
            label1 = new Label();
            txtPassword = new TextBox();
            txtHost = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txtUserName = new TextBox();
            cbOverrideRtspPort = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)nudRtspPort).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPort).BeginInit();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(13, 481);
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
            nudRtspPort.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            nudRtspPort.Location = new Point(320, 404);
            nudRtspPort.Margin = new Padding(4);
            nudRtspPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            nudRtspPort.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
            nudRtspPort.Name = "nudRtspPort";
            nudRtspPort.Size = new Size(189, 38);
            nudRtspPort.TabIndex = 6;
            nudRtspPort.Value = new decimal(new int[] { 1, 0, 0, int.MinValue });
            nudRtspPort.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 171);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(62, 31);
            label6.TabIndex = 21;
            label6.Text = "Port";
            // 
            // nudPort
            // 
            nudPort.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            nudPort.Location = new Point(13, 205);
            nudPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            nudPort.Name = "nudPort";
            nudPort.Size = new Size(496, 38);
            nudPort.TabIndex = 3;
            nudPort.Value = new decimal(new int[] { 80, 0, 0, 0 });
            // 
            // cbScheme
            // 
            cbScheme.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbScheme.DropDownStyle = ComboBoxStyle.DropDownList;
            cbScheme.FormattingEnabled = true;
            cbScheme.Items.AddRange(new object[] { "http", "https" });
            cbScheme.Location = new Point(13, 43);
            cbScheme.Name = "cbScheme";
            cbScheme.Size = new Size(496, 39);
            cbScheme.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 9);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(105, 31);
            label5.TabIndex = 18;
            label5.Text = "Scheme";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 90);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(68, 31);
            label1.TabIndex = 12;
            label1.Text = "Host";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.Location = new Point(13, 358);
            txtPassword.Margin = new Padding(4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(495, 38);
            txtPassword.TabIndex = 5;
            // 
            // txtHost
            // 
            txtHost.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtHost.Location = new Point(13, 125);
            txtHost.Margin = new Padding(4);
            txtHost.Name = "txtHost";
            txtHost.Size = new Size(495, 38);
            txtHost.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 323);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(122, 31);
            label3.TabIndex = 16;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 246);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(135, 31);
            label2.TabIndex = 14;
            label2.Text = "UserName";
            // 
            // txtUserName
            // 
            txtUserName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUserName.Location = new Point(13, 281);
            txtUserName.Margin = new Padding(4);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(496, 38);
            txtUserName.TabIndex = 4;
            // 
            // cbOverrideRtspPort
            // 
            cbOverrideRtspPort.AutoSize = true;
            cbOverrideRtspPort.Location = new Point(13, 405);
            cbOverrideRtspPort.Name = "cbOverrideRtspPort";
            cbOverrideRtspPort.Size = new Size(267, 35);
            cbOverrideRtspPort.TabIndex = 101;
            cbOverrideRtspPort.Text = "Override RTSP Port";
            cbOverrideRtspPort.UseVisualStyleBackColor = true;
            cbOverrideRtspPort.CheckedChanged += cbOverrideRtspPort_CheckedChanged;
            // 
            // LoginForm
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 556);
            Controls.Add(cbOverrideRtspPort);
            Controls.Add(nudRtspPort);
            Controls.Add(label6);
            Controls.Add(nudPort);
            Controls.Add(cbScheme);
            Controls.Add(label5);
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnLogin;
        private NumericUpDown nudRtspPort;
        private Label label6;
        private NumericUpDown nudPort;
        private ComboBox cbScheme;
        private Label label5;
        private Label label1;
        private TextBox txtPassword;
        private TextBox txtHost;
        private Label label3;
        private Label label2;
        private TextBox txtUserName;
        private CheckBox cbOverrideRtspPort;
    }
}
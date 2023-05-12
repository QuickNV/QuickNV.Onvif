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
            label1 = new Label();
            txtDeviceServiceAddress = new TextBox();
            txtUserName = new TextBox();
            label2 = new Label();
            txtPassword = new TextBox();
            label3 = new Label();
            tcConnectInfo = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            nudRtspPort = new NumericUpDown();
            label4 = new Label();
            btnLogin = new Button();
            tcConnectInfo.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudRtspPort).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 4);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(279, 31);
            label1.TabIndex = 0;
            label1.Text = "Device Service Address";
            // 
            // txtDeviceServiceAddress
            // 
            txtDeviceServiceAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDeviceServiceAddress.Location = new Point(8, 39);
            txtDeviceServiceAddress.Margin = new Padding(4, 4, 4, 4);
            txtDeviceServiceAddress.Name = "txtDeviceServiceAddress";
            txtDeviceServiceAddress.Size = new Size(686, 38);
            txtDeviceServiceAddress.TabIndex = 1;
            // 
            // txtUserName
            // 
            txtUserName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUserName.Location = new Point(8, 116);
            txtUserName.Margin = new Padding(4, 4, 4, 4);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(686, 38);
            txtUserName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 81);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(135, 31);
            label2.TabIndex = 2;
            label2.Text = "UserName";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.Location = new Point(8, 194);
            txtPassword.Margin = new Padding(4, 4, 4, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(686, 38);
            txtPassword.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 159);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(122, 31);
            label3.TabIndex = 4;
            label3.Text = "Password";
            // 
            // tcConnectInfo
            // 
            tcConnectInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tcConnectInfo.Controls.Add(tabPage1);
            tcConnectInfo.Controls.Add(tabPage2);
            tcConnectInfo.Location = new Point(15, 16);
            tcConnectInfo.Margin = new Padding(4, 4, 4, 4);
            tcConnectInfo.Name = "tcConnectInfo";
            tcConnectInfo.SelectedIndex = 0;
            tcConnectInfo.Size = new Size(717, 324);
            tcConnectInfo.TabIndex = 6;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(txtPassword);
            tabPage1.Controls.Add(txtDeviceServiceAddress);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(txtUserName);
            tabPage1.Location = new Point(8, 45);
            tabPage1.Margin = new Padding(4, 4, 4, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(4, 4, 4, 4);
            tabPage1.Size = new Size(701, 271);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Basic";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(nudRtspPort);
            tabPage2.Controls.Add(label4);
            tabPage2.Location = new Point(8, 45);
            tabPage2.Margin = new Padding(4, 4, 4, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(4, 4, 4, 4);
            tabPage2.Size = new Size(701, 271);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Advance";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // nudRtspPort
            // 
            nudRtspPort.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            nudRtspPort.Location = new Point(8, 39);
            nudRtspPort.Margin = new Padding(4, 4, 4, 4);
            nudRtspPort.Maximum = new decimal(new int[] { 65536, 0, 0, 0 });
            nudRtspPort.Name = "nudRtspPort";
            nudRtspPort.Size = new Size(686, 38);
            nudRtspPort.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 4);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(128, 31);
            label4.TabIndex = 2;
            label4.Text = "RTSP Port";
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLogin.Location = new Point(15, 347);
            btnLogin.Margin = new Padding(4, 4, 4, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(276, 59);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // LoginForm
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(747, 422);
            Controls.Add(btnLogin);
            Controls.Add(tcConnectInfo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 4, 4, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quick.Onvif.TestUI";
            Load += LoginForm_Load;
            tcConnectInfo.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudRtspPort).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox txtDeviceServiceAddress;
        private TextBox txtUserName;
        private Label label2;
        private TextBox txtPassword;
        private Label label3;
        private TabControl tcConnectInfo;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button btnLogin;
        private NumericUpDown nudRtspPort;
        private Label label4;
    }
}
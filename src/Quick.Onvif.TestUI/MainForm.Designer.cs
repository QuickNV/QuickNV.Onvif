namespace Quick.Onvif.TestUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tcMain = new TabControl();
            tpDevice = new TabPage();
            tabControl2 = new TabControl();
            tpDeviceInformation = new TabPage();
            odcDeviceInformation = new ObjectDisplayControl();
            tpDeviceCapabilities = new TabPage();
            tpNetwork = new TabPage();
            tabControl1 = new TabControl();
            tpNetworkInterfaces = new TabPage();
            odcNetworkInterfaces = new ObjectDisplayControl();
            tpNetworkProtocols = new TabPage();
            odcNetworkProtocols = new ObjectDisplayControl();
            tpNetworkDefaultGateway = new TabPage();
            odcNetworkDefaultGateway = new ObjectDisplayControl();
            tpNetworkDNS = new TabPage();
            odcDNS = new ObjectDisplayControl();
            odcDeviceCapabilities = new ObjectDisplayControl();
            tcMain.SuspendLayout();
            tpDevice.SuspendLayout();
            tabControl2.SuspendLayout();
            tpDeviceInformation.SuspendLayout();
            tpDeviceCapabilities.SuspendLayout();
            tpNetwork.SuspendLayout();
            tabControl1.SuspendLayout();
            tpNetworkInterfaces.SuspendLayout();
            tpNetworkProtocols.SuspendLayout();
            tpNetworkDefaultGateway.SuspendLayout();
            tpNetworkDNS.SuspendLayout();
            SuspendLayout();
            // 
            // tcMain
            // 
            tcMain.Controls.Add(tpDevice);
            tcMain.Controls.Add(tpNetwork);
            tcMain.Dock = DockStyle.Fill;
            tcMain.Location = new Point(0, 0);
            tcMain.Margin = new Padding(4);
            tcMain.Name = "tcMain";
            tcMain.SelectedIndex = 0;
            tcMain.Size = new Size(1287, 809);
            tcMain.TabIndex = 0;
            // 
            // tpDevice
            // 
            tpDevice.Controls.Add(tabControl2);
            tpDevice.Location = new Point(8, 45);
            tpDevice.Margin = new Padding(4);
            tpDevice.Name = "tpDevice";
            tpDevice.Padding = new Padding(4);
            tpDevice.Size = new Size(1271, 756);
            tpDevice.TabIndex = 0;
            tpDevice.Text = "Device";
            tpDevice.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tpDeviceInformation);
            tabControl2.Controls.Add(tpDeviceCapabilities);
            tabControl2.Dock = DockStyle.Fill;
            tabControl2.Location = new Point(4, 4);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(1263, 748);
            tabControl2.TabIndex = 1;
            // 
            // tpDeviceInformation
            // 
            tpDeviceInformation.Controls.Add(odcDeviceInformation);
            tpDeviceInformation.Location = new Point(8, 45);
            tpDeviceInformation.Name = "tpDeviceInformation";
            tpDeviceInformation.Padding = new Padding(3);
            tpDeviceInformation.Size = new Size(1247, 695);
            tpDeviceInformation.TabIndex = 0;
            tpDeviceInformation.Text = "Information";
            tpDeviceInformation.UseVisualStyleBackColor = true;
            // 
            // odcDeviceInformation
            // 
            odcDeviceInformation.Dock = DockStyle.Fill;
            odcDeviceInformation.FirstValueAsyncFunc = null;
            odcDeviceInformation.Location = new Point(3, 3);
            odcDeviceInformation.Margin = new Padding(5);
            odcDeviceInformation.Name = "odcDeviceInformation";
            odcDeviceInformation.RefreshAsyncFunc = null;
            odcDeviceInformation.Size = new Size(1241, 689);
            odcDeviceInformation.TabIndex = 0;
            // 
            // tpDeviceCapabilities
            // 
            tpDeviceCapabilities.Controls.Add(odcDeviceCapabilities);
            tpDeviceCapabilities.Location = new Point(8, 45);
            tpDeviceCapabilities.Name = "tpDeviceCapabilities";
            tpDeviceCapabilities.Padding = new Padding(3);
            tpDeviceCapabilities.Size = new Size(1247, 695);
            tpDeviceCapabilities.TabIndex = 1;
            tpDeviceCapabilities.Text = "Capabilities";
            tpDeviceCapabilities.UseVisualStyleBackColor = true;
            // 
            // tpNetwork
            // 
            tpNetwork.Controls.Add(tabControl1);
            tpNetwork.Location = new Point(8, 45);
            tpNetwork.Margin = new Padding(4);
            tpNetwork.Name = "tpNetwork";
            tpNetwork.Padding = new Padding(4);
            tpNetwork.Size = new Size(1271, 756);
            tpNetwork.TabIndex = 1;
            tpNetwork.Text = "Network";
            tpNetwork.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tpNetworkInterfaces);
            tabControl1.Controls.Add(tpNetworkProtocols);
            tabControl1.Controls.Add(tpNetworkDefaultGateway);
            tabControl1.Controls.Add(tpNetworkDNS);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(4, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1263, 748);
            tabControl1.TabIndex = 1;
            // 
            // tpNetworkInterfaces
            // 
            tpNetworkInterfaces.Controls.Add(odcNetworkInterfaces);
            tpNetworkInterfaces.Location = new Point(8, 45);
            tpNetworkInterfaces.Name = "tpNetworkInterfaces";
            tpNetworkInterfaces.Padding = new Padding(3);
            tpNetworkInterfaces.Size = new Size(1247, 695);
            tpNetworkInterfaces.TabIndex = 0;
            tpNetworkInterfaces.Text = "Interfaces";
            tpNetworkInterfaces.UseVisualStyleBackColor = true;
            // 
            // odcNetworkInterfaces
            // 
            odcNetworkInterfaces.Dock = DockStyle.Fill;
            odcNetworkInterfaces.FirstValueAsyncFunc = null;
            odcNetworkInterfaces.Location = new Point(3, 3);
            odcNetworkInterfaces.Margin = new Padding(5);
            odcNetworkInterfaces.Name = "odcNetworkInterfaces";
            odcNetworkInterfaces.RefreshAsyncFunc = null;
            odcNetworkInterfaces.Size = new Size(1241, 689);
            odcNetworkInterfaces.TabIndex = 0;
            // 
            // tpNetworkProtocols
            // 
            tpNetworkProtocols.Controls.Add(odcNetworkProtocols);
            tpNetworkProtocols.Location = new Point(8, 45);
            tpNetworkProtocols.Name = "tpNetworkProtocols";
            tpNetworkProtocols.Padding = new Padding(3);
            tpNetworkProtocols.Size = new Size(1247, 695);
            tpNetworkProtocols.TabIndex = 1;
            tpNetworkProtocols.Text = "Protocols";
            tpNetworkProtocols.UseVisualStyleBackColor = true;
            // 
            // odcNetworkProtocols
            // 
            odcNetworkProtocols.Dock = DockStyle.Fill;
            odcNetworkProtocols.FirstValueAsyncFunc = null;
            odcNetworkProtocols.Location = new Point(3, 3);
            odcNetworkProtocols.Margin = new Padding(5);
            odcNetworkProtocols.Name = "odcNetworkProtocols";
            odcNetworkProtocols.RefreshAsyncFunc = null;
            odcNetworkProtocols.Size = new Size(1241, 689);
            odcNetworkProtocols.TabIndex = 1;
            // 
            // tpNetworkDefaultGateway
            // 
            tpNetworkDefaultGateway.Controls.Add(odcNetworkDefaultGateway);
            tpNetworkDefaultGateway.Location = new Point(8, 45);
            tpNetworkDefaultGateway.Name = "tpNetworkDefaultGateway";
            tpNetworkDefaultGateway.Padding = new Padding(3);
            tpNetworkDefaultGateway.Size = new Size(1247, 695);
            tpNetworkDefaultGateway.TabIndex = 2;
            tpNetworkDefaultGateway.Text = "DefaultGateway";
            tpNetworkDefaultGateway.UseVisualStyleBackColor = true;
            // 
            // odcNetworkDefaultGateway
            // 
            odcNetworkDefaultGateway.Dock = DockStyle.Fill;
            odcNetworkDefaultGateway.FirstValueAsyncFunc = null;
            odcNetworkDefaultGateway.Location = new Point(3, 3);
            odcNetworkDefaultGateway.Margin = new Padding(5);
            odcNetworkDefaultGateway.Name = "odcNetworkDefaultGateway";
            odcNetworkDefaultGateway.RefreshAsyncFunc = null;
            odcNetworkDefaultGateway.Size = new Size(1241, 689);
            odcNetworkDefaultGateway.TabIndex = 2;
            // 
            // tpNetworkDNS
            // 
            tpNetworkDNS.Controls.Add(odcDNS);
            tpNetworkDNS.Location = new Point(8, 45);
            tpNetworkDNS.Name = "tpNetworkDNS";
            tpNetworkDNS.Padding = new Padding(3);
            tpNetworkDNS.Size = new Size(1247, 695);
            tpNetworkDNS.TabIndex = 3;
            tpNetworkDNS.Text = "DNS";
            tpNetworkDNS.UseVisualStyleBackColor = true;
            // 
            // odcDNS
            // 
            odcDNS.Dock = DockStyle.Fill;
            odcDNS.FirstValueAsyncFunc = null;
            odcDNS.Location = new Point(3, 3);
            odcDNS.Margin = new Padding(5);
            odcDNS.Name = "odcDNS";
            odcDNS.RefreshAsyncFunc = null;
            odcDNS.Size = new Size(1241, 689);
            odcDNS.TabIndex = 3;
            // 
            // odcDeviceCapabilities
            // 
            odcDeviceCapabilities.Dock = DockStyle.Fill;
            odcDeviceCapabilities.FirstValueAsyncFunc = null;
            odcDeviceCapabilities.Location = new Point(3, 3);
            odcDeviceCapabilities.Margin = new Padding(5);
            odcDeviceCapabilities.Name = "odcDeviceCapabilities";
            odcDeviceCapabilities.RefreshAsyncFunc = null;
            odcDeviceCapabilities.Size = new Size(1241, 689);
            odcDeviceCapabilities.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1287, 809);
            Controls.Add(tcMain);
            Margin = new Padding(4);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            tcMain.ResumeLayout(false);
            tpDevice.ResumeLayout(false);
            tabControl2.ResumeLayout(false);
            tpDeviceInformation.ResumeLayout(false);
            tpDeviceCapabilities.ResumeLayout(false);
            tpNetwork.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tpNetworkInterfaces.ResumeLayout(false);
            tpNetworkProtocols.ResumeLayout(false);
            tpNetworkDefaultGateway.ResumeLayout(false);
            tpNetworkDNS.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tcMain;
        private TabPage tpDevice;
        private TabPage tpNetwork;
        private ObjectDisplayControl odcDeviceInformation;
        private ObjectDisplayControl odcNetworkInterfaces;
        private TabControl tabControl1;
        private TabPage tpNetworkInterfaces;
        private TabPage tpNetworkProtocols;
        private TabPage tpNetworkDefaultGateway;
        private ObjectDisplayControl odcNetworkProtocols;
        private ObjectDisplayControl odcNetworkDefaultGateway;
        private TabPage tpNetworkDNS;
        private ObjectDisplayControl odcDNS;
        private TabControl tabControl2;
        private TabPage tpDeviceInformation;
        private TabPage tpDeviceCapabilities;
        private ObjectDisplayControl odcDeviceCapabilities;
    }
}
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tcMain = new TabControl();
            tpDevice = new TabPage();
            tabControl2 = new TabControl();
            tpDeviceInformation = new TabPage();
            odcDeviceInformation = new Controls.ObjectDisplayControl();
            tpDeviceCapabilities = new TabPage();
            odcDeviceCapabilities = new Controls.ObjectDisplayControl();
            tpNetwork = new TabPage();
            tabControl1 = new TabControl();
            tpNetworkInterfaces = new TabPage();
            odcNetworkInterfaces = new Controls.ObjectDisplayControl();
            tpNetworkProtocols = new TabPage();
            odcNetworkProtocols = new Controls.ObjectDisplayControl();
            tpNetworkDefaultGateway = new TabPage();
            odcNetworkDefaultGateway = new Controls.ObjectDisplayControl();
            tpNetworkDNS = new TabPage();
            odcDNS = new Controls.ObjectDisplayControl();
            tpMedia = new TabPage();
            tabControl3 = new TabControl();
            tpMediaVideoSourceConfigurations = new TabPage();
            odcMediaVideoSourceConfigurations = new Controls.ObjectDisplayControl();
            tpMediaVideoSources = new TabPage();
            odcMediaVideoSources = new Controls.ObjectDisplayControl();
            tpMediaProfiles = new TabPage();
            odcMediaProfiles = new Controls.ObjectDisplayControl();
            tpPreview = new TabPage();
            scPreview = new SplitContainer();
            gbPreviewPTZ = new GroupBox();
            btnPtzFocusNear = new Button();
            btnPtzFocusFar = new Button();
            btnPtzZoomOut = new Button();
            btnPtzZoomIn = new Button();
            btnPtzRight = new Button();
            btnPtzLeft = new Button();
            btnPtzUp = new Button();
            btnPtzDown = new Button();
            gbPreviewProfile = new GroupBox();
            btnPreviewLive = new Button();
            cbProfiles = new ComboBox();
            btnPreviewSnapshot = new Button();
            txtPreviewProfileInfo = new TextBox();
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
            tpMedia.SuspendLayout();
            tabControl3.SuspendLayout();
            tpMediaVideoSourceConfigurations.SuspendLayout();
            tpMediaVideoSources.SuspendLayout();
            tpMediaProfiles.SuspendLayout();
            tpPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)scPreview).BeginInit();
            scPreview.Panel1.SuspendLayout();
            scPreview.SuspendLayout();
            gbPreviewPTZ.SuspendLayout();
            gbPreviewProfile.SuspendLayout();
            SuspendLayout();
            // 
            // tcMain
            // 
            tcMain.Controls.Add(tpDevice);
            tcMain.Controls.Add(tpNetwork);
            tcMain.Controls.Add(tpMedia);
            tcMain.Controls.Add(tpPreview);
            tcMain.Dock = DockStyle.Fill;
            tcMain.Location = new Point(0, 0);
            tcMain.Margin = new Padding(4);
            tcMain.Name = "tcMain";
            tcMain.SelectedIndex = 0;
            tcMain.Size = new Size(1468, 944);
            tcMain.TabIndex = 0;
            // 
            // tpDevice
            // 
            tpDevice.Controls.Add(tabControl2);
            tpDevice.Location = new Point(8, 45);
            tpDevice.Margin = new Padding(4);
            tpDevice.Name = "tpDevice";
            tpDevice.Padding = new Padding(4);
            tpDevice.Size = new Size(1452, 891);
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
            tabControl2.Size = new Size(1444, 883);
            tabControl2.TabIndex = 1;
            // 
            // tpDeviceInformation
            // 
            tpDeviceInformation.Controls.Add(odcDeviceInformation);
            tpDeviceInformation.Location = new Point(8, 45);
            tpDeviceInformation.Name = "tpDeviceInformation";
            tpDeviceInformation.Padding = new Padding(3);
            tpDeviceInformation.Size = new Size(1428, 830);
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
            odcDeviceInformation.Size = new Size(1422, 824);
            odcDeviceInformation.TabIndex = 0;
            // 
            // tpDeviceCapabilities
            // 
            tpDeviceCapabilities.Controls.Add(odcDeviceCapabilities);
            tpDeviceCapabilities.Location = new Point(8, 45);
            tpDeviceCapabilities.Name = "tpDeviceCapabilities";
            tpDeviceCapabilities.Padding = new Padding(3);
            tpDeviceCapabilities.Size = new Size(1428, 830);
            tpDeviceCapabilities.TabIndex = 1;
            tpDeviceCapabilities.Text = "Capabilities";
            tpDeviceCapabilities.UseVisualStyleBackColor = true;
            // 
            // odcDeviceCapabilities
            // 
            odcDeviceCapabilities.Dock = DockStyle.Fill;
            odcDeviceCapabilities.FirstValueAsyncFunc = null;
            odcDeviceCapabilities.Location = new Point(3, 3);
            odcDeviceCapabilities.Margin = new Padding(5);
            odcDeviceCapabilities.Name = "odcDeviceCapabilities";
            odcDeviceCapabilities.RefreshAsyncFunc = null;
            odcDeviceCapabilities.Size = new Size(1422, 824);
            odcDeviceCapabilities.TabIndex = 1;
            // 
            // tpNetwork
            // 
            tpNetwork.Controls.Add(tabControl1);
            tpNetwork.Location = new Point(8, 45);
            tpNetwork.Margin = new Padding(4);
            tpNetwork.Name = "tpNetwork";
            tpNetwork.Padding = new Padding(4);
            tpNetwork.Size = new Size(1452, 891);
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
            tabControl1.Size = new Size(1444, 883);
            tabControl1.TabIndex = 1;
            // 
            // tpNetworkInterfaces
            // 
            tpNetworkInterfaces.Controls.Add(odcNetworkInterfaces);
            tpNetworkInterfaces.Location = new Point(8, 45);
            tpNetworkInterfaces.Name = "tpNetworkInterfaces";
            tpNetworkInterfaces.Padding = new Padding(3);
            tpNetworkInterfaces.Size = new Size(1428, 830);
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
            odcNetworkInterfaces.Size = new Size(1422, 824);
            odcNetworkInterfaces.TabIndex = 0;
            // 
            // tpNetworkProtocols
            // 
            tpNetworkProtocols.Controls.Add(odcNetworkProtocols);
            tpNetworkProtocols.Location = new Point(8, 45);
            tpNetworkProtocols.Name = "tpNetworkProtocols";
            tpNetworkProtocols.Padding = new Padding(3);
            tpNetworkProtocols.Size = new Size(1428, 830);
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
            odcNetworkProtocols.Size = new Size(1422, 824);
            odcNetworkProtocols.TabIndex = 1;
            // 
            // tpNetworkDefaultGateway
            // 
            tpNetworkDefaultGateway.Controls.Add(odcNetworkDefaultGateway);
            tpNetworkDefaultGateway.Location = new Point(8, 45);
            tpNetworkDefaultGateway.Name = "tpNetworkDefaultGateway";
            tpNetworkDefaultGateway.Padding = new Padding(3);
            tpNetworkDefaultGateway.Size = new Size(1428, 830);
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
            odcNetworkDefaultGateway.Size = new Size(1422, 824);
            odcNetworkDefaultGateway.TabIndex = 2;
            // 
            // tpNetworkDNS
            // 
            tpNetworkDNS.Controls.Add(odcDNS);
            tpNetworkDNS.Location = new Point(8, 45);
            tpNetworkDNS.Name = "tpNetworkDNS";
            tpNetworkDNS.Padding = new Padding(3);
            tpNetworkDNS.Size = new Size(1428, 830);
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
            odcDNS.Size = new Size(1422, 824);
            odcDNS.TabIndex = 3;
            // 
            // tpMedia
            // 
            tpMedia.Controls.Add(tabControl3);
            tpMedia.Location = new Point(8, 45);
            tpMedia.Name = "tpMedia";
            tpMedia.Size = new Size(1452, 891);
            tpMedia.TabIndex = 2;
            tpMedia.Text = "Media";
            tpMedia.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            tabControl3.Controls.Add(tpMediaVideoSourceConfigurations);
            tabControl3.Controls.Add(tpMediaVideoSources);
            tabControl3.Controls.Add(tpMediaProfiles);
            tabControl3.Dock = DockStyle.Fill;
            tabControl3.Location = new Point(0, 0);
            tabControl3.Name = "tabControl3";
            tabControl3.SelectedIndex = 0;
            tabControl3.Size = new Size(1452, 891);
            tabControl3.TabIndex = 2;
            // 
            // tpMediaVideoSourceConfigurations
            // 
            tpMediaVideoSourceConfigurations.Controls.Add(odcMediaVideoSourceConfigurations);
            tpMediaVideoSourceConfigurations.Location = new Point(8, 45);
            tpMediaVideoSourceConfigurations.Name = "tpMediaVideoSourceConfigurations";
            tpMediaVideoSourceConfigurations.Padding = new Padding(3);
            tpMediaVideoSourceConfigurations.Size = new Size(1436, 838);
            tpMediaVideoSourceConfigurations.TabIndex = 2;
            tpMediaVideoSourceConfigurations.Text = "VideoSourceConfigurations";
            tpMediaVideoSourceConfigurations.UseVisualStyleBackColor = true;
            // 
            // odcMediaVideoSourceConfigurations
            // 
            odcMediaVideoSourceConfigurations.Dock = DockStyle.Fill;
            odcMediaVideoSourceConfigurations.FirstValueAsyncFunc = null;
            odcMediaVideoSourceConfigurations.Location = new Point(3, 3);
            odcMediaVideoSourceConfigurations.Margin = new Padding(5);
            odcMediaVideoSourceConfigurations.Name = "odcMediaVideoSourceConfigurations";
            odcMediaVideoSourceConfigurations.RefreshAsyncFunc = null;
            odcMediaVideoSourceConfigurations.Size = new Size(1430, 832);
            odcMediaVideoSourceConfigurations.TabIndex = 2;
            // 
            // tpMediaVideoSources
            // 
            tpMediaVideoSources.Controls.Add(odcMediaVideoSources);
            tpMediaVideoSources.Location = new Point(8, 45);
            tpMediaVideoSources.Name = "tpMediaVideoSources";
            tpMediaVideoSources.Padding = new Padding(3);
            tpMediaVideoSources.Size = new Size(1436, 838);
            tpMediaVideoSources.TabIndex = 1;
            tpMediaVideoSources.Text = "VideoSources";
            tpMediaVideoSources.UseVisualStyleBackColor = true;
            // 
            // odcMediaVideoSources
            // 
            odcMediaVideoSources.Dock = DockStyle.Fill;
            odcMediaVideoSources.FirstValueAsyncFunc = null;
            odcMediaVideoSources.Location = new Point(3, 3);
            odcMediaVideoSources.Margin = new Padding(5);
            odcMediaVideoSources.Name = "odcMediaVideoSources";
            odcMediaVideoSources.RefreshAsyncFunc = null;
            odcMediaVideoSources.Size = new Size(1430, 832);
            odcMediaVideoSources.TabIndex = 1;
            // 
            // tpMediaProfiles
            // 
            tpMediaProfiles.Controls.Add(odcMediaProfiles);
            tpMediaProfiles.Location = new Point(8, 45);
            tpMediaProfiles.Name = "tpMediaProfiles";
            tpMediaProfiles.Padding = new Padding(3);
            tpMediaProfiles.Size = new Size(1436, 838);
            tpMediaProfiles.TabIndex = 0;
            tpMediaProfiles.Text = "Profiles";
            tpMediaProfiles.UseVisualStyleBackColor = true;
            // 
            // odcMediaProfiles
            // 
            odcMediaProfiles.Dock = DockStyle.Fill;
            odcMediaProfiles.FirstValueAsyncFunc = null;
            odcMediaProfiles.Location = new Point(3, 3);
            odcMediaProfiles.Margin = new Padding(5);
            odcMediaProfiles.Name = "odcMediaProfiles";
            odcMediaProfiles.RefreshAsyncFunc = null;
            odcMediaProfiles.Size = new Size(1430, 832);
            odcMediaProfiles.TabIndex = 0;
            // 
            // tpPreview
            // 
            tpPreview.Controls.Add(scPreview);
            tpPreview.Location = new Point(8, 45);
            tpPreview.Name = "tpPreview";
            tpPreview.Padding = new Padding(3);
            tpPreview.Size = new Size(1452, 891);
            tpPreview.TabIndex = 3;
            tpPreview.Text = "Preview";
            tpPreview.UseVisualStyleBackColor = true;
            tpPreview.Enter += tpPreview_Enter;
            // 
            // scPreview
            // 
            scPreview.Dock = DockStyle.Fill;
            scPreview.Location = new Point(3, 3);
            scPreview.Name = "scPreview";
            // 
            // scPreview.Panel1
            // 
            scPreview.Panel1.Controls.Add(gbPreviewPTZ);
            scPreview.Panel1.Controls.Add(gbPreviewProfile);
            scPreview.Size = new Size(1446, 885);
            scPreview.SplitterDistance = 482;
            scPreview.TabIndex = 0;
            // 
            // gbPreviewPTZ
            // 
            gbPreviewPTZ.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbPreviewPTZ.Controls.Add(btnPtzFocusNear);
            gbPreviewPTZ.Controls.Add(btnPtzFocusFar);
            gbPreviewPTZ.Controls.Add(btnPtzZoomOut);
            gbPreviewPTZ.Controls.Add(btnPtzZoomIn);
            gbPreviewPTZ.Controls.Add(btnPtzRight);
            gbPreviewPTZ.Controls.Add(btnPtzLeft);
            gbPreviewPTZ.Controls.Add(btnPtzUp);
            gbPreviewPTZ.Controls.Add(btnPtzDown);
            gbPreviewPTZ.Location = new Point(0, 422);
            gbPreviewPTZ.Name = "gbPreviewPTZ";
            gbPreviewPTZ.Size = new Size(482, 460);
            gbPreviewPTZ.TabIndex = 1;
            gbPreviewPTZ.TabStop = false;
            gbPreviewPTZ.Text = "PTZ";
            // 
            // btnPtzFocusNear
            // 
            btnPtzFocusNear.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnPtzFocusNear.Location = new Point(6, 401);
            btnPtzFocusNear.Name = "btnPtzFocusNear";
            btnPtzFocusNear.Size = new Size(470, 46);
            btnPtzFocusNear.TabIndex = 9;
            btnPtzFocusNear.Text = "Focus Near";
            btnPtzFocusNear.UseVisualStyleBackColor = true;
            btnPtzFocusNear.MouseDown += btnPtzFocusNear_MouseDown;
            btnPtzFocusNear.MouseUp += btnPtzFocus_MouseUp;
            // 
            // btnPtzFocusFar
            // 
            btnPtzFocusFar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnPtzFocusFar.Location = new Point(6, 349);
            btnPtzFocusFar.Name = "btnPtzFocusFar";
            btnPtzFocusFar.Size = new Size(470, 46);
            btnPtzFocusFar.TabIndex = 8;
            btnPtzFocusFar.Text = "Focus Far";
            btnPtzFocusFar.UseVisualStyleBackColor = true;
            btnPtzFocusFar.MouseDown += btnPtzFocusFar_MouseDown;
            btnPtzFocusFar.MouseUp += btnPtzFocus_MouseUp;
            // 
            // btnPtzZoomOut
            // 
            btnPtzZoomOut.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnPtzZoomOut.Location = new Point(6, 297);
            btnPtzZoomOut.Name = "btnPtzZoomOut";
            btnPtzZoomOut.Size = new Size(470, 46);
            btnPtzZoomOut.TabIndex = 7;
            btnPtzZoomOut.Text = "Zoom Out";
            btnPtzZoomOut.UseVisualStyleBackColor = true;
            btnPtzZoomOut.MouseDown += btnPtzZoomOut_MouseDown;
            btnPtzZoomOut.MouseUp += btnPtzAny_MouseUp;
            // 
            // btnPtzZoomIn
            // 
            btnPtzZoomIn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnPtzZoomIn.Location = new Point(6, 245);
            btnPtzZoomIn.Name = "btnPtzZoomIn";
            btnPtzZoomIn.Size = new Size(470, 46);
            btnPtzZoomIn.TabIndex = 6;
            btnPtzZoomIn.Text = "Zoom In";
            btnPtzZoomIn.UseVisualStyleBackColor = true;
            btnPtzZoomIn.MouseDown += btnPtzZoomIn_MouseDown;
            btnPtzZoomIn.MouseUp += btnPtzAny_MouseUp;
            // 
            // btnPtzRight
            // 
            btnPtzRight.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnPtzRight.Location = new Point(6, 89);
            btnPtzRight.Name = "btnPtzRight";
            btnPtzRight.Size = new Size(470, 46);
            btnPtzRight.TabIndex = 5;
            btnPtzRight.Text = "Right";
            btnPtzRight.UseVisualStyleBackColor = true;
            btnPtzRight.MouseDown += btnPtzRight_MouseDown;
            btnPtzRight.MouseUp += btnPtzAny_MouseUp;
            // 
            // btnPtzLeft
            // 
            btnPtzLeft.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnPtzLeft.Location = new Point(6, 37);
            btnPtzLeft.Name = "btnPtzLeft";
            btnPtzLeft.Size = new Size(470, 46);
            btnPtzLeft.TabIndex = 5;
            btnPtzLeft.Text = "Left";
            btnPtzLeft.UseVisualStyleBackColor = true;
            btnPtzLeft.MouseDown += btnPtzLeft_MouseDown;
            btnPtzLeft.MouseUp += btnPtzAny_MouseUp;
            // 
            // btnPtzUp
            // 
            btnPtzUp.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnPtzUp.Location = new Point(6, 141);
            btnPtzUp.Name = "btnPtzUp";
            btnPtzUp.Size = new Size(470, 46);
            btnPtzUp.TabIndex = 5;
            btnPtzUp.Text = "Up";
            btnPtzUp.UseVisualStyleBackColor = true;
            btnPtzUp.MouseDown += btnPtzUp_MouseDown;
            btnPtzUp.MouseUp += btnPtzAny_MouseUp;
            // 
            // btnPtzDown
            // 
            btnPtzDown.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnPtzDown.Location = new Point(6, 193);
            btnPtzDown.Name = "btnPtzDown";
            btnPtzDown.Size = new Size(470, 46);
            btnPtzDown.TabIndex = 5;
            btnPtzDown.Text = "Down";
            btnPtzDown.UseVisualStyleBackColor = true;
            btnPtzDown.MouseDown += btnPtzDown_MouseDown;
            btnPtzDown.MouseUp += btnPtzAny_MouseUp;
            // 
            // gbPreviewProfile
            // 
            gbPreviewProfile.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbPreviewProfile.Controls.Add(btnPreviewLive);
            gbPreviewProfile.Controls.Add(cbProfiles);
            gbPreviewProfile.Controls.Add(btnPreviewSnapshot);
            gbPreviewProfile.Controls.Add(txtPreviewProfileInfo);
            gbPreviewProfile.Location = new Point(0, 0);
            gbPreviewProfile.Name = "gbPreviewProfile";
            gbPreviewProfile.Size = new Size(482, 416);
            gbPreviewProfile.TabIndex = 0;
            gbPreviewProfile.TabStop = false;
            gbPreviewProfile.Text = "Profile";
            // 
            // btnPreviewLive
            // 
            btnPreviewLive.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPreviewLive.Location = new Point(162, 364);
            btnPreviewLive.Name = "btnPreviewLive";
            btnPreviewLive.Size = new Size(150, 46);
            btnPreviewLive.TabIndex = 4;
            btnPreviewLive.Text = "Live";
            btnPreviewLive.UseVisualStyleBackColor = true;
            btnPreviewLive.Click += btnPreviewLive_Click;
            // 
            // cbProfiles
            // 
            cbProfiles.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbProfiles.DisplayMember = "Name";
            cbProfiles.DropDownStyle = ComboBoxStyle.DropDownList;
            cbProfiles.FormattingEnabled = true;
            cbProfiles.Location = new Point(6, 37);
            cbProfiles.Name = "cbProfiles";
            cbProfiles.Size = new Size(470, 39);
            cbProfiles.TabIndex = 1;
            cbProfiles.SelectedValueChanged += cbProfiles_SelectedValueChanged;
            // 
            // btnPreviewSnapshot
            // 
            btnPreviewSnapshot.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPreviewSnapshot.Location = new Point(6, 364);
            btnPreviewSnapshot.Name = "btnPreviewSnapshot";
            btnPreviewSnapshot.Size = new Size(150, 46);
            btnPreviewSnapshot.TabIndex = 3;
            btnPreviewSnapshot.Text = "Snapshot";
            btnPreviewSnapshot.UseVisualStyleBackColor = true;
            btnPreviewSnapshot.Click += btnPreviewSnapshot_Click;
            // 
            // txtPreviewProfileInfo
            // 
            txtPreviewProfileInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPreviewProfileInfo.Location = new Point(6, 82);
            txtPreviewProfileInfo.Multiline = true;
            txtPreviewProfileInfo.Name = "txtPreviewProfileInfo";
            txtPreviewProfileInfo.ReadOnly = true;
            txtPreviewProfileInfo.ScrollBars = ScrollBars.Vertical;
            txtPreviewProfileInfo.Size = new Size(467, 276);
            txtPreviewProfileInfo.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1468, 944);
            Controls.Add(tcMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
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
            tpMedia.ResumeLayout(false);
            tabControl3.ResumeLayout(false);
            tpMediaVideoSourceConfigurations.ResumeLayout(false);
            tpMediaVideoSources.ResumeLayout(false);
            tpMediaProfiles.ResumeLayout(false);
            tpPreview.ResumeLayout(false);
            scPreview.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scPreview).EndInit();
            scPreview.ResumeLayout(false);
            gbPreviewPTZ.ResumeLayout(false);
            gbPreviewProfile.ResumeLayout(false);
            gbPreviewProfile.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tcMain;
        private TabPage tpDevice;
        private TabPage tpNetwork;
        private Controls.ObjectDisplayControl odcDeviceInformation;
        private Controls.ObjectDisplayControl odcNetworkInterfaces;
        private TabControl tabControl1;
        private TabPage tpNetworkInterfaces;
        private TabPage tpNetworkProtocols;
        private TabPage tpNetworkDefaultGateway;
        private Controls.ObjectDisplayControl odcNetworkProtocols;
        private Controls.ObjectDisplayControl odcNetworkDefaultGateway;
        private TabPage tpNetworkDNS;
        private Controls.ObjectDisplayControl odcDNS;
        private TabControl tabControl2;
        private TabPage tpDeviceInformation;
        private TabPage tpDeviceCapabilities;
        private Controls.ObjectDisplayControl odcDeviceCapabilities;
        private TabPage tpMedia;
        private TabControl tabControl3;
        private TabPage tpMediaProfiles;
        private Controls.ObjectDisplayControl odcMediaProfiles;
        private TabPage tpMediaVideoSources;
        private Controls.ObjectDisplayControl odcMediaVideoSources;
        private TabPage tpMediaVideoSourceConfigurations;
        private Controls.ObjectDisplayControl odcMediaVideoSourceConfigurations;
        private TabPage tpPreview;
        private SplitContainer scPreview;
        private GroupBox gbPreviewProfile;
        private ComboBox cbProfiles;
        private TextBox txtPreviewProfileInfo;
        private Button btnPreviewLive;
        private Button btnPreviewSnapshot;
        private Button btnPtzRight;
        private Button btnPtzLeft;
        private Button btnPtzDown;
        private Button btnPtzUp;
        private GroupBox gbPreviewPTZ;
        private Button btnPtzZoomOut;
        private Button btnPtzZoomIn;
        private Button btnPtzFocusNear;
        private Button btnPtzFocusFar;
    }
}
using Microsoft.Win32;
using Quick.Onvif.Imaging;
using Quick.Onvif.TestUI.Utils;
using System.Diagnostics;
using System.Text;

namespace Quick.Onvif.TestUI
{
    public partial class MainForm : Form
    {
        private OnvifClient client;
        private Media.MediaClient mediaClient;
        private PTZ.PTZClient ptzClient;
        private Imaging.ImagingPortClient imagingPortClient;

        public MainForm(OnvifClient client)
        {
            this.client = client;
            mediaClient = new Media.MediaClient(client);
            imagingPortClient = new ImagingPortClient(client);
            if (client.Capabilities.PTZ != null)
                ptzClient = new PTZ.PTZClient(client);

            InitializeComponent();
            Text = $"{client.DeviceInformation.Manufacturer} - {client.DeviceInformation.Model} - {client.DeviceServiceAddressUri} v{Application.ProductVersion}";
            odcDeviceInformation.FirstValueAsyncFunc = () => Task.FromResult<object>(client.DeviceInformation);
            odcDeviceCapabilities.FirstValueAsyncFunc = () => Task.FromResult<object>(client.Capabilities);
            odcNetworkInterfaces.RefreshAsyncFunc = async () => await client.DeviceClient.GetNetworkInterfacesAsync();
            odcNetworkProtocols.RefreshAsyncFunc = async () => await client.DeviceClient.GetNetworkProtocolsAsync();
            odcNetworkDefaultGateway.RefreshAsyncFunc = async () => await client.DeviceClient.GetNetworkDefaultGatewayAsync();
            odcDNS.RefreshAsyncFunc = async () => await client.DeviceClient.GetDNSAsync();
            odcMediaVideoSourceConfigurations.RefreshAsyncFunc = async () => await mediaClient.GetVideoSourceConfigurationsAsync();
            odcMediaVideoSources.RefreshAsyncFunc = async () => await mediaClient.GetVideoSourcesAsync();
            odcMediaProfiles.RefreshAsyncFunc = async () => await mediaClient.GetProfilesAsync();
        }

        private async void tpPreview_Enter(object sender, EventArgs e)
        {
            if (cbProfiles.Items.Count == 0)
            {
                scPreview.Enabled = false;
                var rep = await mediaClient.GetProfilesAsync();
                var profiles = rep.Profiles;
                foreach (var profile in profiles)
                {
                    cbProfiles.Items.Add(profile);
                }
                cbProfiles.SelectedIndex = 0;
                scPreview.Enabled = true;
            }
        }
        private Media.Profile currentProfile;
        private void cbProfiles_SelectedValueChanged(object sender, EventArgs e)
        {
            currentProfile = (Media.Profile)cbProfiles.SelectedItem;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"token: {currentProfile.token}");
            sb.AppendLine($"Name: {currentProfile.Name}");
            sb.AppendLine($"VideoEncoderConfiguration:");
            sb.AppendLine($"    Name: {currentProfile.VideoEncoderConfiguration.Name}");
            sb.AppendLine($"    ViewMode: {currentProfile.VideoEncoderConfiguration.Encoding}");
            sb.AppendLine($"    Resolution: {currentProfile.VideoEncoderConfiguration.Resolution.Width} * {currentProfile.VideoEncoderConfiguration.Resolution.Height}");
            sb.AppendLine($"    Quality: {currentProfile.VideoEncoderConfiguration.Quality}");
            sb.AppendLine($"    RateControl:");
            sb.AppendLine($"        FrameRateLimit: {currentProfile.VideoEncoderConfiguration.RateControl.FrameRateLimit}");
            sb.AppendLine($"        EncodingInterval: {currentProfile.VideoEncoderConfiguration.RateControl.EncodingInterval}");
            sb.AppendLine($"        BitrateLimit: {currentProfile.VideoEncoderConfiguration.RateControl.BitrateLimit}");
            txtPreviewProfileInfo.Text = sb.ToString();
            gbPreviewPTZ.Visible = currentProfile.PTZConfiguration != null;
        }

        private async void btnPreviewSnapshot_Click(object sender, EventArgs e)
        {
            try
            {
                scPreview.Panel2.Controls.Clear();
                scPreview.Enabled = false;
                Image image = null;
                await mediaClient.QuickOnvif_SnapshotAsync(
                    currentProfile.token,
                    snapshotStream => image = Image.FromStream(snapshotStream)
                    );
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = image;
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                scPreview.Panel2.Controls.Add(pictureBox);
                pictureBox.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                scPreview.Panel2.Controls.Clear();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                scPreview.Enabled = true;
            }
        }

        private async void btnPreviewLive_Click(object sender, EventArgs e)
        {
            try
            {
                scPreview.Panel2.Controls.Clear();
                scPreview.Enabled = false;

                var streamUri = await mediaClient.QuickOnvif_GetStreamUriAsync(currentProfile.token, true);
                var panel = new FlowLayoutPanel();
                panel.Controls.Add(new Label()
                {
                    AutoSize = true,
                    Text = "Live Url:"
                });
                var textBox = new TextBox()
                {
                    Text = streamUri,
                    Multiline = true,
                    ScrollBars = ScrollBars.Vertical,
                    Height = 300,
                    ReadOnly = true
                };
                panel.Controls.Add(textBox);
                var button = new Button()
                {
                    AutoSize = true,
                    Text = "Open in VLC media player"
                };
                button.Click += (sender, e) =>
                {
                    try
                    {
                        //计算机\HKEY_LOCAL_MACHINE\SOFTWARE\VideoLAN\VLC
                        using (var softwareRK = Registry.LocalMachine.OpenSubKey("SOFTWARE"))
                        using (var videoLANRK = softwareRK.OpenSubKey("VideoLAN"))
                        {
                            if (videoLANRK == null)
                                throw new ArgumentNullException();
                            using (var vlcRK = videoLANRK.OpenSubKey("VLC"))
                            {
                                if (vlcRK == null)
                                    throw new ArgumentNullException();
                                var appPath = vlcRK.GetValue(null).ToString();
                                Process.Start(appPath, streamUri);
                            }
                        }
                    }
                    catch (ArgumentNullException)
                    {
                        MessageBox.Show("Please install VLC media player first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ExceptionUtils.GetExceptionMessage(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
                panel.Controls.Add(button);
                panel.Dock = DockStyle.Fill;
                panel.SizeChanged += (sender, e) =>
                {
                    textBox.Width = panel.ClientSize.Width;
                };
                scPreview.Panel2.Controls.Add(panel);
            }
            catch (Exception ex)
            {
                scPreview.Panel2.Controls.Clear();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                scPreview.Enabled = true;
            }
        }

        private const float PTZ_MOVE_SPEED = 0.2f;
        private async Task ptzContinuousMove(float xSpeed, float ySpeed, float zoomSpeed)
        {
            try
            {
                if (ptzClient == null)
                    throw new ApplicationException("Device not support PTZ");
                await ptzClient.ContinuousMoveAsync(currentProfile.token, new PTZ.PTZSpeed()
                {
                    PanTilt = new PTZ.Vector2D()
                    {
                        x = xSpeed,
                        y = ySpeed
                    },
                    Zoom = new PTZ.Vector1D()
                    {
                        x = zoomSpeed
                    }
                }, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async Task ptzFocusMove(float focusSpeed)
        {
            try
            {
                await imagingPortClient.MoveAsync(currentProfile.VideoSourceConfiguration.SourceToken, new FocusMove()
                {
                    Continuous = new ContinuousFocus()
                    {
                        Speed = focusSpeed
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnPtzAny_MouseUp(object sender, MouseEventArgs e)
        {
            await ptzContinuousMove(0, 0, 0);
        }

        private async void btnPtzFocus_MouseUp(object sender, MouseEventArgs e)
        {
            await ptzFocusMove(0);
        }

        private async void btnPtzUp_MouseDown(object sender, MouseEventArgs e)
        {
            await ptzContinuousMove(0, PTZ_MOVE_SPEED, 0);
        }


        private async void btnPtzDown_MouseDown(object sender, MouseEventArgs e)
        {
            await ptzContinuousMove(0, 0 - PTZ_MOVE_SPEED, 0);
        }

        private async void btnPtzLeft_MouseDown(object sender, MouseEventArgs e)
        {
            await ptzContinuousMove(0 - PTZ_MOVE_SPEED, 0, 0);
        }

        private async void btnPtzRight_MouseDown(object sender, MouseEventArgs e)
        {
            await ptzContinuousMove(PTZ_MOVE_SPEED, 0, 0);
        }

        private async void btnPtzZoomIn_MouseDown(object sender, MouseEventArgs e)
        {
            await ptzContinuousMove(0, 0, PTZ_MOVE_SPEED);
        }

        private async void btnPtzZoomOut_MouseDown(object sender, MouseEventArgs e)
        {
            await ptzContinuousMove(0, 0, 0 - PTZ_MOVE_SPEED);
        }

        private async void btnPtzFocusFar_MouseDown(object sender, MouseEventArgs e)
        {
            await ptzFocusMove(PTZ_MOVE_SPEED);
        }

        private async void btnPtzFocusNear_MouseDown(object sender, MouseEventArgs e)
        {
            await ptzFocusMove(0 - PTZ_MOVE_SPEED);
        }
    }
}

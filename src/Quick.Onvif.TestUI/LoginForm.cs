namespace Quick.Onvif.TestUI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
#if DEBUG
            txtDeviceServiceAddress.Text = "http://127.0.0.1/onvif/device_service";
            txtUserName.Text = "admin";
            txtPassword.Text = "Bs123456";
#endif
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                tcConnectInfo.Enabled = false;
                btnLogin.Enabled = false;
                var client = new OnvifClient(new OnvifClientOptions()
                {
                    DeviceServiceAddress = txtDeviceServiceAddress.Text,
                    UserName = txtUserName.Text,
                    Password = txtPassword.Text,
                    RtspPort = Convert.ToInt32(nudRtspPort.Value)
                });
                await client.ConnectAsync();
                this.Hide();
                new MainForm(client).ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                tcConnectInfo.Enabled = true;
                btnLogin.Enabled = true;
            }
        }
    }
}
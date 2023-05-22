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
            cbScheme.SelectedIndex = 0;
#if DEBUG
            nudPort.Value = 80;
            txtHost.Text = "127.0.0.1";
            txtUserName.Text = "admin";
            txtPassword.Text = "Bs123456";
#endif
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;
                var client = new OnvifClient(new OnvifClientOptions()
                {
                    Scheme = cbScheme.SelectedItem.ToString(),
                    Host = txtHost.Text,
                    Port = Convert.ToInt32(nudPort.Value),
                    UserName = txtUserName.Text,
                    Password = txtPassword.Text,
                    RtspPort = Convert.ToInt32(nudRtspPort.Value)
                });
                await client.ConnectAsync();
                this.Hide();
                new MainForm(client).ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                this.Enabled = true;
            }
        }
    }
}
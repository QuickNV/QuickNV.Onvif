using Quick.Onvif.TestUI.Utils;
using System.ServiceModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Quick.Onvif.TestUI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            Text = $"{Text} v{Application.ProductVersion}";
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
#if DEBUG
            nudPort.Value = 80;
            txtHost.Text = "127.0.0.1";
            txtUserName.Text = "admin";
            txtPassword.Text = "Bs123456";
#endif
            cbCredentialType.SelectedIndex = 1;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var scheme = cbHttps.Checked ? "https" : "http";
            try
            {
                this.Enabled = false;
                var clientOptions = new OnvifClientOptions()
                {
                    Scheme = scheme,
                    Host = txtHost.Text,
                    Port = Convert.ToInt32(nudPort.Value),
                    ClientCredentialType = Enum.Parse<HttpClientCredentialType>(cbCredentialType.SelectedItem.ToString()),
                    RtspPort = Convert.ToInt32(nudRtspPort.Value),
                    SnapshotPort = Convert.ToInt32(nudSnapshotPort.Value)
                };
                if (clientOptions.ClientCredentialType != HttpClientCredentialType.None)
                {
                    clientOptions.UserName = txtUserName.Text;
                    clientOptions.Password = txtPassword.Text;
                }
                var client = new OnvifClient(clientOptions);
                await client.ConnectAsync();
                this.Hide();
                new MainForm(client).ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ExceptionUtils.GetExceptionString(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                this.Enabled = true;
            }
        }

        private void cbOverrideRtspPort_CheckedChanged(object sender, EventArgs e)
        {
            nudRtspPort.Visible = cbOverrideRtspPort.Checked;
            if (!cbOverrideRtspPort.Checked)
                nudRtspPort.Value = -1;
        }

        private void cbOverrideSnapshotPort_CheckedChanged(object sender, EventArgs e)
        {
            nudSnapshotPort.Visible = cbOverrideSnapshotPort.Checked;
            if (!cbOverrideSnapshotPort.Checked)
                nudSnapshotPort.Value = -1;
        }

        private void cbCredentialType_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlCredentialType.Visible = cbCredentialType.SelectedIndex > 0;
        }
    }
}
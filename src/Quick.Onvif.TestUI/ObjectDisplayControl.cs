using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quick.Onvif.TestUI
{
    public partial class ObjectDisplayControl : UserControl
    {
        public Func<Task<object>> RefreshAsyncFunc { get; set; }

        public ObjectDisplayControl()
        {
            InitializeComponent();
        }

        private async Task refreshAsync()
        {
            if (RefreshAsyncFunc == null)
            {
                txtContent.Text = "'RefreshAsyncFunc' is null.";
            }
            else
            {
                btnRefresh.Enabled = false;
                txtContent.Text = "Refreshing...";
                try
                {
                    var obj = await RefreshAsyncFunc.Invoke();
                    txtContent.Text = JsonConvert.SerializeObject(obj, Formatting.Indented);
                }
                catch (Exception ex)
                {
                    txtContent.Text = ex.ToString();
                }
                btnRefresh.Enabled = true;
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await refreshAsync();
        }

        private async void ObjectDisplayControl_Load(object sender, EventArgs e)
        {
            await refreshAsync();
        }
    }
}

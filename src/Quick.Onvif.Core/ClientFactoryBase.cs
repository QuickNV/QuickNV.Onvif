using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Quick.Onvif.Core
{
    public abstract class ClientFactoryBase
    {
        public Binding Binding { get; private set; }

        protected void InitConfig(Binding binding)
        {
            this.Binding = binding;
        }

        public abstract void InitClient<TChannel>(ClientBase<TChannel> client, string username, string password)
            where TChannel : class;
    }
}

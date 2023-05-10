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
        public EndpointAddress RemoteAddress { get; private set; }

        protected void InitConfig(Binding binding, EndpointAddress remoteAddress)
        {
            this.Binding = binding;
            this.RemoteAddress = remoteAddress;
        }

        public abstract void InitClient<TChannel>(ClientBase<TChannel> client)
            where TChannel : class;
    }
}

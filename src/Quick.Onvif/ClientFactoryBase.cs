using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Quick.Onvif
{
    public abstract class ClientFactoryBase
    {
        private Binding binding;
        private EndpointAddress endpoint;

        protected void Init(Binding binding, EndpointAddress endpoint)
        {
            this.binding = binding;
            this.endpoint = endpoint;
        }

        public virtual TClient Create<TChannel, TClient>()
            where TChannel : class
            where TClient : ClientBase<TChannel>
        {
            var client = (TClient)Activator.CreateInstance(typeof(TClient), new object[] { binding, endpoint });
            return client;
        }
    }
}

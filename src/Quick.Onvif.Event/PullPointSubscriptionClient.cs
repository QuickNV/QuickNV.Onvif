﻿using Quick.Onvif.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Quick.Onvif.Event
{
    public partial class PullPointSubscriptionClient
    {
        public PullPointSubscriptionClient(string url, string username, string password, HttpClientCredentialType clientCredentialType = HttpClientCredentialType.Digest)
                    : base(
                          ClientFactoryBase.GetClientFactory(url, clientCredentialType).Binding,
                          new EndpointAddress(url))
        {
            ClientFactoryBase.GetClientFactory(url, clientCredentialType).InitClient(this, username, password);
        }
    }
}
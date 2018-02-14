using RemitaIntegrate.NET.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemitaIntegrate.NET.Abstractions
{
    public abstract class IntegrateConfig
    {

        public string MerchantId { get; protected set; }

        public string ServiceTypeId { get; protected set; }

        /// <summary>
        /// Translates to service type number given to a client
        /// by remita
        /// </summary>
        public List<ServiceType> ServiceTypes { get; set; }
        
        public string ApiKey { get; protected set; }

        public string GateWayUrl { get; protected set; } = "https://login.remita.net/remita/ecomm/init.reg";

        public string BaseUrl { get; protected set; } = "https://login.remita.net/remita/ecomm";

        public string DemoGateWayUrl { get; protected set; } = "https://login.remitademo.net/remita/ecomm/init.reg";

        public string DemoBaseUrl { get; protected set; } = "https://login.remitademo.net/remita/ecomm";
    }
}

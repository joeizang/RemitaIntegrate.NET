using System;
using System.Collections.Generic;
using System.Text;

namespace RemitaIntegrate.NET.Abstractions
{
    public abstract class IntegrateConfig
    {
        

        //public const string MERCHANTID = "2587711795";
        //public const string CHECKSTATUSURL = "https://login.remita.net/remita/ecomm";
        //public const string GATEWAYURL = "https://login.remita.net/remita/ecomm/init.reg";
        //public const string CHECKSTATUSURL = "https://login.remita.net/remita/ecomm";
        //public const string SERVICETYPEID = "2587615591";
        //public const string APIKEY = "245183";

        public string MerchantId { get; protected set; }

        public string ServiceTypeId { get; protected set; }

        public Dictionary<string,string> ServiceTypes { get; set; }
        
        public string ApiKey { get; protected set; }

        public string GateWayUrl { get; protected set; } = "https://login.remita.net/remita/ecomm/init.reg";

        public string CheckStatusUrl { get; protected set; } = "https://login.remita.net/remita/ecomm";

        public string DemoGateWayUrl { get; protected set; } = "https://login.remitademo.net/remita/ecomm/init.reg";

        public string DemoCheckStatusUrl { get; protected set; } = "https://login.remitademo.net/remita/ecomm";
    }
}

using RemitaIntegrate.NET.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemitaIntegrate.NET
{
    public class RemitaConfig
    {

        public RemitaConfig(string merchantId, string serviceTypeId,  string apiKey )
        {
            if(string.IsNullOrWhiteSpace(merchantId) && string.IsNullOrWhiteSpace(serviceTypeId) && 
                string.IsNullOrWhiteSpace(apiKey))
            {
                throw new RemitaConfigException("You did not supply either the merchant Id, service type Id or the api key supplied you from Remita");
            }

            MerchantId = merchantId;
            ServiceTypeId = serviceTypeId;
            ApiKey = apiKey;
        }
        //public const string MERCHANTID = "2587711795";
        //public const string CHECKSTATUSURL = "https://login.remita.net/remita/ecomm";
        //public const string GATEWAYURL = "https://login.remita.net/remita/ecomm/init.reg";
        //public const string CHECKSTATUSURL = "https://login.remita.net/remita/ecomm";
        //public const string SERVICETYPEID = "2587615591";
        //public const string APIKEY = "245183";

        public string MerchantId { get; private set; }

        public string ServiceTypeId { get; private set; }

        public string ApiKey { get; private set; }        

        public string GateWayUrl { get; private set; } = "https://login.remita.net/remita/ecomm/init.reg";

        public string CheckStatusUrl { get; private set; }

    }
}

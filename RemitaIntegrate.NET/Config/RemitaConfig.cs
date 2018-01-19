using RemitaIntegrate.NET.Exceptions;
using RemitaIntegrate.NET.Abstractions;

namespace RemitaIntegrate.NET.Config
{
    public class RemitaConfig : IntegrateConfig
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
            GateWayUrl = "https://login.remita.net/remita/ecomm/init.reg";
            CheckStatusUrl = "https://login.remita.net/remita/ecomm";
        }

        //public const string MERCHANTID = "2587711795";
        //public const string CHECKSTATUSURL = "https://login.remita.net/remita/ecomm";
        //public const string GATEWAYURL = "https://login.remita.net/remita/ecomm/init.reg";
        //public const string CHECKSTATUSURL = "https://login.remita.net/remita/ecomm";
        //public const string SERVICETYPEID = "2587615591";
        //public const string APIKEY = "245183";

        
    }
}

using System.Collections;
using RemitaIntegrate.NET.Exceptions;
using RemitaIntegrate.NET.Abstractions;
using System.Collections.Generic;

namespace RemitaIntegrate.NET.Config
{
    public class RemitaConfig : IntegrateConfig
    {
        /// <summary>
        /// Overload to handle when a merchant has only one servicetype handled by Remita.
        /// </summary>
        /// <param name="merchantId"></param>
        /// <param name="serviceTypeId"></param>
        /// <param name="apiKey"></param>
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
            BaseUrl = "https://login.remita.net/remita/ecomm";
        }

        public RemitaConfig()
        {
            
        }

        /// <summary>
        /// Constructor overload to handle scenario where merchant has more than one service type.
        /// </summary>
        /// <param name="merchantId">ID of merchant from Remita</param>
        /// <param name="serviceType">Reference type that holds ICollection of service types</param>
        /// <param name="apiKey">ApiKey given by Remita</param>
        public RemitaConfig(string merchantId, List<ServiceType> serviceTypes, string apiKey)
        {
            if (string.IsNullOrWhiteSpace(merchantId) && string.IsNullOrWhiteSpace(apiKey) 
                                                      && serviceTypes == null || serviceTypes.Count < 1)
                throw new RemitaConfigException("You are missing either merchant id, api key or your service types.");
            MerchantId = merchantId;
            ApiKey = apiKey;
            ServiceTypes = serviceTypes;
        }

        
    }
}

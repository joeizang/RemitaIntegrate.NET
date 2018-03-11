using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RemitaIntegrate.NET.Abstractions;

namespace SampleMVCApp.Infrastructure
{
    public class SampleConfig : IntegrateConfig
    {
        public SampleConfig(string merchantId, string serviceTypeId, string apiKey)
        {
            MerchantId = merchantId;
            ServiceTypeId = serviceTypeId;
            ApiKey = apiKey;
        }
    }
}
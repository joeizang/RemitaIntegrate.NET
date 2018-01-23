using Newtonsoft.Json;
using RemitaIntegrate.NET.Abstractions;
using RemitaIntegrate.NET.Config;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace RemitaIntegrate.NET
{
    public class RemitaGateWayIntegrator : IGatewayIntegrator
    {
        private readonly RemitaHashGenerator _hasher;

        public IntegrateConfig Config { get; set; }

        public RemitaGateWayIntegrator(RemitaHashGenerator hasher)
        {
            _hasher = hasher;
        }
        public RemitaResponse PerformPaymentStatusCheck(string orderId, string url = null)
        {
            var hashed = _hasher.HashRemitedValidate(orderId);
            var checkurl = url;

            var rgxUrl = new 
         Regex("^(ht|f)tp(s?)\\:\\/\\/[0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*(:(0-9)*)*(\\/?)([a-zA-Z0-9\\-\\.\\?\\,\\\'\\/\\\\\\+&%\\$#_]*)?$");

            if (string.IsNullOrWhiteSpace(checkurl) && !rgxUrl.IsMatch(checkurl))
                checkurl = $"{Config.CheckStatusUrl}/{Config.MerchantId}/{orderId}/{hashed}/orderstatus.reg";
            
            return JsonDeserialize(checkurl);
        }

        public RemitaResponse CheckRrrStatus(string rrr)
        {
            var hashed = _hasher.HashRrrQuery(rrr);
            var url = $"{Config.CheckStatusUrl}/{Config.MerchantId}/{rrr}/{hashed}/status.reg";
            return JsonDeserialize(url);
        }

        private static RemitaResponse JsonDeserialize(string checkurl)
        {
            var jsondata = new WebClient().DownloadString(checkurl);
            return JsonConvert.DeserializeObject<RemitaResponse>(jsondata);
        }
    }
}

using Newtonsoft.Json;
using RemitaIntegrate.NET.Abstractions;
using RemitaIntegrate.NET.Config;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

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
        public RemitaResponse PerformPaymentStatusCheck(string OrderId)
        {
            var hashed = _hasher.HashRemitedValidate(OrderId);
            string checkurl = $"{Config.CheckStatusUrl}/{Config.MerchantId}/{OrderId}/{hashed}/orderstatus.reg";
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
            string jsondata = new WebClient().DownloadString(checkurl);
            return JsonConvert.DeserializeObject<RemitaResponse>(jsondata);
        }
    }
}

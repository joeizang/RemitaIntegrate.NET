using Newtonsoft.Json;
using RemitaIntegrate.NET.Abstractions;
using System.Net;
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


        public virtual string PerformNewPaymentHashing(RemitaPost post)
        {
            return _hasher.HashRemitaRequest(post);
        }




        public virtual RemitaResponse PerformPaymentStatusCheck(string orderId, string url = null)
        {
            var hashed = _hasher.HashRemitedValidate(orderId);
            var checkurl = url;

            var rgxUrl = new 
         Regex("^(ht|f)tp(s?)\\:\\/\\/[0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*(:(0-9)*)*(\\/?)([a-zA-Z0-9\\-\\.\\?\\,\\\'\\/\\\\\\+&%\\$#_]*)?$");

            if (string.IsNullOrWhiteSpace(checkurl))
                checkurl = $"{Config.CheckStatusUrl}/{Config.MerchantId}/{orderId}/{hashed}/orderstatus.reg";
            rgxUrl.IsMatch(checkurl);
            return JsonDeserialize(checkurl);
        }

        public virtual RemitaResponse PerformPaymentStatusCheck(string orderId)
        {
            var hashed = _hasher.HashRemitedValidate(orderId);
            var checkurl = Config.CheckStatusUrl+"/"+Config.MerchantId+"/"+orderId+"/"+hashed+"/orderstatus.reg";
            return JsonDeserialize(checkurl);
        }

        public virtual RemitaResponse CheckRrrStatus(string rrr)
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

using RemitaIntegrate.NET.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemitaIntegrate.NET
{
    public class RemitaGateWayIntegrator : IGatewayIntegrator
    {
        private readonly RemitaHashGenerator _hasher;

        public RemitaGateWayIntegrator(RemitaHashGenerator hasher)
        {
            _hasher = hasher;
        }
        public void PrepareParameters()
        {
            var hashed = _hasher.HashRemitedValidate(hasPayed.OrderId, RemitaConfigParams.APIKEY, RemitaConfigParams.MERCHANTID);
            string checkurl = RemitaConfig.CHECKSTATUSURL + "/" + RemitaConfig.MERCHANTID + "/" + hasPayed.OrderId
                + "/" + hashed + "/" + "orderstatus.reg";
            string jsondata = new WebClient().DownloadString(checkurl);
            var result = JsonConvert.DeserializeObject<RemitaResponse>(jsondata);
        }
    }
}

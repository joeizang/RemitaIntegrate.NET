using System;
using System.Collections.Generic;
using System.Text;

namespace RemitaIntegrate.NET.Abstractions
{
    public interface IGatewayIntegrator
    {
        RemitaResponse PerformPaymentStatusCheck(string orderid, string url = null);

        RemitaResponse CheckRrrStatus(string rrr);
    }
}

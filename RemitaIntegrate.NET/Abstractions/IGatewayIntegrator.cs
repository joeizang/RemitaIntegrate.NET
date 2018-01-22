﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RemitaIntegrate.NET.Abstractions
{
    public interface IGatewayIntegrator
    {
        RemitaResponse PrepareParametersForPaymentStatusCheck(string orderid);
    }
}

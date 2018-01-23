using NUnit.Framework;
using RemitaIntegrate.NET;
using RemitaIntegrate.NET.Abstractions;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using RemitaIntegrate.NET.Config;

namespace RemitaIntegrate.NETTests
{
    [TestFixture]
    public class IntegratorTest
    {

        [Test]
        public void TestPerformPaymentStatusCheck()
        {
            //Arrange
            var config = new RemitaIntegrateConfig("6789ab", "12345", "123456789");

            var hasher = new RemitaHashGenerator(config, new SHA512Managed());

            var rintegrator = new RemitaGateWayIntegrator(hasher);



        }
    }

    public class RemitaIntegrateConfig : RemitaConfig
    {

        public RemitaIntegrateConfig(string merchantId, string serviceTypeId, string apiKey) 
            : base(merchantId, serviceTypeId, apiKey)
        {
        }
    }
}

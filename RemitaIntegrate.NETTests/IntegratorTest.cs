using NUnit.Framework;
using RemitaIntegrate.NET;
using RemitaIntegrate.NET.Abstractions;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using NSubstitute;
using NSubstitute.Extensions;
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

            var rintegrator = Substitute.For<IGatewayIntegrator>();

            var jsonThing = new JsonThing
            {
                OrderId = "3437534",
                Rrr = "3445-bbfc-434fed",
                Status = "Approved",
                Message = "Transaction Successful"
            };

            var json = JsonConvert.SerializeObject(jsonThing);
            rintegrator.PerformPaymentStatusCheck("33344556677","https://127.0.0.1/nowhere/nowhere.reg")
                                    .Returns(JsonConvert.DeserializeObject(json, typeof(RemitaResponse)));

            //Act
            var result = rintegrator.PerformPaymentStatusCheck("33344556677", "https://127.0.0.1/nowhere/nowhere.reg");

            //Assert
            Assert.IsInstanceOf(typeof(RemitaResponse), result);
        }
    }

    public class JsonThing
    {
        public string OrderId { get; set; }

        public string Rrr { get; set; }

        public string Status { get; set; }

        public string Message { get; set; }
    }

    public class RemitaIntegrateConfig : RemitaConfig
    {

        public RemitaIntegrateConfig(string merchantId, string serviceTypeId, string apiKey) 
            : base(merchantId, serviceTypeId, apiKey)
        {
        }
    }
}

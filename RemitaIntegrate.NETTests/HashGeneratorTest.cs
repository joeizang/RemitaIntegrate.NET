using NUnit.Framework;
using RemitaIntegrate.NET;
using RemitaIntegrate.NET.Abstractions;
using RemitaIntegrate.NET.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RemitaIntegrate.NETTests
{
    [TestFixture]
    public class HashGeneratorTest
    {
        [Test]
        public void TestThatHasherReturnsProperHash()
        {
            //Arrange
            var remitapost = new TestRemitaPost
            {
                Amount = "500",
                ResponseUrl = "http://testdomain.local/returnurl",
                RemitaPaymentType = PaymentType.MASTERCARD.ToString(),
                OrderId = DateTimeOffset.UtcNow.Ticks.ToString(),
                PayerEmail = "someemail@testdomain.local",
                PayerName = "Tester Domain",
                PayerPhone = "08032491753"
            };

            var config = new TestRemitaConfig("2547916", "77783221234", "2345");
            var hasher = new RemitaHashGenerator(config);
            remitapost.MerchantId = config.MerchantId;
            remitapost.ServiceTypeId = config.ServiceTypeId;
            //Act
            var result = hasher.HashRemitaRequest(remitapost);

            //Assert
            Assert.IsInstanceOf(typeof(string),result);
            //usually SHA512Managed hashes are 128 characters long if you remove the dashes.
            Assert.AreEqual(result.Count(), 128);

        }

        //public void TestThat
    }

    public class TestRemitaPost : RemitaPost
    {

    }

    public class TestRemitaConfig : RemitaConfig
    {
        public TestRemitaConfig(string merchantid, string servicetypeid, string apikey):
            base(merchantid, servicetypeid,apikey)
        {

        }
    }
}

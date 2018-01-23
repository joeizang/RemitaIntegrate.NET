﻿using NUnit.Framework;
using RemitaIntegrate.NET;
using RemitaIntegrate.NET.Abstractions;
using RemitaIntegrate.NET.Config;
using System;
using System.Collections.Generic;
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
                RemitaPaymentType = PaymentType.MASTERCARD,
                OrderId = DateTime.UtcNow.Ticks.ToString(),
                PayerEmail = "someemail@testdomain.local",
                PayerName = "Tester Domain",
                PayerPhone = "08032491753"
            };

            var config = new TestRemitaConfig("33411123", "77783221234", "2345");
            var hasher = new RemitaHashGenerator(config, new SHA512Managed());
            remitapost.MerchantId = config.MerchantId;
            remitapost.ServiceTypeId = config.ServiceTypeId;


            //Act
            var result = hasher.HashRemitaRequest(remitapost);

            //Assert

            Assert.IsInstanceOf(typeof(string),result);

        }
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

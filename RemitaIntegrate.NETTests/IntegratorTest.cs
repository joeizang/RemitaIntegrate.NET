using NSubstitute;
using NUnit.Framework;
using RemitaIntegrate.NET;
using RemitaIntegrate.NET.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemitaIntegrate.NETTests
{
    [TestFixture]
    public class IntegratorTest
    {

        [Test]
        public void TestParameterPreparation()
        {
            var rintegrator = Substitute.For<RemitaGateWayIntegrator>();

            rintegrator.Config = Substitute.For<IntegrateConfig>();
            rintegrator.Config.ApiKey.Returns("abc123");
            rintegrator.Config.ServiceTypeId.Returns("12345");
            rintegrator.Config.MerchantId.Returns("6789ab");
            rintegrator.Config.GateWayUrl.Returns("https://testdomain.local/status");

        }
    }
}

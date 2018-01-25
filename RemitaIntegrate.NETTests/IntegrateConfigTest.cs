using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Linq;
using RemitaIntegrate.NET.Abstractions;
using RemitaIntegrate.NET.Config;

namespace RemitaIntegrate.NETTests
{
    [TestFixture]
    public class IntegrateConfigTest
    {

        [Test]
        public void TestThatBootstrappingConfigSetsDictionaryProperly()
        {
            //Arrange
            //var servicet = new ServiceType("schoolfees", "89878768");
            var servicet = new ServiceType
            {
                ServiceTypes = new Dictionary<string, string>()
            };
            servicet.ServiceTypes.Add("hostelfees","23089983");
            servicet.ServiceTypes.Add("courseregistration","23726349");
            var sample = new RemitaConfig
            {
                ServiceTypes = new Dictionary<string, string>()
            };

            sample.ServiceTypes = servicet.ServiceTypes;
            
            //Act
            var result = sample.ServiceTypes.Count;

            //Assert
            //Assert.AreEqual(2,result);
            Assert.AreEqual(true,sample.ServiceTypes.ContainsKey("hostelfees"));

        }
    }

}

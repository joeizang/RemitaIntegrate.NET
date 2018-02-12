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

            var serviceTypes = new List<ServiceType>();
            serviceTypes.Add(new ServiceType
            { ServiceTypeId = 1, ServiceTypeName = "hostelfees", ServiceTypeNumber = "23089983" });
            serviceTypes.Add(new ServiceType
            { ServiceTypeId = 2, ServiceTypeName = "courseregistration", ServiceTypeNumber = "23726349" });
            var sample = new RemitaConfig
            {
                ServiceTypes = new List<ServiceType>()
            };

            sample.ServiceTypes = serviceTypes;
            
            //Act
            var result = sample.ServiceTypes.Count;

            //Assert
            //Assert.AreEqual(2,result);
            Assert.AreEqual(true,sample.ServiceTypes.Any(s => s.ServiceTypeName.Equals("hostelfees")));

        }
    }

    public class TestRemitaConfig1 : RemitaConfig
    {
        public TestRemitaConfig1():base()
        {
                
        }
    }

}

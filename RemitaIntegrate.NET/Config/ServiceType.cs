using System;
using System.Collections.Generic;
using System.Text;

namespace RemitaIntegrate.NET.Config
{
    /// <summary>
    /// Base type to hold all service types and their numbers.
    /// It can be extended by any properties in the inheriting type
    /// but should me made an entity.
    /// </summary>
    public class ServiceType
    {
        public int Id { get; set; }

        public string ServiceTypeName { get; set; }

        public string ServiceTypeNumber { get; set; }

    }
}

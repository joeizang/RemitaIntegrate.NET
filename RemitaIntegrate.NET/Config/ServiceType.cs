using System;
using System.Collections.Generic;
using System.Text;

namespace RemitaIntegrate.NET.Config
{
    public class ServiceType
    {
        public Dictionary<string,string> ServiceTypes { get; set; }

        public ServiceType()
        {

        }
        //public ServiceType(string key, string value)
        //{
        //    if (string.IsNullOrWhiteSpace(key) && string.IsNullOrWhiteSpace(value))


        //    ServiceTypes = new Dictionary<string, string>();
        //    ServiceTypes.Add(key,value);
        //}



        //public static ServiceType NotFound()
        //{
        //    var st = new ServiceType(null, null);
        //    st.ServiceTypes.Add(null,null);
        //    return st;
        //}
    }
}

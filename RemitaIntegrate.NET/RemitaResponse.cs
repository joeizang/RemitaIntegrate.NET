using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace RemitaIntegrate.NET
{
    public class RemitaResponse
    {
        [DataMember(Name = "orderId")]
        public string OrderId { get; set; }

        [DataMember(Name = "RRR")]
        public string Rrr { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}

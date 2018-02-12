using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace RemitaIntegrate.NET
{ }
    /// <summary>
    /// Represents reply gotten from remita for every transaction
    /// </summary>
    public class RemitaResponse
    {
        /// <summary>
        /// Unique string that uniquely identities a transaction with remita
        /// </summary>
        [DataMember(Name = "orderId")]
        public string OrderId { get; set; }

        /// <summary>
        /// Remita Reference generated for every transaction
        /// </summary>
        [DataMember(Name = "RRR")]
        public string Rrr { get; set; }

        /// <summary>
        /// Status of every transaction indicating if the transaction was a success or failure
        /// </summary>
        [DataMember(Name = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Message payload obtained from remita which usually accompanies a transaction.
        /// </summary>
        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}

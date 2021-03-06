﻿using RemitaIntegrate.NET.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RemitaIntegrate.NET
{
    /// <summary>
    /// Represents the fields that get sent to Remita's REST endpoint
    /// This is a base class that should be inherited by classes that 
    /// represent what gets sent to remita.
    /// </summary>
    public abstract class RemitaPost
    {
        /// <summary>
        /// Id that gets given to the client by Remita
        /// </summary>
        [Required(ErrorMessage ="You must provide the merchant Id along with any transaction.")]
        public string MerchantId { get; set; }

        /// <summary>
        /// This is a SHA512 hash of MerchantId+ServiceTypeId+OrderId+Amount+ResponseUrl+ApiKey
        /// </summary>
        [Required]
        public string Hash { get; set; }

        /// <summary>
        /// This is a Unique Identification number that gets issued by Remita for every transaction.
        /// </summary>
        [Required]
        public string Rrr { get; set; }

        /// <summary>
        /// The Url that Remita should expect to send a summary of a transaction.
        /// </summary>
        [DataType(DataType.Url, ErrorMessage ="You have to provide a valid Url relative to your domain.")]
        [Required]
        public string ResponseUrl { get; set; }

        /// <summary>
        /// Enum that contains the different payment types from Remita
        /// </summary>
        [Display(Name ="Remita Payment Type")]
        public string RemitaPaymentType { get; set; }

        /// <summary>
        /// Self Generated and must be sent with every transaction to Remita
        /// </summary>
        [Required]
        public string OrderId { get; set; }

        /// <summary>
        /// Unique Identifier that identifies the payer from Clientside.
        /// </summary>
        [Required]
        public string PayerId { get; set; }

        /// <summary>
        /// Email Address of the Payer
        /// </summary>
        [DataType(DataType.EmailAddress)]
        [Required]
        public string PayerEmail { get; set; }

        /// <summary>
        /// Name of the Payer
        /// </summary>
        [DataType(DataType.Text)]
        [Required]
        public string PayerName { get; set; }

        /// <summary>
        /// Value of the transaction
        /// </summary>
        [Required]
        public string Amount { get; set; }

        /// <summary>
        /// Payers phone number required for Transaction
        /// </summary>
        public string PayerPhone { get; set; }

        /// <summary>
        /// Unique Service Type Remita is recieving payment for
        /// </summary>
        [Required]
        public string ServiceTypeId { get; set; }
    }
}

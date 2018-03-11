using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RemitaIntegrate.NET.Config;

namespace SampleMVCApp.Models
{
    public class Payment
    {
        [Display(Name = "Payer Name")]
        public string PayerName { get; set; }

        [Display(Name = "Payer's Email Address")]
        public string PayerEmail { get; set; }

        [Display(Name = "Payer's Phone Number")]
        public string PayerPhoneNumber { get; set; }

        [Display(Name = "Payment Type")]
        public PaymentType PaymentType { get; set; }

        [Display(Name = "Amount Payable")]
        public decimal PaymentAmount { get; set; }


    }
}
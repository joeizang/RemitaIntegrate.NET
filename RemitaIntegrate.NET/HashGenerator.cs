using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace RemitaIntegrate.NET
{
    public class HashGenerator
    {
        public RemitaConfig Config { get; private set; }
        public HashGenerator(RemitaConfig config)
        {
            Config = config;
        }
            public string HashRemitaRequest(RemitaPost post)
            {
                string hash_string = post.MerchantId + post.ServiceTypeId + post.OrderId + post.Amount 
                + post.ResponseUrl + Config.ApiKey;
                var sha512 = new SHA512Managed();
                Byte[] EncryptedSHA512 = sha512.ComputeHash(Encoding.UTF8.GetBytes(hash_string));
                sha512.Clear();
                return BitConverter.ToString(EncryptedSHA512).Replace("-", "").ToLower();
            }

            public string HashRemitedValidate(string orderID, string apiKey, string merchantId)
            {
                string hash_string = orderID + apiKey + merchantId;
                var sha512 = new SHA512Managed();
                Byte[] EncryptedSHA512 = sha512.ComputeHash(Encoding.UTF8.GetBytes(hash_string));
                sha512.Clear();
                return BitConverter.ToString(EncryptedSHA512).Replace("-", "").ToLower();
            }

            public string HashRemitedRePost(string rrr)
            {
                string hash_string = Config.MerchantId + rrr + Config.ApiKey;
                var sha512 = new SHA512Managed();
                Byte[] EncryptedSHA512 = sha512.ComputeHash(Encoding.UTF8.GetBytes(hash_string));
                sha512.Clear();
                return BitConverter.ToString(EncryptedSHA512).Replace("-", "").ToLower();
            }

            public string HashRrrQuery(string rrr)/*, string apiKey, string merchantId)*/
            {
                string hash_string = rrr + Config.ApiKey + Config.MerchantId;
                var sha512 = new SHA512Managed();
                Byte[] EncryptedSHA512 = sha512.ComputeHash(Encoding.UTF8.GetBytes(hash_string));
                sha512.Clear();
                return BitConverter.ToString(EncryptedSHA512).Replace("-", "").ToLower();
            }
    }
}

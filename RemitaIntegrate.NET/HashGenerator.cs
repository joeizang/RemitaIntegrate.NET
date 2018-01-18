using System;
using System.Collections.Generic;
using System.Text;

namespace RemitaIntegrate.NET
{
    public class HashGenerator
    {
            public string HashRemitaRequest(string merchantId, string serviceTypeId, string orderId, 
                string amount, string responseUrl, string apiKey)
            {
                string hash_string = merchantId + serviceTypeId + orderId + amount + responseUrl + apiKey;
                var sha512 = new System.Security.Cryptography.SHA512Managed();
                Byte[] EncryptedSHA512 = sha512.ComputeHash(System.Text.Encoding.UTF8.GetBytes(hash_string));
                sha512.Clear();
                return BitConverter.ToString(EncryptedSHA512).Replace("-", "").ToLower();
            }

            public string HashRemitedValidate(string orderID, string apiKey, string merchantId)
            {
                string hash_string = orderID + apiKey + merchantId;
                var sha512 = new System.Security.Cryptography.SHA512Managed();
                Byte[] EncryptedSHA512 = sha512.ComputeHash(System.Text.Encoding.UTF8.GetBytes(hash_string));
                sha512.Clear();
                return BitConverter.ToString(EncryptedSHA512).Replace("-", "").ToLower();
            }

            public string HashRemitedRePost(string merchantId, string rrr, string apiKey)
            {
                string hash_string = merchantId + rrr + apiKey;
                var sha512 = new System.Security.Cryptography.SHA512Managed();
                Byte[] EncryptedSHA512 = sha512.ComputeHash(System.Text.Encoding.UTF8.GetBytes(hash_string));
                sha512.Clear();
                return BitConverter.ToString(EncryptedSHA512).Replace("-", "").ToLower();
            }

            public string HashRrrQuery(string rrr, string apiKey, string merchantId)
            {
                string hash_string = rrr + apiKey + merchantId;
                var sha512 = new System.Security.Cryptography.SHA512Managed();
                Byte[] EncryptedSHA512 = sha512.ComputeHash(System.Text.Encoding.UTF8.GetBytes(hash_string));
                sha512.Clear();
                return BitConverter.ToString(EncryptedSHA512).Replace("-", "").ToLower();
            }
    }
}

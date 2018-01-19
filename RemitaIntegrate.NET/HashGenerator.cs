using RemitaIntegrate.NET.Abstractions;
using RemitaIntegrate.NET.Config;
using System;
using System.Security.Cryptography;
using System.Text;

namespace RemitaIntegrate.NET
{
    public class RemitaHashGenerator
    {
        public IntegrateConfig Config { get; private set; }

        public SHA512 HasherBase { get; private set; }
        public RemitaHashGenerator(RemitaConfig config, SHA512 hasher)
        {
            Config = config;
            HasherBase = hasher;
        }
        public string HashRemitaRequest(RemitaPost post)
        {
            string hash_string = post.MerchantId + post.ServiceTypeId + post.OrderId + post.Amount 
            + post.ResponseUrl + Config.ApiKey;
            
            Byte[] EncryptedSHA512 = ComputeHash(hash_string);
            HasherBase.Clear();
            return BitConverter.ToString(EncryptedSHA512).Replace("-", "").ToLower();
        }

        public string HashRemitedValidate(string orderID)
        {
            string hash_string = orderID + Config.ApiKey + Config.MerchantId;
            
            Byte[] EncryptedSHA512 = ComputeHash(hash_string);
            HasherBase.Clear();
            return BitConverter.ToString(EncryptedSHA512).Replace("-", "").ToLower();
        }

        public string HashRemitedRePost(string rrr)
        {
            string hash_string = Config.MerchantId + rrr + Config.ApiKey;
            
            Byte[] EncryptedSHA512 = ComputeHash(hash_string);
            HasherBase.Clear();
            return BitConverter.ToString(EncryptedSHA512).Replace("-", "").ToLower();
        }

        public string HashRrrQuery(string rrr)/*, string apiKey, string merchantId)*/
        {
            string hash_string = rrr + Config.ApiKey + Config.MerchantId;

            byte[] EncryptedSHA512 = ComputeHash(hash_string);
            HasherBase.Clear();
            return BitConverter.ToString(EncryptedSHA512).Replace("-", "").ToLower();
        }

        private byte[] ComputeHash(string hashstring)
        {
            return HasherBase.ComputeHash(Encoding.UTF8.GetBytes(hashstring));
        }
    }
}

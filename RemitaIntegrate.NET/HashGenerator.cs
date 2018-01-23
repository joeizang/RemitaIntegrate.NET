using RemitaIntegrate.NET.Abstractions;
using RemitaIntegrate.NET.Config;
using System;
using System.Security.Cryptography;
using System.Text;

namespace RemitaIntegrate.NET
{
    public class RemitaHashGenerator
    {
        /// <summary>
        /// Remita configuration that holds all the constants given by remita
        /// and allows for basic config values for other things like the apikey
        /// merchantid and servicetypeid to vary from client to client.
        /// </summary>
        public IntegrateConfig Config { get; private set; }

        /// <summary>
        /// Hasher required to perform all hashing required by remita.
        /// Use an IoC container to resolve to SHA512Managed instance
        /// </summary>
        public SHA512 HasherBase { get; private set; }


        public RemitaHashGenerator(IntegrateConfig config, SHA512 hasher)
        {
            Config = config;
            HasherBase = hasher;
        }


        public string HashRemitaRequest(RemitaPost post)
        {
            var hashString = post.MerchantId + post.ServiceTypeId + post.OrderId + post.Amount 
            + post.ResponseUrl + Config.ApiKey;
            
            Byte[] encryptedSha512 = ComputeHash(hashString);
            HasherBase.Clear();
            return BitConverter.ToString(encryptedSha512).Replace("-", "").ToLower();
        }

        public string HashRemitedValidate(string orderId)
        {
            var hashString = orderId + Config.ApiKey + Config.MerchantId;
            
            Byte[] encryptedSha512 = ComputeHash(hashString);
            HasherBase.Clear();
            return BitConverter.ToString(encryptedSha512).Replace("-", "").ToLower();
        }

        public string HashRemitedRePost(string rrr)
        {
            var hashString = Config.MerchantId + rrr + Config.ApiKey;
            
            Byte[] encryptedSha512 = ComputeHash(hashString);
            HasherBase.Clear();
            return BitConverter.ToString(encryptedSha512).Replace("-", "").ToLower();
        }

        public string HashRrrQuery(string rrr)/*, string apiKey, string merchantId)*/
        {
            var hashString = rrr + Config.ApiKey + Config.MerchantId;

            byte[] encryptedSha512 = ComputeHash(hashString);
            HasherBase.Clear();
            return BitConverter.ToString(encryptedSha512).Replace("-", "").ToLower();
        }

        private byte[] ComputeHash(string hashstring)
        {
            return HasherBase.ComputeHash(Encoding.UTF8.GetBytes(hashstring));
        }
    }
}

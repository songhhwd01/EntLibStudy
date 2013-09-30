using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography.Configuration;

namespace EntLibStudy.Helper.EntLibExtension.CryptographyExtension
{
    [ConfigurationElementType(typeof(CustomSymmetricCryptoProviderData))]
    public class CustomSymmetricCryptography : ISymmetricCryptoProvider
    {
        private string encryptKey="";
        public CustomSymmetricCryptography(NameValueCollection attributes)
        {
            //从配置文件中获取key，如不存在则指定默认key
            encryptKey = String.IsNullOrEmpty(attributes["key"]) ? "kyo-yo" : attributes["key"];
        }

        //默认密钥向量
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="ciphertext">待加密数据</param>
        /// <returns>加密后数据</returns>
        public byte[] Decrypt(byte[] ciphertext)
        {
            if (encryptKey.Length > 8)
            {
                encryptKey = encryptKey.Substring(0, 7);
            }
            encryptKey = encryptKey.PadRight(8, ' ');
            byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey);
            byte[] rgbIV = Keys;
            byte[] inputByteArray = ciphertext;
            DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();

            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();
            return mStream.ToArray();
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="plaintext">加密数据</param>
        /// <returns>解密后数据</returns>
        public byte[] Encrypt(byte[] plaintext)
        {
            if (encryptKey.Length > 8)
            {
                encryptKey = encryptKey.Substring(0, 7);
            }
            encryptKey = encryptKey.PadRight(8, ' ');
            byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
            byte[] rgbIV = Keys;
            byte[] inputByteArray = plaintext;
            DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();
            return mStream.ToArray();
        }
    }
}


using System;
using System.Collections.Generic;
//构造函数中接受参数的类型NameValueCollection所在命名空间
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;//用于企业库配置工具绑定
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography.Configuration;

namespace EntLibStudy.Helper.EntLibExtension.CryptographyExtension
{
    [ConfigurationElementType(typeof(CustomHashProviderData))]
    public class CustomHashCryptography : IHashProvider
    {
        /// <summary>
        /// 构造函数，此处不可省略，否则会导致异常
        /// </summary>
        /// <param name="attributes">配置文件中所配置的参数</param>
        public CustomHashCryptography(NameValueCollection attributes)
        {
        }
        /// <summary>
        /// 比较数据和已加密数据是否相等
        /// </summary>
        /// <param name="plaintext">未加密数据</param>
        /// <param name="hashedtext">已加密数据</param>
        /// <returns>是否相等</returns>
        public bool CompareHash(byte[] plaintext, byte[] hashedtext)
        {
            var tmpHashText = CreateHash(plaintext);
            if (tmpHashText == null || hashedtext == null)
                return false;
            if (tmpHashText.Length != hashedtext.Length)
                return false;
            for (int i = 0; i < tmpHashText.Length; i++)
            {
                if (tmpHashText[i] != hashedtext[i])
                    return false;
            }
            return true;
        }
        /// <summary>
        /// 创建加密
        /// </summary>
        /// <param name="plaintext">待加密数据</param>
        /// <returns>加密后数据</returns>
        public byte[] CreateHash(byte[] plaintext)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            return md5.ComputeHash(plaintext);
        }
    }
}

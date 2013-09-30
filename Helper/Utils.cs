using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;

namespace EntLibStudy.Helper
{
    public static class Utils
    {
        public static void WriteToCookie(int sid, string uid, string isAdmin, int expires)
        {
            HttpCookie cookie = new HttpCookie("entlib");
            cookie.Values["sid"] = sid.ToString();
            cookie.Values["uid"] = uid;
            cookie.Values["isadmin"] = isAdmin;
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static string GetCookies(string name)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies["entlib"] != null && HttpContext.Current.Request.Cookies["entlib"][name] != null)
            {
                return HttpContext.Current.Request.Cookies["entlib"][name];
            }
            return "";
        }

        public static void ClearCookie()
        {
            HttpCookie cookie = new HttpCookie("entlib");
            cookie.Values.Clear();
            cookie.Expires = DateTime.Now.AddYears(-1);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static void MessageBox(Page page, string msg, string redirectUrl = "")
        {
            if (page == null)
            {
                throw new ArgumentNullException("Page is null");
            }
            if (!string.IsNullOrEmpty(redirectUrl))
            {

                redirectUrl = "location.href='" + page.ResolveClientUrl(redirectUrl) + "'";
            }
            msg = "alert('" + msg + "');";
            page.ClientScript.RegisterStartupScript(page.ClientScript.GetType(), "msg", msg + redirectUrl, true);
        }

        /// <summary>
        /// 获取2个字符串之间的字符串
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <param name="beginTag">开始字符串</param>
        /// <param name="endTag">截止字符串</param>
        /// <returns></returns>
        public static string GetBetweenString(string str, string beginTag, string endTag)
        {
            int startIndex = str.IndexOf(beginTag);
            int endIndex = str.LastIndexOf(endTag);
            int length = endIndex - (startIndex + 1);

            return length == -1 ? "" : str.Substring(startIndex + 1, length);
        }

        /// <summary>
        /// 获取2个字符串之间的字符串
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <param name="beginTag">开始字符串</param>
        /// <param name="endTag">截止字符串</param>
        /// <param name="beginOffset">开始字符串偏移量</param>
        /// <returns></returns>
        public static string GetBetweenString(string str, string beginTag, string endTag, int beginOffset)
        {
            int startIndex = str.IndexOf(beginTag);
            int endIndex = str.LastIndexOf(endTag);
            int length = endIndex - (startIndex);

            return length == -1 ? "" : str.Substring(startIndex + beginOffset, length - beginOffset);
        }

        /// <summary>
        /// 根据配置进行加密
        /// </summary>
        /// <param name="instance">配置实例名</param>
        /// <param name="encryptString">待加密字符串</param>
        /// <returns>加密后字符串</returns>
        public static string Encode(string instance, string encryptString)
        {
            return Cryptographer.EncryptSymmetric(instance, encryptString);
        }
        /// <summary>
        /// 根据配置进行解密
        /// </summary>
        /// <param name="instance">配置实例名</param>
        /// <param name="decryptString">待解密字符串</param>
        /// <returns>解密后字符串</returns>
        public static string Decode(string instance, string decryptString)
        {
            return Cryptographer.DecryptSymmetric(instance, decryptString);
        }
        /// <summary>
        /// 根据配置进行离散加密
        /// </summary>
        /// <param name="instance">配置实例名</param>
        /// <param name="plaintString">待加密字符串</param>
        /// <returns>解密后字符串</returns>
        public static string CreateHash(string instance, string plaintString)
        {
            return Cryptographer.CreateHash(instance, plaintString);
        }
        /// <summary>
        /// 比较离散值是否相等
        /// </summary>
        /// <param name="instance">配置实例名</param>
        /// <param name="plaintString">未加密字符串</param>
        /// <param name="hashedString">已加密字符串</param>
        /// <returns>是否相等</returns>
        public static bool CompareHash(string instance, string plaintString, string hashedString)
        {
            return Cryptographer.CompareHash(instance, plaintString, hashedString);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace EntLibStudy.Helper
{
    public class BasePage : System.Web.UI.Page
    {
        private bool _isLogin;

        public bool IsLogin
        {
            get
            {
                return _isLogin;
            }
            private set
            {
                _isLogin = value;
            }
        }

        private string _userName;

        public string UserName
        {
            get
            {
                return _userName;
            }
            private set
            {
                _userName = value;
            }
        }

        private bool _isAdmin;

        public bool IsAdmin
        {
            get
            {
                return _isAdmin;
            }
            private set
            {
                _isAdmin = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UserName = Utils.GetCookies("uid");
            var a = Utils.GetCookies("sid");
            if (string.IsNullOrEmpty(this.UserName) == false)
            {
                this.IsLogin = true;
                this.IsAdmin = Utils.GetCookies("isadmin") == "1" ? true : false;
            }
            ShowPage();
        }


        protected void Page_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();

            HandleException(ex, "ExceptionPolicy");
            Server.ClearError();
        }
        protected void HandleException(Exception ex, string policy)
        {
            bool rethrow = false;
            var exManager = EnterpriseLibraryContainer.Current.GetInstance<ExceptionManager>();
            rethrow = exManager.HandleException(ex, policy);
            if (rethrow)
            {
                this.RedirectPermanent("~/error.aspx");
            }
        }

        /// <summary>
        /// 展示子页面,可被子页面重写
        /// </summary>
        protected virtual void ShowPage()
        {
            //TODO 具体的业务逻辑
        }

        /// <summary>
        /// 永久重定向
        /// </summary>
        /// <param name="url"></param>
        protected void RedirectPermanent(string url)
        {
            Response.RedirectPermanent(url);
        }
    }
}
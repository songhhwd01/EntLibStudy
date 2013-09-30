using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntLibStudy.IBLL;
using EntLibStudy.BLL;
using EntLibStudy.Helper.EntLibExtension.PolicyInjectionExtension;

using Microsoft.Practices.EnterpriseLibrary.PolicyInjection;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity.InterceptionExtension;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Unity;



namespace EntLibStudy.WEB
{
    public partial class Login : Helper.BasePage
    {
        protected override void ShowPage()
        {
            if (IsLogin)
            {
                Response.Write("<script>alert('已经登录成功!现在转到首页!');</script>");
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Login1();
            //Login2();
        }

        private void Login1()
        {
            try
            {
                IUnityContainer container = new UnityContainer().AddNewExtension<Interception>();
                container.Configure<Interception>()
               //为IStudentManage设置拦截器为TransparentProxyInterceptor
                       .SetDefaultInterceptorFor<IStudentManage>(new TransparentProxyInterceptor())
                       .AddPolicy("UserLog")
               //增加MemberNameMatchingRule，使用InjectionConstructor初始化MemberNameMatchingRule的构造函数
                       .AddMatchingRule<MemberNameMatchingRule>
                            (new InjectionConstructor("Login"))
               //增加CallHandler，使用InjectionConstructor来初始化CallHandler的构造函数
                       .AddCallHandler<UserLogCallHandler>
                           ("UserLogCallHandler",
                           new ContainerControlledLifetimeManager(),
                           new InjectionConstructor("登录成功", ""));
                //注册对象关系
                container.RegisterType<IStudentManage, StudentManage>();
                IStudentManage studentBll = container.Resolve<IStudentManage>();
                bool isAdmin2 = false;
                if (studentBll.Login(txtUid.Text.Trim(), txtPwd.Text.Trim(), out isAdmin2))
                {
                    if (string.IsNullOrEmpty(Request.QueryString["returnUrl"]) == false)
                    {
                        Response.Redirect(Request.QueryString["returnUrl"]);
                    }
                    else
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                }
                else
                {
                    ltMsg.Text = "用户名或密码不正确,请重试!";
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void Login2()
        {
            IUnityContainer container = new UnityContainer()
                .LoadConfiguration("Log");
            IStudentManage studentBll = container.Resolve<IStudentManage>();
            bool isAdmin2 = false;
            if (studentBll.Login(txtUid.Text.Trim(), txtPwd.Text.Trim(), out isAdmin2))
            {
                if (string.IsNullOrEmpty(Request.QueryString["returnUrl"]) == false)
                {
                    Response.Redirect(Request.QueryString["returnUrl"]);
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            else
            {
                ltMsg.Text = "用户名或密码不正确,请重试!";
            }
        }
    }
}
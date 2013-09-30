using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace EntLibStudy.Helper.EntLibExtension.PolicyInjectionExtension
{
    [AttributeUsage(AttributeTargets.Method)]
    public class UserLogCallHandlerAttribute : HandlerAttribute
    {
        public UserLogCallHandlerAttribute(string message, string ParameterName)
        {
            this.Message = message;
            this.ParameterName = ParameterName;
        }

        public string Message { get; set; }

        public string ParameterName { get; set; }

        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            //创建具体Call Handler，并调用
            UserLogCallHandler handler = new UserLogCallHandler(this.Message, this.ParameterName);

            return handler;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ContainerModel;
using Microsoft.Practices.Unity;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Design;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace EntLibStudy.Helper.EntLibExtension.PolicyInjectionExtension
{
    [ResourceDescription(typeof(DesignResources), "UserLogCallHandlerDataDisplayDescription")]
    [ResourceDisplayName(typeof(DesignResources), "UserLogCallHandlerDataDisplayName")]
    public class UserLogCallHandlerData : CallHandlerData
    {
        public UserLogCallHandlerData()
        {
            Type = typeof(UserLogCallHandler);
        }

        public UserLogCallHandlerData(string handlerName)
            : base(handlerName, typeof(UserLogCallHandler))
        {
        }

        public UserLogCallHandlerData(string handlerName, string message, string parameterName)
            : base(handlerName, typeof(UserLogCallHandler))
        {
            this.Message = message;
            this.ParameterName = parameterName;
        }

        [ConfigurationProperty("Message", IsRequired = true)]
        [ResourceDisplayName(typeof(DesignResources), "UserLogCallHandlerDataMessageDisplayName")]
        [ResourceDescription(typeof(DesignResources), "UserLogCallHandlerDataMessageDisplayDescription")]
        public string Message
        {
            get { return (string)base["Message"]; }
            set { base["Message"] = value; }
        }

        [ConfigurationProperty("ParameterName", IsRequired = true)]
        [ResourceDisplayName(typeof(DesignResources), "UserLogCallHandlerDataParameterNameDisplayName")]
        [ResourceDescription(typeof(DesignResources), "UserLogCallHandlerDataParameterNameDisplayDescription")]
        public string ParameterName
        {
            get { return (string)base["ParameterName"]; }
            set { base["ParameterName"] = value; }
        }

        public override IEnumerable<TypeRegistration> GetRegistrations(string nameSuffix)
        {
            yield return
                new TypeRegistration<ICallHandler>(() =>
                                                   new UserLogCallHandler(
                                                       this.Message,
                                                       this.ParameterName)
                                                   {
                                                       Order = this.Order
                                                   })
                {
                    Name = this.Name + nameSuffix,
                    Lifetime = TypeRegistrationLifetime.Transient
                };
        }
    }
}

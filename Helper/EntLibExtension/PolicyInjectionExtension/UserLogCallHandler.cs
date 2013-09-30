using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace EntLibStudy.Helper.EntLibExtension.PolicyInjectionExtension
{
    [ConfigurationElementType(typeof(CustomCallHandlerData))]
    public class UserLogCallHandler : ICallHandler
    {
        /// <summary>
        /// 构造函数，此构造函数是用于Attribute调用
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="parameterName">参数名</param>
        public UserLogCallHandler(string message, string parameterName)
        {
            this.Message = message;
            this.ParameterName = parameterName.Trim();
        }

        /// <summary>
        /// 构造函数，此处不可省略，否则会导致异常
        /// </summary>
        /// <param name="attributes">配置文件中所配置的参数</param>
        public UserLogCallHandler(NameValueCollection attributes)
        {
            //从配置文件中获取key，如不存在则指定默认key
            this.Message = String.IsNullOrEmpty(attributes["Message"]) ? "" : attributes["Message"];
            this.ParameterName = String.IsNullOrEmpty(attributes["ParameterName"]) ? "" : attributes["ParameterName"];
        }

        /// <summary>
        /// 实现ICallHandler.Invoke方法，用于对具体拦截方法做相应的处理
        /// </summary>
        /// <param name="input"></param>
        /// <param name="getNext"></param>
        /// <returns></returns>
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            //检查参数是否存在
            if (input == null) throw new ArgumentNullException("input");
            if (getNext == null) throw new ArgumentNullException("getNext");

            //开始拦截，此处可以根据需求编写具体业务逻辑代码

            //调用具体方法
            var result = getNext()(input, getNext);
            //判断所拦截的方法返回值是否是bool类型，
            //如果是bool则判断返回值是否为false,false:表示调用不成功，则直接返回方法不记录日志
            if (result.ReturnValue.GetType() == typeof(bool))
            {
                if (Convert.ToBoolean(result.ReturnValue) == false)
                {
                    return result;
                }
            }
            //如果调用方法没有出现异常则记录操作日志
            if (result.Exception == null)
            {
                //获取当前登录的用户名，从cookies中获取，如果采用的session记录，则更改为从session中获取
                var uid = Utils.GetCookies("sid");
                //如果未登录则抛出异常
                if (String.IsNullOrEmpty(uid)) throw new Exception("用户未登录！");
               
                //操作附加消息，用于获取操作的记录相关标识
                var actionMessage = "";
                object para = null;
                //判断调用方法的主要参数名是否为空，不为空则从拦截的方法中获取参数对象
                if (String.IsNullOrEmpty(this.ParameterName) == false)
                {
                    para = input.Inputs[this.ParameterName];
                }
                //判断参数对象是否为null，不为null时则获取参数标识
                //此处对应着具体参数的ToString方法，我已经在具体类中override了ToString方法
                if (para != null)
                {
                    actionMessage = " 编号:[" + para.ToString() + "]";
                }
                //插入操作日志
                Database db = DBHelper.CreateDataBase();
                StringBuilder sb = new StringBuilder();
                sb.Append("insert into UserLog(StudentId,Message,LogDate) values(@StudentId,@Message,@LogDate);");
                DbCommand cmd = db.GetSqlStringCommand(sb.ToString());
                db.AddInParameter(cmd, "@StudentId", DbType.Int32, uid);
                db.AddInParameter(cmd, "@Message", DbType.String, this.Message + actionMessage);
                db.AddInParameter(cmd, "@LogDate", DbType.DateTime, DateTime.Now);
                db.ExecuteNonQuery(cmd);
            }
            //返回方法，拦截结束
            return result;
        }

        public string Message { get; set; }

        public string ParameterName { get; set; }

        private int _order = 0;
        public int Order
        {
            get
            {
                return _order;
            }
            set
            {
                _order = value;
            }
        }
    }
}

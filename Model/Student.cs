using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntLibStudy.Helper;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace EntLibStudy.Model
{
    /// <summary>
    /// 表名：Student
    /// 表描述：
    /// </summary>
    [Serializable]
    public class Student : BaseClass<Student>
    {
        private int _id;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public int ClassId
        {
            get;
            set;
        }
        [StringLengthValidator(1, 16,
            MessageTemplate = "登录ID的长度必须在{3}-{5}之间!")]
        //MessageTemplateResourceType = typeof(EntLibStudy.Model.Properties.Resources),
        //MessageTemplateResourceName = "SidMessage")]
        public string Sid
        {
            get;
            set;
        }

        [StringLengthValidator(1, 256,
            MessageTemplateResourceType = typeof(EntLibStudy.Model.Properties.Resources),
            MessageTemplateResourceName = "PasswordMessage")]
        public string Password
        {
            get;
            set;
        }

        [StringLengthValidator(1, 16,
            MessageTemplateResourceType = typeof(EntLibStudy.Model.Properties.Resources),
            MessageTemplateResourceName = "NameMessage")]
        public string Name
        {
            get;
            set;
        }

        public int Sex
        {
            get;
            set;
        }

        public DateTime Birthday
        {
            get;
            set;
        }

        public int IsAdmin
        {
            get;
            set;
        }

        public override string ToString()
        {
            return this.Id.ToString();
        }
    }
}
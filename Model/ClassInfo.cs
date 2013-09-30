using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntLibStudy.Helper;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace EntLibStudy.Model
{
    /// <summary>
    /// 表名：Class
    /// 表描述：
    /// </summary>
    [Serializable]
    public class ClassInfo : BaseClass<ClassInfo>
    {
        
        public int _id;
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

        [StringLengthValidator(1, 64, MessageTemplate = "班级名称的长度必须在{3}-{5}之间!")]
        public string Name
        {
            get;
            set;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntLibStudy.Helper;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace EntLibStudy.Model
{
    /// <summary>
    /// 表名：Subject
    /// 表描述：
    /// </summary>
    [Serializable]
    public class Subject : BaseClass<Subject>
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

        [StringLengthValidator(1, 64, MessageTemplate = "科目名称的长度必须在{3}-{5}之间!")]
        public string Name { get; set; }

        public double Score { get; set; }

    }
}
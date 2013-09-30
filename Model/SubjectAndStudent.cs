using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntLibStudy.Helper;

namespace EntLibStudy.Model
{
    /// <summary>
    /// 表名：SubjectAndStudent
    /// 表描述：
    /// </summary>
    [Serializable]
    public class SubjectAndStudent : BaseClass<SubjectAndStudent>
    {

        private int _subjectId;
        /// <summary>
        /// 
        /// </summary>
        public int SubjectId
        {
            get
            {
                return _subjectId;
            }
            set
            {
                _subjectId = value;
            }
        }

        private int _studentId;
        /// <summary>
        /// 
        /// </summary>
        public int StudentId
        {
            get
            {
                return _studentId;
            }
            set
            {
                _studentId = value;
            }
        }

    }
}
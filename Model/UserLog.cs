using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntLibStudy.Helper;

namespace EntLibStudy.Model
{
    [Serializable]
    public class UserLog : BaseClass<Subject>
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public string Message { get; set; }

        public DateTime LogDate { get; set; }
    }
}

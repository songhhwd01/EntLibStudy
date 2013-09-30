using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntLibStudy.IDAL;
using EntLibStudy.DAL;
using EntLibStudy.Factory;
using EntLibStudy.Model;

namespace EntLibStudy.BLL
{
    public class SubjectManage
    {
        private static readonly ISubjectService subjectService = DataAccess<ISubjectService>.CreateObject("SubjectService");

        public int Add(Subject subject)
        {
            return subjectService.Add(subject);
        }

        public bool Update(Subject subject)
        {
            return subjectService.Update(subject);
        }

        public bool Delete(int id)
        {
            return subjectService.Delete(id);
        }

        public Subject SelectById(int id)
        {
            return subjectService.SelectById(id);
        }

        public IList<Subject> SelectAll()
        {
            return subjectService.SelectAll();
        }
    }
}

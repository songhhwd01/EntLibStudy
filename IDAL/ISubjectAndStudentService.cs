using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntLibStudy.Model;

namespace EntLibStudy.IDAL
{
    public interface ISubjectAndStudentService
    {
        void Add(SubjectAndStudent subjectAndStudent);

        bool Delete(int subjectId, int studentId);
    }
}

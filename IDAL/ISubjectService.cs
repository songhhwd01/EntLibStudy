using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntLibStudy.Model;

namespace EntLibStudy.IDAL
{
    public interface ISubjectService
    {
        int Add(Subject subject);
        bool Update(Subject subject);
        bool Delete(int id);
        Subject SelectById(int id);
        IList<Subject> SelectAll();
    }
}

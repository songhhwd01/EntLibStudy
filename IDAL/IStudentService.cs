using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntLibStudy.Model;

namespace EntLibStudy.IDAL
{
    public interface IStudentService
    {
        int Add(Student student);
        bool Update(Student student);
        bool Delete(int id);
        IList<Student> SelectAll();
        IList<Student> SelectAllMapper();
        Student SelectById(int id);
        Student SelectBySid(string sid);
    }
}

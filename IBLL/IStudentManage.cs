using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntLibStudy.Model;

namespace EntLibStudy.IBLL
{
    public interface IStudentManage
    {
        int Add(Student student);
        bool Update(Student student);
        bool Delete(int id);
        IList<Student> SelectAll();
        IList<Student> SelectAllMapper();
        Student SelectById(int id);
        bool Login(string uid, string pwd, out bool isAdmin);
    }
}

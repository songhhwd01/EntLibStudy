using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntLibStudy.IDAL;
using EntLibStudy.DAL;
using EntLibStudy.Factory;
using EntLibStudy.Model;
using EntLibStudy.IBLL;
using EntLibStudy.Helper.EntLibExtension.PolicyInjectionExtension;


namespace EntLibStudy.BLL
{
    
    public class StudentManage : IStudentManage
    {
        public StudentManage()
        {
        }

        //public StudentManage(int type)
        //{
        //}
        private static readonly IStudentService studentService = DataAccess<IStudentService>.CreateObject("StudentService");

        public int Add(Student student)
        {
            return studentService.Add(student);
        }

        [UserLogCallHandler("更新学生信息","student")]
        public bool Update(Student student)
        {
            return studentService.Update(student);
        }

        public bool Delete(int id)
        {
            return studentService.Delete(id);
        }

        public Student SelectById(int id)
        {
            return studentService.SelectById(id);
        }

        public IList<Student> SelectAll()
        {
            return studentService.SelectAll();
        }

        public IList<Student> SelectAllMapper()
        {
            return studentService.SelectAllMapper();
        }

        public bool Login(string uid, string pwd, out bool isAdmin)
        {
            bool result = false;
            isAdmin = false;
            Student student = studentService.SelectBySid(uid);
            if (student != null)
            {
                if (student.Password == pwd)
                {
                    result = true;
                    Helper.Utils.WriteToCookie(student.Id, uid, isAdmin ? "1" : "0", 30);
                    if (student.IsAdmin == 1)
                    {
                        isAdmin = true;
                    }
                }
            }

            return result;
        }
    }
}

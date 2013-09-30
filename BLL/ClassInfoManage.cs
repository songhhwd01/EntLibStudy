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
    public class ClassInfoManage
    {
        private IClassInfoService classInfoService = DataAccess<IClassInfoService>.CreateObject("ClassInfoService");

        public int Add(ClassInfo classInfo)
        {
            return classInfoService.Add(classInfo);
        }

        public bool Update(ClassInfo classInfo)
        {
            return classInfoService.Update(classInfo);
        }

        public bool Delete(int id)
        {
            return classInfoService.Delete(id);
        }

        public ClassInfo SelectById(int id)
        {
            return classInfoService.SelectById(id);
        }

        public IList<ClassInfo> SelectAll()
        {
            return classInfoService.SelectAll();
        }
    }
}

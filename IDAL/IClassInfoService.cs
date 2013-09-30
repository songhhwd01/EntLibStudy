using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntLibStudy.Model;

namespace EntLibStudy.IDAL
{
    public interface IClassInfoService
    {
        int Add(ClassInfo classInfo);
        bool Update(ClassInfo classInfo);
        bool Delete(int id);
        IList<ClassInfo> SelectAll();
        ClassInfo SelectById(int id);
    }
}

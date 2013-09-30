using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntLibStudy.Model;

namespace EntLibStudy.IDAL
{
    public interface IUserLogService
    {
        int Add(UserLog userLog);

        bool Update(UserLog userLog);

        bool Delete(int id);

        UserLog SelectById(int id);

        IList<UserLog> SelectAll();
    }
}

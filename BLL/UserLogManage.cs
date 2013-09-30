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
    public class UserLogManage
    {
        private static readonly IUserLogService userLogService = DataAccess<IUserLogService>.CreateObject("UserLog");

        public int Add(UserLog userLog)
        {
            return userLogService.Add(userLog);
        }

        public bool Update(UserLog userLog)
        {
            return userLogService.Update(userLog);
        }

        public bool Delete(int id)
        {
            return userLogService.Delete(id);
        }

        public UserLog SelectById(int id)
        {
            return userLogService.SelectById(id);
        }

        public IList<UserLog> SelectAll()
        {
            return userLogService.SelectAll();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Data;

using EntLibStudy.Model;
using EntLibStudy.Helper;

namespace EntLibStudy.DAL
{
    public class UserLogService : EntLibStudy.IDAL.IUserLogService
    {
        public int Add(UserLog userLog)
        {
            Database db = DBHelper.CreateDataBase();
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into UserLog(StudentId,Message) values(@StudentId,@Message);SELECT @@IDENTITY;");
            DbCommand cmd = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(cmd, "@StudentId", DbType.Int32, userLog.StudentId);
            db.AddInParameter(cmd, "@Message", DbType.String, userLog.Message);
            int id = Convert.ToInt32(db.ExecuteScalar(cmd));
            return id;
        }

        public bool Update(UserLog userLog)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            Database db = DBHelper.CreateDataBase();
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from UserLog where ID=@ID");
            DbCommand cmd = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(cmd, "@ID", DbType.Int32, id);
            return db.ExecuteNonQuery(cmd) > 0 ? true : false;
        }

        public UserLog SelectById(int id)
        {
            UserLog subject = null;
            Database db = DBHelper.CreateDataBase();
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from UserLog ");
            sb.Append(" where ID=@ID");
            DbCommand cmd = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(cmd, "@ID", DbType.Int32, id);

            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                if (reader.Read())
                {
                    subject = new UserLog()
                    {
                        Id = reader.GetInt32(0),
                        StudentId = reader.GetInt32(1),
                        Message = reader.GetString(2),
                        LogDate = reader.GetDateTime(3)
                    };
                }
            }

            return subject;
        }

        public IList<UserLog> SelectAll()
        {
            List<UserLog> list = new List<UserLog>();
            Database db = DBHelper.CreateDataBase();
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from UserLog ");
            DbCommand cmd = db.GetSqlStringCommand(sb.ToString());

            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    list.Add(new UserLog()
                    {
                        Id = reader.GetInt32(0),
                        StudentId = reader.GetInt32(1),
                        Message = reader.GetString(2),
                        LogDate = reader.GetDateTime(3)
                    });
                }
            }
            return list;
        }
    }
}

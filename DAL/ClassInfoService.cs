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
    public class ClassInfoService : EntLibStudy.IDAL.IClassInfoService
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="classInfo">班级对象</param>
        /// <returns></returns>
        public int Add(ClassInfo classInfo)
        {
            Database db = DBHelper.CreateDataBase();
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into Class values(@Name);SELECT @@IDENTITY;");
            DbCommand cmd = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(cmd, "@Name", DbType.String, classInfo.Name);
            int id = Convert.ToInt32(db.ExecuteScalar(cmd));
            return id;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="classInfo">班级对象</param>
        /// <returns>是否成功</returns>
        public bool Update(ClassInfo classInfo)
        {
            Database db = DBHelper.CreateDataBase();
            StringBuilder sb = new StringBuilder();
            sb.Append("update Class set Name=@Name");
            sb.Append(" where ID=@ID");
            DbCommand cmd = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(cmd, "@Name", DbType.String, classInfo.Name);
            db.AddInParameter(cmd, "@ID", DbType.Int32, classInfo.Id);
            return db.ExecuteNonQuery(cmd) > 0 ? true : false;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">班级ID</param>
        /// <returns>是否成功</returns>
        public bool Delete(int id)
        {
            Database db = DBHelper.CreateDataBase();
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from Class ");
            sb.Append(" where ID=@ID");
            DbCommand cmd = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(cmd, "@ID", DbType.Int32, id);

            return db.ExecuteNonQuery(cmd) > 0 ? true : false;
        }

        /// <summary>
        /// 根据班级ID查询班级对象
        /// </summary>
        /// <param name="id">班级ID</param>
        /// <returns></returns>
        public ClassInfo SelectById(int id)
        {
            ClassInfo classInfo = null;
            Database db = DBHelper.CreateDataBase();
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from Class ");
            sb.Append(" where ID=@ID");
            DbCommand cmd = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(cmd, "@ID", DbType.Int32, id);

            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                if (reader.Read())
                {
                    classInfo = new ClassInfo()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    };
                }
            }

            return classInfo;
        }

        /// <summary>
        /// 查询所有班级信息
        /// </summary>
        /// <returns></returns>
        public IList<ClassInfo> SelectAll()
        {
            List<ClassInfo> list = new List<ClassInfo>();
            Database db = DBHelper.CreateDataBase();
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from Class ");
            DbCommand cmd = db.GetSqlStringCommand(sb.ToString());

            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    list.Add(new ClassInfo()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    });
                }
            }
            return list;
        }
    }
}

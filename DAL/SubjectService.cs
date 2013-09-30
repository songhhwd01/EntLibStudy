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
    [Serializable]
    public class SubjectService : EntLibStudy.IDAL.ISubjectService
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="subject">科目对象</param>
        /// <returns></returns>
        public int Add(Subject subject)
        {
            Database db = DBHelper.CreateDataBase();
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into Subject(Name,Score) values(@Name,@Score);SELECT @@IDENTITY;");
            DbCommand cmd = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(cmd, "@Name", DbType.String, subject.Name);
            db.AddInParameter(cmd, "@Score", DbType.Double, subject.Score);
            int id = Convert.ToInt32(db.ExecuteScalar(cmd));
            return id;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="subject">科目对象</param>
        /// <returns>是否成功</returns>
        public bool Update(Subject subject)
        {
            Database db = DBHelper.CreateDataBase();
            StringBuilder sb = new StringBuilder();
            sb.Append("update Subject set ");
            sb.Append("Name=@Name,");
            sb.Append("Score=@Score,");
            sb.Append(" where ID=@ID");
            DbCommand cmd = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(cmd, "@Name", DbType.String, subject.Name);
            db.AddInParameter(cmd, "@Score", DbType.Int32, subject.Score);
            db.AddInParameter(cmd, "@ID", DbType.Int32, subject.Id);
            return db.ExecuteNonQuery(cmd) > 0 ? true : false;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">学生ID</param>
        /// <returns>是否成功</returns>
        public bool Delete(int id)
        {
            Database db = DBHelper.CreateDataBase();
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from Subject ");
            sb.Append(" where ID=@ID");
            DbCommand cmd = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(cmd, "@ID", DbType.Int32, id);

            return db.ExecuteNonQuery(cmd) > 0 ? true : false;
        }

        /// <summary>
        /// 根据科目ID查询科目对象
        /// </summary>
        /// <param name="id">科目ID</param>
        /// <returns></returns>
        public Subject SelectById(int id)
        {
            Subject subject = null;
            Database db = DBHelper.CreateDataBase();
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from Subject ");
            sb.Append(" where ID=@ID");
            DbCommand cmd = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(cmd, "@ID", DbType.Int32, id);

            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                if (reader.Read())
                {
                    subject = new Subject()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Score = reader.GetDouble(2)
                    };
                }
            }

            return subject;
        }

        /// <summary>
        /// 查询所有科目信息
        /// </summary>
        /// <returns></returns>
        public IList<Subject> SelectAll()
        {
            List<Subject> list = new List<Subject>();
            Database db = DBHelper.CreateDataBase();
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from Subject ");
            DbCommand cmd = db.GetSqlStringCommand(sb.ToString());

            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    list.Add(new Subject()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Score = reader.GetDouble(2)
                    });
                }
            }
            return list;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Data;

using EntLibStudy.Model;
using EntLibStudy.Helper;

namespace EntLibStudy.DALSQLite
{
    [Serializable]
    public class StudentService : EntLibStudy.IDAL.IStudentService
    {
        /// <summary>
        /// 新增学生
        /// </summary>
        /// <param name="student">学生对象</param>
        /// <returns></returns>
        public int Add(Student student)
        {
            Database db = DBHelper.CreateDataBase();
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into Student values(@ClassId,@SID,@Password,@Name,@Sex,@Birthday,@IsAdmin);SELECT last_insert_rowid()");
            DbCommand cmd = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(cmd, "@ClassId", DbType.String, student.ClassId);
            db.AddInParameter(cmd, "@SID", DbType.String, student.Sid);
            db.AddInParameter(cmd, "@Password", DbType.String, student.Password);
            db.AddInParameter(cmd, "@Name", DbType.String, student.Name);
            db.AddInParameter(cmd, "@Sex", DbType.Int32, student.Sex);
            db.AddInParameter(cmd, "@Birthday", DbType.DateTime, student.Birthday);
            db.AddInParameter(cmd, "@IsAdmin", DbType.Int32, student.IsAdmin);
            int id = Convert.ToInt32(db.ExecuteScalar(cmd));
            return id;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="classInfo">学生对象</param>
        /// <returns>是否成功</returns>
        public bool Update(Student student)
        {
            Database db = DBHelper.CreateDataBase();
            StringBuilder sb = new StringBuilder();
            sb.Append("update Student set ClassId=@ClassId,");
            sb.Append("SID=@SID,");
            sb.Append("Password=@Password,");
            sb.Append("Name=@Name,");
            sb.Append("Sex=@Sex,");
            sb.Append("Birthday=@Birthday,");
            sb.Append("IsAdmin=@IsAdmin ");
            sb.Append(" where ID=@ID");
            DbCommand cmd = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(cmd, "@ClassId", DbType.String, student.ClassId);
            db.AddInParameter(cmd, "@SID", DbType.String, student.Sid);
            db.AddInParameter(cmd, "@Password", DbType.String, student.Password);
            db.AddInParameter(cmd, "@Name", DbType.String, student.Name);
            db.AddInParameter(cmd, "@Sex", DbType.Int32, student.Sex);
            db.AddInParameter(cmd, "@Birthday", DbType.DateTime, student.Birthday);
            db.AddInParameter(cmd, "@IsAdmin", DbType.Int32, student.IsAdmin);
            db.AddInParameter(cmd, "@ID", DbType.Int32, student.Id);
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
            sb.Append("delete from Student ");
            sb.Append(" where ID=@ID");
            DbCommand cmd = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(cmd, "@ID", DbType.Int32, id);

            return db.ExecuteNonQuery(cmd) > 0 ? true : false;
        }

        /// <summary>
        /// 根据学生ID查询学生对象
        /// </summary>
        /// <param name="id">学生ID</param>
        /// <returns></returns>
        public Student SelectById(int id)
        {
            Student student = null;
            Database db = DBHelper.CreateDataBase();
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from Student ");
            sb.Append(" where ID=@ID");
            DbCommand cmd = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(cmd, "@ID", DbType.Int32, id);

            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                if (reader.Read())
                {
                    student = new Student()
                    {
                        Id = reader.GetInt32(0),
                        ClassId = reader.GetInt32(1),
                        Sid = reader.GetString(2),
                        Password = reader.GetString(3),
                        Name = reader.GetString(4),
                        Sex = reader.GetInt32(5),
                        Birthday = reader.GetDateTime(6),
                        IsAdmin = reader.GetInt32(7)
                    };
                }
            }

            return student;
        }

        /// <summary>
        /// 查询所有学生信息
        /// </summary>
        /// <returns></returns>
        public IList<Student> SelectAll()
        {
            List<Student> list = new List<Student>();
            Database db = DBHelper.CreateDataBase();
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from Student ");
            DbCommand cmd = db.GetSqlStringCommand(sb.ToString());

            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    list.Add(new Student()
                    {
                        Id = reader.GetInt32(0),
                        ClassId = reader.GetInt32(1),
                        Sid = reader.GetString(2),
                        Password = reader.GetString(3),
                        Name = reader.GetString(4),
                        Sex = reader.GetInt32(5),
                        Birthday = reader.GetDateTime(6),
                        IsAdmin = reader.GetInt32(7)
                    });
                }
            }
            return list;
        }

        /// <summary>
        /// 查询所有学生信息
        /// </summary>
        /// <returns></returns>
        public IList<Student> SelectAllMapper()
        {
            var list = new List<Student>();
            Database db = DBHelper.CreateDataBase();
            DataAccessor<Student> studentAccessor;
            studentAccessor = db.CreateSqlStringAccessor("select * from Student",
                MapBuilder<Student>.MapAllProperties().
                Build()
                );
            list = studentAccessor.Execute().ToList();
            return list;
        }

        public Student SelectBySid(string sid)
        {
            Student student = null;
            Database db = DBHelper.CreateDataBase();
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from Student ");
            sb.Append(" where SID=@SID");
            DbCommand cmd = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(cmd, "@SID", DbType.String, sid);

            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                if (reader.Read())
                {
                    student = new Student()
                    {
                        Id = reader.GetInt32(0),
                        ClassId = reader.GetInt32(1),
                        Sid = reader.GetString(2),
                        Password = reader.GetString(3),
                        Name = reader.GetString(4),
                        Sex = reader.GetInt32(5),
                        Birthday = reader.GetDateTime(6),
                        IsAdmin = reader.GetInt32(7)
                    };
                }
            }

            return student;
        }
    }
}

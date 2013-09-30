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
    public class SubjectAndStudentService : EntLibStudy.IDAL.ISubjectAndStudentService
    {
        #region ISubjectAndStudentService 成员

        public void Add(SubjectAndStudent subjectAndStudent)
        {
            Database db = DBHelper.CreateDataBase();
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into SubjectAndStudent values(@SubjectId,@StudentId)");
            DbCommand cmd = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(cmd, "@SubjectId", DbType.Int32, subjectAndStudent.SubjectId);
            db.AddInParameter(cmd, "@StudentId", DbType.Int32, subjectAndStudent.StudentId);

            db.ExecuteNonQuery(cmd);
        }

        public bool Delete(int subjectId, int studentId)
        {
            Database db = DBHelper.CreateDataBase();
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from SubjectAndStudent ");
            sb.Append(" where SubjectId=@SubjectId and StudentId=@StudentId");
            DbCommand cmd = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(cmd, "@SubjectId", DbType.Int32, subjectId);
            db.AddInParameter(cmd, "@StudentId", DbType.Int32, studentId);

            return db.ExecuteNonQuery(cmd) > 0 ? true : false;
        }

        #endregion
    }
}

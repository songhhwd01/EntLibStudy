using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters;
using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;

namespace EntLibStudy.Helper.EntLibExtension.ExceptionExtension
{
    [ConfigurationElementType(typeof(CustomTraceListenerData))]
    public class ExceptionCustomerListener : CustomTraceListener
    {
        string writeLogSQL = String.Empty;
        Database database;

        public ExceptionCustomerListener()
            : base()
        {
            database = DBHelper.CreateDataBase();
        }

        public override void TraceData(TraceEventCache eventCache, string source,
            TraceEventType eventType, int id, object data)
        {
            if ((this.Filter == null) || this.Filter.ShouldTrace(eventCache, source, eventType, id, null, null, data, null))
            {
                if (data is LogEntry)
                {
                    LogEntry logEntry = data as LogEntry;
                    ExecuteSQL(logEntry);
                }
                else if (data is string)
                {
                    Write(data as string);
                }
                else
                {
                    base.TraceData(eventCache, source, eventType, id, data);
                }
            }
        }

        public override void Write(string message)
        {
            ExecuteWriteLogSQL(TraceEventType.Information, DateTime.Now, message, database);
        }

        public override void WriteLine(string message)
        {
            Write(message);
        }

        /// <summary>
        ///执行SQL
        /// </summary>
        /// <param name="logEntry">日志对象</param>
        private void ExecuteSQL(LogEntry logEntry)
        {
            using (DbConnection connection = database.CreateConnection())
            {
                try
                {
                    connection.Open();
                    using (DbTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            ExecuteWriteLogSQL(logEntry, database, transaction);
                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }

                    }
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 执行写入日志数据库语句
        /// </summary>
        /// <param name="severity">异常等级</param>
        /// <param name="message">消息</param>
        /// <param name="db">保存日志的数据库实例</param>
        private void ExecuteWriteLogSQL(TraceEventType severity, DateTime timeStamp, string message, Database db)
        {
            writeLogSQL = (string)this.Attributes["writeLogSQL"];
            DbCommand cmd = db.GetSqlStringCommand(writeLogSQL);

            string exceptionMessage = Utils.GetBetweenString(message, "Message :", "Source :", 9);
            string exceptionInfo = Utils.GetBetweenString(message, "Stack Trace :", "Additional Info:", 13);
            db.AddInParameter(cmd, "@Message", DbType.String, exceptionMessage);
            db.AddInParameter(cmd, "@LogDate", DbType.DateTime, timeStamp);
            db.AddInParameter(cmd, "@Level", DbType.String, message);
            db.AddInParameter(cmd, "@Exception", DbType.String, exceptionInfo);

            db.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// 执行写入日志数据库语句
        /// </summary>
        /// <param name="logEntry">日志对象</param>
        /// <param name="db">保存日志的数据库实例</param>
        /// <param name="transaction">事务对象</param>
        private void ExecuteWriteLogSQL(LogEntry logEntry, Database db, DbTransaction transaction)
        {
            writeLogSQL = (string)this.Attributes["writeLogSQL"];
            DbCommand cmd = db.GetSqlStringCommand(writeLogSQL);
           
            string exceptionMessage = Utils.GetBetweenString(logEntry.Message, "Message :", "Source :", 9);
            string exceptionInfo = Utils.GetBetweenString(logEntry.Message, "Stack Trace :", "Additional Info:", 13);
            db.AddInParameter(cmd, "@Message", DbType.String, exceptionMessage);
            db.AddInParameter(cmd, "@LogDate", DbType.DateTime, logEntry.TimeStamp.ToLocalTime());
            db.AddInParameter(cmd, "@Level", DbType.String, logEntry.LoggedSeverity);
            db.AddInParameter(cmd, "@Exception", DbType.String, exceptionInfo);


            db.ExecuteNonQuery(cmd, transaction);
        }

    }
}

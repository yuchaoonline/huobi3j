using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ADeeWu.HuoBi3J.SQL.Logger;
using ADeeWu.HuoBi3J.SQL.SqlBuilder;

namespace ADeeWu.HuoBi3J.SQL.DBDriver
{
    public class MsSqlCore
    {
        private static string connectionString = string.Empty;
        private static bool _debug = false;
        private static bool _alwaysTrace = false;//总是追踪

        /// <summary>
        /// 设置或获取是否启动调试模式,可通过AppSetting 节点下名为ADeeWu.HuoBi3J.SQL.DBProvider.MsSqlCore.Debug元素配置
        /// </summary>
        public static bool Debug
        {
            get { return _debug; }
            set { _debug = value; }
        }


        private static bool _errorTrace = false;
        /// <summary>
        /// 设置或获取是否启动调用跟踪,可通过AppSetting 节点下名为ADeeWu.HuoBi3J.SQL.DBProvider.MsSqlCore.ErrorTrace元素配置
        /// </summary>
        public static bool ErrorTrace 
        {
            get { return _errorTrace; }
            set { _errorTrace = value; }
        }

        /// <summary>
        /// 设置或获取是否总是追踪,可通过AppSetting 节点下名为ADeeWu.HuoBi3J.SQL.DBProvider.MsSqlCore.AlwaysTrace元素配置
        /// </summary>
        public static bool AlwaysTrace
        {
            set { _alwaysTrace = value; }
            get { return _alwaysTrace; }
        }

        private static ILog _ilog = null;
        /// <summary>
        /// 设置或获取日志器
        /// </summary>
        public static ILog Loger
        {
            get { return _ilog; }
            set { _ilog = value; }
        }

        private static string _filePath = "C:\\";

        static MsSqlCore()
        {
            string strDebug = System.Configuration.ConfigurationManager.AppSettings["ADeeWu.HuoBi3J.SQL.DBProvider.MsSqlCore.Debug"];
            if (!string.IsNullOrEmpty(strDebug))
            {
                if (string.Compare(strDebug, "true", true) == 0)
                {
                    _debug = true;
                }
            }

            string strErrorTrace = System.Configuration.ConfigurationManager.AppSettings["ADeeWu.HuoBi3J.SQL.DBProvider.MsSqlCore.ErrorTrace"];
            if (!string.IsNullOrEmpty(strErrorTrace))
            {
                if (string.Compare(strErrorTrace, "true", true) == 0)
                {
                    _errorTrace = true;
                }
            }

            string strAlwaysTrace = System.Configuration.ConfigurationManager.AppSettings["ADeeWu.HuoBi3J.SQL.DBProvider.MsSqlCore.AlwaysTrace"];
            if (!string.IsNullOrEmpty(strErrorTrace))
            {
                if (string.Compare(strAlwaysTrace, "true", true) == 0)
                {
                    _alwaysTrace = true;
                }
            }

            string logMode = System.Configuration.ConfigurationManager.AppSettings["ADeeWu.HuoBi3J.SQL.DBProvider.MsSqlCore.LogMode"];
            if (string.IsNullOrEmpty(logMode))
            {
                logMode = "web";
            }
            else
            {
                logMode = logMode.ToLower();
            }
           
            
            string logPath = System.Configuration.ConfigurationManager.AppSettings["ADeeWu.HuoBi3J.SQL.DBProvider.MsSqlCore.LogPath"];
            if (!string.IsNullOrEmpty(logPath))
            {
                if (!logPath.EndsWith("\\"))
                {
                    logPath += "\\";
                }

                if (logMode == "web")
                {
                    _filePath = System.Web.HttpContext.Current.Server.MapPath(logPath);
                }

                _filePath += string.Format("{0}.log", DateTime.Now.ToString("yyyy-MM-dd"));
                _ilog = new TextLogger(_filePath);
            }
            else
            {
                _ilog = new TextLogger();
            }

            

            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mssql"].ToString();
        }


        private static void LogMessage(string methodName,string sql,string source,string message,string otherMsg )
        {
            List<string> msgList = new List<string>();
            msgList.Add("******************** 错误捕捉 ********************");
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null)
            {
                msgList.Add("URL:" + System.Web.HttpContext.Current.Request.Url.ToString());
            }
            msgList.Add(string.Format("{0} 调用方法 {1}", DateTime.Now.ToLongTimeString(),methodName));
            msgList.Add(string.Format("SQL:      {0}", sql));
            msgList.Add(string.Format("错误源:   {0}", source));
            msgList.Add(string.Format("错误信息: {0}", message));
            msgList.Add(string.Format("其它信息: {0}", otherMsg));
            msgList.Add("");

            Loger.Log(msgList.ToArray());
        }

        private static void AlwaysLog(string methodName, string sql,IDataParameter[] parameters, string otherMsg)
        {
            
            StringBuilder builder = new StringBuilder();
            builder.Append("\r\nAlwaysLog:\r\n");
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null)
            {
                builder.AppendFormat("URL:{0}\r\n", System.Web.HttpContext.Current.Request.Url.ToString());
            }
            builder.AppendFormat("{0} 调用方法 {1}", DateTime.Now.ToLongTimeString(), methodName);
            builder.AppendFormat("SQL:      {0}\r\n", sql);
            builder.AppendFormat("Paramters:\r\n");
            if (parameters != null)
            {
                foreach (IDataParameter parameter in parameters)
                {
                    builder.AppendFormat("{0} = {1}\r\n", parameter.ParameterName, parameter.Value);
                }
            }
            builder.AppendFormat("其它信息: {0}", otherMsg);
            builder.AppendFormat("\r\n");

            Loger.Log(builder.ToString());
        }

        #region 静态函数

        public static SqlConnection CreateConnInstance()
        {
            return new SqlConnection(connectionString);
        }

        public static DataSet GetDataSet(string sql)
        {
            if (AlwaysTrace)
            {
                AlwaysLog("GetDataSet(string sql)", sql,null,string.Empty);
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter ad = new SqlDataAdapter(sql, connection);
                    ad.Fill(ds, "ds");
                }
                catch (SqlException ex)
                {
                    connection.Close();
                    connection.Dispose();
                    if (ErrorTrace)
                    {
                        LogMessage("GetDataSet(string sql)", sql, ex.Source, ex.Message, null);
                    }
                    if (Debug)
                    {
                        connection.Close();
                        connection.Dispose();
                        throw ex;
                    }
                    
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
                return ds;
            }

        }

        public static DataSet GetDataSet(string sql, params IDataParameter[] parameters)
        {
            if (AlwaysTrace)
            {
                AlwaysLog("GetDataSet", sql, parameters,string.Empty);
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        SqlDataAdapter ad = new SqlDataAdapter(sql, connection);
                        ad.SelectCommand = cmd;
                        ad.Fill(ds, "ds");
                    }
                    catch (SqlException ex)
                    {
                        if(ErrorTrace)
                        {
                            LogMessage("GetDataSet", sql, ex.Source, ex.Message, null);
                        }

                        if (Debug)
                        {
                            cmd.Dispose();
                            connection.Close();
                            connection.Dispose();
                            throw ex;
                        }
                        
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                        connection.Dispose();
                    }
                    return ds;
                }
            }

        }

        /// <summary>
        /// 更新记录 (可用于特殊情况筛选要更新的记录)
        /// </summary>
        /// <param name="tableName">更新的表</param>
        /// <param name="updateColumns">更新的字段集合</param>
        /// <param name="updateValues">更新对应<paramref name="updateColumns"/>所指定的列的值</param>
        /// <param name="where">筛选条件</param>
        /// <param name="parameters"><paramref name="where"/>所使用的参数</param>
        /// <returns></returns>
        public static int Update(string tableName, string[] updateColumns, object[] updateValues, string where, params IDataParameter[] parameters)
        {
            if (updateColumns.Length == 0)
            {
                throw new Exception("updateColumns长度小于1,更新的列不能为空");
            }
            if (updateValues.Length < updateColumns.Length)
            {
                throw new Exception("更新字段对应的值与对应列(updateColumns)的数目不匹配");
            }

            StringBuilder builder = new StringBuilder();
            List<IDataParameter> allParameters = new List<IDataParameter>();

            builder.AppendFormat("update [{0}] set", tableName);
            for (int i = 0; i < updateColumns.Length; i++)
            {
                builder.AppendFormat(" [{0}]=@{0} ,", updateColumns[i]);
                SqlParameter parameter = new SqlParameter("@" + updateColumns[i], updateValues[i]);
                allParameters.Add(parameter);
            }

           

            builder.Remove(builder.Length - 1, 1);
            builder.Append(" where 1=1 ");
            if (where.Trim().Length > 0)
            {
                builder.AppendFormat(" and {0}", where);
                if (parameters != null)
                {
                    allParameters.AddRange(parameters);
                }
            }
            return ExecuteSql(builder.ToString(), allParameters.ToArray());
        }


        public static int Update(string tableName, string columnName, object value, string where)
        {
            return Update(tableName, columnName, value, where, null);
        }

        public static int Update(string tableName, string columnName, object value, string where, params IDataParameter[] parameters)
        {
            
            StringBuilder builder = new StringBuilder();
            List<IDataParameter> allParameters = new List<IDataParameter>();

            builder.AppendFormat("update [{0}] set [{1}]=@{1}", tableName,columnName);
            SqlParameter parameter = new SqlParameter("@" + columnName, value);
            allParameters.Add(parameter);

           
            builder.Append(" where 1=1 ");
            if (where.Trim().Length > 0)
            {
                builder.AppendFormat(" and {0}", where);
                if (parameters != null)
                {
                    allParameters.AddRange(parameters);
                }
            }
            return ExecuteSql(builder.ToString(), allParameters.ToArray());
        }

        public static int Update(string tableName, string[] updateColumns, object[] updateValues, string[] filterColumns, object[] filterValues)
        {
            if (updateColumns.Length == 0)
            {
                throw new Exception("updateColumns长度小于1,更新的列不能为空");
            }
            if (updateValues.Length < updateColumns.Length)
            {
                throw new Exception("更新字段对应的值与对应列(updateColumns)的数目不匹配");
            }



            StringBuilder builder = new StringBuilder();
            SqlParameter[] parameters = null;
            if (filterColumns.Length > 0)
            {
                parameters = new SqlParameter[updateColumns.Length + filterColumns.Length];
            }
            else
            {
                parameters = new SqlParameter[updateColumns.Length];
            }

            builder.AppendFormat("update [{0}] set", tableName);
            int length = 0;
            for (int i = 0; i < updateColumns.Length; i++)
            {
                builder.AppendFormat(" [{0}]=@{0} ,", updateColumns[i]);
                parameters[length] = new SqlParameter("@" + updateColumns[i], updateValues[i]);
                length++;
            }

            builder.Remove(builder.Length - 1, 1);
            if (filterColumns.Length > 0)
            {

                if (filterValues.Length < filterColumns.Length)
                {
                    throw new Exception("筛选字段对应的值与对应列(filterColumns)的数目不匹配");
                }

                builder.Append(" where 1=1 ");
                for (int i = 0; i < filterColumns.Length; i++)
                {
                    builder.AppendFormat(" and [{0}]=@{0}2 ,", filterColumns[i]);
                    parameters[length] = new SqlParameter("@" + filterColumns[i] + "2", filterValues[i]);
                    length++;
                }
                builder.Remove(builder.Length - 1, 1);
            }

            return ExecuteSql(builder.ToString(), parameters);
        }

        public static int Delete(string tableName,string[] columns, params object[] values)
        {
            if (columns.Length == 0)
            {
                throw new Exception("columns长度小于1,筛选的列不能为空");
            }

            StringBuilder builder = new StringBuilder();
            SqlParameter[] parameters = new SqlParameter[columns.Length];
            builder.AppendFormat("delete from [{0}] where 1=1",tableName);
            for (int i = 0; i < columns.Length; i++)
            {
                builder.AppendFormat(" and [{0}]=@{0}", columns[i]);
                parameters[i] = new SqlParameter("@" + columns[i], values[i]);
            }
            return ExecuteSql(builder.ToString(), parameters);
        }


       
        
        #region 无分页查询数据
        public static DataTable GetDataTable(string sql)
        {
            return GetDataTable(sql,null);
        }

        public static DataTable GetDataTable(string sql, params IDataParameter[] parameters)
        {
            if (AlwaysTrace)
            {
                AlwaysLog("GetDataTable", sql, parameters, string.Empty);
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    DataTable dt = new DataTable();
                    try
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        SqlDataAdapter ad = new SqlDataAdapter(sql, connection);
                        ad.SelectCommand = cmd;
                        ad.Fill(dt);
                    }
                    catch (SqlException ex)
                    {
                        
                        if (ErrorTrace)
                        {
                            LogMessage("GetDataTable", sql, ex.Source, ex.Message, "");
                        }
                        if (Debug)
                        {
                            cmd.Dispose();
                            connection.Close();
                            connection.Dispose();
                            throw ex;
                        }
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                        connection.Dispose();
                    }
                    return dt;
                }
            }
        }
        #endregion

        #region 分页查询数据(动态构造SQL语句)
        
        public static DataTable Select(int pageSize, int pageIndex, string sourceName, string identity)
        {
            return Select(pageSize, pageIndex, sourceName, identity, "", "", null);
        }

        public static DataTable Select(int pageSize, int pageIndex, string sourceName, string identity, string orderBy)
        {
            return Select(pageSize, pageIndex, sourceName, identity, orderBy, "", null);
        }

        public static DataTable Select(int pageSize, int pageIndex, string sourceName, string identity, string orderBy, string where)
        {
            return Select(pageSize, pageIndex, sourceName, identity, orderBy, where, null);
        }

        public static DataTable Select(int pageSize, int pageIndex, string sourceName, string identity, string orderBy, string where, params IDataParameter[] parameters)
        {
            SortPageSqlBuilder sqlBuilder = new SortPageSqlBuilder(sourceName, identity, where, pageSize, pageIndex, orderBy);
            sqlBuilder.GenerateSql();

            if (AlwaysTrace)
            {
                AlwaysLog("Select", sqlBuilder.PagingSQL, parameters, string.Empty);
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sqlBuilder.PagingSQL, connection))
                {
                    DataTable dt = new DataTable();
                    try
                    {
                        if (where.Trim()!="" && parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        SqlDataAdapter ad = new SqlDataAdapter(cmd);
                        ad.Fill(dt);
                    }
                    catch (SqlException ex)
                    {
                        
                        if (ErrorTrace)
                        {
                            LogMessage("Select",sqlBuilder.PagingSQL, ex.Source, ex.Message, "");
                        }
                        if (Debug)
                        {
                            cmd.Dispose();
                            connection.Close();
                            connection.Dispose();
                            throw ex;
                        }
                        
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                        connection.Dispose();
                    }
                    return dt;
                }
            }
        }


        //带总记录数重载

        public static DataTable Select2(int pageSize, int pageIndex, string sourceName, string identity, out int recordCount)
        {
            return Select2(pageSize, pageIndex, sourceName, identity, "", out recordCount, "", null);
        }

        public static DataTable Select2(int pageSize, int pageIndex, string sourceName, string identity, string orderBy, out int recordCount)
        {
            return Select2(pageSize, pageIndex, sourceName, identity, orderBy, out recordCount, "", null);
        }

        public static DataTable Select2(int pageSize, int pageIndex, string sourceName, string identity, string orderBy, out int recordCount, string where)
        {
            return Select2(pageSize, pageIndex, sourceName, identity, orderBy, out recordCount, where, null);
        }

        public static DataTable Select2(int pageSize, int pageIndex, string sourceName, string identity, string orderBy, out int recordCount, string where, params IDataParameter[] parameters)
        {
            SortPageSqlBuilder sqlBuilder = new SortPageSqlBuilder(sourceName, identity, where, pageSize, pageIndex, orderBy);
            sqlBuilder.GenerateSql();

            if (AlwaysTrace)
            {
                AlwaysLog("Select2", sqlBuilder.PagingSQL, parameters, string.Empty);
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sqlBuilder.PagingSQL, connection))
                {
                    DataTable dt = new DataTable();
                    try
                    {
                        if (where.Trim() != "" && parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        SqlDataAdapter ad = new SqlDataAdapter(cmd);
                        ad.Fill(dt);

                        cmd.Parameters.Clear();
                        recordCount = (int)ExecuteScalar(sqlBuilder.CountSQL, parameters);
                        return dt;
                    }
                    catch (SqlException ex)
                    {
                        cmd.Dispose();
                        connection.Close();
                        connection.Dispose();
                        if (ErrorTrace)
                        {
                            LogMessage("Select2",
                                sqlBuilder.PagingSQL, ex.Source, ex.Message,
                                "SQL2:" + sqlBuilder.CountSQL
                                );
                        }
                        if (Debug)
                        {
                            throw ex;
                        }
                        
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                        connection.Dispose();
                    }
                    recordCount = 0;
                    return dt;
                }
            }
        }

        #endregion





        public static int ExecuteSql(string sql)
        {
            return ExecuteSql(sql, null);
        }

     
        public static int ExecuteSql(string sql, params IDataParameter[] parameters)
        {
            if (AlwaysTrace)
            {
                AlwaysLog("ExecuteSql", sql, parameters, string.Empty);
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    try
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        connection.Open();
                        return cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        if (ErrorTrace)
                        {
                            LogMessage("ExecuteSql",sql, ex.Source, ex.Message,"");
                        }

                        if (Debug)
                        {
                            cmd.Dispose();
                            connection.Close();
                            connection.Dispose();
                            throw ex;
                        }
                    }
                    finally
                    {
                        connection.Close();
                        connection.Dispose();
                        cmd.Dispose();
                    }
                    return -1;
                }
            }
        }

        public static object ExecuteScalar(string sql)
        {
            return ExecuteScalar(sql, null);
        }

        public static object ExecuteScalar(string sql, params IDataParameter[] parameters)
        {

            if (AlwaysTrace)
            {
                AlwaysLog("ExecuteScalar", sql, parameters, string.Empty);
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    try
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (SqlException ex)
                    {
                        if (ErrorTrace)
                        {
                            LogMessage("ExecuteScalar", sql, ex.Source, ex.Message, "");
                        }

                        if (Debug)
                        {
                            cmd.Dispose();
                            connection.Close();
                            connection.Dispose();
                            throw ex;
                        }
                    }
                    finally
                    {
                        connection.Close();
                        connection.Dispose();
                        cmd.Dispose();
                    }
                    return null;
                }
            }
        }

        public static bool Exist(string sql)
        {
            return Exist(sql, null);
        }

        public static bool Exist(string sql,params IDataParameter[] parameters)
        {
            if (AlwaysTrace)
            {
                AlwaysLog("Exist", sql, parameters, string.Empty);
            }
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    try
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        bool ret = reader.Read();
                        reader.Close();
                        reader.Dispose();
                        return ret;

                    }
                    catch (SqlException e)
                    {
                        if (ErrorTrace)
                        {
                            LogMessage("Exist", sql, e.Source, e.Message, "");
                        }

                        if (Debug)
                        {
                            cmd.Dispose();
                            connection.Close();
                            connection.Dispose();
                            throw e;
                        }
                        return false;
                    }
                    finally
                    {
                        connection.Close();
                        connection.Dispose();
                        cmd.Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// 调用RunProcDataSet 返回第一个DataTable对象
        /// </summary>
        /// <param name="procducre"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable RunProcDataTable(string procducre, params IDataParameter[] parameters)
        {
            if (AlwaysTrace)
            {
                AlwaysLog("RunProcDataTable", procducre, parameters, string.Empty);
            }
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    DataTable dt = new DataTable();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procducre;
                    try
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        SqlDataAdapter ad = new SqlDataAdapter(cmd);
                        ad.Fill(dt);
                        return dt;
                    }
                    catch (SqlException ex)
                    {

                        if (ErrorTrace)
                        {
                            LogMessage("RunProcDataTable", procducre, ex.Source, ex.Message, "");
                        }

                        if (Debug)
                        {
                            cmd.Dispose();
                            connection.Close();
                            connection.Dispose();
                            throw ex;
                        }
                        return dt;
                    }
                    finally
                    {
                        connection.Close();
                        connection.Dispose();
                        cmd.Dispose();
                    }

                   
                }
            }
        }

        public static DataSet RunProcDataSet(string procducre, params IDataParameter[] parameters)
        {

            if (AlwaysTrace)
            {
                AlwaysLog("RunProcDataSet", procducre, parameters, string.Empty);
            }
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    DataSet ds = new DataSet();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procducre;
                    try
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        
                        SqlDataAdapter ad = new SqlDataAdapter(cmd);
                        ad.Fill(ds);
                    }
                    catch (SqlException ex)
                    {
                        if (ErrorTrace)
                        {
                            LogMessage("RunProcDataSet", procducre, ex.Source, ex.Message, "");
                        }

                        if (Debug)
                        {
                            cmd.Dispose();
                            connection.Close();
                            connection.Dispose();
                            throw ex;
                        }
                        return ds;
                    }
                    finally
                    {
                        connection.Close();
                        connection.Dispose();
                        cmd.Dispose();
                    }

                    return ds;
                }
            }
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procducre">存储过程名称</param>
        /// <param name="parameters">参数</param>
        /// <returns>返回存储过程返回值,该值有可能为空</returns>
        public static object RunProc(string procducre, params IDataParameter[] parameters)
        {

            if (AlwaysTrace)
            {
                AlwaysLog("RunProc", procducre, parameters, string.Empty);
            }
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procducre;
                    try
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        SqlParameter returnValue = new SqlParameter("@ReturnValue", SqlDbType.Int);
                        returnValue.Direction = ParameterDirection.ReturnValue;
                        cmd.Parameters.Add(returnValue);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        return returnValue.Value;
                    }
                    catch (SqlException ex)
                    {
                        if (ErrorTrace)
                        {
                            LogMessage("RunProc", procducre, ex.Source, ex.Message, "");
                        }

                        if (Debug)
                        {
                            cmd.Dispose();
                            connection.Close();
                            connection.Dispose();
                            throw ex;
                        }
                        return null;
                    }
                    finally
                    {
                        connection.Close();
                        connection.Dispose();
                        cmd.Dispose();
                    }
                }
            }
        }
       

       
        /// <summary>
        /// 设置连接字符串
        /// </summary>
        /// <param name="connStr"></param>
        public static void SetConnectionString(string connStr)
        {
            connectionString = connStr;
        }

        /// <summary>
        /// 重设连接字符串,通过配置文件ConfigurationManager.ConnectionStrings["MsSql"]
        /// </summary>
        public static void ResetConnectionString()
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MsSql"].ToString();
        }

        #endregion


    }
}

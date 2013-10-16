﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ADeeWu.HuoBi3J.SQL.Logger;
using ADeeWu.HuoBi3J.SQL.SqlBuilder;
using ADeeWu.HuoBi3J.SQL.ParameterCollection;

namespace ADeeWu.HuoBi3J.SQL.DBDriver
{
    public class MsSqlDriver : DataBase
    {



        public MsSqlDriver()
        {

        }


        #region 实现

        public override IDbConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public override IDbCommand CreateDbCommand()
        {
            return new SqlCommand();
        }

        public override IDbDataAdapter CreateDataAdpater()
        {
            return new SqlDataAdapter();
        }

        public override IDbDataParameter CreateParameter()
        {
            return new SqlParameter();
        }

        //public override IDbDataAdapter CreateDataAdpater(IDbCommand cmd)
        //{
        //    SqlCommand cmd2 = cmd as SqlCommand;
        //    if (cmd2==null) return null;
        //    return new SqlDataAdapter(cmd2);
        //}

        //public override IDbDataAdapter CreateDataAdpater(string sql,CommandType cmdType)
        //{
        //    SqlCommand cmd = CreateDbCommand() as SqlCommand;
        //    cmd.Connection = CreateConnInstance() as SqlConnection;
        //    cmd.CommandType= cmdType;
        //    cmd.CommandText = sql;
        //    if (this.Parameters.Count > 0)
        //    {
        //        cmd.Parameters.AddRange(this.Parameters.ToArray());
        //    }
        //    return new SqlDataAdapter(cmd);
        //}

       

        public override DataSet GetDataSet(string sql)
        {
            FormatSQL(sql);

            if (EnableAlwaysTrace)
            {
                AlwaysLog("GetDataSet", sql,string.Empty);
            }

            using (SqlConnection connection = CreateConnection() as SqlConnection)
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        if (this.Parameters.Count > 0)
                        {
                            cmd.Parameters.AddRange(this.Parameters.ToArray());
                        }
                        SqlDataAdapter ad = new SqlDataAdapter(sql, connection);
                        ad.SelectCommand = cmd;
                        ad.Fill(ds, "ds");
                    }
                    catch (Exception ex)
                    {
                        if(EnableErrorTrace)
                        {
                            LogMessage("GetDataSet", sql, ex.Source, ex.Message, null);
                        }

                        if (EnableDebug)
                        {
                            cmd.Parameters.Clear();
                            cmd.Dispose();
                            connection.Close();
                            connection.Dispose();
                            AfterExecute();
                            throw ex;
                        }
                        
                    }
                    finally
                    {
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                        connection.Close();
                        connection.Dispose();
                        AfterExecute();
                    }
                    return ds;
                }
            }

        }


      


       
        
        

        #region 分页查询数据(动态构造SQL语句)



        //带总记录数重载
        public override DataTable Select(long pageSize, long pageIndex, string sourceName, string identity)
        {
            return Select(pageSize, pageIndex, sourceName, identity, "", "");
        }

        public override DataTable Select(long pageSize, long pageIndex, string sourceName, string identity, string where, string orderBy)
        {
            
            
            SortPageSqlBuilder sqlBuilder = new SortPageSqlBuilder(sourceName, identity, where, pageSize, pageIndex, orderBy);
            sqlBuilder.GenerateSql();
            FormatSQL(sqlBuilder.PagingSQL);
            if (EnableAlwaysTrace)
            {
                AlwaysLog("Select", sqlBuilder.PagingSQL, string.Empty);
            }

            using (SqlConnection connection = CreateConnection() as SqlConnection)
            {
                using (SqlCommand cmd = new SqlCommand(sqlBuilder.PagingSQL, connection))
                {
                    DataTable dt = new DataTable();
                    try
                    {
                        if (where.Trim() != "" && this.Parameters.Count > 0)
                        {
                            cmd.Parameters.AddRange(this.Parameters.ToArray());
                        }
                        SqlDataAdapter ad = new SqlDataAdapter(cmd);
                        ad.Fill(dt);

                        cmd.Parameters.Clear();
                        if(this.EnableRecordCount){
                            FormatSQL(sqlBuilder.CountSQL);
                            object  o = ExecuteScalar(sqlBuilder.CountSQL);
                            this.RecordCount = (o == null) ? -1 : long.Parse(o.ToString());
                        }
                        return dt;
                    }
                    catch (Exception ex)
                    {
                        
                        if (EnableErrorTrace)
                        {
                            LogMessage("Select",
                                sqlBuilder.PagingSQL, ex.Source, ex.Message,
                                "SQL2:" + sqlBuilder.CountSQL
                                );
                        }
                        if (EnableDebug)
                        {
                            cmd.Parameters.Clear();
                            cmd.Dispose();
                            connection.Close();
                            connection.Dispose();
                            AfterExecute();
                            throw ex;
                        }
                        
                    }
                    finally
                    {
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                        connection.Close();
                        connection.Dispose();
                        AfterExecute();
                    }
                    return dt;
                }
            }
        }

        #endregion






        public override int ExecuteSql(string sqlFormat, params object[] args)
        {

            string sql = args == null ? sqlFormat : string.Format(sqlFormat, args);

            BeforeExecute();

            FormatSQL(sql);

            if (EnableAlwaysTrace)
            {
                AlwaysLog("ExecuteSql", sql, string.Empty);
            }

            using (SqlConnection connection = CreateConnection() as SqlConnection)
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    try
                    {
                        if (this.Parameters.Count > 0)
                        {
                            cmd.Parameters.AddRange(this.Parameters.ToArray());
                        }
                        connection.Open();
                        return cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        if (EnableErrorTrace)
                        {
                            LogMessage("ExecuteSql",sql, ex.Source, ex.Message,"");
                        }
                        
                        if (EnableDebug)
                        {
                            cmd.Parameters.Clear();
                            cmd.Dispose();
                            connection.Close();
                            connection.Dispose();
                            AfterExecute();
                            throw ex;
                        }
                    }
                    finally
                    {
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                        connection.Close();
                        connection.Dispose();
                        AfterExecute();                        
                    }
                    return -1;
                }
            }
        }

        public override object ExecuteScalar(string sqlFormat, params object[] args)
        {
            string sql = args == null ? sqlFormat : string.Format(sqlFormat, args);

            BeforeExecute();

            FormatSQL(sql);

            if (EnableAlwaysTrace)
            {
                AlwaysLog("ExecuteScalar", sql, string.Empty);
            }

            using (SqlConnection connection = CreateConnection() as SqlConnection)
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    try
                    {
                        if (this.Parameters.Count > 0)
                        {
                            cmd.Parameters.AddRange(this.Parameters.ToArray());
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
                    catch (Exception ex)
                    {
                        if (EnableErrorTrace)
                        {
                            LogMessage("ExecuteScalar", sql, ex.Source, ex.Message, "");
                        }

                        if (EnableDebug)
                        {
                            cmd.Parameters.Clear();
                            cmd.Dispose();
                            connection.Close();
                            connection.Dispose();
                            AfterExecute();
                            throw ex;
                        }
                    }
                    finally
                    {
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                        connection.Close();
                        connection.Dispose();
                        AfterExecute();
                    }
                    return null;
                }
            }
        }



        public override bool Exist(string sqlFormat, params object[] args)
        {
            string sql = args == null ? sqlFormat : string.Format(sqlFormat, args);

            BeforeExecute();

            FormatSQL(sql);

            if (EnableAlwaysTrace)
            {
                AlwaysLog("Exist", sql, string.Empty);
            }

            using (SqlConnection connection = CreateConnection() as SqlConnection)
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    try
                    {
                        if (this.Parameters.Count > 0)
                        {
                            cmd.Parameters.AddRange(this.Parameters.ToArray());
                        }
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        bool ret = reader.Read();
                        reader.Close();
                        reader.Dispose();
                        return ret;

                    }
                    catch (Exception e)
                    {
                        if (EnableErrorTrace)
                        {
                            LogMessage("Exist", sql, e.Source, e.Message, "");
                        }

                        if (EnableDebug)
                        {
                            cmd.Parameters.Clear();
                            cmd.Dispose();
                            connection.Close();
                            connection.Dispose();
                            AfterExecute();
                            throw e;
                        }
                        return false;
                    }
                    finally
                    {
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                        connection.Close();
                        connection.Dispose();
                        AfterExecute();
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
        public override DataTable RunProcDataTable(string procducre)
        {
            BeforeExecute();

            if (EnableAlwaysTrace)
            {
                AlwaysLog("RunProcDataTable", procducre, string.Empty);
            }

            using (SqlConnection connection = CreateConnection() as SqlConnection)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    DataTable dt = new DataTable();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procducre;
                    try
                    {
                        if (this.Parameters.Count > 0)
                        {
                            cmd.Parameters.AddRange(this.Parameters.ToArray());
                        }
                        SqlDataAdapter ad = new SqlDataAdapter(cmd);
                        ad.Fill(dt);
                        return dt;
                    }
                    catch (Exception ex)
                    {

                        if (EnableErrorTrace)
                        {
                            LogMessage("RunProcDataTable", procducre, ex.Source, ex.Message, "");
                        }

                        if (EnableDebug)
                        {
                            cmd.Parameters.Clear();
                            cmd.Dispose();
                            connection.Close();
                            connection.Dispose();
                            AfterExecute();
                            throw ex;
                        }
                        return dt;
                    }
                    finally
                    {
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                        connection.Close();
                        connection.Dispose();
                        AfterExecute();
                    }

                   
                }
            }
        }

        public override DataSet RunProcDataSet(string procducre)
        {
            BeforeExecute();

            if (EnableAlwaysTrace)
            {
                AlwaysLog("RunProcDataSet", procducre, string.Empty);
            }

            using (SqlConnection connection = CreateConnection() as SqlConnection)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    DataSet ds = new DataSet();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procducre;
                    try
                    {
                        if (this.Parameters.Count > 0)
                        {
                            cmd.Parameters.AddRange(this.Parameters.ToArray());
                        }
                        
                        SqlDataAdapter ad = new SqlDataAdapter(cmd);
                        ad.Fill(ds);
                    }
                    catch (Exception ex)
                    {
                        if (EnableErrorTrace)
                        {
                            LogMessage("RunProcDataSet", procducre, ex.Source, ex.Message, "");
                        }

                        if (EnableDebug)
                        {
                            cmd.Parameters.Clear();
                            cmd.Dispose();
                            connection.Close();
                            connection.Dispose();
                            AfterExecute();
                            throw ex;
                        }
                        return ds;
                    }
                    finally
                    {
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                        connection.Close();
                        connection.Dispose();
                        AfterExecute();
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
        public override object RunProc(string procducre)
        {
            BeforeExecute();

            if (EnableAlwaysTrace)
            {
                AlwaysLog("RunProc", procducre, string.Empty);
            }

            using (SqlConnection connection = CreateConnection() as SqlConnection)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procducre;
                    try
                    {
                        if (this.Parameters.Count > 0)
                        {
                            cmd.Parameters.AddRange(this.Parameters.ToArray());
                        }
                        SqlParameter returnValue = new SqlParameter("@ReturnValue", SqlDbType.Int);
                        returnValue.Direction = ParameterDirection.ReturnValue;
                        cmd.Parameters.Add(returnValue);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        return returnValue.Value;
                    }
                    catch (Exception ex)
                    {
                        if (EnableErrorTrace)
                        {
                            LogMessage("RunProc", procducre, ex.Source, ex.Message, "");
                        }

                        if (EnableDebug)
                        {
                            cmd.Parameters.Clear();
                            cmd.Dispose();
                            connection.Close();
                            connection.Dispose();
                            AfterExecute();
                            throw ex;
                        }
                        return null;
                    }
                    finally
                    {
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                        connection.Close();
                        connection.Dispose();
                        AfterExecute();
                    }
                }
            }
        }
       

       
        

        #endregion



        private MssqlParameters parameterCollection = null;
        public override CommandParameters Parameters
        {
            get {
                if (parameterCollection == null)
                {
                    parameterCollection = new MssqlParameters();
                }
                return parameterCollection;
            }
        }

        public override CommandParameters CreateCommandParameters()
        {
            return new MssqlParameters();
        }


        
    }
}

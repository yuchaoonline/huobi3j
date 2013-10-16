using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ADeeWu.HuoBi3J.SQL.Logger;
using ADeeWu.HuoBi3J.SQL.ParameterCollection;
using System.Text.RegularExpressions;

namespace ADeeWu.HuoBi3J.SQL
{

    public enum DataBaseType
    {
        MsSQL =0,
        MySQL = 1,
        OleDB = 2,
        Odbc = 3
    }
    
    /// <summary>
    /// 数据库抽象,每次执行数据库操作可使用Parameters添加参数,在执行完数据库操作后,将自动调用Parameters.Clear()方法清除
    /// </summary>
    public abstract class DataBase:IDisposable
    {

        #region 日志记录状态
        public enum LogMode
        {
            Web = 0,
            Window = 1
        }
        #endregion

        /// <summary>
        /// 表示执行数据库操作命令的参数集合,每次调用数据库操作前请调用该属性Clear()后再重新添加新的项
        /// </summary>
        public abstract CommandParameters Parameters { get;  }
        
       
        /// <summary>
        /// 分页查询数据(pageSize或pageIndex小于0时查询所有)
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">当前页码从1开始</param>
        /// <param name="sourceName">数据源名称,视图或表</param>
        /// <param name="identity">标识字段或无重复字段</param>
        /// <returns></returns>
        public abstract DataTable Select(long pageSize, long pageIndex, string sourceName, string identity);
        /// <summary>
        /// 分页查询数据(pageSize或pageIndex小于0时查询所有)
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">当前页码从1开始</param>
        /// <param name="sourceName">数据源名称,视图或表</param>
        /// <param name="identity">标识字段或无重复字段</param>
        /// <param name="orderBy">排序,<code>fieldName desc</code></param>
        /// <param name="where">可带变量条件语句,例:<code>name like @name</code>使用Parameters属性设置对应变量的值</param>
        /// <returns></returns>
        public abstract DataTable Select(long pageSize, long pageIndex, string sourceName, string identity, string where, string orderBy);

        /// <summary>
        /// 数据查询(该方法不支持RecordCount属性,应该使用返回结果DataTable.Rows.Count来获取总行数)
        /// </summary>
        /// <param name="sourceName">数据源名称,视图或表</param>
        /// <param name="where">可带变量条件语句,例:<code>name like @name</code>使用Parameters属性设置对应变量的值</param>
        /// <param name="orderBy">排序,<code>fieldName desc</code></param>
        /// <returns></returns>
        public virtual DataTable Select(string sourceName, string where, string orderBy)
        {
             

            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.AppendFormat("select * from {0}", sourceName);
            if (!string.IsNullOrEmpty(where))
            {
                sqlBuilder.AppendFormat(" where {0}", where);
            }
            if (!string.IsNullOrEmpty(orderBy))
            {
                sqlBuilder.AppendFormat(" order by {0}", orderBy);
            }
            string sql = sqlBuilder.ToString();

            if (EnableAlwaysTrace)
            {
                AlwaysLog("Select", sql, string.Empty);
            }

            FormatSQL(sql);

            using (IDbConnection connection = CreateConnection())
            {
                using (IDbCommand cmd = CreateDbCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    DataSet ds = new DataSet();
                    try
                    {
                        //IDbDataParameter[] scalarParams = null;//用于执行聚合函数的参数
                        if (where.Trim() != "" && this.UseParameters && this.Parameters.Count > 0)
                        {
                            //scalarParams = this.Parameters.ToArray();
                            for (int i = 0; i < this.Parameters.Count; i++)
                            {
                                cmd.Parameters.Add(this.Parameters[i]);
                            }
                        }
                        IDbDataAdapter ad = CreateDataAdpater();
                        ad.SelectCommand = cmd;
                        ad.Fill(ds);

                        cmd.Parameters.Clear();
                        //if (this.EnableRecordCount && this.UseParameters && scalarParams != null && scalarParams.Length > 0)
                        //{
                        //    string countSql = string.Format("select count(*) from {0}", sourceName);
                        //    if (!string.IsNullOrEmpty(where))
                        //    {
                        //        countSql += " where " + where;
                        //    }
                        //    if (this.EnableAlwaysTrace)
                        //    {
                        //        AlwaysLog("Select", countSql, string.Empty);
                        //    }
                        //    object obj = this.ExecuteScalar(countSql);
                        //    this.RecordCount = (obj == null) ? -1 : long.Parse(obj.ToString());
                        //}
                        
                        return ds.Tables[0];
                    }
                    catch (Exception ex)
                    {
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                        connection.Close();
                        connection.Dispose();
                        AfterExecute();
                        if (EnableErrorTrace)
                        {
                            LogMessage("Select",
                                sql, ex.Source, ex.Message,""
                                );
                        }
                        if (EnableDebug)
                        {
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
                    return new DataTable();
                }
            }
        }

        /// <summary>
        /// 执行查询语句(调用string.Format进行格式化SQL) 该方法不支持RecordCount属性,应该使用返回结果DataTable.Rows.Count来获取总行数
        /// </summary>
        /// <param name="sqlFomat">SQL格式</param>
        /// <param name="args">参数</param>
        /// <returns></returns>
        public virtual DataTable Select(string sqlFomat, params object[] args)
        {
            string sql = string.Format(sqlFomat, args);
            return Select(sql);
        }

        /// <summary>
        /// 执行查询语句(该方法不支持RecordCount属性,应该使用返回结果DataTable.Rows.Count来获取总行数)
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns></returns>
        public virtual DataTable Select(string sql)
        {
            if (this.EnableAlwaysTrace)
            {
                AlwaysLog("Select", sql, string.Empty);
            }
            
            using (IDbConnection connection = CreateConnection())
            {
                using (IDbCommand cmd = CreateDbCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    DataSet ds = new DataSet();
                    try
                    {
                        if (this.UseParameters)
                        {
                            for (int i = 0; i < this.Parameters.Count; i++)
                            {
                                cmd.Parameters.Add(this.Parameters[i]);
                            }
                        }
                          
                        IDbDataAdapter ad = CreateDataAdpater();
                        ad.SelectCommand = cmd;
                        FormatSQL(sql);
                        ad.Fill(ds);

                        cmd.Parameters.Clear();
                        //分离数据集
                        DataTable dt = ds.Tables[0];
                        ds.Tables.Remove(dt);
                        return dt;
                    }
                    catch (Exception ex)
                    {
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                        connection.Close();
                        connection.Dispose();
                        AfterExecute();
                        if (EnableErrorTrace)
                        {
                            LogMessage("Select",
                                sql, ex.Source, ex.Message, ""
                                );
                        }
                        if (EnableDebug)
                        {
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
                    return new DataTable();
                }
            }


            //AfterExecute();
        }

        /// <summary>
        /// 查询数据集
        /// </summary>
        /// <param name="sql">查询语句,可带变量条件语句,例:<code>name like @name</code>使用Parameters属性设置对应变量的值</param>
        /// <returns></returns>
        public abstract DataSet GetDataSet(string sql);

        /// <summary>
        /// 调用存储过程 查询一个数据源(使用Parameters属性设置存储过程参数)
        /// </summary>
        /// <param name="procducre">存储过程名称</param>
        /// <returns></returns>
        public abstract DataTable RunProcDataTable(string procducre);
        /// <summary>
        /// 调用存储过程,查询一个数据集(使用Parameters属性设置存储过程参数)
        /// </summary>
        /// <param name="procducre">存储过程名称</param>
        /// <returns></returns>
        public abstract DataSet RunProcDataSet(string procducre);


        /// <summary>
        /// 执行存储过程(使用Parameters属性设置存储过程参数) 成功 -- 返回存储过程返回的值,失败 -- 返回NULL
        /// </summary>
        /// <param name="procducre">存储过程名称</param>
        /// <returns>返回存储过程返回值,该值有可能为空</returns>
        public abstract object RunProc(string procducre);


        /// <summary>
        /// 执行SQL,返回:成功 -- 影响行数 , 失败 -- -1
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public virtual int ExecuteSql(string sql)
        {
            return ExecuteSql(sql, null);
        }

        /// <summary>
        /// 执行SQL,返回:成功 -- 影响行数 , 失败 -- -1
        /// </summary>
        /// <param name="sqlFormat">格式化字符串</param>
        /// <param name="args">格式化变量</param>
        /// <returns></returns>
        public abstract int ExecuteSql(string sqlFormat,params object[] args);


        /// <summary>
        /// 执行聚合SQL,返回:成功 -- Object , 失败 -- Null
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public virtual object ExecuteScalar(string sql)
        {
            return this.ExecuteScalar(sql, null);
        }

        /// <summary>
        /// 执行聚合SQL,返回:成功 -- Object , 失败 -- Null
        /// </summary>
        /// <param name="sqlFormat">格式化字符串</param>
        /// <param name="args">格式化变量</param>
        /// <returns></returns>
        public abstract object ExecuteScalar(string sqlFormat, params object[] args);

        /// <summary>
        /// 查询是否存在记录,返回:成功 -- true , 失败 -- false
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public virtual bool Exist(string sql)
        {
            return this.Exist(sql, null);
        }

        /// <summary>
        /// 查询是否存在记录,返回:成功 -- true , 失败 -- false
        /// </summary>
        /// <param name="sqlFormat">格式化字符串</param>
        /// <param name="args">格式化变量</param>
        /// <returns></returns>
        public abstract bool Exist(string sqlFormat,params object[] args);


        /// <summary>
        /// 执行数据库操作前事件触发
        /// </summary>
        protected virtual void FormatSQL(string sql)
        {
            //Regex reg = new Regex(@"\{(.*)\}", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            //MatchCollection matchs = reg.Matches(sql);
            //if (matchs != null)
            //{
            //    foreach (Match match in matchs)
            //    {
                    
            //    }
            //}
        }

        /// <summary>
        /// 执行数据库操作前事件触发
        /// </summary>
        protected virtual void BeforeExecute()
        {
            this.RecordCount = 0;
        }

        /// <summary>
        /// 执行数据库操作后事件触发
        /// </summary>
        protected virtual void AfterExecute()
        {
            if (this.AutoClearParameters)
            {
                this.Parameters.Clear();
            }
            this.EnableRecordCount = false;
        }


        /// <summary>
        /// 创建数据库连接对象,通常用于动态多事务
        /// </summary>
        /// <returns></returns>
        public abstract IDbConnection CreateConnection();

        /// <summary>
        /// 创建Command对象
        /// </summary>
        /// <returns></returns>
        public abstract IDbCommand CreateDbCommand();

        /// <summary>
        /// 创建Parameter对象
        /// </summary>
        /// <returns></returns>
        public abstract IDbDataParameter CreateParameter();

        /// <summary>
        /// 创建DataAdpate
        /// </summary>
        /// <returns></returns>
        public abstract IDbDataAdapter CreateDataAdpater();


        public abstract CommandParameters CreateCommandParameters();
        
        

        /*
        /// <summary>
        /// 创建DataAdpater
        /// </summary>
        /// <returns></returns>
        public abstract IDbDataAdapter CreateDataAdpater(IDbCommand cmd);

        /// <summary>
        /// 创建准备填充数据的DataAdpater,在使用后必须
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="cmdType">查询类型</param>
        /// <remarks>根据当前上下文如连接的数据库创建IDataAdpater</remarks>
        /// <returns></returns>
        public abstract IDbDataAdapter CreateDataAdpater(string sql,CommandType cmdType);
         * */


        //public DataBaseTrans BeginTrans()
        //{
        //    IDbConnection connection = this.CreateConnection();
        //    connection.Open();
        //    IDbTransaction trans = connection.BeginTransaction();
        //    return new DataBaseTrans(trans, this.CreateCommandParameters());
        //}




        #region 基类实现属性

        private string _connectionString = string.Empty;
        private bool _enableDebug = false;
        private bool _enableAlwaysTrace = false;//总是追踪
        private bool _enableRecordCount = false;
        private bool _autoClearParameters = true;//默认每次执行数据库操作后自动清除命令参数
        private LogMode _currentLogMode = LogMode.Web;
        private ILog _logger = null;
        private long _recordCount = 0;
        private bool _hasError = false;//每次执行操作后是否出现错误
        private bool _useParameters = true;//每次执行操作是否使用命令参数

        /// <summary>
        /// 获取上一次数据库操作是否出现错误
        /// </summary>
        public bool HasError
        {
            internal set { this._hasError = value; }
            get { return this._hasError; }
        }
        
        /// <summary>
        /// 设置或获取是否启动调试模式,可通过AppSetting 节点下名为ADeeWu.HuoBi3J.SQL.DataBase.Debug元素配置
        /// </summary>
        public bool EnableDebug
        {
            get { return _enableDebug; }
            set { _enableDebug = value; }
        }


        private bool _errorTrace = false;
        /// <summary>
        /// 设置或获取是否启动调用跟踪,可通过AppSetting 节点下名为ADeeWu.HuoBi3J.SQL.DataBase.ErrorTrace元素配置
        /// </summary>
        public bool EnableErrorTrace
        {
            get { return _errorTrace; }
            set { _errorTrace = value; }
        }

        /// <summary>
        /// 设置或获取是否总是追踪,可通过AppSetting 节点下名为ADeeWu.HuoBi3J.SQL.DataBase.AlwaysTrace元素配置
        /// </summary>
        public bool EnableAlwaysTrace
        {
            set { _enableAlwaysTrace = value; }
            get { return _enableAlwaysTrace; }
        }

        /// <summary>
        /// 用于设置调用Select 函数后,是否返回总记录行数,在执行Select 后将自动设置为False
        /// </summary>
        public bool EnableRecordCount
        {
            get { return _enableRecordCount; }
            set { _enableRecordCount = value; }
        }

        /// <summary>
        /// 设置或获取是否再每次执行操作数据库后自动清除命令参数,(默认自动清除)
        /// </summary>
        public bool AutoClearParameters
        {
            get { return _autoClearParameters; }
            set { _autoClearParameters = value; }
        }

        /// <summary>
        /// 设置或获取下一次操作是否使用命令参数(默认为True)
        /// </summary>
        public bool UseParameters
        {
            get { return _useParameters; }
            set { _useParameters = value; }
        }
        
        /// <summary>
        /// 当前日志记录模式
        /// </summary>
        public LogMode CurrentLogMode
        {
            get { return _currentLogMode; }
            set { _currentLogMode = value; }
        }

        /// <summary>
        /// 表示用于记录数据库操作的日志器
        /// </summary>
        public ILog Logger
        {
            get
            {
                if (_logger == null)
                {
                    initLogger();
                }
                return _logger;
            }
            internal set
            {
                _logger = value;
            }
        }

       
        /// <summary>
        /// 表示调用Select 函数进行分页后,返回的总记录行数
        /// </summary>
        public long RecordCount {
            get { return _recordCount; } 
            internal set{ _recordCount=value; } 
        }

       
        

        protected string ConnectionString
        {
            get
            {
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }

        #endregion


        #region 构造函数
        public DataBase()
            : this(System.Configuration.ConfigurationManager.AppSettings["ADeeWu.HuoBi3J.SQL.DataBase.ConnectionString"])
        {

        }
        
        public DataBase(string connectionString)
        {
            string strDebug = System.Configuration.ConfigurationManager.AppSettings["ADeeWu.HuoBi3J.SQL.DataBase.Debug"];
            if (!string.IsNullOrEmpty(strDebug))
            {
                if (string.Compare(strDebug, "true", true) == 0)
                {
                    _enableDebug = true;
                }
            }

            string strErrorTrace = System.Configuration.ConfigurationManager.AppSettings["ADeeWu.HuoBi3J.SQL.DataBase.ErrorTrace"];
            if (!string.IsNullOrEmpty(strErrorTrace))
            {
                if (string.Compare(strErrorTrace, "true", true) == 0)
                {
                    _errorTrace = true;
                }
            }

            string strAlwaysTrace = System.Configuration.ConfigurationManager.AppSettings["ADeeWu.HuoBi3J.SQL.DataBase.AlwaysTrace"];
            if (!string.IsNullOrEmpty(strErrorTrace))
            {
                if (string.Compare(strAlwaysTrace, "true", true) == 0)
                {
                    _enableAlwaysTrace = true;
                }
            }

            

            _connectionString = connectionString;
        }


        private void initLogger()
        {
            string strLogMode = System.Configuration.ConfigurationManager.AppSettings["ADeeWu.HuoBi3J.SQL.DataBase.LogMode"];
            if (!string.IsNullOrEmpty(strLogMode))
            {
                if (string.Compare(strLogMode, "web", true) == 0)
                {
                    _currentLogMode = LogMode.Web;
                }
                else
                {
                    _currentLogMode = LogMode.Window;
                }

            }
            else
            {
                _currentLogMode = LogMode.Web;
            }



            string logPath = System.Configuration.ConfigurationManager.AppSettings["ADeeWu.HuoBi3J.SQL.DataBase.LogPath"];
            if (!string.IsNullOrEmpty(logPath))
            {
                if (!logPath.EndsWith("\\") || !logPath.EndsWith("/"))
                {
                    logPath += "\\";
                }

                if (CurrentLogMode == LogMode.Web)
                {
                    if (System.Web.HttpContext.Current == null)
                    {
                        throw new Exception("在创建DataBase时出错,当前日志模式为web,却不在web环境,应该改成windows");
                    }
                    else
                    {
                        logPath = System.Web.HttpContext.Current.Server.MapPath(logPath);
                    }
                }

                logPath += string.Format("{0}.log", DateTime.Now.ToString("yyyy-MM-dd"));
                _logger = new TextLogger(logPath);
            }
            else
            {
                _logger = new TextLogger();
            }
        }



        #endregion

        

        protected void LogMessage(string methodName, string sql, string source, string message, string otherMsg)
        {
            this.HasError = true;
            List<string> msgList = new List<string>();
            msgList.Add("******************** 错误捕捉 ********************");
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null)
            {
                msgList.Add("URL:" + System.Web.HttpContext.Current.Request.Url.ToString());
            }
            msgList.Add(string.Format("{0} 调用方法 {1}", DateTime.Now.ToLongTimeString(), methodName));
            msgList.Add(string.Format("SQL:      {0}", sql));
            msgList.Add(string.Format("错误源:   {0}", source));
            msgList.Add(string.Format("错误信息: {0}", message));
            msgList.Add(string.Format("其它信息: {0}", otherMsg));
            msgList.Add("");

            Logger.Log(msgList.ToArray());
        }

        protected void AlwaysLog(string methodName, string sql, string otherMsg)
        {

            StringBuilder builder = new StringBuilder();
            builder.Append("\r\nAlwaysLog:\r\n");
            try
            {
                if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null)
                {
                    builder.AppendFormat("URL:{0}\r\n", System.Web.HttpContext.Current.Request.Url.ToString());
                }
            }
            catch
            {
                builder.Append("Excute in Application_Start\r\n");
            }
            builder.AppendFormat("{0} 调用方法 {1}", DateTime.Now.ToLongTimeString(), methodName);
            builder.AppendFormat("SQL:      {0}\r\n", sql);
            builder.AppendFormat("Paramters:\r\n");
            if (this.Parameters.Count > 0)
            {
                for (int i = 0; i < this.Parameters.Count; i++)
                {
                    IDataParameter parameter = this.Parameters[i];
                    builder.AppendFormat("{0} = {1}\r\n", parameter.ParameterName, parameter.Value);
                }
               
            }
            builder.AppendFormat("其它信息: {0}", otherMsg);
            builder.AppendFormat("\r\n");

            Logger.Log(builder.ToString());
        }

        /// <summary>
        /// 设置连接字符串
        /// </summary>
        /// <param name="connStr"></param>
        public void SetConnectionString(string connStr)
        {
            _connectionString = connStr;
        }
        
        /// <summary>
        /// 重设连接字符串,可通过AppSetting 节点下名为ADeeWu.HuoBi3J.SQL.DataBase.ConnectionString元素配置
        /// </summary>
        public void ResetConnectionString()
        {
            _connectionString = System.Configuration.ConfigurationManager.AppSettings["ADeeWu.HuoBi3J.SQL.DataBase.ConnectionString"];
        }


        /// <summary>
        /// 根据上下文配置创建默认的DataBase
        /// </summary>
        /// <returns></returns>
        public static DataBase Create()
        {
            return Create(System.Configuration.ConfigurationManager.AppSettings["ADeeWu.HuoBi3J.SQL.DataBase.ConnectionString"]);
        }

        /// <summary>
        /// 根据上下文配置创建默认的DataBase
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DataBase Create(string connectionString)
        {
            
            DBProvider.IDBProvider provider = GetProvider("default");
            if (provider == null)
            {
                string dbProvider = System.Configuration.ConfigurationManager.AppSettings["ADeeWu.HuoBi3J.SQL.DataBase.DBProvider"];
                Type type = Type.GetType(dbProvider);
                provider = (DBProvider.IDBProvider)Activator.CreateInstance(type);
                RegisterProvider("default", provider);
            }

            DataBase db = provider.Create(connectionString);
            return db;
        }
        
        /// <summary>
        /// 根据已有的数据库类型创建DataBase
        /// </summary>
        /// <param name="dbType"></param>
        /// <returns></returns>
        public static DataBase Create(DataBaseType dbType)
        {
            ADeeWu.HuoBi3J.SQL.DBProvider.IDBProvider provider = null;
            switch (dbType)
            {
                case DataBaseType.MsSQL:
                    provider= new ADeeWu.HuoBi3J.SQL.DBProvider.MsSqlProvider();
                    break;
                case DataBaseType.MySQL:
                    provider = new  ADeeWu.HuoBi3J.SQL.DBProvider.MySqlProvider();
                    break;
                case DataBaseType.Odbc:
                    provider = new ADeeWu.HuoBi3J.SQL.DBProvider.OdbcProvider();
                    break;
                case DataBaseType.OleDB:
                    provider =new  ADeeWu.HuoBi3J.SQL.DBProvider.OledbProvider();
                    break;
                default:
                    throw new Exception("错误的数据库类型");
            }
            return provider.Create(System.Configuration.ConfigurationManager.AppSettings["ADeeWu.HuoBi3J.SQL.DataBase.ConnectionString"]);
        }

        /// <summary>
        /// 根据已有的数据库类型创建DataBase
        /// </summary>
        /// <param name="dbType"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DataBase Create(DataBaseType dbType, string connectionString)
        {
            DataBase db = Create(dbType);
            db.SetConnectionString(connectionString);
            return db;
        }

        ///// <summary>
        ///// 根据指定
        ///// </summary>
        ///// <typeparam name="DBDriver"></typeparam>
        ///// <param name="connectionString"></param>
        ///// <returns></returns>
        //public static DataBase Create<DBDriver>(string connectionString) where DBDriver : DataBase
        //{
        //    DataBase db = Load(typeof(DBDriver), null) as DataBase;
        //    db.SetConnectionString(connectionString);
        //    return db;
        //}

        /// <summary>
        /// 根据已注册的IDBProvider,创建DataBase
        /// </summary>
        /// <param name="name"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DataBase Create(string name,string connectionString)
        {
            DBProvider.IDBProvider provider = GetProvider(name);
            if (provider == null) return null;
            return provider.Create(connectionString);
        }

        private static object Load(Type type, params object[] initParams)
        {
            try
            {
                return Activator.CreateInstance(type, initParams);
            }
            catch
            {
                return null;
            }
        }


        private static object syncProviderList = new object();
        private static Dictionary<string, DBProvider.IDBProvider> providerList = null;
        /// <summary>
        /// 注册新的数据库提供器(动态注射数据库提供器)到缓存中
        /// </summary>
        /// <param name="provider"></param>
        public static void RegisterProvider(string name,DBProvider.IDBProvider provider)
        {
            if (providerList == null)
            {
                providerList = new Dictionary<string, ADeeWu.HuoBi3J.SQL.DBProvider.IDBProvider>();
            }
            lock (syncProviderList)
            {
                if (providerList.ContainsKey(name))
                {
                    providerList.Remove(name);
                }
                providerList.Add(name, provider);
            }
           
        }

        private static DBProvider.IDBProvider GetProvider(string name)
        {
            if (providerList == null) return null;
            if (providerList.ContainsKey(name))
            {
                return providerList[name] as DBProvider.IDBProvider;
            }
            return null;
        }

        //private static DataBase context;
        //public static DataBase Context {
        //    get {
        //        if (context == null)
        //        {
        //            context = Create();
        //        }
        //        return context;
        //    }
        //}

        

        public virtual void Dispose()
        {
            if (this.Logger != null)
            {
                this.Logger.Dispose();
            }

            if (this.Parameters != null)
            {
                this.Parameters.Dispose();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;

namespace ADeeWu.HuoBi3J.SQL.ParameterCollection
{

    /// <summary>
    /// 命令参数集合,提供静态创建IDataPatameter方法
    /// </summary>
    public abstract class CommandParameters: NameObjectCollectionBase,IDisposable
    {

        #region 公共参数

        public static readonly string DataParamterTypeName = System.Configuration.ConfigurationManager.AppSettings["ADeeWu.HuoBi3J.SQL.ParameterCollection.CommandParameters.DataParameterType"];
        public static IDataParameter BuildParameter(string paramName, object value)
        {
            return BuildParameter(paramName, value, ParameterDirection.Input);
        }

        public static IDataParameter BuildParameter(string parameterName, object value, ParameterDirection direction)
        {
            try
            {
                Type type = Type.GetType(DataParamterTypeName);
                IDataParameter parameter = Activator.CreateInstance(type) as IDataParameter;
                //SqlParameter parameter = new SqlParameter();                
                parameter.ParameterName = parameterName;
                parameter.Value = value;
                parameter.Direction = direction;
                return parameter;
            }
            catch (Exception e)
            {
                throw new Exception("IDataParameter 创建失败", e);
            }
        }

        public static IDataParameter BuildParameter(string parameterName, object value, ParameterDirection direction, DbType dataType)
        {

            try
            {
                Type type = Type.GetType(DataParamterTypeName);
                IDataParameter parameter = Activator.CreateInstance(type) as IDataParameter;
                //SqlParameter parameter = new SqlParameter();                
                parameter.ParameterName = parameterName;
                parameter.Value = value;
                parameter.Direction = direction;
                parameter.DbType = dataType;
                return parameter;
            }
            catch (Exception e)
            {
                throw new Exception("IDataParameter 创建失败", e);
            }

        }
        #endregion


        #region 实例成员

        public CommandParameters()
        {
        }

        #region 抽象成员

        public abstract IDbDataParameter CreateParameter(string parameterName, object value);
        public abstract IDbDataParameter CreateParameter(string parameterName, object value, ParameterDirection direction);
        public abstract IDbDataParameter CreateParameter(string parameterName, object value, ParameterDirection direction, DbType dataType);
        
        #endregion

        public IDbDataParameter this[int index]
        {
            get { return base.BaseGet(index) as IDbDataParameter; }
            set { BaseSet(index, value); }
        }

        public IDbDataParameter this[string parameterName]
        {
            get { return base.BaseGet(parameterName) as IDbDataParameter; }
            set { base.BaseSet(parameterName, value); }
        }

        public IDbDataParameter Append(string parameterName, object value)
        {
            IDbDataParameter parameter = CreateParameter(parameterName, value);
            base.BaseAdd(parameterName, parameter);
            return parameter;
        }

        public IDbDataParameter Append(string parameterName, object value, ParameterDirection direction)
        {
            IDbDataParameter parameter = CreateParameter(parameterName, value, direction);
            base.BaseAdd(parameterName, parameter);
            return parameter;
        }

        public IDbDataParameter Append(string parameterName, object value, ParameterDirection direction, DbType dataType)
        {
            IDbDataParameter parameter = CreateParameter(parameterName, value, direction, dataType);
            base.BaseAdd(parameterName, parameter);
            return parameter;
        }
        

        public void Remove(string parameterName)
        {
            base.BaseRemove(parameterName);
        }

        public void Remove(int index)
        {
            base.BaseRemoveAt(index);
        }

        public void Clear()
        {
            base.BaseClear();
        }


        public IDbDataParameter[] ToArray()
        {
            object[] values = base.BaseGetAllValues();
            List<IDbDataParameter> ret = new List<IDbDataParameter>();
            for (int i = 0; i < values.Length; i++)
            {
                ret.Add((IDbDataParameter)values[i]);
            }
            return ret.ToArray();
        }

        #endregion



       

        public virtual void Dispose()
        {
            for (int i = 0; i < this.Count;i++ )
            {
                this[i] = null;
            }
            this.Clear();
        }

    }
}

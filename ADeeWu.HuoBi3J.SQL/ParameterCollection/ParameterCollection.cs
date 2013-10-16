using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;

namespace SQLUtility
{

    /// <summary>
    /// 命令参数集合,提供静态创建IDataPatameter方法
    /// </summary>
   public class ParameterCollection : NameObjectCollectionBase
    {

        #region
        public static readonly string DataParamterTypeName = System.Configuration.ConfigurationManager.AppSettings["SQLUtility.ParameterCollection.DataParameterType"];
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


        public IDataParameter this[int index]
        {
            get { return base.BaseGet(index) as IDataParameter; }
            set { BaseSet(index, value); }
        }

        public IDataParameter this[string parameterName]
        {
            get { return base.BaseGet(parameterName) as IDataParameter; }
            set { base.BaseSet(parameterName, value); }
        }

        public IDataParameter Append(string parameterName, object value, ParameterDirection direction)
        {
            IDataParameter parameter = ParameterCollection.BuildParameter(parameterName, value,direction);
            base.BaseAdd(parameterName, parameter);
            return parameter;
        }

        public IDataParameter Append(string parameterName, object value)
        {
           IDataParameter parameter = ParameterCollection.BuildParameter(parameterName, value);
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


        public IDataParameter[] ToArray()
        {
            object[] values = base.BaseGetAllValues();
            List<IDataParameter> ret = new List<IDataParameter>();
            for (int i = 0; i < values.Length; i++)
            {
                ret.Add((IDataParameter)values[i]);
            }
            return ret.ToArray();
        }
        

    }
}

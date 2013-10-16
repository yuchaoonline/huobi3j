using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;

namespace ADeeWu.HuoBi3J.SQL.ParameterCollection
{
    public class OdbcParameters : CommandParameters
    {

        public override System.Data.IDbDataParameter CreateParameter(string parameterName, object value)
        {
            return CreateParameter(parameterName, value, ParameterDirection.Input);
        }

        public override System.Data.IDbDataParameter CreateParameter(string parameterName, object value, System.Data.ParameterDirection direction)
        {
            try
            {
                OdbcParameter parameter = new OdbcParameter();
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

        public override System.Data.IDbDataParameter CreateParameter(string parameterName, object value, System.Data.ParameterDirection direction, System.Data.DbType dataType)
        {
            try
            {
                OdbcParameter parameter = new OdbcParameter();
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
    }
}

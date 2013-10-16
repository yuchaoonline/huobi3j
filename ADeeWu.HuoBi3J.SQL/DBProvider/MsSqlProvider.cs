using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ADeeWu.HuoBi3J.SQL.Logger;
using ADeeWu.HuoBi3J.SQL.SqlBuilder;
using ADeeWu.HuoBi3J.SQL.ParameterCollection;

namespace ADeeWu.HuoBi3J.SQL.DBProvider
{
    public class MsSqlProvider : IDBProvider
    {



        public MsSqlProvider()
        {

        }

        public DataBase Create(string connectionString)
        {
            DataBase db = new DBDriver.MsSqlDriver();
            db.SetConnectionString(connectionString);
            return db;
        }


        
    }
}

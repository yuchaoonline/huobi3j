using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using ADeeWu.HuoBi3J.SQL.SqlBuilder;
using System.Web;
using ADeeWu.HuoBi3J.SQL.ParameterCollection;


namespace ADeeWu.HuoBi3J.SQL.DBProvider
{
    public class OdbcProvider : IDBProvider
    {

       

        public OdbcProvider()
        {
           
        }

        public DataBase Create(string connectionString)
        {
            DataBase db = new DBDriver.OdbcDriver();
            db.SetConnectionString(connectionString);
            return db;
        }

       
    }
}
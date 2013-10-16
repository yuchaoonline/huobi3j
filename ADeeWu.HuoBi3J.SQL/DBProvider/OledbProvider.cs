using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ADeeWu.HuoBi3J.SQL.SqlBuilder;
using System.Web;
using System.Data.OleDb;
using ADeeWu.HuoBi3J.SQL.ParameterCollection;


namespace ADeeWu.HuoBi3J.SQL.DBProvider
{
    public class OledbProvider : IDBProvider
    {


        public OledbProvider()
        {
           
        }


        public DataBase Create(string connectionString)
        {
            DataBase db = new DBDriver.OledbDriver();
            db.SetConnectionString(connectionString);
            return db;
        }

     
    }
}
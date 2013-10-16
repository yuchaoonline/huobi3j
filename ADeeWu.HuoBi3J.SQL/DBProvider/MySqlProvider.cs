using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ADeeWu.HuoBi3J.SQL.Logger;
using ADeeWu.HuoBi3J.SQL.SqlBuilder;
using ADeeWu.HuoBi3J.SQL.ParameterCollection;
using MySql.Data.MySqlClient;

namespace ADeeWu.HuoBi3J.SQL.DBProvider
{
    public class MySqlProvider : IDBProvider
    {

        

        public MySqlProvider()
        {
            
        }

        public DataBase Create(string connectionString)
        {
            DataBase db = new DBDriver.MySqlDriver();
            db.SetConnectionString(connectionString);
            return db;
        }

     

   
        
    }
}

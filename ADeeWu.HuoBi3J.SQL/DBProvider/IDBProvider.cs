using System;
using System.Collections.Generic;
using System.Text;

namespace ADeeWu.HuoBi3J.SQL.DBProvider
{
    /// <summary>
    /// DataBase抽象工厂
    /// </summary>
    public interface IDBProvider
    {
        DataBase Create(string connectionString);
    }
}

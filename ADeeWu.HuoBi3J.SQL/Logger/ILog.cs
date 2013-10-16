using System;
using System.Collections.Generic;
using System.Text;

namespace ADeeWu.HuoBi3J.SQL.Logger
{
    public interface ILog : IDisposable
    {
        void Log(params string[] msg);
        void Log(string msg);
        void LogOverWrite(string msg);
        void LogStart();
        void LogEnd();
    }
}

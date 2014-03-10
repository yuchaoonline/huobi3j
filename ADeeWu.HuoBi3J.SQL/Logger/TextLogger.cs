using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ADeeWu.HuoBi3J.SQL.Logger
{
    public class TextLogger:ILog
    {
        #region ILog 成员

        private static object objLock = new object();

        private string _filePath = string.Empty;


        public TextLogger()
        {
            _filePath = System.Configuration.ConfigurationManager.AppSettings["SQLUtility.Logger.TextLogger.LogPath"];
             if ( string.IsNullOrEmpty(_filePath))
             {
                 _filePath = @"C:\";
             }
        }

        public TextLogger(string filePath)
        {
            _filePath = filePath;
        }
        
        public void Log(params string[] msg)
        {
            StreamWriter writer = null;
            if (!File.Exists(_filePath))
            {
                writer = File.CreateText(_filePath);
            }
            else
            {
                writer = File.AppendText(_filePath);
            }
            
            foreach (string s in msg)
            {
                writer.WriteLine(s);
            }
            
            writer.Flush();
            writer.Close();
            writer.Dispose();
        }

        public void Log(string msg)
        {
            lock (objLock)
            {
                Directory.CreateDirectory(new FileInfo(_filePath).DirectoryName);
                File.AppendAllText(_filePath, msg);
            }
        }

        public void LogOverWrite(string msg)
        {
           
            if (!File.Exists(_filePath))
            {
                StreamWriter writer = File.CreateText(_filePath);
                writer.Write(msg);
                writer.WriteLine();
                writer.Flush();
                writer.Close();
                writer.Dispose();
            }
            else
            {
                File.WriteAllText(_filePath, msg);
                return;               
            }
            
           
        }

        public void LogStart()
        {
            
        }

        public void LogEnd()
        {
            
        }

        

        #endregion

        

        public void Dispose()
        {
            
        }

        
    }
}

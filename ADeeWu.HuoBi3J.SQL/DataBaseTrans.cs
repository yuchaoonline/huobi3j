using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ADeeWu.HuoBi3J.SQL
{

    /// <summary>
    /// 事务命令构造器
    /// </summary>
    public class DataBaseTrans : IDisposable
    {
        public delegate void TransErrorHandler(IDbCommand command);

        private ParameterCollection.CommandParameters parameters = null;
        private IDbTransaction currentTrans = null;
       
        public ParameterCollection.CommandParameters Parameters
        {
            get {
                return this.parameters;
            }
        }

        public IDbTransaction CurrentTrans
        {
            get { return this.currentTrans; }
        }
        
        

        /// <summary>
        /// 构造函数,应该调用DataBase.CreateConnection()方法进行构造当前实例
        /// </summary>
        public DataBaseTrans(IDbTransaction trans,ParameterCollection.CommandParameters parameters)
        {
            this.currentTrans = trans;
            this.parameters = parameters;
        }




        /// <summary>
        /// 根据当前DB.Parameters属性指定的命令参数追加一个用于多事务执行指定SQL的Command
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IDbCommand CreateCommand(string sql)
        {
            IDbCommand cmd = this.currentTrans.Connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.Transaction = this.currentTrans;

            for (int i = 0; i < this.Parameters.Count; i++)
            {
                cmd.Parameters.Add(this.Parameters[i]);
            }
            this.parameters.Clear();
            return cmd;
        }


        

        #region IDisposable Members

        public void Dispose()
        {
            if (this.CurrentTrans != null)
            {
                this.CurrentTrans.Connection.Close();
                this.CurrentTrans.Connection.Dispose();
                this.CurrentTrans.Dispose();
            }
        }

        #endregion
    }
}

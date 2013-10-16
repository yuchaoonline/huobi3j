
using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Text;
using ADeeWu.HuoBi3J.SQL.ParameterCollection;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.DAL{
	
	public class Users{
	
		private DataBase db = null;
		///<summary>
		///获取总记录数,该属性应该在调用Select方法后获取
		///</summary>
		public long RecordCount
		{
			get{ return this.db.RecordCount; }
		}
		
		public bool EnableRecordCount
        {
            get { return db.EnableRecordCount; }
            set { db.EnableRecordCount = value; }
        }
		
		public CommandParameters Parameters
        {
            get { return db.Parameters; }
        }
		
		public Users()
		{
			this.db = ADeeWu.HuoBi3J.SQL.DataBase.Create();
		}
		
		
		
		public bool Exist(string where)
        {
           StringBuilder builder = new StringBuilder();
           builder.Append("select * from [Users] where 1=1");
           if (!string.IsNullOrEmpty(where) && where.Trim()!="")
           {
               builder.AppendFormat(" and ( {0} )", where);
           }
           return db.Exist(builder.ToString());
        }
		
		public bool Exist(string columnName, object value)
        {
            return Exist(new string[] { columnName }, value);
        }

        public bool Exist(string[] columns,params object[] values)
        {
           
            StringBuilder builder = new StringBuilder();
            builder.Append("select * from [Users] where 1=1");
			db.Parameters.Clear();
            for (int i = 0; i < columns.Length; i++)
            {
                builder.AppendFormat(" and {0}=@{0}{1}", columns[i],i);
                db.Parameters.Append("@" + columns[i] + i, values[i]);
            }
            return db.Exist(builder.ToString());
        }
		
	    /// <summary>
		/// 成功返回大于0的新ID
		/// </summary>
		public long Add(ADeeWu.HuoBi3J.Model.Users model)
		{
			db.Parameters.Clear();
		db.Parameters.Append("@UserType",model.UserType);
		db.Parameters.Append("@UIN",model.UIN);
		db.Parameters.Append("@LoginName",model.LoginName);
		db.Parameters.Append("@LoginPwd",model.LoginPwd);
		db.Parameters.Append("@Money",model.Money);
		db.Parameters.Append("@Coins",model.Coins);
		db.Parameters.Append("@Points",model.Points);
		db.Parameters.Append("@AlipayAccount",model.AlipayAccount);
		db.Parameters.Append("@ProvinceID",model.ProvinceID);
		db.Parameters.Append("@CityID",model.CityID);
		db.Parameters.Append("@AreaID",model.AreaID);
		db.Parameters.Append("@Province",model.Province);
		db.Parameters.Append("@City",model.City);
		db.Parameters.Append("@Area",model.Area);
		db.Parameters.Append("@CheckState",model.CheckState);
		db.Parameters.Append("@LastLoginIP",model.LastLoginIP);
		db.Parameters.Append("@LastLogin",model.LastLogin);
		db.Parameters.Append("@LoginTimes",model.LoginTimes);
		db.Parameters.Append("@RegTime",model.RegTime);
		db.Parameters.Append("@Name",model.Name);
		db.Parameters.Append("@Tel",model.Tel);
		db.Parameters.Append("@Email",model.Email);
		    DataTable dt = db.Select("insert into [Users]([UserType],[UIN],[LoginName],[LoginPwd],[Money],[Coins],[Points],[AlipayAccount],[ProvinceID],[CityID],[AreaID],[Province],[City],[Area],[CheckState],[LastLoginIP],[LastLogin],[LoginTimes],[RegTime],[Name],[Tel],[Email]) values (@UserType,@UIN,@LoginName,@LoginPwd,@Money,@Coins,@Points,@AlipayAccount,@ProvinceID,@CityID,@AreaID,@Province,@City,@Area,@CheckState,@LastLoginIP,@LastLogin,@LoginTimes,@RegTime,@Name,@Tel,@Email);select @@Identity;");
			long newID = long.Parse(dt.Rows[0][0].ToString());
			model.ID = newID;
			return newID;
		}
		
		public int Update(ADeeWu.HuoBi3J.Model.Users model)
		{
			db.Parameters.Clear();
		db.Parameters.Append("@ID",model.ID);
		db.Parameters.Append("@UserType",model.UserType);
		db.Parameters.Append("@UIN",model.UIN);
		db.Parameters.Append("@LoginName",model.LoginName);
		db.Parameters.Append("@LoginPwd",model.LoginPwd);
		db.Parameters.Append("@Money",model.Money);
		db.Parameters.Append("@Coins",model.Coins);
		db.Parameters.Append("@Points",model.Points);
		db.Parameters.Append("@AlipayAccount",model.AlipayAccount);
		db.Parameters.Append("@ProvinceID",model.ProvinceID);
		db.Parameters.Append("@CityID",model.CityID);
		db.Parameters.Append("@AreaID",model.AreaID);
		db.Parameters.Append("@Province",model.Province);
		db.Parameters.Append("@City",model.City);
		db.Parameters.Append("@Area",model.Area);
		db.Parameters.Append("@CheckState",model.CheckState);
		db.Parameters.Append("@LastLoginIP",model.LastLoginIP);
		db.Parameters.Append("@LastLogin",model.LastLogin);
		db.Parameters.Append("@LoginTimes",model.LoginTimes);
		db.Parameters.Append("@RegTime",model.RegTime);
		db.Parameters.Append("@Name",model.Name);
		db.Parameters.Append("@Tel",model.Tel);
		db.Parameters.Append("@Email",model.Email);
			return db.ExecuteSql("update [Users] set [UserType]=@UserType,[UIN]=@UIN,[LoginName]=@LoginName,[LoginPwd]=@LoginPwd,[Money]=@Money,[Coins]=@Coins,[Points]=@Points,[AlipayAccount]=@AlipayAccount,[ProvinceID]=@ProvinceID,[CityID]=@CityID,[AreaID]=@AreaID,[Province]=@Province,[City]=@City,[Area]=@Area,[CheckState]=@CheckState,[LastLoginIP]=@LastLoginIP,[LastLogin]=@LastLogin,[LoginTimes]=@LoginTimes,[RegTime]=@RegTime,[Name]=@Name,[Tel]=@Tel,[Email]=@Email where [ID]=@ID");
		}
		
	
		
		
		
		/// <summary>
        /// 更新单个列的值
        /// </summary>
        /// <param name="updateColumns">更新的字段名称</param>
        /// <param name="updateValues">更新对应<paramref name="updateColumns"/>所指定的列的值</param>
        /// <param name="where">筛选条件</param>
        /// <returns></returns>
		public int Update(string columnName, object value, string where)
		{
			string sql = String.Format("update [{0}] set {1}=@{1}","Users",columnName);
			if(!string.IsNullOrEmpty(where)){
				sql += " where " + where;
			}
			db.Parameters.Clear();
			db.Parameters.Append("@" + columnName,value);
			return db.ExecuteSql(sql);
		}
	
		
		/// <summary>
        /// 更新记录 (可用于特殊情况筛选要更新的记录)
        /// </summary>
        /// <param name="updateColumns">更新的字段集合</param>
        /// <param name="updateValues">更新对应<paramref name="updateColumns"/>所指定的列的值</param>
        /// <param name="where">筛选条件</param>
        /// <returns></returns>
		public int Update(string[] updateColumns, object[] updateValues, string where)
		{
			if( updateColumns==null || updateColumns.Length==0 || updateValues== null || updateValues.Length != updateColumns.Length) return -1;
			
			string sql = String.Format("update [{0}] ","Users");
			
			db.Parameters.Clear();
			StringBuilder builder = new StringBuilder();
			for(int i=0;i<updateColumns.Length;i++)
			{
				builder.AppendFormat(",{0}=@{0}",updateColumns[i]);
				db.Parameters.Append("@" + updateColumns[i],updateValues[i]);
			}
			if(builder.Length==0) return -1;
			
			if(builder.Length>0)
			{
				sql +=" set " + builder.ToString().Substring(1);
			}
			
			if(!string.IsNullOrEmpty(where)){
				sql += " where " + where;
			}
			
			return db.ExecuteSql(sql);
		}
		
		
		
		
		public int Delete(long  ID)
		{
			db.Parameters.Clear();
			db.Parameters.Append("@ID",ID);
			return db.ExecuteSql("delete from [Users]  where  @ID=ID");
		}
		
		/// <summary>
		/// 无条件删除所有记录
		/// </summary>
		/// <param name="where">可带变量条件</param>
		/// <returns>影响行数</returns>
		public int DeleteAll()
		{
			string sql = string.Format("delete from [{0}] ", "Users");
			return db.ExecuteSql(sql);

		}
		
		/// <summary>
		/// 根据条件删除记录,当条件为空时将会停止执行操作(删除所有记录请使用DeleteAll)
		/// </summary>
		/// <param name="where">可带变量条件</param>
		/// <returns>影响行数</returns>
		public int Delete(string where)
        {
            string sql = string.Format("delete from [{0}] where 1=2 ", "Users");
			if(string.IsNullOrEmpty(where)){
				return -1;
			}
            return db.ExecuteSql(sql + " or( " + where + ")");
        }

        public int Delete(string columnName, object value)
        {
            string sql = string.Format("delete from [{0}] where {1}=@{1} ", "Users",columnName);
			db.Parameters.Clear();
            db.Parameters.Append("@" + columnName, value);
            return db.ExecuteSql(sql);
        }
		
		public ADeeWu.HuoBi3J.Model.Users GetEntity(long  ID)
		{
			db.Parameters.Clear();
		db.Parameters.Append("@ID",ID);
			DataTable dt = db.Select("select * from [Users] where 1=1  and [ID]=@ID");
			if(dt.Rows.Count==0) return null;
			DataRow dr = dt.Rows[0];
			ADeeWu.HuoBi3J.Model.Users Entity = new ADeeWu.HuoBi3J.Model.Users();
			Entity.ID = long.Parse(dr["ID"].ToString());
			Entity.UserType = int.Parse(dr["UserType"].ToString());
			Entity.UIN = (string)(dr["UIN"]);
			Entity.LoginName = (string)(dr["LoginName"]);
			Entity.LoginPwd = (string)(dr["LoginPwd"]);
			Entity.Money = decimal.Parse(dr["Money"].ToString());
            Entity.Coins = decimal.Parse(dr["Coins"].ToString());
			Entity.Points = int.Parse(dr["Points"].ToString());
			Entity.AlipayAccount = (string)(dr["AlipayAccount"]);
			Entity.ProvinceID = long.Parse(dr["ProvinceID"].ToString());
			Entity.CityID = long.Parse(dr["CityID"].ToString());
			Entity.AreaID = long.Parse(dr["AreaID"].ToString());
			Entity.Province = (string)(dr["Province"]);
			Entity.City = (string)(dr["City"]);
			Entity.Area = (string)(dr["Area"]);
			Entity.CheckState = int.Parse(dr["CheckState"].ToString());
			Entity.LastLoginIP = (string)(dr["LastLoginIP"]);
			Entity.LastLogin = DateTime.Parse(dr["LastLogin"].ToString());
			Entity.LoginTimes = int.Parse(dr["LoginTimes"].ToString());
			Entity.RegTime = DateTime.Parse(dr["RegTime"].ToString());
			Entity.Name = (string)(dr["Name"]);
			Entity.Tel = (string)(dr["Tel"]);
			Entity.Email = (string)(dr["Email"]);
			return Entity;
		}
		
		
		public ADeeWu.HuoBi3J.Model.Users GetEntity(string[] columns,params object[] values)
		{
			ADeeWu.HuoBi3J.Model.Users[] EntityList = GetEntityList("",columns,values);
			if(EntityList.Length==0)return null;
			return EntityList[0];
		}
		
		public ADeeWu.HuoBi3J.Model.Users GetEntity(string where)
		{
			DataTable dt = this.Select(where,"");
			if(dt.Rows.Count==0) return null;
			DataRow dr = dt.Rows[0];
			ADeeWu.HuoBi3J.Model.Users Entity = new ADeeWu.HuoBi3J.Model.Users();
			Entity.ID = long.Parse(dr["ID"].ToString());
			Entity.UserType = int.Parse(dr["UserType"].ToString());
			Entity.UIN = (string)(dr["UIN"]);
			Entity.LoginName = (string)(dr["LoginName"]);
			Entity.LoginPwd = (string)(dr["LoginPwd"]);
			Entity.Money = decimal.Parse(dr["Money"].ToString());
            Entity.Coins = decimal.Parse(dr["Coins"].ToString());
			Entity.Points = int.Parse(dr["Points"].ToString());
			Entity.AlipayAccount = (string)(dr["AlipayAccount"]);
			Entity.ProvinceID = long.Parse(dr["ProvinceID"].ToString());
			Entity.CityID = long.Parse(dr["CityID"].ToString());
			Entity.AreaID = long.Parse(dr["AreaID"].ToString());
			Entity.Province = (string)(dr["Province"]);
			Entity.City = (string)(dr["City"]);
			Entity.Area = (string)(dr["Area"]);
			Entity.CheckState = int.Parse(dr["CheckState"].ToString());
			Entity.LastLoginIP = (string)(dr["LastLoginIP"]);
			Entity.LastLogin = DateTime.Parse(dr["LastLogin"].ToString());
			Entity.LoginTimes = int.Parse(dr["LoginTimes"].ToString());
			Entity.RegTime = DateTime.Parse(dr["RegTime"].ToString());
			Entity.Name = (string)(dr["Name"]);
			Entity.Tel = (string)(dr["Tel"]);
			Entity.Email = (string)(dr["Email"]);
			return Entity;
		}
		
		public ADeeWu.HuoBi3J.Model.Users[] GetEntityList(string orderBy,string[] columns,params object[] values)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * from [Users] where 1=1");
			db.Parameters.Clear();
			for(int i=0;i<columns.Length;i++)
			{
				builder.AppendFormat(" and [{0}]=@{0}", columns[i]);
				db.Parameters.Append("@"+columns[i],values[i]);
			}
			
            if (!string.IsNullOrEmpty(orderBy))
            {
                builder.AppendFormat(" order by {0}", orderBy);
            }

            DataTable dt = db.Select(builder.ToString());
           
            ADeeWu.HuoBi3J.Model.Users[] EntityList = new ADeeWu.HuoBi3J.Model.Users[dt.Rows.Count];
			 if (dt.Rows.Count == 0) return EntityList;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
				DataRow dr = dt.Rows[i];
                ADeeWu.HuoBi3J.Model.Users Entity = new ADeeWu.HuoBi3J.Model.Users();
				Entity.ID = long.Parse(dr["ID"].ToString());
				Entity.UserType = int.Parse(dr["UserType"].ToString());
				Entity.UIN = (string)(dr["UIN"]);
				Entity.LoginName = (string)(dr["LoginName"]);
				Entity.LoginPwd = (string)(dr["LoginPwd"]);
				Entity.Money = decimal.Parse(dr["Money"].ToString());
                Entity.Coins = decimal.Parse(dr["Coins"].ToString());
				Entity.Points = int.Parse(dr["Points"].ToString());
				Entity.AlipayAccount = (string)(dr["AlipayAccount"]);
				Entity.ProvinceID = long.Parse(dr["ProvinceID"].ToString());
				Entity.CityID = long.Parse(dr["CityID"].ToString());
				Entity.AreaID = long.Parse(dr["AreaID"].ToString());
				Entity.Province = (string)(dr["Province"]);
				Entity.City = (string)(dr["City"]);
				Entity.Area = (string)(dr["Area"]);
				Entity.CheckState = int.Parse(dr["CheckState"].ToString());
				Entity.LastLoginIP = (string)(dr["LastLoginIP"]);
				Entity.LastLogin = DateTime.Parse(dr["LastLogin"].ToString());
				Entity.LoginTimes = int.Parse(dr["LoginTimes"].ToString());
				Entity.RegTime = DateTime.Parse(dr["RegTime"].ToString());
				Entity.Name = (string)(dr["Name"]);
				Entity.Tel = (string)(dr["Tel"]);
				Entity.Email = (string)(dr["Email"]);
                EntityList[i] = Entity;
            }
             return EntityList;
        }
		
		/// <summary>
        /// 查询数据(查询所有数据设置<paramref name="pageIndex"/>为-1
        /// </summary>
        /// <param name="where">支持变量的条件,如Name=@Name</param>
		/// <param name="orderBy">排序,默认按照无重复列(如ID)倒序(desc)</param>
        /// <returns></returns>
		public DataTable Select(string where,string orderBy)
		{
			return db.Select(-1,-1,"Users","ID",where,orderBy);
		}
		
		
		
		/// <summary>
        /// 分页查询数据(查询所有数据设置<paramref name="pageIndex"/>为-1
        /// </summary>
        /// <param name="pageSize">每页大小 设置-1 查询所有数据 </param>
        /// <param name="pageIndex">页码 设置-1 查询所有数据 </param>
        /// <returns></returns>
		public DataTable Select(long pageSize,long pageIndex)
		{
			return db.Select(pageSize,pageIndex,"Users","ID","","");
		}
		
		/// <summary>
        /// 分页查询数据(查询所有数据设置<paramref name="pageIndex"/>为-1
        /// </summary>
        /// <param name="pageSize">每页大小 设置-1 查询所有数据 </param>
        /// <param name="pageIndex">页码 设置-1 查询所有数据 </param>
        /// <param name="orderBy">排序,默认按照无重复列(如ID)倒序(desc)</param>
        /// <returns></returns>
		public DataTable Select(long pageSize,long pageIndex,string orderBy)
		{
			return db.Select(pageSize,pageIndex,"Users","ID","",orderBy);
		}
		
		/// <summary>
        /// 分页查询数据(查询所有数据设置<paramref name="pageIndex"/>为-1
        /// </summary>
        /// <param name="pageSize">每页大小</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="where">支持变量的条件,如Name=@Name</param>
        /// <param name="orderBy">排序,默认按照无重复列(如ID)倒序(desc)</param>
        /// <returns></returns>
		public DataTable Select(long pageSize,long pageIndex,string where,string orderBy)
		{
			return db.Select(pageSize,pageIndex,"Users","ID",where,orderBy);
		}
		
		
		
		
		
	}
	
}


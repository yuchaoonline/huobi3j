
using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Text;
using ADeeWu.HuoBi3J.SQL.ParameterCollection;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.DAL{
	
	public class Shop_Orders{
	
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
		
		public Shop_Orders()
		{
			this.db = ADeeWu.HuoBi3J.SQL.DataBase.Create();
		}
		
		
		
		public bool Exist(string where)
        {
           StringBuilder builder = new StringBuilder();
           builder.Append("select * from [Shop_Orders] where 1=1");
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
            builder.Append("select * from [Shop_Orders] where 1=1");
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
		public long Add(ADeeWu.HuoBi3J.Model.Shop_Orders model)
		{
			db.Parameters.Clear();
		db.Parameters.Append("@OrderCode",model.OrderCode);
		db.Parameters.Append("@SellerCorpID",model.SellerCorpID);
		db.Parameters.Append("@SellerUserID",model.SellerUserID);
		db.Parameters.Append("@CorpAgentID",model.CorpAgentID);
		db.Parameters.Append("@BuyerUserID",model.BuyerUserID);
		db.Parameters.Append("@SubTotal",model.SubTotal);
		db.Parameters.Append("@Freight",model.Freight);
		db.Parameters.Append("@OrderState",model.OrderState);
		db.Parameters.Append("@HasPaid",model.HasPaid);
		db.Parameters.Append("@DeliveryType",model.DeliveryType);
		db.Parameters.Append("@Receiver",model.Receiver);
		db.Parameters.Append("@ProvinceID",model.ProvinceID);
		db.Parameters.Append("@CityID",model.CityID);
		db.Parameters.Append("@AreaID",model.AreaID);
		db.Parameters.Append("@Address",model.Address);
		db.Parameters.Append("@ZipCode",model.ZipCode);
		db.Parameters.Append("@Note",model.Note);
		db.Parameters.Append("@DeliveryTime",model.DeliveryTime.HasValue ? (object)model.DeliveryTime.Value : (object)DBNull.Value );
		db.Parameters.Append("@CreateTime",model.CreateTime);
		db.Parameters.Append("@ModifyTime",model.ModifyTime);
		    DataTable dt = db.Select("insert into [Shop_Orders]([OrderCode],[SellerCorpID],[SellerUserID],[CorpAgentID],[BuyerUserID],[SubTotal],[Freight],[OrderState],[HasPaid],[DeliveryType],[Receiver],[ProvinceID],[CityID],[AreaID],[Address],[ZipCode],[Note],[DeliveryTime],[CreateTime],[ModifyTime]) values (@OrderCode,@SellerCorpID,@SellerUserID,@CorpAgentID,@BuyerUserID,@SubTotal,@Freight,@OrderState,@HasPaid,@DeliveryType,@Receiver,@ProvinceID,@CityID,@AreaID,@Address,@ZipCode,@Note,@DeliveryTime,@CreateTime,@ModifyTime);select @@Identity;");
			long newID = long.Parse(dt.Rows[0][0].ToString());
			model.ID = newID;
			return newID;
		}
		
		public int Update(ADeeWu.HuoBi3J.Model.Shop_Orders model)
		{
			db.Parameters.Clear();
		db.Parameters.Append("@ID",model.ID);
		db.Parameters.Append("@OrderCode",model.OrderCode);
		db.Parameters.Append("@SellerCorpID",model.SellerCorpID);
		db.Parameters.Append("@SellerUserID",model.SellerUserID);
		db.Parameters.Append("@CorpAgentID",model.CorpAgentID);
		db.Parameters.Append("@BuyerUserID",model.BuyerUserID);
		db.Parameters.Append("@SubTotal",model.SubTotal);
		db.Parameters.Append("@Freight",model.Freight);
		db.Parameters.Append("@OrderState",model.OrderState);
		db.Parameters.Append("@HasPaid",model.HasPaid);
		db.Parameters.Append("@DeliveryType",model.DeliveryType);
		db.Parameters.Append("@Receiver",model.Receiver);
		db.Parameters.Append("@ProvinceID",model.ProvinceID);
		db.Parameters.Append("@CityID",model.CityID);
		db.Parameters.Append("@AreaID",model.AreaID);
		db.Parameters.Append("@Address",model.Address);
		db.Parameters.Append("@ZipCode",model.ZipCode);
		db.Parameters.Append("@Note",model.Note);
		db.Parameters.Append("@DeliveryTime",model.DeliveryTime.HasValue ? (object)model.DeliveryTime.Value : (object)DBNull.Value );
		db.Parameters.Append("@CreateTime",model.CreateTime);
		db.Parameters.Append("@ModifyTime",model.ModifyTime);
			return db.ExecuteSql("update [Shop_Orders] set [OrderCode]=@OrderCode,[SellerCorpID]=@SellerCorpID,[SellerUserID]=@SellerUserID,[CorpAgentID]=@CorpAgentID,[BuyerUserID]=@BuyerUserID,[SubTotal]=@SubTotal,[Freight]=@Freight,[OrderState]=@OrderState,[HasPaid]=@HasPaid,[DeliveryType]=@DeliveryType,[Receiver]=@Receiver,[ProvinceID]=@ProvinceID,[CityID]=@CityID,[AreaID]=@AreaID,[Address]=@Address,[ZipCode]=@ZipCode,[Note]=@Note,[DeliveryTime]=@DeliveryTime,[CreateTime]=@CreateTime,[ModifyTime]=@ModifyTime where [ID]=@ID");
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
			string sql = String.Format("update [{0}] set {1}=@{1}","Shop_Orders",columnName);
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
			
			string sql = String.Format("update [{0}] ","Shop_Orders");
			
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
			return db.ExecuteSql("delete from [Shop_Orders]  where  @ID=ID");
		}
		
		/// <summary>
		/// 无条件删除所有记录
		/// </summary>
		/// <param name="where">可带变量条件</param>
		/// <returns>影响行数</returns>
		public int DeleteAll()
		{
			string sql = string.Format("delete from [{0}] ", "Shop_Orders");
			return db.ExecuteSql(sql);

		}
		
		/// <summary>
		/// 根据条件删除记录,当条件为空时将会停止执行操作(删除所有记录请使用DeleteAll)
		/// </summary>
		/// <param name="where">可带变量条件</param>
		/// <returns>影响行数</returns>
		public int Delete(string where)
        {
            string sql = string.Format("delete from [{0}] where 1=2 ", "Shop_Orders");
			if(string.IsNullOrEmpty(where)){
				return -1;
			}
            return db.ExecuteSql(sql + " or( " + where + ")");
        }

        public int Delete(string columnName, object value)
        {
            string sql = string.Format("delete from [{0}] where {1}=@{1} ", "Shop_Orders",columnName);
			db.Parameters.Clear();
            db.Parameters.Append("@" + columnName, value);
            return db.ExecuteSql(sql);
        }
		
		public ADeeWu.HuoBi3J.Model.Shop_Orders GetEntity(long  ID)
		{
			db.Parameters.Clear();
		db.Parameters.Append("@ID",ID);
			DataTable dt = db.Select("select * from [Shop_Orders] where 1=1  and [ID]=@ID");
			if(dt.Rows.Count==0) return null;
			DataRow dr = dt.Rows[0];
			ADeeWu.HuoBi3J.Model.Shop_Orders Entity = new ADeeWu.HuoBi3J.Model.Shop_Orders();
			Entity.ID = long.Parse(dr["ID"].ToString());
			Entity.OrderCode = (string)(dr["OrderCode"]);
			Entity.SellerCorpID = long.Parse(dr["SellerCorpID"].ToString());
			Entity.SellerUserID = long.Parse(dr["SellerUserID"].ToString());
			Entity.CorpAgentID = long.Parse(dr["CorpAgentID"].ToString());
			Entity.BuyerUserID = long.Parse(dr["BuyerUserID"].ToString());
			Entity.SubTotal = decimal.Parse(dr["SubTotal"].ToString());
			Entity.Freight = decimal.Parse(dr["Freight"].ToString());
			Entity.OrderState = int.Parse(dr["OrderState"].ToString());
			Entity.HasPaid = bool.Parse(dr["HasPaid"].ToString());
			Entity.DeliveryType = int.Parse(dr["DeliveryType"].ToString());
			Entity.Receiver = (string)(dr["Receiver"]);
			Entity.ProvinceID = long.Parse(dr["ProvinceID"].ToString());
			Entity.CityID = long.Parse(dr["CityID"].ToString());
			Entity.AreaID = long.Parse(dr["AreaID"].ToString());
			Entity.Address = (string)(dr["Address"]);
			Entity.ZipCode = (string)(dr["ZipCode"]);
			Entity.Note = (string)(dr["Note"]);
			Entity.DeliveryTime = dr["DeliveryTime"] as DateTime?;
			Entity.CreateTime = DateTime.Parse(dr["CreateTime"].ToString());
			Entity.ModifyTime = DateTime.Parse(dr["ModifyTime"].ToString());
			return Entity;
		}
		
		
		public ADeeWu.HuoBi3J.Model.Shop_Orders GetEntity(string[] columns,params object[] values)
		{
			ADeeWu.HuoBi3J.Model.Shop_Orders[] EntityList = GetEntityList("",columns,values);
			if(EntityList.Length==0)return null;
			return EntityList[0];
		}
		
		public ADeeWu.HuoBi3J.Model.Shop_Orders GetEntity(string where)
		{
			DataTable dt = this.Select(where,"");
			if(dt.Rows.Count==0) return null;
			DataRow dr = dt.Rows[0];
			ADeeWu.HuoBi3J.Model.Shop_Orders Entity = new ADeeWu.HuoBi3J.Model.Shop_Orders();
			Entity.ID = long.Parse(dr["ID"].ToString());
			Entity.OrderCode = (string)(dr["OrderCode"]);
			Entity.SellerCorpID = long.Parse(dr["SellerCorpID"].ToString());
			Entity.SellerUserID = long.Parse(dr["SellerUserID"].ToString());
			Entity.CorpAgentID = long.Parse(dr["CorpAgentID"].ToString());
			Entity.BuyerUserID = long.Parse(dr["BuyerUserID"].ToString());
			Entity.SubTotal = decimal.Parse(dr["SubTotal"].ToString());
			Entity.Freight = decimal.Parse(dr["Freight"].ToString());
			Entity.OrderState = int.Parse(dr["OrderState"].ToString());
			Entity.HasPaid = bool.Parse(dr["HasPaid"].ToString());
			Entity.DeliveryType = int.Parse(dr["DeliveryType"].ToString());
			Entity.Receiver = (string)(dr["Receiver"]);
			Entity.ProvinceID = long.Parse(dr["ProvinceID"].ToString());
			Entity.CityID = long.Parse(dr["CityID"].ToString());
			Entity.AreaID = long.Parse(dr["AreaID"].ToString());
			Entity.Address = (string)(dr["Address"]);
			Entity.ZipCode = (string)(dr["ZipCode"]);
			Entity.Note = (string)(dr["Note"]);
			Entity.DeliveryTime = dr["DeliveryTime"] as DateTime?;
			Entity.CreateTime = DateTime.Parse(dr["CreateTime"].ToString());
			Entity.ModifyTime = DateTime.Parse(dr["ModifyTime"].ToString());
			return Entity;
		}
		
		public ADeeWu.HuoBi3J.Model.Shop_Orders[] GetEntityList(string orderBy,string[] columns,params object[] values)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * from [Shop_Orders] where 1=1");
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
           
            ADeeWu.HuoBi3J.Model.Shop_Orders[] EntityList = new ADeeWu.HuoBi3J.Model.Shop_Orders[dt.Rows.Count];
			 if (dt.Rows.Count == 0) return EntityList;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
				DataRow dr = dt.Rows[i];
                ADeeWu.HuoBi3J.Model.Shop_Orders Entity = new ADeeWu.HuoBi3J.Model.Shop_Orders();
				Entity.ID = long.Parse(dr["ID"].ToString());
				Entity.OrderCode = (string)(dr["OrderCode"]);
				Entity.SellerCorpID = long.Parse(dr["SellerCorpID"].ToString());
				Entity.SellerUserID = long.Parse(dr["SellerUserID"].ToString());
				Entity.CorpAgentID = long.Parse(dr["CorpAgentID"].ToString());
				Entity.BuyerUserID = long.Parse(dr["BuyerUserID"].ToString());
				Entity.SubTotal = decimal.Parse(dr["SubTotal"].ToString());
				Entity.Freight = decimal.Parse(dr["Freight"].ToString());
				Entity.OrderState = int.Parse(dr["OrderState"].ToString());
				Entity.HasPaid = bool.Parse(dr["HasPaid"].ToString());
				Entity.DeliveryType = int.Parse(dr["DeliveryType"].ToString());
				Entity.Receiver = (string)(dr["Receiver"]);
				Entity.ProvinceID = long.Parse(dr["ProvinceID"].ToString());
				Entity.CityID = long.Parse(dr["CityID"].ToString());
				Entity.AreaID = long.Parse(dr["AreaID"].ToString());
				Entity.Address = (string)(dr["Address"]);
				Entity.ZipCode = (string)(dr["ZipCode"]);
				Entity.Note = (string)(dr["Note"]);
				Entity.DeliveryTime = dr["DeliveryTime"] as DateTime?;
				Entity.CreateTime = DateTime.Parse(dr["CreateTime"].ToString());
				Entity.ModifyTime = DateTime.Parse(dr["ModifyTime"].ToString());
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
			return db.Select(-1,-1,"Shop_Orders","ID",where,orderBy);
		}
		
		
		
		/// <summary>
        /// 分页查询数据(查询所有数据设置<paramref name="pageIndex"/>为-1
        /// </summary>
        /// <param name="pageSize">每页大小 设置-1 查询所有数据 </param>
        /// <param name="pageIndex">页码 设置-1 查询所有数据 </param>
        /// <returns></returns>
		public DataTable Select(long pageSize,long pageIndex)
		{
			return db.Select(pageSize,pageIndex,"Shop_Orders","ID","","");
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
			return db.Select(pageSize,pageIndex,"Shop_Orders","ID","",orderBy);
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
			return db.Select(pageSize,pageIndex,"Shop_Orders","ID",where,orderBy);
		}
		
		
		
		
		
	}
	
}


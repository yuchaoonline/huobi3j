
using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Text;
using ADeeWu.HuoBi3J.SQL.ParameterCollection;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.DAL{
	
	public class GroupBuy_Product{
	
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
		
		public GroupBuy_Product()
		{
			this.db = ADeeWu.HuoBi3J.SQL.DataBase.Create();
		}
		
		
		
		public bool Exist(string where)
        {
           StringBuilder builder = new StringBuilder();
           builder.Append("select * from [GroupBuy_Product] where 1=1");
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
            builder.Append("select * from [GroupBuy_Product] where 1=1");
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
		public long Add(ADeeWu.HuoBi3J.Model.GroupBuy_Product model)
		{
			db.Parameters.Clear();
		db.Parameters.Append("@Title",model.Title);
		db.Parameters.Append("@Detail",model.Detail);
		db.Parameters.Append("@Remind",model.Remind);
		db.Parameters.Append("@Photo",model.Photo);
		db.Parameters.Append("@SellerIntro",model.SellerIntro);
		db.Parameters.Append("@MapLocation",model.MapLocation);
		db.Parameters.Append("@AreaID",model.AreaID.HasValue ? (object)model.AreaID.Value : (object)DBNull.Value );
		db.Parameters.Append("@BusinessCircle",model.BusinessCircle);
		db.Parameters.Append("@Category",model.Category);
		db.Parameters.Append("@Summary",model.Summary.HasValue ? (object)model.Summary.Value : (object)DBNull.Value );
		db.Parameters.Append("@Price",model.Price.HasValue ? (object)model.Price.Value : (object)DBNull.Value );
		db.Parameters.Append("@MarketPrice",model.MarketPrice.HasValue ? (object)model.MarketPrice.Value : (object)DBNull.Value );
		db.Parameters.Append("@SaleDay",model.SaleDay.HasValue ? (object)model.SaleDay.Value : (object)DBNull.Value );
		db.Parameters.Append("@CreateDate",model.CreateDate.HasValue ? (object)model.CreateDate.Value : (object)DBNull.Value );
		db.Parameters.Append("@PassDate",model.PassDate.HasValue ? (object)model.PassDate.Value : (object)DBNull.Value );
		db.Parameters.Append("@IsPass",model.IsPass.HasValue ? (object)model.IsPass.Value : (object)DBNull.Value );
		db.Parameters.Append("@IsExpire",model.IsExpire.HasValue ? (object)model.IsExpire.Value : (object)DBNull.Value );
		db.Parameters.Append("@HotPlaceID",model.HotPlaceID.HasValue ? (object)model.HotPlaceID.Value : (object)DBNull.Value );
		db.Parameters.Append("@CreateUserID",model.CreateUserID);
		db.Parameters.Append("@ProductIntro",model.ProductIntro );
		db.Parameters.Append("@OrderCount",model.OrderCount);
		db.Parameters.Append("@BuyLink",model.BuyLink );
		db.Parameters.Append("@SaleCount",model.SaleCount);
		    DataTable dt = db.Select("insert into [GroupBuy_Product]([Title],[Detail],[Remind],[Photo],[SellerIntro],[MapLocation],[AreaID],[BusinessCircle],[Category],[Summary],[Price],[MarketPrice],[SaleDay],[CreateDate],[PassDate],[IsPass],[IsExpire],[HotPlaceID],[CreateUserID],[ProductIntro],[OrderCount],[BuyLink],[SaleCount]) values (@Title,@Detail,@Remind,@Photo,@SellerIntro,@MapLocation,@AreaID,@BusinessCircle,@Category,@Summary,@Price,@MarketPrice,@SaleDay,@CreateDate,@PassDate,@IsPass,@IsExpire,@HotPlaceID,@CreateUserID,@ProductIntro,@OrderCount,@BuyLink,@SaleCount);select @@Identity;");
			int newID = int.Parse(dt.Rows[0][0].ToString());
			model.ID = newID;
			return newID;
		}
		
		public int Update(ADeeWu.HuoBi3J.Model.GroupBuy_Product model)
		{
			db.Parameters.Clear();
		db.Parameters.Append("@ID",model.ID);
		db.Parameters.Append("@Title",model.Title );
		db.Parameters.Append("@Detail",model.Detail );
		db.Parameters.Append("@Remind",model.Remind );
		db.Parameters.Append("@Photo",model.Photo );
		db.Parameters.Append("@SellerIntro",model.SellerIntro );
		db.Parameters.Append("@MapLocation",model.MapLocation );
		db.Parameters.Append("@AreaID",model.AreaID.HasValue ? (object)model.AreaID.Value : (object)DBNull.Value );
		db.Parameters.Append("@BusinessCircle",model.BusinessCircle );
		db.Parameters.Append("@Category",model.Category );
		db.Parameters.Append("@Summary",model.Summary.HasValue ? (object)model.Summary.Value : (object)DBNull.Value );
		db.Parameters.Append("@Price",model.Price.HasValue ? (object)model.Price.Value : (object)DBNull.Value );
		db.Parameters.Append("@MarketPrice",model.MarketPrice.HasValue ? (object)model.MarketPrice.Value : (object)DBNull.Value );
		db.Parameters.Append("@SaleDay",model.SaleDay.HasValue ? (object)model.SaleDay.Value : (object)DBNull.Value );
		db.Parameters.Append("@CreateDate",model.CreateDate.HasValue ? (object)model.CreateDate.Value : (object)DBNull.Value );
		db.Parameters.Append("@PassDate",model.PassDate.HasValue ? (object)model.PassDate.Value : (object)DBNull.Value );
		db.Parameters.Append("@IsPass",model.IsPass.HasValue ? (object)model.IsPass.Value : (object)DBNull.Value );
		db.Parameters.Append("@IsExpire",model.IsExpire.HasValue ? (object)model.IsExpire.Value : (object)DBNull.Value );
		db.Parameters.Append("@HotPlaceID",model.HotPlaceID.HasValue ? (object)model.HotPlaceID.Value : (object)DBNull.Value );
		db.Parameters.Append("@CreateUserID",model.CreateUserID);
		db.Parameters.Append("@ProductIntro",model.ProductIntro );
		db.Parameters.Append("@OrderCount",model.OrderCount);
		db.Parameters.Append("@BuyLink",model.BuyLink );
		db.Parameters.Append("@SaleCount",model.SaleCount);
			return db.ExecuteSql("update [GroupBuy_Product] set [Title]=@Title,[Detail]=@Detail,[Remind]=@Remind,[Photo]=@Photo,[SellerIntro]=@SellerIntro,[MapLocation]=@MapLocation,[AreaID]=@AreaID,[BusinessCircle]=@BusinessCircle,[Category]=@Category,[Summary]=@Summary,[Price]=@Price,[MarketPrice]=@MarketPrice,[SaleDay]=@SaleDay,[CreateDate]=@CreateDate,[PassDate]=@PassDate,[IsPass]=@IsPass,[IsExpire]=@IsExpire,[HotPlaceID]=@HotPlaceID,[CreateUserID]=@CreateUserID,[ProductIntro]=@ProductIntro,[OrderCount]=@OrderCount,[BuyLink]=@BuyLink,[SaleCount]=@SaleCount where [ID]=@ID");
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
			string sql = String.Format("update [{0}] set {1}=@{1}","GroupBuy_Product",columnName);
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
			
			string sql = String.Format("update [{0}] ","GroupBuy_Product");
			
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
		
		
		
		
		public int Delete(int  ID)
		{
			db.Parameters.Clear();
			db.Parameters.Append("@ID",ID);
			return db.ExecuteSql("delete from [GroupBuy_Product]  where  @ID=ID");
		}
		
		/// <summary>
		/// 无条件删除所有记录
		/// </summary>
		/// <param name="where">可带变量条件</param>
		/// <returns>影响行数</returns>
		public int DeleteAll()
		{
			string sql = string.Format("delete from [{0}] ", "GroupBuy_Product");
			return db.ExecuteSql(sql);

		}
		
		/// <summary>
		/// 根据条件删除记录,当条件为空时将会停止执行操作(删除所有记录请使用DeleteAll)
		/// </summary>
		/// <param name="where">可带变量条件</param>
		/// <returns>影响行数</returns>
		public int Delete(string where)
        {
            string sql = string.Format("delete from [{0}] where 1=2 ", "GroupBuy_Product");
			if(string.IsNullOrEmpty(where)){
				return -1;
			}
            return db.ExecuteSql(sql + " or( " + where + ")");
        }

        public int Delete(string columnName, object value)
        {
            string sql = string.Format("delete from [{0}] where {1}=@{1} ", "GroupBuy_Product",columnName);
			db.Parameters.Clear();
            db.Parameters.Append("@" + columnName, value);
            return db.ExecuteSql(sql);
        }
		
		public ADeeWu.HuoBi3J.Model.GroupBuy_Product GetEntity(int  ID)
		{
			db.Parameters.Clear();
		db.Parameters.Append("@ID",ID);
			DataTable dt = db.Select("select * from [GroupBuy_Product] where 1=1  and [ID]=@ID");
			if(dt.Rows.Count==0) return null;
			DataRow dr = dt.Rows[0];
			ADeeWu.HuoBi3J.Model.GroupBuy_Product Entity = new ADeeWu.HuoBi3J.Model.GroupBuy_Product();
			Entity.ID = int.Parse(dr["ID"].ToString());
			Entity.Title = dr["Title"] as string;
			Entity.Detail = dr["Detail"] as string;
			Entity.Remind = dr["Remind"] as string;
			Entity.Photo = dr["Photo"] as string;
			Entity.SellerIntro = dr["SellerIntro"] as string;
			Entity.MapLocation = dr["MapLocation"] as string;
			Entity.AreaID = dr["AreaID"] as long?;
			Entity.BusinessCircle = dr["BusinessCircle"] as string;
			Entity.Category = dr["Category"] as string;
			Entity.Summary = dr["Summary"] as int?;
			Entity.Price = dr["Price"] as decimal?;
			Entity.MarketPrice = dr["MarketPrice"] as decimal?;
			Entity.SaleDay = dr["SaleDay"] as int?;
			Entity.CreateDate = dr["CreateDate"] as DateTime?;
			Entity.PassDate = dr["PassDate"] as DateTime?;
			Entity.IsPass = dr["IsPass"] as bool?;
			Entity.IsExpire = dr["IsExpire"] as bool?;
			Entity.HotPlaceID = dr["HotPlaceID"] as int?;
			Entity.CreateUserID = int.Parse(dr["CreateUserID"].ToString());
			Entity.ProductIntro = dr["ProductIntro"] as string;
			Entity.OrderCount = int.Parse(dr["OrderCount"].ToString());
			Entity.BuyLink = dr["BuyLink"] as string;
			Entity.SaleCount = int.Parse(dr["SaleCount"].ToString());
			return Entity;
		}
		
		
		public ADeeWu.HuoBi3J.Model.GroupBuy_Product GetEntity(string[] columns,params object[] values)
		{
			ADeeWu.HuoBi3J.Model.GroupBuy_Product[] EntityList = GetEntityList("",columns,values);
			if(EntityList.Length==0)return null;
			return EntityList[0];
		}
		
		public ADeeWu.HuoBi3J.Model.GroupBuy_Product GetEntity(string where)
		{
			DataTable dt = this.Select(where,"");
			if(dt.Rows.Count==0) return null;
			DataRow dr = dt.Rows[0];
			ADeeWu.HuoBi3J.Model.GroupBuy_Product Entity = new ADeeWu.HuoBi3J.Model.GroupBuy_Product();
			Entity.ID = int.Parse(dr["ID"].ToString());
			Entity.Title = dr["Title"] as string;
			Entity.Detail = dr["Detail"] as string;
			Entity.Remind = dr["Remind"] as string;
			Entity.Photo = dr["Photo"] as string;
			Entity.SellerIntro = dr["SellerIntro"] as string;
			Entity.MapLocation = dr["MapLocation"] as string;
			Entity.AreaID = dr["AreaID"] as long?;
			Entity.BusinessCircle = dr["BusinessCircle"] as string;
			Entity.Category = dr["Category"] as string;
			Entity.Summary = dr["Summary"] as int?;
			Entity.Price = dr["Price"] as decimal?;
			Entity.MarketPrice = dr["MarketPrice"] as decimal?;
			Entity.SaleDay = dr["SaleDay"] as int?;
			Entity.CreateDate = dr["CreateDate"] as DateTime?;
			Entity.PassDate = dr["PassDate"] as DateTime?;
			Entity.IsPass = dr["IsPass"] as bool?;
			Entity.IsExpire = dr["IsExpire"] as bool?;
			Entity.HotPlaceID = dr["HotPlaceID"] as int?;
			Entity.CreateUserID = int.Parse(dr["CreateUserID"].ToString());
			Entity.ProductIntro = dr["ProductIntro"] as string;
			Entity.OrderCount = int.Parse(dr["OrderCount"].ToString());
			Entity.BuyLink = dr["BuyLink"] as string;
			Entity.SaleCount = int.Parse(dr["SaleCount"].ToString());
			return Entity;
		}
		
		public ADeeWu.HuoBi3J.Model.GroupBuy_Product[] GetEntityList(string orderBy,string[] columns,params object[] values)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * from [GroupBuy_Product] where 1=1");
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
           
            ADeeWu.HuoBi3J.Model.GroupBuy_Product[] EntityList = new ADeeWu.HuoBi3J.Model.GroupBuy_Product[dt.Rows.Count];
			 if (dt.Rows.Count == 0) return EntityList;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
				DataRow dr = dt.Rows[i];
                ADeeWu.HuoBi3J.Model.GroupBuy_Product Entity = new ADeeWu.HuoBi3J.Model.GroupBuy_Product();
				Entity.ID = int.Parse(dr["ID"].ToString());
				Entity.Title = dr["Title"] as string;
				Entity.Detail = dr["Detail"] as string;
				Entity.Remind = dr["Remind"] as string;
				Entity.Photo = dr["Photo"] as string;
				Entity.SellerIntro = dr["SellerIntro"] as string;
				Entity.MapLocation = dr["MapLocation"] as string;
				Entity.AreaID = dr["AreaID"] as long?;
				Entity.BusinessCircle = dr["BusinessCircle"] as string;
				Entity.Category = dr["Category"] as string;
				Entity.Summary = dr["Summary"] as int?;
				Entity.Price = dr["Price"] as decimal?;
				Entity.MarketPrice = dr["MarketPrice"] as decimal?;
				Entity.SaleDay = dr["SaleDay"] as int?;
				Entity.CreateDate = dr["CreateDate"] as DateTime?;
				Entity.PassDate = dr["PassDate"] as DateTime?;
				Entity.IsPass = dr["IsPass"] as bool?;
				Entity.IsExpire = dr["IsExpire"] as bool?;
				Entity.HotPlaceID = dr["HotPlaceID"] as int?;
				Entity.CreateUserID = int.Parse(dr["CreateUserID"].ToString());
				Entity.ProductIntro = dr["ProductIntro"] as string;
				Entity.OrderCount = int.Parse(dr["OrderCount"].ToString());
				Entity.BuyLink = dr["BuyLink"] as string;
				Entity.SaleCount = int.Parse(dr["SaleCount"].ToString());
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
			return db.Select(-1,-1,"GroupBuy_Product","ID",where,orderBy);
		}
		
		
		
		/// <summary>
        /// 分页查询数据(查询所有数据设置<paramref name="pageIndex"/>为-1
        /// </summary>
        /// <param name="pageSize">每页大小 设置-1 查询所有数据 </param>
        /// <param name="pageIndex">页码 设置-1 查询所有数据 </param>
        /// <returns></returns>
		public DataTable Select(long pageSize,long pageIndex)
		{
			return db.Select(pageSize,pageIndex,"GroupBuy_Product","ID","","");
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
			return db.Select(pageSize,pageIndex,"GroupBuy_Product","ID","",orderBy);
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
			return db.Select(pageSize,pageIndex,"GroupBuy_Product","ID",where,orderBy);
		}
		
		
		
		
		
	}
	
}



using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Text;
using ADeeWu.HuoBi3J.SQL.ParameterCollection;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.DAL{
	
	public class Shop_ProductCategories{
	
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
		
		public Shop_ProductCategories()
		{
			this.db = ADeeWu.HuoBi3J.SQL.DataBase.Create();
		}
		
		
		
		public bool Exist(string where)
        {
           StringBuilder builder = new StringBuilder();
           builder.Append("select * from [Shop_ProductCategories] where 1=1");
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
            builder.Append("select * from [Shop_ProductCategories] where 1=1");
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
		public long Add(ADeeWu.HuoBi3J.Model.Shop_ProductCategories model)
		{
			db.Parameters.Clear();
		db.Parameters.Append("@AttrTplCateID",model.AttrTplCateID);
		db.Parameters.Append("@Name",model.Name);
		db.Parameters.Append("@ItemCount",model.ItemCount);
		db.Parameters.Append("@ParentID",model.ParentID);
		db.Parameters.Append("@ParentPath",model.ParentPath);
		db.Parameters.Append("@Depth",model.Depth);
		db.Parameters.Append("@Sequence",model.Sequence);
		db.Parameters.Append("@IsRecommend",model.IsRecommend);
		db.Parameters.Append("@IsHidden",model.IsHidden);
		db.Parameters.Append("@CreateTime",model.CreateTime);
		db.Parameters.Append("@ModifyTime",model.ModifyTime);
		    DataTable dt = db.Select("insert into [Shop_ProductCategories]([AttrTplCateID],[Name],[ItemCount],[ParentID],[ParentPath],[Depth],[Sequence],[IsRecommend],[IsHidden],[CreateTime],[ModifyTime]) values (@AttrTplCateID,@Name,@ItemCount,@ParentID,@ParentPath,@Depth,@Sequence,@IsRecommend,@IsHidden,@CreateTime,@ModifyTime);select @@Identity;");
			long newID = long.Parse(dt.Rows[0][0].ToString());
			model.ID = newID;
			return newID;
		}
		
		public int Update(ADeeWu.HuoBi3J.Model.Shop_ProductCategories model)
		{
			db.Parameters.Clear();
		db.Parameters.Append("@ID",model.ID);
		db.Parameters.Append("@AttrTplCateID",model.AttrTplCateID);
		db.Parameters.Append("@Name",model.Name);
		db.Parameters.Append("@ItemCount",model.ItemCount);
		db.Parameters.Append("@ParentID",model.ParentID);
		db.Parameters.Append("@ParentPath",model.ParentPath);
		db.Parameters.Append("@Depth",model.Depth);
		db.Parameters.Append("@Sequence",model.Sequence);
		db.Parameters.Append("@IsRecommend",model.IsRecommend);
		db.Parameters.Append("@IsHidden",model.IsHidden);
		db.Parameters.Append("@CreateTime",model.CreateTime);
		db.Parameters.Append("@ModifyTime",model.ModifyTime);
			return db.ExecuteSql("update [Shop_ProductCategories] set [AttrTplCateID]=@AttrTplCateID,[Name]=@Name,[ItemCount]=@ItemCount,[ParentID]=@ParentID,[ParentPath]=@ParentPath,[Depth]=@Depth,[Sequence]=@Sequence,[IsRecommend]=@IsRecommend,[IsHidden]=@IsHidden,[CreateTime]=@CreateTime,[ModifyTime]=@ModifyTime where [ID]=@ID");
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
			string sql = String.Format("update [{0}] set {1}=@{1}","Shop_ProductCategories",columnName);
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
			
			string sql = String.Format("update [{0}] ","Shop_ProductCategories");
			
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
			return db.ExecuteSql("delete from [Shop_ProductCategories]  where  @ID=ID");
		}
		
		/// <summary>
		/// 无条件删除所有记录
		/// </summary>
		/// <param name="where">可带变量条件</param>
		/// <returns>影响行数</returns>
		public int DeleteAll()
		{
			string sql = string.Format("delete from [{0}] ", "Shop_ProductCategories");
			return db.ExecuteSql(sql);

		}
		
		/// <summary>
		/// 根据条件删除记录,当条件为空时将会停止执行操作(删除所有记录请使用DeleteAll)
		/// </summary>
		/// <param name="where">可带变量条件</param>
		/// <returns>影响行数</returns>
		public int Delete(string where)
        {
            string sql = string.Format("delete from [{0}] where 1=2 ", "Shop_ProductCategories");
			if(string.IsNullOrEmpty(where)){
				return -1;
			}
            return db.ExecuteSql(sql + " or( " + where + ")");
        }

        public int Delete(string columnName, object value)
        {
            string sql = string.Format("delete from [{0}] where {1}=@{1} ", "Shop_ProductCategories",columnName);
			db.Parameters.Clear();
            db.Parameters.Append("@" + columnName, value);
            return db.ExecuteSql(sql);
        }
		
		public ADeeWu.HuoBi3J.Model.Shop_ProductCategories GetEntity(long  ID)
		{
			db.Parameters.Clear();
		db.Parameters.Append("@ID",ID);
			DataTable dt = db.Select("select * from [Shop_ProductCategories] where 1=1  and [ID]=@ID");
			if(dt.Rows.Count==0) return null;
			DataRow dr = dt.Rows[0];
			ADeeWu.HuoBi3J.Model.Shop_ProductCategories Entity = new ADeeWu.HuoBi3J.Model.Shop_ProductCategories();
			Entity.ID = long.Parse(dr["ID"].ToString());
			Entity.AttrTplCateID = long.Parse(dr["AttrTplCateID"].ToString());
			Entity.Name = (string)(dr["Name"]);
			Entity.ItemCount = int.Parse(dr["ItemCount"].ToString());
			Entity.ParentID = long.Parse(dr["ParentID"].ToString());
			Entity.ParentPath = (string)(dr["ParentPath"]);
			Entity.Depth = int.Parse(dr["Depth"].ToString());
			Entity.Sequence = int.Parse(dr["Sequence"].ToString());
			Entity.IsRecommend = bool.Parse(dr["IsRecommend"].ToString());
			Entity.IsHidden = bool.Parse(dr["IsHidden"].ToString());
			Entity.CreateTime = DateTime.Parse(dr["CreateTime"].ToString());
			Entity.ModifyTime = DateTime.Parse(dr["ModifyTime"].ToString());
			return Entity;
		}
		
		
		public ADeeWu.HuoBi3J.Model.Shop_ProductCategories GetEntity(string[] columns,params object[] values)
		{
			ADeeWu.HuoBi3J.Model.Shop_ProductCategories[] EntityList = GetEntityList("",columns,values);
			if(EntityList.Length==0)return null;
			return EntityList[0];
		}
		
		public ADeeWu.HuoBi3J.Model.Shop_ProductCategories GetEntity(string where)
		{
			DataTable dt = this.Select(where,"");
			if(dt.Rows.Count==0) return null;
			DataRow dr = dt.Rows[0];
			ADeeWu.HuoBi3J.Model.Shop_ProductCategories Entity = new ADeeWu.HuoBi3J.Model.Shop_ProductCategories();
			Entity.ID = long.Parse(dr["ID"].ToString());
			Entity.AttrTplCateID = long.Parse(dr["AttrTplCateID"].ToString());
			Entity.Name = (string)(dr["Name"]);
			Entity.ItemCount = int.Parse(dr["ItemCount"].ToString());
			Entity.ParentID = long.Parse(dr["ParentID"].ToString());
			Entity.ParentPath = (string)(dr["ParentPath"]);
			Entity.Depth = int.Parse(dr["Depth"].ToString());
			Entity.Sequence = int.Parse(dr["Sequence"].ToString());
			Entity.IsRecommend = bool.Parse(dr["IsRecommend"].ToString());
			Entity.IsHidden = bool.Parse(dr["IsHidden"].ToString());
			Entity.CreateTime = DateTime.Parse(dr["CreateTime"].ToString());
			Entity.ModifyTime = DateTime.Parse(dr["ModifyTime"].ToString());
			return Entity;
		}
		
		public ADeeWu.HuoBi3J.Model.Shop_ProductCategories[] GetEntityList(string orderBy,string[] columns,params object[] values)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * from [Shop_ProductCategories] where 1=1");
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
           
            ADeeWu.HuoBi3J.Model.Shop_ProductCategories[] EntityList = new ADeeWu.HuoBi3J.Model.Shop_ProductCategories[dt.Rows.Count];
			 if (dt.Rows.Count == 0) return EntityList;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
				DataRow dr = dt.Rows[i];
                ADeeWu.HuoBi3J.Model.Shop_ProductCategories Entity = new ADeeWu.HuoBi3J.Model.Shop_ProductCategories();
				Entity.ID = long.Parse(dr["ID"].ToString());
				Entity.AttrTplCateID = long.Parse(dr["AttrTplCateID"].ToString());
				Entity.Name = (string)(dr["Name"]);
				Entity.ItemCount = int.Parse(dr["ItemCount"].ToString());
				Entity.ParentID = long.Parse(dr["ParentID"].ToString());
				Entity.ParentPath = (string)(dr["ParentPath"]);
				Entity.Depth = int.Parse(dr["Depth"].ToString());
				Entity.Sequence = int.Parse(dr["Sequence"].ToString());
				Entity.IsRecommend = bool.Parse(dr["IsRecommend"].ToString());
				Entity.IsHidden = bool.Parse(dr["IsHidden"].ToString());
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
			return db.Select(-1,-1,"Shop_ProductCategories","ID",where,orderBy);
		}
		
		
		
		/// <summary>
        /// 分页查询数据(查询所有数据设置<paramref name="pageIndex"/>为-1
        /// </summary>
        /// <param name="pageSize">每页大小 设置-1 查询所有数据 </param>
        /// <param name="pageIndex">页码 设置-1 查询所有数据 </param>
        /// <returns></returns>
		public DataTable Select(long pageSize,long pageIndex)
		{
			return db.Select(pageSize,pageIndex,"Shop_ProductCategories","ID","","");
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
			return db.Select(pageSize,pageIndex,"Shop_ProductCategories","ID","",orderBy);
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
			return db.Select(pageSize,pageIndex,"Shop_ProductCategories","ID",where,orderBy);
		}
		
		
		
		
		
	}
	
}


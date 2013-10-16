using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ADeeWu.HuoBi3J.SQL.SqlBuilder
{
    public abstract class PageSqlBuilder
    {
        private long _pageSize = 10;
        /// <summary>
        /// <para>分页大小</para>
        /// 默认为10
        /// </summary>
        public long PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        private long _pageIndex = 1;
        /// <summary>
        /// <para>分页索引</para>
        /// 页码从1开始,少于1时查询所有
        /// </summary>
        public long PageIndex
        {
            get { return _pageIndex; }
            set { _pageIndex = value; }
        }

        private string _where = string.Empty;
        /// <summary>
        /// 筛选条件
        /// </summary>
        public string Where
        {
            get { return _where == null ? string.Empty : _where; }
            set { _where = value; }
        }

        private string _orderBy = string.Empty;
        /// <summary>
        /// <para>排序</para>
        /// 多个排序用逗号分开
        /// <example>addTime desc,[order] asc</example>
        /// </summary>
        public string OrderBy
        {
            get { return _orderBy; }
            set { _orderBy = value; }
        }

        private bool _pagingByDesc = true;
        /// <summary>
        /// <para>设置或获取是否倒序分页</para>
        /// 默认True
        /// </summary>
        public bool PagingByDesc
        {
            get { return _pagingByDesc; }
            set { _pagingByDesc = value; }
        }

        private string _sourceName = string.Empty;
        /// <summary>
        /// <para>数据源名称(表,视图)</para>
        /// 关键字需要添加中括号修饰
        /// </summary>
        public string SourceName
        {
            get { return _sourceName; }
            set { _sourceName = value; }
        }

        private string _identity = string.Empty;
        /// <summary>
        /// <para>设置或获取用于分页的标识字段(无重复字段)</para>
        /// 关键字需要添加中括号修饰
        /// </summary>
        public string Identity
        {
            get { return _identity; }
            set { _identity = value; }
        }


        protected string _pagingSQL = string.Empty;
        /// <summary>
        /// <para>获取分页SQL</para>
        /// 请调用GenerateSQL()
        /// </summary>
        public string PagingSQL
        {
            get { return this._pagingSQL; }
        }

        protected string _countSQL = string.Empty;
        /// <summary>
        /// <para>根据查询条件获取总记录数SQL</para>
        /// 请调用GenerateSQL()
        /// </summary>
        public string CountSQL
        {
            get { return this._countSQL; }
        }

        private string _NotRepeatField = string.Empty;
        public string NotRepeatField
        {

            get { return _NotRepeatField; }
            set { _NotRepeatField = value; }
        }

        protected virtual void Valid()
        {
            if (this.SourceName.Length == 0)
            {
                throw new Exception("SourceName属性不能为空!请设置为表或视图名称");
            }
        }
        

        /// <summary>
        /// <para>构造SQL语句</para>
        /// <para>通过PagingSql属性获取分页语句</para>
        /// <para>通过CountSql属性获取统计记录语句</para>
        /// </summary>
        public abstract void GenerateSql();
    }
}

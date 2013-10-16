using System;
using System.Collections.Generic;
using System.Text;

namespace ADeeWu.HuoBi3J.SQL.SqlBuilder
{
    public class SortPageSqlBuilder:PageSqlBuilder
    {
        public SortPageSqlBuilder() { }

        public SortPageSqlBuilder(string sourceName, string identity, string where, long pageSize, long pageIndex, string orderBy)
        {
                this.SourceName = sourceName;
                this.Identity = identity;
                this.Where = where;
                this.PageSize = pageSize;
                this.PageIndex = pageIndex;
                this.OrderBy = orderBy;
        }

            /// <summary>
            /// <para>构造SQL语句</para>
            /// <para>通过PagingSql属性获取分页语句</para>
            /// <para>通过CountSql属性获取统计记录语句</para>
            /// </summary>
            public override void GenerateSql() {
                this.Valid();
                string sql = string.Empty;
                string AscOrDesc = this.PagingByDesc ? "desc" : "asc";
                if (this.PageIndex < 1 || PageSize < 1)
                {
                    sql = string.Format("select * from {0} where 1=1 [$Where] order by [$OrderBy] {1} {2}", this.SourceName, this.Identity, AscOrDesc);
                }
                else if (this.PageIndex == 1) {
                    sql = string.Format("select top {0} * from {1} where 1=1 [$Where] order by [$OrderBy] {2} {3}", this.PageSize, this.SourceName, this.Identity, AscOrDesc);
                }
                else {

                    /*主要语句
                     @"select top {0} * from {1} where {2} not in (
                        select top {3} {2} from {1} [$InnerWhere] order by {2} {4}[$OrderBy] 
                        ) [$OuterWhere] order by {2}{4}[$OrderBy]";
                    */
                    sql = @"select top {0} * from {1} where {2} not in ( select top {3} {2} from {1} where 1=1 [$Where] order by [$OrderBy] {2} {4} ) [$Where] order by [$OrderBy] {2} {4} ";

                    sql = string.Format(sql,
                        this.PageSize,
                        this.SourceName,
                        this.Identity,
                        (this.PageIndex - 1) * this.PageSize,
                        AscOrDesc
                        );
                }

                this._countSQL = string.Format("select count({0}) from {1} where 1=1 [$Where] ", this.Identity, this.SourceName);

                if (this.Where.Length > 0) {
                    sql = sql.Replace(
                        "[$Where]",
                        string.Format("and {0}", this.Where)
                        );
                    this._countSQL = this._countSQL.Replace(
                        "[$Where]",
                        string.Format("and {0}", this.Where)
                        );
                }
                else {
                    sql = sql.Replace("[$Where]", "");
                    this._countSQL = this._countSQL.Replace("[$Where]", "");
                }

                if (this.OrderBy.Length > 0) {
                    sql = sql.Replace(
                        "[$OrderBy]",
                        string.Format("{0},", this.OrderBy)
                        );
                }
                else {
                    sql = sql.Replace("[$OrderBy]", "");
                }

                this._pagingSQL = sql;

            }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ADeeWu.HuoBi3J.SQL.SqlBuilder
{
    public class MySqlPageSqlBuilder:PageSqlBuilder
    {
        public MySqlPageSqlBuilder() { }

        public MySqlPageSqlBuilder(string sourceName, string identity, string where, long pageSize, long pageIndex, string orderBy)
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
                if (this.PageIndex < 1 || this.PageSize < 1)
                {
                    sql = string.Format("select * from {0} where 1=1 [$Where] order by [$OrderBy] {1} {2}", this.SourceName, this.Identity, AscOrDesc);
                }
                else if (this.PageSize == 1 && this.PageIndex == 1)
                {
                    sql = string.Format("select * from {0} where 1=1 [$Where] order by [$OrderBy] {1} {2}", this.SourceName, this.Identity, AscOrDesc);
                }
                else if (this.PageIndex == 1)
                {
                    sql = string.Format("select * from {0} where 1=1 [$Where] order by [$OrderBy] {1} {2} limit 1,{3}", this.SourceName, this.Identity, AscOrDesc, this.PageSize);
                }
                else
                {

                    sql = string.Format("select * from {0} where 1=1 [$Where] order by [$OrderBy] {1} {2} limit {3},{4}",
                         this.SourceName,
                        this.Identity,
                        AscOrDesc,
                        this.PageSize,
                        this.PageIndex - 1
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

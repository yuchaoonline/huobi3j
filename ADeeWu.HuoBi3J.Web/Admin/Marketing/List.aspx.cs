using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.Admin.Marketing
{
    public partial class List : PageBase
    {

        public override string PageID
        {
            get
            {
                return "015003";
            }
        }

        DataBase db = DataBase.Create();
        protected void Page_Load(object sender, EventArgs e)
        {
            db.Parameters.Clear();
            int pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlInt("pagesize", ADeeWu.HuoBi3J.Web.Admin.PageBase.DataList_PageSize);
            int pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlInt("page", 1);


            string title = ADeeWu.HuoBi3J.Libary.WebUtility.UpdateRequestStr("title", "", true);
            string userName = ADeeWu.HuoBi3J.Libary.WebUtility.UpdateRequestStr("UserName", "", true);
            
            string begintime = beginTimeSelector.Text ;
            string endtime = endTimeSelector.Text; ;
            //string endtime = ADeeWu.HuoBi3J.Libary.WebUtility.UpdateRequestStr("txtendtime", "", true);
            string checkstate= ddlCheckState.SelectedValue;

            StringBuilder builderWhere = new StringBuilder();
            List<SqlParameter> parameters = new List<SqlParameter>();
            builderWhere.Append(" 1=1");
            //db.Parameters.Append("@CorpID", string.Format("{0}", LoginUser.CorpID));
            if(checkstate!="-1")
            {
                builderWhere.Append(" and CheckState=@CheckState");
                db.Parameters.Append("@CheckState", string.Format("{0}",checkstate));
            }
            if (title != "")
            {
                builderWhere.Append(" and Title like @Title");
                db.Parameters.Append("@Title", string.Format("%{0}%", title));
                this.Pager1.AppendUrlParam("title", title);
            }
            if (userName != "")
            {
                builderWhere.Append(" and Name like @Name");
                db.Parameters.Append("@Name", string.Format("%{0}%", userName));
                this.Pager1.AppendUrlParam("UserName", title);
            }
            if (begintime.Length > 0 && endtime.Length > 0)
            {
                builderWhere.Append(" and CreateTime between @begintime and @endtime");
                db.Parameters.Append("@begintime", string.Format("{0}", begintime + " 0:00"));
                db.Parameters.Append("@endtime", string.Format("{0}", DateTime.Parse(endtime).AddDays(1).ToString("yyyy-MM-dd") + " 0:00"));
                this.Pager1.AppendUrlParam("txtbegintime", begintime);
                this.Pager1.AppendUrlParam("txtendtime", endtime);
            }
            else
            {
                if (begintime.Length > 0)
                {
                    builderWhere.Append(" and CreateTime >= @begintime ");
                    db.Parameters.Append("@begintime", string.Format("{0}", begintime + " 0:00"));
                    this.Pager1.AppendUrlParam("txtbegintime", begintime);
                }
                if (endtime.Length > 0)
                {
                    builderWhere.Append(" and CreateTime <= @endtime ");
                    db.Parameters.Append("@endtime", string.Format("{0}", DateTime.Parse(endtime).AddDays(1).ToString("yyyy-MM-dd") + " 0:00"));
                    this.Pager1.AppendUrlParam("txtendtime", endtime);
                }

            }
            
            db.EnableRecordCount = true;
            this.gvData.DataSource = db.Select(pageSize, pageIndex, "vw_Market_Infos", "ID", builderWhere.ToString(), " CreateTime desc");
            this.gvData.DataBind();

            
            this.Pager1.PageSize = pageSize;
            this.Pager1.PageIndex = pageIndex;
            this.Pager1.TotalRecords = Convert.ToInt32(db.RecordCount);
        }
    }
}

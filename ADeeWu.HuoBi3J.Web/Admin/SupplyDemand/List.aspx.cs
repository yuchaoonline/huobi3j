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
using System.Text;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.Admin.SupplyDemand
{
    public partial class List : PageBase
    {

        public override string PageID
        {
            get
            {
                return "017003";
            }
        }

        DataBase db = DataBase.Create();
        protected void Page_Load(object sender, EventArgs e)
        {
            int pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlInt("pagesize", ADeeWu.HuoBi3J.Web.Admin.PageBase.DataList_PageSize);
            int pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlInt("page", 1);
            string title = ADeeWu.HuoBi3J.Libary.WebUtility.GetFormStr("title", "");
            string name = ADeeWu.HuoBi3J.Libary.WebUtility.GetFormStr("name", "");
            string usertype = ADeeWu.HuoBi3J.Libary.WebUtility.GetFormStr("ddlUserType", "-1");
            string checkstate = ADeeWu.HuoBi3J.Libary.WebUtility.GetFormStr("ddlCheckState", "-1");
            
            string begintime = this.beginTime.Text;
            string endtime = this.endTime.Text;
            StringBuilder builderWhere = new StringBuilder();

            builderWhere.Append(" 1=1 ");

            if (IsPostBack)
            {
                if (begintime.Length > 0 && endtime.Length > 0)
                {
                    builderWhere.Append(" and CreateTime between @begintime and @endtime");
                    db.Parameters.Append("@begintime", string.Format("{0}", begintime + " 0:00"));
                    db.Parameters.Append("@endtime", DateTime.Parse(endtime).AddDays(1).ToString("yyyy-MM-dd") + " 0:00");

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
                        db.Parameters.Append("@endtime", DateTime.Parse(endtime).AddDays(1).ToString("yyyy-MM-dd") + " 0:00");
                        this.Pager1.AppendUrlParam("txtendtime", endtime);
                    }

                }

                if (title != "")
                {
                    builderWhere.Append(" and Title like @Title");
                    db.Parameters.Append("@Title", string.Format("%{0}%", title));
                    this.Pager1.AppendUrlParam("title", title);
                }
                if (name != "")
                {
                    builderWhere.Append(" and Name like @Name");
                    db.Parameters.Append("@Name", string.Format("%{0}%", name));
                    this.Pager1.AppendUrlParam("name", name);
                }
                if (usertype != ""&&usertype!="-1")
                {
                    builderWhere.Append(" and UserType =@UserType");
                    db.Parameters.Append("@UserType", usertype);
                    this.Pager1.AppendUrlParam("ddlUserType", usertype);
                }
                if (checkstate != "" && checkstate != "-1")
                {
                    builderWhere.Append(" and CheckState =@CheckState");
                    db.Parameters.Append("@CheckState", checkstate);
                    this.Pager1.AppendUrlParam("ddlCheckState", checkstate);
                }
                
            }

            db.EnableRecordCount = true;
            this.gvData.DataSource = db.Select(pageSize, pageIndex,
                    "vw_SD_User", "ID", builderWhere.ToString(), "CreateTime desc"
               );
            this.gvData.DataBind();
            this.Pager1.PageSize = pageSize;
            this.Pager1.PageIndex = pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }
    }
}


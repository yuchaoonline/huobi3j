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
using System.Text;
using System.Collections.Generic;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.My.User.SupplyDemand.Favs
{
    public partial class Default : Class.PageBase_MyUser
    {
        protected DataBase db = DataBase.Create();
        protected void Page_Load(object sender, EventArgs e)
        {
            int pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlInt("pagesize", ADeeWu.HuoBi3J.Web.Admin.PageBase.DataList_PageSize);
            int pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlInt("page", 1);
            string note = ADeeWu.HuoBi3J.Libary.WebUtility.GetFormStr("note", "");
            string begintime = this.beginTime.Text;
            string endtime = this.endTime.Text;
            StringBuilder builderWhere = new StringBuilder();
            builderWhere.Append(" UserID=@UserID ");
            db.Parameters.Append("@UserID", this.LoginUser.UserID);
            if (IsPostBack)
            {
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

                if (note != "")
                {
                    builderWhere.Append(" and Notes like @Note");
                    db.Parameters.Append("@Note", string.Format("%{0}%", note));
                    this.Pager1.AppendUrlParam("note", note);
                }
            }

            db.EnableRecordCount = true;
            this.gvData.DataSource =db.Select(pageSize, pageIndex,"vw_SD_Favs", "ID", builderWhere.ToString(), "CreateTime desc");
            this.gvData.DataBind();
            this.Pager1.PageSize = pageSize;
            this.Pager1.PageIndex = pageIndex;
            this.Pager1.TotalRecords =(int)db.RecordCount;
        }
    }
}

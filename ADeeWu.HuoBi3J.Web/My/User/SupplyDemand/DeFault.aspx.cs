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
using ADeeWu.HuoBi3J.Web.Class;
using System.Text;
using System.Collections.Generic;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.My.User.SupplyDemand
{
    public partial class DeFault : PageBase_MyUser
    {
        DataBase db = DataBase.Create();
        protected void Page_Load(object sender, EventArgs e)
        {
            int pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlInt("pagesize", ADeeWu.HuoBi3J.Web.Admin.PageBase.DataList_PageSize);
            int pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlInt("page", 1);

           
            string title = ADeeWu.HuoBi3J.Libary.WebUtility.GetFormStr("title", "");

            string begintime = this.beginTime.Text;
            string endtime = this.endTime.Text;
            StringBuilder builderWhere = new StringBuilder();
            List<IDataParameter> parameters = new List<IDataParameter>();
            builderWhere.Append(" UserID=@UserID ");
            db.Parameters.Append("@UserID", this.LoginUser.UserID);

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
            }

            db.EnableRecordCount = true;
            this.gvData.DataSource = db.Select(pageSize, pageIndex,
                    "SD_SupplyDemands", "ID",builderWhere.ToString(), "CreateTime desc");
            // this.Pager1.AppendUrlParam("key", loginName);


            //this.key.Value = loginName;

            this.gvData.DataBind();
            this.Pager1.PageSize = pageSize;
            this.Pager1.PageIndex = pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

         
    }
}

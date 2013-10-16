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
using System.Data.SqlClient;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.Admin.Houses
{
    public partial class List : PageBase
    {
        DataBase db = DataBase.Create();
        ADeeWu.HuoBi3J.DAL.HouseInfos dalhouse = new ADeeWu.HuoBi3J.DAL.HouseInfos();

        public override string PageID
        {
            get
            {
                return "013003";
            }
        }


    
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {
                bindData();
            }

        }
        void bindData()
        {
            long pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("pagesize", PageBase.DataList_PageSize);
            long pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("page", 1);


            string title = ADeeWu.HuoBi3J.Libary.WebUtility.UpdateRequestStr("txtTitle", "", true);

            int housestruct = ADeeWu.HuoBi3J.Libary.WebUtility.UpdateRequestInt("ddlhousestrcts", -1, true);
            string begintime = ADeeWu.HuoBi3J.Libary.WebUtility.UpdateRequestStr("txtbegintime", "", true);
            string endtime = ADeeWu.HuoBi3J.Libary.WebUtility.UpdateRequestStr("txtendtime", "", true);
            //string endtime = ADeeWu.HuoBi3J.Libary.WebUtility.UpdateRequestStr("txtendtime", "", true);

            db.Parameters.Clear();
            StringBuilder builderWhere = new StringBuilder();

            builderWhere.Append(" 1=1 ");


            if (title != "")
            {
                builderWhere.Append(" and Title like @Title");
                db.Parameters.Append("@Title", string.Format("%{0}%", title));
                this.Pager1.AppendUrlParam("txtTitle", title);
            }
            if(ddlstate.SelectedValue!="-1")
            {
                builderWhere.Append(" and CheckState = @CheckState");
                db.Parameters.Append("@CheckState", string.Format("{0}", ddlstate.SelectedValue));
                this.Pager1.AppendUrlParam("ddlstate", ddlstate.SelectedValue);
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
            if (housestruct != -1)
            {
                builderWhere.Append(" and HouseStructValue = @HouseStructValue");
                db.Parameters.Append("@HouseStructValue", string.Format("{0}", housestruct));
                this.Pager1.AppendUrlParam("ddlhousestrcts", housestruct.ToString());
            }

            db.EnableRecordCount = true;
           
            this.gvData.DataSource = db.Select(pageSize, pageIndex,"vw_HouseInfos","id", builderWhere.ToString(), "CreateTime DESC ");
            this.gvData.DataBind();
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            bindData();
        }




        
    }
}

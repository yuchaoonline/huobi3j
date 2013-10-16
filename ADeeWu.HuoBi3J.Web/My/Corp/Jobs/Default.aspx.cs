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
using ADeeWu.HuoBi3J.Libary;
namespace ADeeWu.HuoBi3J.Web.My.Corp.Jobs
{
    public partial class Default : ADeeWu.HuoBi3J.Web.Class.PageBase_MyCorp
    {

        public override string FunctionCode
        {
            get
            {
                return "Corp-Jobs-Default";
            }
        }
       

        DataBase db = DataBase.Create();
        long pageSize = 20;
        long pageIndex = 1;
        string jobName = string.Empty;
        DateTime? beginTime = null;
        DateTime? endTime = null;

        protected void Page_Load(object sender, EventArgs e)
        {


            pageSize = Utility.GetLong(Request["pagesize"], 20, 5, 20);
            pageIndex = WebUtility.GetRequestInt("page", 1);

             if (!IsPostBack)//获取外部参数
            {
                jobName = WebUtility.GetUrlStr("jobName", "");
                beginTime = Utility.GetDateTime(Request.QueryString["beginTime"], null);
                endTime = Utility.GetDateTime(Request.QueryString["endTime"], null);
            }
            else//更新参数
            {
                jobName = Utility.GetStr(Request.QueryString["jobName"], this.txtJobName.Text, "", true);
                beginTime = Utility.GetDateTime(Request.QueryString["beginTime"], this.txtBeginTime.Text, null);
                endTime = Utility.GetDateTime(Request.QueryString["endTime"], this.txtEndTime.Text, null);
            }
            


            StringBuilder builderWhere = new StringBuilder();
           
            builderWhere.Append(" CorpID=@CorpID");
            db.Parameters.Append("@CorpID", string.Format("{0}", LoginUser.CorpID));

            if (jobName != "")
            {
                builderWhere.Append(" and Title like @Title");
                db.Parameters.Append("@Title", string.Format("%{0}%", jobName));
                this.Pager1.AppendUrlParam("txtTitle", jobName);
            }
            if (beginTime.HasValue && endTime.HasValue)
            {
                builderWhere.Append(" and CreateTime between @begintime and @endtime");
                db.Parameters.Append("@begintime", beginTime.Value.ToString("yyyy-MM-dd 0:00:00"));
                db.Parameters.Append("@endtime", endTime.Value.ToString("yyyy-MM-dd 23:59:59"));
                this.Pager1.AppendUrlParam("beginTime", beginTime.Value.ToString("yyyy-MM-dd"));
                this.Pager1.AppendUrlParam("endTime", endTime.Value.ToString("yyyy-MM-dd"));
            }
            else
            {
                if(beginTime.HasValue)
                {
                    builderWhere.Append(" and CreateTime >= @begintime ");
                    db.Parameters.Append("@begintime", beginTime.Value.ToString("yyyy-MM-dd 0:00:00"));
                    this.Pager1.AppendUrlParam("beginTime", beginTime.Value.ToString("yyyy-MM-dd"));
                }
                if (endTime.HasValue)
                {
                    builderWhere.Append(" and CreateTime <= @endtime ");
                    db.Parameters.Append("@endtime", endTime.Value.ToString("yyyy-MM-dd 23:59:59"));
                    this.Pager1.AppendUrlParam("endTime", endTime.Value.ToString("yyyy-MM-dd"));
                }

            }
            
            db.EnableRecordCount = true;
            this.gvData.DataSource = db.Select(pageSize, pageIndex, "vw_Jobs", "ID", builderWhere.ToString(), " CreateTime desc");
            this.gvData.DataBind();

            
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }

        
        
    }
}

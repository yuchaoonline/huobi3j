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
using System.Data.SqlClient;
using System.Collections.Generic;
using ADeeWu.HuoBi3J.Web.Class;
using System.Text;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.My.User.Fav_Jobs
{
    public partial class Default : Class.PageBase_MyUser
    {

        public override string FunctionCode
        {
            get
            {
                return "My-User-FavJobs";
            }
        }

        private DateTime? beginTime = null;
        protected Button btnSubmit;
        private DataBase db = DataBase.Create();
        private DateTime? endTime = null;
        private string note = string.Empty;
        private long pageIndex = 1L;
        private long pageSize = 20L;

        protected void Page_Load(object sender, EventArgs e)
        {
            pageSize = Utility.GetLong(Request["pagesize"], 20, 5, 20);
            pageIndex = WebUtility.GetRequestLong("page", 1);

            if (!base.IsPostBack)
            {
                this.note = WebUtility.GetRequestStr("note", "");
                this.beginTime = Utility.GetDateTime(base.Request.QueryString["beginTime"], null);
                this.endTime = Utility.GetDateTime(base.Request.QueryString["endTime"], null);
                this.bindData();
            }
        }

        private void bindData()
        {
            StringBuilder builderWhere = new StringBuilder();
            long realBusinessUserID = base.GetRealBusinessUserID();
            builderWhere.Append(" UserID=@UserID ");
            this.db.Parameters.Append("@UserID", realBusinessUserID);
            if (this.beginTime.HasValue && this.endTime.HasValue)
            {
                builderWhere.Append(" and CreateTime between @begintime and @endtime");
                this.db.Parameters.Append("@begintime", this.beginTime.Value.ToString("yyyy-MM-dd 0:00"));
                this.db.Parameters.Append("@endtime", this.endTime.Value.ToString("yyyy-MM-dd 23:59:59"));
                this.Pager1.AppendUrlParam("beginTime", this.beginTime.Value.ToString("yyyy-MM-dd"));
                this.Pager1.AppendUrlParam("endTime", this.endTime.Value.ToString("yyyy-MM-dd"));
                this.txtBeginTime.Text = this.beginTime.Value.ToString("yyyy-MM-dd");
                this.txtEndTime.Text = this.endTime.Value.ToString("yyyy-MM-dd");
            }
            else
            {
                if (this.beginTime.HasValue)
                {
                    builderWhere.Append(" and CreateTime >= @begintime ");
                    this.db.Parameters.Append("@begintime", this.beginTime.Value.ToString("yyyy-MM-dd 0:00"));
                    this.Pager1.AppendUrlParam("beginTime", this.beginTime.Value.ToString("yyyy-MM-dd"));
                    this.txtBeginTime.Text = this.beginTime.Value.ToString("yyyy-MM-dd");
                }
                if (this.endTime.HasValue)
                {
                    builderWhere.Append(" and CreateTime <= @endtime ");
                    this.db.Parameters.Append("@endtime", this.endTime.Value.ToString("yyyy-MM-dd 23:59:59"));
                    this.Pager1.AppendUrlParam("endTime", this.endTime.Value.ToString("yyyy-MM-dd"));
                    this.txtEndTime.Text = this.endTime.Value.ToString("yyyy-MM-dd");
                }
            }
            if (this.note != "")
            {
                builderWhere.Append(" and Notes like @Note");
                this.db.Parameters.Append("@Note", string.Format("%{0}%", this.note));
                this.Pager1.AppendUrlParam("note", this.note);
                this.txtNote.Text = this.note;
            }
            this.db.EnableRecordCount = true;
            this.gvData.DataSource = this.db.Select(this.pageSize, this.pageIndex, "vw_Job_SeekerFavs", "ID", builderWhere.ToString(), "CreateTime desc");
            this.gvData.DataBind();
            this.Pager1.PageSize = (int)this.pageSize;
            this.Pager1.PageIndex = (int)this.pageIndex;
            this.Pager1.TotalRecords = (int)this.db.RecordCount;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            this.pageIndex = 1L;
            this.note = Utility.GetStr(base.Request.QueryString["note"], this.txtNote.Text, "", true);

            this.beginTime = Utility.GetDateTime(base.Request.QueryString["beginTime"], this.txtBeginTime.Text, null);
            this.endTime = Utility.GetDateTime(base.Request.QueryString["endTime"], this.txtEndTime.Text, null);
            this.bindData();
        }

        


      

    }
}

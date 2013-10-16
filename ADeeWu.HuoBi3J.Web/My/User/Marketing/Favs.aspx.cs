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
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.My.User.Marketing
{
    public partial class Favs : Class.PageBase_MyUser
    {

        public override string FunctionCode
        {
            get
            {
                return "My-User-Marketing-Favs";
            }
        }


        protected DataBase db = DataBase.Create();
        protected long pageSize = 20;
        protected long pageIndex = 1;
        string note = string.Empty;
        DateTime? beginTime = null;
        DateTime? endTime = null;

        protected void Page_Load(object sender, EventArgs e)
        {

            pageSize = Utility.GetLong(Request["pagesize"], 20, 5, 20);
            pageIndex = WebUtility.GetRequestLong("page", 1);

            if (!IsPostBack)//获取外部参数
            {
                note = WebUtility.GetRequestStr("note", "");
                beginTime = Utility.GetDateTime(Request.QueryString["beginTime"], null);
                endTime = Utility.GetDateTime(Request.QueryString["endTime"], null);
                bindData();
            }
           
        }

        void bindData()
        {

            long realBusinessUserID = this.GetRealBusinessUserID();

            StringBuilder builderWhere = new StringBuilder();
            builderWhere.Append(" UserID=@UserID ");
            db.Parameters.Append("@UserID", realBusinessUserID);

            if (beginTime.HasValue && endTime.HasValue)
            {
                builderWhere.Append(" and CreateTime between @begintime and @endtime");
                db.Parameters.Append("@begintime", beginTime.Value.ToString("yyyy-MM-dd 0:00"));
                db.Parameters.Append("@endtime", endTime.Value.ToString("yyyy-MM-dd 23:59:59"));
                this.Pager1.AppendUrlParam("beginTime", beginTime.Value.ToString("yyyy-MM-dd"));
                this.Pager1.AppendUrlParam("endTime", endTime.Value.ToString("yyyy-MM-dd"));

                this.txtBeginTime.Text = beginTime.Value.ToString("yyyy-MM-dd");
                this.txtEndTime.Text = endTime.Value.ToString("yyyy-MM-dd");
            }
            else
            {
                if (beginTime.HasValue)
                {
                    builderWhere.Append(" and CreateTime >= @begintime ");
                    db.Parameters.Append("@begintime", beginTime.Value.ToString("yyyy-MM-dd 0:00"));
                    this.Pager1.AppendUrlParam("beginTime", beginTime.Value.ToString("yyyy-MM-dd"));
                    this.txtBeginTime.Text = beginTime.Value.ToString("yyyy-MM-dd");
                }

                if (endTime.HasValue)
                {
                    builderWhere.Append(" and CreateTime <= @endtime ");
                    db.Parameters.Append("@endtime", endTime.Value.ToString("yyyy-MM-dd 23:59:59"));
                    this.Pager1.AppendUrlParam("endTime", endTime.Value.ToString("yyyy-MM-dd"));
                    this.txtEndTime.Text = endTime.Value.ToString("yyyy-MM-dd");
                }
            }


            if (note != "")
            {
                builderWhere.Append(" and Notes like @Note");
                db.Parameters.Append("@Note", string.Format("%{0}%", note));
                this.Pager1.AppendUrlParam("note", note);
                this.txtNote.Text = note;
            }
            

            db.EnableRecordCount = true;
            this.gvData.DataSource = db.Select(pageSize, pageIndex, "vw_Market_SeekerFavs", "ID", builderWhere.ToString(), " CreateTime desc");
            this.gvData.DataBind();
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            pageIndex = 1;
            note = Utility.GetStr(Request.QueryString["note"], this.txtNote.Text, "", true);
            beginTime = Utility.GetDateTime(Request.QueryString["beginTime"], this.txtBeginTime.Text, null);
            endTime = Utility.GetDateTime(Request.QueryString["endTime"], this.txtEndTime.Text, null);
            bindData();
        }
    }
}

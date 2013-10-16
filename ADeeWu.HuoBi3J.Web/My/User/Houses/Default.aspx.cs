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

namespace ADeeWu.HuoBi3J.Web.My.User.Houses
{
    public partial class Default :Class.PageBase_MyUser
    {

        public override string FunctionCode
        {
            get
            {
                return "My-User-Houses-Default";
            }
        }

        ADeeWu.HuoBi3J.DAL.HouseInfos dalHouse = new ADeeWu.HuoBi3J.DAL.HouseInfos();
        long pageSize = 20;
        long pageIndex = 1;
        string title = string.Empty;
        int houseStruct = -1;
        DateTime? beginTime = null;
        DateTime? endTime = null;

       
        protected void Page_Load(object sender, EventArgs e)
        {

            pageSize = Utility.GetLong(Request["pagesize"], 20, 5, 20);
            pageIndex = WebUtility.GetRequestLong("page", 1);

            if (!IsPostBack)//获取外部参数
            {
                title = WebUtility.GetRequestStr("title", "");
                houseStruct = WebUtility.GetRequestInt("houseStruct", -1);
                beginTime = Utility.GetDateTime(Request.QueryString["beginTime"], null);
                endTime = Utility.GetDateTime(Request.QueryString["endTime"], null);
                bindData();
            }
            
        }

        void bindData()
        {

            long realBusinessUserID = this.GetRealBusinessUserID();

            StringBuilder builderWhere = new StringBuilder();
            builderWhere.Append(" UserID=@UserID");
            dalHouse.Parameters.Append("@UserID", realBusinessUserID);

            if (title != "")
            {
                builderWhere.Append(" and Title like @Title");
                dalHouse.Parameters.Append("@Title", string.Format("%{0}%", title));
                this.Pager1.AppendUrlParam("title", title);
                this.txtTitle.Text = title;
            }

            if (beginTime.HasValue && endTime.HasValue)
            {
                builderWhere.Append(" and CreateTime between @begintime and @endtime");
                dalHouse.Parameters.Append("@begintime", beginTime.Value.ToString("yyyy-MM-dd 0:00"));
                dalHouse.Parameters.Append("@endtime", endTime.Value.ToString("yyyy-MM-dd 23:59:59"));
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
                    dalHouse.Parameters.Append("@begintime", beginTime.Value.ToString("yyyy-MM-dd 0:00"));
                    this.Pager1.AppendUrlParam("beginTime", beginTime.Value.ToString("yyyy-MM-dd"));
                    this.txtBeginTime.Text = beginTime.Value.ToString("yyyy-MM-dd");
                }

                if (endTime.HasValue)
                {
                    builderWhere.Append(" and CreateTime <= @endtime ");
                    dalHouse.Parameters.Append("@endtime", endTime.Value.ToString("yyyy-MM-dd 23:59:59"));
                    this.Pager1.AppendUrlParam("endTime", endTime.Value.ToString("yyyy-MM-dd"));
                    this.txtEndTime.Text = endTime.Value.ToString("yyyy-MM-dd");
                }
            }

            if (houseStruct > -1)
            {
                builderWhere.Append(" and HouseStructValue = @HouseStructValue");
                dalHouse.Parameters.Append("@HouseStructValue", houseStruct);
                this.Pager1.AppendUrlParam("houseStruct", houseStruct.ToString());
                this.ddlhousestrcts.SelectedValue = houseStruct.ToString();
            }

            dalHouse.EnableRecordCount = true;
            this.gvData.DataSource = dalHouse.Select(pageSize, pageIndex, builderWhere.ToString(), "CreateTime DESC ");
            this.gvData.DataBind();
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)dalHouse.RecordCount;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            pageIndex = 1;
            title = Utility.GetStr(Request.QueryString["title"], this.txtTitle.Text, "", true);
            houseStruct = Utility.GetInt(Request.QueryString["houseStruct"], this.ddlhousestrcts.SelectedValue, -1);
            beginTime = Utility.GetDateTime(Request.QueryString["beginTime"], this.txtBeginTime.Text, null);
            endTime = Utility.GetDateTime(Request.QueryString["endTime"], this.txtEndTime.Text, null);
            bindData();
        }
    }
}

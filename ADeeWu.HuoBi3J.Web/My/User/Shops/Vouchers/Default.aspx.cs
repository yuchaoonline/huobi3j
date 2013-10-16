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

namespace ADeeWu.HuoBi3J.Web.My.User.Shops.Vouchers
{
    public partial class Default :Class.PageBase_MyUser
    {
        DataBase db = DataBase.Create();
        long pageSize = 20;
        long pageIndex = 1;

        string title = string.Empty;


        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>          

        protected void Page_Load(object sender, EventArgs e)
        {

            pageSize = Utility.GetInt(Request["pagesize"], 20, 5, 20);
            pageIndex = WebUtility.GetRequestInt("page", 1);

            if (!IsPostBack)//获取外部参数
            {
                title = WebUtility.GetUrlStr("Title", "");
                bindData();
            }
        }

        void bindData()
        {
            StringBuilder builderWhere = new StringBuilder();

            builderWhere.Append("BuyerUserID=@BuyerUserID");
            db.Parameters.Append("@BuyerUserID", this.LoginUser.UserID);

            if (title != "")
            {
                builderWhere.Append(" and Title like @Title");
                db.Parameters.Append("@Title", string.Format("%{0}%", title));
                this.Pager1.AppendUrlParam("Title", Title);
                this.txtName.Text = title;
            }

            db.EnableRecordCount = true;
            this.gvData.DataSource = db.Select(pageSize, pageIndex, "vw_Shop_Users_Vouchers", "ID", builderWhere.ToString(), "CreateTime DESC ");
            this.gvData.DataBind();
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            pageIndex = 1;
            title = Utility.GetStr(Request.QueryString["title"], this.txtName.Text, "", true);
            bindData();
        }
    }
}

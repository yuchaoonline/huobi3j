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

namespace ADeeWu.HuoBi3J.Web.My.User.Shops.Orders
{
    public partial class Default : ADeeWu.HuoBi3J.Web.Class.PageBase_MyUser
    {
      
        DataBase db = DataBase.Create();
        long pageSize = 20;
        long pageIndex = 1;
        string orderCode = string.Empty;

          
        protected void Page_Load(object sender, EventArgs e)
        {

            pageSize = Utility.GetInt(Request["pagesize"], 20, 5, 20);
            pageIndex = WebUtility.GetRequestInt("page", 1);

            if (!IsPostBack)//获取外部参数
            {
                orderCode = WebUtility.GetRequestStr("order", "");
                bindData();
            }
        }

        void bindData()
        {
            StringBuilder builderWhere = new StringBuilder();
             builderWhere.Append(" BuyerUserID=@BuyerUserID");
            db.Parameters.Append("@BuyerUserID", LoginUser.UserID);

            if (this.orderCode.Length > 0)
            {
                builderWhere.Append(" and OrderCode like @OrderCode");
                db.Parameters.Append("@OrderCode", string.Format("%{0}%", orderCode));
                this.Pager1.AppendUrlParam("order", orderCode);
                this.txtOrderCode.Text = orderCode;
            }

           
            
            db.EnableRecordCount = true;

            this.gvData.DataSource = db.Select(pageSize, pageIndex, "vw_Shop_Orders", "ID", builderWhere.ToString(), "CreateTime DESC ");
            this.gvData.DataBind();

            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            pageIndex = 1;
            orderCode = Utility.GetStr(Request.QueryString["order"], this.txtOrderCode.Text, "", true);
            bindData();
        }

     



    }
}

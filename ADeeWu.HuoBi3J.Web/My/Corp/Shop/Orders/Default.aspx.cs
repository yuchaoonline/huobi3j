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
using System;


namespace ADeeWu.HuoBi3J.Web.My.Corp.Orders
{
    public partial class Default : ADeeWu.HuoBi3J.Web.Class.PageBase_MyCorp_Shop
    {

        DataBase db = DataBase.Create();
        long pageSize = 20;
        long pageIndex = 1;
        int orderState = -1;
        string orderCode = string.Empty;
        

        protected void Page_Load(object sender, EventArgs e)
        {

            pageSize = Utility.GetInt(Request["pagesize"], 20, 5, 20);
            pageIndex = WebUtility.GetRequestInt("page", 1);

            if (!IsPostBack)
            {
                orderState = WebUtility.GetRequestInt("state", -1);
                orderCode = WebUtility.GetRequestStr("orderCode", "");
                bindData();
            }
        }

        void bindData()
        {
            StringBuilder builderWhere = new StringBuilder();

            builderWhere.Append(" SellerCorpID=@SellerCorpID");
            db.Parameters.Append("@SellerCorpID", LoginUser.CorpID);

            if (orderCode.Trim().Length > 0)
            {
                builderWhere.Append(" and OrderCode like @OrderCode");
                db.Parameters.Append("@OrderCode", string.Format("%{0}%", orderCode));
                this.Pager1.AppendUrlParam("orderCode", orderCode);
                this.txtOrderCode.Text = orderCode.ToString();
            }
            
            if (orderState > -1)
            {
                builderWhere.AppendFormat(" and OrderState=" + orderState);
                Pager1.AppendUrlParam("state", orderState.ToString());
                this.ddlOrderState.SelectedValue = orderState.ToString();
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
            orderState = Utility.GetInt(Request.QueryString["state"], this.ddlOrderState.SelectedValue, -1);
            orderCode = Utility.GetStr(Request.QueryString["orderCode"], this.txtOrderCode.Text, "", true);
            bindData();
        }

    }
}
        
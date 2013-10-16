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


namespace ADeeWu.HuoBi3J.Web.My.Corp.Orders.AfterSaleRecords
{
    public partial class Default : ADeeWu.HuoBi3J.Web.Class.PageBase_MyCorp_Shop
    {

        DataBase db = DataBase.Create();
        long pageSize = 20;
        long pageIndex = 1;
        protected long orderDetailID = 0;
        string orderCode = string.Empty;//订单号优先 orderDetailID 作为查询条件

        protected void Page_Load(object sender, EventArgs e)
        {
            pageSize = Utility.GetInt(Request["pagesize"], 20, 5, 20);
            pageIndex = WebUtility.GetRequestInt("page", 1);
            orderDetailID = WebUtility.GetRequestLong("orderDetailID", 0);

            if (!IsPostBack)
            {
                orderCode = WebUtility.GetRequestStr("orderCode", "");
                bindData();
            }
        }

        void bindData()
        {
            StringBuilder builderWhere = new StringBuilder();
            builderWhere.Append("ServerCorpID=" + this.LoginUser.CorpID);

            if (orderCode.Length > 0)
            {
                builderWhere.Append(" and OrderCode=@OrderCode");
                db.Parameters.Append("@OrderCode", orderCode);
                this.Pager1.AppendUrlParam("orderCode", orderCode);
                this.txtOrderCode.Text = orderCode;
            }
            else
            {
                if (orderDetailID > 0)
                {
                    builderWhere.Append(" and OrderDetailID=@OrderDetailID");
                    db.Parameters.Append("@OrderDetailID", orderDetailID);
                    this.Pager1.AppendUrlParam("orderDetailID", orderDetailID.ToString());
                }
            }


            db.EnableRecordCount = true;
            this.gvData.DataSource = db.Select(pageSize, pageIndex, "vw_Shop_AfterSaleRecords", "ID", builderWhere.ToString(), "CreateTime DESC ");
            this.gvData.DataBind();

            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            pageIndex = 1;
            orderCode = Utility.GetStr(Request["orderCode"], this.txtOrderCode.Text, "", true);
            bindData();
        }          


    }
}
        
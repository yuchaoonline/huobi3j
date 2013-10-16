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

namespace ADeeWu.HuoBi3J.Web.My.Corp.Shop.Vouchers
{
    public partial class Default : ADeeWu.HuoBi3J.Web.Class.PageBase_MyCorp_Shop
    {
        DataBase db = DataBase.Create();
        long pageSize = 20;
        long pageIndex = 1;

        string buyerUIN = string.Empty;


      
        protected void Page_Load(object sender, EventArgs e)
        {

            pageSize = Utility.GetInt(Request["pagesize"], 20, 5, 20);
            pageIndex = WebUtility.GetRequestInt("page", 1);

            if (!IsPostBack)//获取外部参数
            {
                buyerUIN = WebUtility.GetUrlStr("uin", "");
                bindData();
            }
        }

        void bindData()
        {
            StringBuilder builderWhere = new StringBuilder();

            builderWhere.Append("SellerCorpID=@SellerCorpID");
            db.Parameters.Append("@SellerCorpID", LoginUser.CorpID);

            if (buyerUIN.Length > 0)
            {
                builderWhere.Append(" and BuyerUIN = @BuyerUIN");
                db.Parameters.Append("@BuyerUIN",buyerUIN);
                this.Pager1.AppendUrlParam("uin", buyerUIN);
                this.txtBuyerUIN.Text = buyerUIN;
            }

            db.EnableRecordCount = true;
            this.gvData.DataSource = db.Select(pageSize, pageIndex, "vw_Shop_Vouchers", "ID", builderWhere.ToString(), "CreateTime DESC ");
            this.gvData.DataBind();
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            pageIndex = 1;
            buyerUIN = this.txtBuyerUIN.Text.Trim();
            bindData();
        }

        
    }
}

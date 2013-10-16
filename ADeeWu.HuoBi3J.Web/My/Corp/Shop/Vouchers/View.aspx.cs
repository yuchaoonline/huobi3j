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
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using System.Text;

namespace ADeeWu.HuoBi3J.Web.My.Corp.Shop.Vouchers
{
    public partial class View : ADeeWu.HuoBi3J.Web.Class.PageBase_MyCorp_Shop
    {

        DataBase db = DataBase.Create();
        long id = WebUtility.GetRequestLong("id", 0);       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindData();
            }
        }

        void bindData()
        {

            if (id > 0)
            {

                DataTable dt = db.Select("select * from vw_Shop_Vouchers where ID={0} and SellerCorpID={1}", id, this.LoginUser.CorpID);

                 if (dt.Rows.Count == 0)
                 {
                        ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "当前没有电子凭证!");
                        return;
                 }                  
                
                DataRow dr = dt.Rows[0];
                this.lblTitle.Text = dr["Title"].ToString();
                this.lblBuyerUIN.Text = dr["BuyerUIN"].ToString();
                this.lblBuyerName.Text = dr["BuyerName"].ToString();
                this.lblBuyerLoginName.Text = dr["BuyerLoginName"].ToString();
                this.lblCreateTime.Text = dr["CreateTime"].ToString();
                this.lblContent.Text = dr["Content"].ToString();
            }
        }
               
       

    
    }
}

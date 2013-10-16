using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.My.User.Shops.Orders.AfterSaleRecords
{
    public partial class View : ADeeWu.HuoBi3J.Web.Class.PageBase_MyUser
    {
        DataBase db = DataBase.Create();

        long id = 0;
       
        protected void Page_Load(object sender, EventArgs e)
        {

            id = WebUtility.GetRequestLong("id", 0);
            
            if (!IsPostBack)//获取外部参数
            {               
                bindData();
            }
        }

        void bindData()
        {
            DataTable dt = db.Select("select * from vs_Shop_AfterSaleRecords where ID={0} and BuyerUserID={1}", id, this.LoginUser.UserID);


            if (dt.Rows.Count == 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "该记录已不存在！");
                return;
            }

            DataRow dr = dt.Rows[0];

            this.lblOrderCode.Text = dr["OrderCode"].ToString();
            this.lblProductName.Text = dr["ProductName"].ToString();
            this.txtCreatTime.Text = dr["CreatTime"].ToString();
            this.lblResult.Text = dr["Result"].ToString();
            this.lblNote.Text = dr["Note"].ToString();

        }         
                  
    }
}

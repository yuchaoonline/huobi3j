using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.My.User.Shops.Vouchers
{
    public partial class View : ADeeWu.HuoBi3J.Web.Class.PageBase_MyUser
    {
        DataBase db = DataBase.Create();
        long id = WebUtility.GetRequestLong("id", 0);
        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        

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
                DataTable dt = db.Select("select * from vw_Shop_Users_Vouchers where ID=" + id + " and BuyerUserID=" + this.LoginUser.UserID);

                if (dt.Rows.Count == 0)
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "当前没有电子凭证!");
                    return;
                }

                DataRow dr = dt.Rows[0];
                this.lblTitle.Text = dr["Title"].ToString();
                this.lblCorpName.Text = dr["CorpName"].ToString();
                this.lblCreateTime.Text = DateTime.Now.Date.ToShortDateString();
                this.lblContent.Text = dr["Content"].ToString();
            }
        }              
       
      
    }
}

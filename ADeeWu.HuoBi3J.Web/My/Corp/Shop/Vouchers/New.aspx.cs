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

namespace ADeeWu.HuoBi3J.Web.My.Corp.Shop.Vouchers
{
    public partial class New : ADeeWu.HuoBi3J.Web.Class.PageBase_MyCorp_Shop
    {

        DataBase db = DataBase.Create();
        DAL.Shops dalShop = new ADeeWu.HuoBi3J.DAL.Shops();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string uin = WebUtility.GetRequestStr("uin", "");
                if (uin.Length > 0)
                {
                    this.txtUserNo.Text = uin;
                }

                this.txtVouchersTitle.Text = "感谢您对 " + this.LoginUser.CorpName + " 的支持！";
                string orderCode = WebUtility.GetRequestStr("orderCode", "");
                if (orderCode.Length > 0)
                {
                    this.txtVouchersTitle.Text = "[订单:{请填写订单号}的电子凭证] ".Replace("{请填写订单号}", orderCode) + this.txtVouchersTitle.Text;
                }

                Model.Shops ent = dalShop.GetEntity(this.LoginUser.ShopID);
                if (ent != null)
                {
                    this.txtContent.Text = WebUtility.ToTextAreaContent(ent.AfterSaleService);
                }
            }
        }

        /// <summary>
        /// 提交电子凭证事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bindData();
        }

        /// <summary>
        /// 发布电子凭证
        /// </summary>
         void bindData()
        {
            string title = this.txtVouchersTitle.Text.Trim();
            string content = WebUtility.GetTextAreaContent(this.txtContent.Text);


            if (title.Length == 0)
            {
                WebUtility.ShowMsg(this,"请填写电子凭证名称！");
                return;
            }

            if (content.Length == 0)
            {
                WebUtility.ShowMsg(this, "请填写电子凭证详细描述内容！");
                return;
            }

           
            DAL.Shop_Vouchers dal = new ADeeWu.HuoBi3J.DAL.Shop_Vouchers();
            Model.Shop_Vouchers voucher = new Model.Shop_Vouchers();

            

            ADeeWu.HuoBi3J.DAL.Users dalUser = new ADeeWu.HuoBi3J.DAL.Users();
            ADeeWu.HuoBi3J.Model.Users user = dalUser.GetEntity(new string[] { "UIN", "CheckState" }, this.txtUserNo.Text, "1");

            if (user != null)
            {
                voucher.BuyerUserID = user.ID;
            }
            else
            {
                WebUtility.ShowMsg(this, "该用户不存在:" + this.txtUserNo.Text + "！");
                return;
            }

            voucher.SellerCorpID = this.LoginUser.CorpID;
            voucher.SellerUserID = this.LoginUser.CorpUserID;
            voucher.Title  = title;      
            voucher.CreateTime = DateTime.Now;
            voucher.ModifyTime = DateTime.Now;
            voucher.Content = content;

            if (dal.Add(voucher) > 0)
            {
               
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "操作成功！", "Default.aspx");
                return;
            }
            else {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "操作失败，请与我们联系！");
            }

        }

       

    
    }
}

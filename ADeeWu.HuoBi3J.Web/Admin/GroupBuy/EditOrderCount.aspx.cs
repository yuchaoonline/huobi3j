using ADeeWu.HuoBi3J.Libary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.Admin.GroupBuy
{
    public partial class EditOrderCount : System.Web.UI.Page
    {
        DAL.GroupBuy_Product productDAL = new DAL.GroupBuy_Product();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var id = WebUtility.GetRequestInt("ID",0);
            var newOrderCount = Utility.GetInt(txtOrderCount.Text, 0);
            if (id == 0)
            {
                WebUtility.ShowMsg(this, "参数错误！");
                return;
            }

            if (!Utility.IsInt(txtOrderCount.Text))
            {
                WebUtility.ShowMsg("订购数应为整数！");
                return;
            }
            if(newOrderCount==0)
            {
                WebUtility.ShowMsg("个性订购数应大于0");
                    return;
            }

            var product = productDAL.GetEntity(id);
            if (product.Summary - product.OrderCount < newOrderCount)
            {
                WebUtility.ShowMsg(string.Format("当前修改数只能在0~{0}之间", product.Summary - product.OrderCount));
                return;
            }
            product.OrderCount += newOrderCount;

            if (productDAL.Update(product) > 0)
            {
                WebUtility.ShowMsg(this, "修改成功！", "default.aspx");
                return;
            }
            else
            {
                WebUtility.ShowMsg("个性失败！");
                return;
            }
        }
    }
}
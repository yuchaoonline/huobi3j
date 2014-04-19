using ADeeWu.HuoBi3J.Libary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.Admin.Center
{
    public partial class ViewClick : System.Web.UI.Page
    {
        DAL.Key_ViewPrice dal = new DAL.Key_ViewPrice();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var kid = WebUtility.GetRequestInt("kid", 0);
                if (kid == 0)
                {
                    WebUtility.ShowMsg("参数有误！");
                    return;
                }
                var view = dal.GetEntity("kid=" + kid);
                if (view == null) return;

                txtCount.Text = view.Count.ToString();
                txtPrice.Text = view.Price.ToString();
            }
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            var kid = WebUtility.GetRequestInt("kid", 0);
            if (kid == 0)
            {
                WebUtility.ShowMsg("参数有误！");
                return;
            }
            var price = Utility.GetDecimal(txtPrice.Text, -1);
            var count = Utility.GetInt(txtCount.Text, -1);
            if(price<0)
            {
                WebUtility.ShowMsg("点击钱要大于等于0！");
                return;
            }
            if(count<0){
                WebUtility.ShowMsg("次数要大于等于0！");
                return;
            }

            var error = 0;
            if (dal.Exist("kid", kid))
            {
                var view = dal.GetEntity("kid=" + kid);
                view.Price = price;
                view.Count = count;
                error = dal.Update(view);
            }
            else
            {
                var view = new Model.Key_ViewPrice
                {
                    Price = price,
                    Count = count,
                    KID = kid,
                };
                error = dal.Add(view);
            }

            if (error > 0)
            {
                WebUtility.ShowMsg("操作成功！");
            }
            else
            {
                WebUtility.ShowMsg("操作失败！");
            }
        }
    }
}
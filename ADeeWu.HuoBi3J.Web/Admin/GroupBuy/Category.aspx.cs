using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.Admin.GroupBuy
{
    public partial class Category : System.Web.UI.Page
    {
        DAL.GroupBuy_Category categoryDAL = new DAL.GroupBuy_Category();

        protected void Page_Load(object sender, EventArgs e)
        {
            BandData();
        }

        protected void rpResult_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "delete":
                    {
                        var id = Utility.GetInt(e.CommandArgument, 0);
                        if (id == 0)
                        {
                            WebUtility.ShowMsg("参数有误，请刷新页面！");
                            return;
                        }
                        Delete(id);
                    }; break;
            }
        }

        private void Delete(int id)
        {
            var category = categoryDAL.GetEntity(id);
            if (category == null)
            {
                WebUtility.ShowMsg("删除出错，请重试！");
                return;
            }

            if (categoryDAL.Delete(id) > 0)
            {
                WebUtility.ShowMsg(this, "删除成功！", "category.aspx");
                return;
            }
            else
            {
                WebUtility.ShowMsg("删除失败，请重试！");
                return;
            }
        }

        private void BandData()
        {
            rpResult.DataSource = categoryDAL.GetEntityList("", new string[] { }, new string[] { });
            rpResult.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                WebUtility.ShowMsg("分类名称不能为空！");
                return;
            }

            var category = new Model.GroupBuy_Category
            {
                Name = txtName.Text
            };

            if (categoryDAL.Add(category) > 0)
            {
                WebUtility.ShowMsg(this, "添加成功！", "category.aspx");
                return;
            }
            else
            {
                WebUtility.ShowMsg("添加失败！");
                return;
            }
        }
    }
}
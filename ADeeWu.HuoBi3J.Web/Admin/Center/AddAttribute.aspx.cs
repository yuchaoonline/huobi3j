using ADeeWu.HuoBi3J.Libary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.Admin.Center
{
    public partial class AddAttribute : System.Web.UI.Page
    {
        private DAL.Key keyDAL = new DAL.Key();
        private DAL.Key_Attribute attrDAL = new DAL.Key_Attribute();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var method = WebUtility.GetRequestStr("method", "").ToLower();
                if (method == "delete")
                {
                    Delete();
                    return;
                }

                var kid = WebUtility.GetRequestInt("kid", 0);
                if (kid == 0)
                {
                    WebUtility.ShowMsg(this, "参数有误！", "key4attribute.aspx");
                    return;
                }

                BandData(kid);
            }
        }

        private void Delete()
        {
            var id = WebUtility.GetRequestInt("id", 0);
            if (id == 0) return;

            var kid = WebUtility.GetRequestInt("kid", 0);
            if (kid == 0)
            {
                WebUtility.ShowMsg(this, "参数有误！", "key4attribute.aspx");
                return;
            }

            if (attrDAL.Delete(id) > 0)
            {
                WebUtility.ShowMsg(this, "删除成功！");
                BandData(kid);
                return;
            }

            WebUtility.ShowMsg("删除失败！");
            return;
        }

        private void BandData(int kid)
        {
            var key = keyDAL.GetEntity(kid);
            if (key == null) return;

            litKeyname.Text = key.Name;

            var attributes = attrDAL.GetEntityList("", new string[] { "kid" }, new object[] { kid });
            if (attributes != null)
            {
                rpResultList.DataSource = attributes;
                rpResultList.DataBind();
            }
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            var kid = WebUtility.GetRequestInt("kid", 0);
            if (kid == 0)
            {
                WebUtility.ShowMsg(this, "参数有误！", "key4attribute.aspx");
                return;
            }

            var attr = new Model.Key_Attribute
            {
                KID = kid,
                DataType = ddlType.SelectedValue,
                DataValue = txtValue.Text,
            };

            if (attrDAL.Add(attr) > 0)
            {
                WebUtility.ShowAndGoBack(this, "保存成功！");
                return;
            }

            WebUtility.ShowAndGoBack(this, "保存失败！");
            return;
        }

        public string ConvertType(object type)
        {
            var t = type.ToString();
            if (t == "SelectType") return "类型";
            if (t == "SelectPrice") return "价格";
            if (t == "SelectSize") return "其他";

            return "";
        }
    }
}
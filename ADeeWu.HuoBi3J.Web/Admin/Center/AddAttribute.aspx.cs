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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var kid = WebUtility.GetRequestInt("kid", 0);
                if (kid == 0)
                {
                    WebUtility.ShowMsg(this, "参数有误！", "key4attribute.aspx");
                    return;
                }

                BandData(kid);
            }
        }

        private DAL.Key keyDAL = new DAL.Key();
        private DAL.Key_Attribute attrDAL = new DAL.Key_Attribute();

        private void BandData(int kid)
        {
            var key = keyDAL.GetEntity(kid);
            if (key == null) return;

            litKeyname.Text = key.Name;
            hfID.Value = key.KID.ToString();

            var attribute = attrDAL.GetEntity("kid=" + kid);
            if (attribute != null)
            {
                txtType.Text = attribute.KeyType;
                txtSize.Text = attribute.KeySize;
                txtPrice.Text = attribute.KeyPrice;
            }
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            var kid = Utility.GetInt(hfID.Value, 0);

            var key = keyDAL.GetEntity(kid);
            var kids = keyDAL.GetEntityList("", new string[] { "name" }, new object[] { key.Name }).Select(p => p.KID);

            foreach (var item in kids)
            {
                var attribute = new Model.Key_Attribute
                {
                    KID = item,
                    KeyType = txtType.Text,
                    KeySize = txtSize.Text,
                    KeyPrice = txtPrice.Text,
                };

                attrDAL.Add(attribute);
            }

            WebUtility.ShowAndGoBack(this, "保存成功！");
        }
    }
}
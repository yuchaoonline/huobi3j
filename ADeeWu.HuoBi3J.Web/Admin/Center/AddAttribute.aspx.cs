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

        private void BandData(int kid)
        {
            var key = new DAL.Key().GetEntity(kid);
            if (key == null) return;

            litKeyname.Text = key.Name;
            hfID.Value = key.KID.ToString();

            var attributes = new DAL.Key_Attribute().GetEntityList("", new string[] { "kid" }, new object[] { kid });

            txtType.Text = string.Join(";", attributes.Select(p => p.KeyType));
            txtSize.Text = string.Join(";", attributes.Select(p => p.KeySize));
            txtPrice.Text = string.Join(";", attributes.Select(p => p.KeyPrice));
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            var kid = Utility.GetInt(hfID.Value, 0);
            var keytypes = txtType.Text.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            var keysizes = txtSize.Text.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            var keyprices = txtPrice.Text.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            var max = keysizes.Count()>keyprices.Count()?keysizes.Count():keyprices.Count();
            max = max > keytypes.Count() ? max : keytypes.Count();

            var keyAttributeDAL = new DAL.Key_Attribute();
            keyAttributeDAL.Delete("kid=" + kid);
            for (int i = 0; i < max; i++)
            {
                var attribute = new Model.Key_Attribute
                {
                    KID = kid,
                    KeyType = keytypes.Count()>i?keytypes[i]:"",
                    KeySize = keysizes.Count()>i?keysizes[i]:"",
                    KeyPrice = keyprices.Count()>i?keyprices[i]:""
                };

                keyAttributeDAL.Add(attribute);
            }

            WebUtility.ShowAndGoBack(this, "保存成功！");
        }
    }
}
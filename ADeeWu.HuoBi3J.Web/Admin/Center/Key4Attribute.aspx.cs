using ADeeWu.HuoBi3J.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.Admin.Center
{
    public partial class Key4Attribute : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtKey.Text))
            {
                BandData(txtKey.Text);
            }
        }

        private void BandData(string keyword)
        {
            var result = DataBase.Create().Select("vw_keys", string.Format("kname like '%{0}%'", keyword), "");
            rpResultList.DataSource = result;
            rpResultList.DataBind();
        }
    }
}
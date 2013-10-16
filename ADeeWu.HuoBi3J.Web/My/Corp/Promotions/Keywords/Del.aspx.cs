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

namespace ADeeWu.HuoBi3J.Web.My.Corp.Promotions.Keywords
{
    public partial class Del : Class.PageBase_MyCorp_Promotions
    {
        public override string FunctionCode
        {
            get
            {
                return "Corp-Promotions-Keywords-Del";
            }
        }

        DAL.CP_Keywords dal = new ADeeWu.HuoBi3J.DAL.CP_Keywords();

        long id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0);
            if (!IsPostBack)
            {
                dal.Delete("id = " + id);
                Response.Redirect(".");
            }
        }

      
    }
}

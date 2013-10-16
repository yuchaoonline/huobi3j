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

namespace ADeeWu.HuoBi3J.Web.My.Corp.Promotions
{
    public partial class Default : Class.PageBase_MyCorp_Promotions
    {

        public override string FunctionCode
        {
            get
            {
                return "Corp-Promotions-Default";
            }
        }

        ADeeWu.HuoBi3J.DAL.CP_Promotions dal = new ADeeWu.HuoBi3J.DAL.CP_Promotions();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.rpPromotion.DataSource = dal.Select("CorpID=" + this.LoginUser.CorpID, "");
                this.rpPromotion.DataBind();
            }
        }
    }
}

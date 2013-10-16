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

namespace ADeeWu.HuoBi3J.Web.My.User.SupplyDemand
{
    public partial class Del : System.Web.UI.Page
    {
        ADeeWu.HuoBi3J.DAL.SD_SupplyDemands dal = new ADeeWu.HuoBi3J.DAL.SD_SupplyDemands();
        protected void Page_Load(object sender, EventArgs e)
        {
            string IDString = ADeeWu.HuoBi3J.Libary.Utility.GetStr(Request["id"]);
            if (IDString.IndexOf(",") > -1)
            {
                foreach (string s in IDString.Split(','))
                {
                    long id = ADeeWu.HuoBi3J.Libary.Utility.GetLong(s, 0);
                    if (id > 0)
                    {
                        dal.Delete(id);
                    }
                }
            }
            else
            {
                long id = ADeeWu.HuoBi3J.Libary.Utility.GetLong(IDString, 0);
                if (id > 0)
                {
                    dal.Delete(id);
                }
            }

        }
    }
}


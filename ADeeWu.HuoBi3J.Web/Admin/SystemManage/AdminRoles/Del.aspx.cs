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

namespace ADeeWu.HuoBi3J.Web.Admin.SystemManage.AdminRoles
{
    public partial class Del : PageBase
    {
        public override string PageID
        {
            get
            {
                return "0204";
            }
        }

        ADeeWu.HuoBi3J.DAL.Admin_Roles dal = new ADeeWu.HuoBi3J.DAL.Admin_Roles();
        protected void Page_Load(object sender, EventArgs e)
        {
            long[] idsGroup = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLongGroups("id", 0);

            foreach (long id in idsGroup)
            {
                if (id > 0)
                {
                    dal.Delete(id);
                }
            }

            ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "操作成功!", "list.aspx");
        }
    }
}

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

namespace ADeeWu.HuoBi3J.Web.Admin.SystemManage.AdminUsers
{
    public partial class Del : PageBase
    {
        public override string PageID
        {
            get
            {
                return "0104";
            }
        }
        
        ADeeWu.HuoBi3J.DAL.Admin_Users dal = new ADeeWu.HuoBi3J.DAL.Admin_Users();
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

            ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "操作成功!", "list.aspx");
        }
    }
}

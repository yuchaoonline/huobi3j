using ADeeWu.HuoBi3J.Libary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.Admin.Center
{
    public partial class HotKeys : System.Web.UI.Page
    {
        DAL.TicketHotKey hotkeyDAL = new DAL.TicketHotKey();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var method = WebUtility.GetRequestStr("method", string.Empty);
                if (method == "del")
                    Delete();
                Search();
            }
        }

        private void Search()
        {
            rpResultList.DataSource = hotkeyDAL.GetEntityList("", new string[] { }, new string[] { });
            rpResultList.DataBind();
        }

        private void Delete()
        {
            var id = WebUtility.GetRequestInt("id", 0);
            if (id == 0) return;

            if (hotkeyDAL.Delete(id) > 0)
            {
                WebUtility.ShowMsg(this, "操作成功！", "HotKeys.aspx");
                return;
            }
            WebUtility.ShowMsg("操作失败！");
            return;
        }
    }
}
using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Web.Class;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.My.User.Center
{
    public partial class ChangeGoOn : PageBase_MyUser
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Search(base.LoginUser.UserID);
            }
        }

        private void Search(long uid)
        {
            var kid = WebUtility.GetRequestLong("kid", -1);

            var userkeyDAL = new DAL.UserKey();
            var userkey = userkeyDAL.GetEntity(string.Format("kid={0} and uid={1}", kid, uid));
            userkey.IsGoOn = false;
            if (userkeyDAL.Update(userkey) > 0)
            {
                WebUtility.ShowMsg(this, "操作成功！", "myattentionlist.aspx");
                return;
            }
            else
            {
                WebUtility.ShowMsg(this, "操作失败！", "myattentionlist.aspx");
                return;
            }
        }
    }
}
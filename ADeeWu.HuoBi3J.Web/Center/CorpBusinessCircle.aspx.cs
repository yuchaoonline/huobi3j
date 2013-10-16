using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.Center
{
    public partial class CorpBusinessCircle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var uid = WebUtility.GetRequestInt("uid", 0);
                if (uid > 0)
                {
                    Search(uid);
                }
            }
        }

        private void Search(int uid)
        {
            var db = DataBase.Create();
            rpResult.DataSource = db.Select(string.Format("select * from [BusinessCircle] where [bid] in (select bid from vw_userkey where uid = {0} group by bname,bid) order by bid", uid));
            rpResult.DataBind();

            var corp = new DAL.Corporations().GetEntity(new string[] { "userid" }, new object[] { uid });
            litCorpName.Text = corp.CorpName;
        }
    }
}
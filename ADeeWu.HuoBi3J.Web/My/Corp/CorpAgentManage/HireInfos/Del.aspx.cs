using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.My.Corp.CorpAgentManage.HireInfos
{
    public partial class Del : Class.PageBase_MyCorp
    {
        DAL.CA_HireInfos dal = new DAL.CA_HireInfos();
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
                        dal.Delete("id=" + id + " and CorpID=" + this.LoginUser.CorpID);
                    }
                }
            }
            else
            {
                long id = ADeeWu.HuoBi3J.Libary.Utility.GetLong(IDString, 0);
                if (id > 0)
                {
                    dal.Delete("id=" + id + " and CorpID=" + this.LoginUser.CorpID);
                }
            }
            WebUtility.ShowMsg(this, "操作成功!", ".");

        }
    }
}

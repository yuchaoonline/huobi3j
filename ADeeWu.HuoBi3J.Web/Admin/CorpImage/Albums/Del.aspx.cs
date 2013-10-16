using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.Admin.CorpImage.Albums
{
    public partial class Del : PageBase
    {
        ADeeWu.HuoBi3J.DAL.CI_Albums dal = new ADeeWu.HuoBi3J.DAL.CI_Albums();

        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            string IDString = ADeeWu.HuoBi3J.Libary.Utility.GetStr(Request["id"]);
            long corpID = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("corpid", 0);

            if (IDString.IndexOf(",") > -1)
            {
                foreach (string s in IDString.Split(','))
                {
                    long id = ADeeWu.HuoBi3J.Libary.Utility.GetLong(s, 0);
                    
                    if (id > 0)
                    {
                        //删除商家相册信息
                        dal.Delete("id=" + id + " and CorpID=" + corpID);
                    }
                }
            }
            else
            {
                long id = ADeeWu.HuoBi3J.Libary.Utility.GetLong(IDString, 0);
                if (id > 0)
                {
                    dal.Delete("id=" + id + " and CorpID=" + corpID);
                }
            }
            WebUtility.ShowMsg(this, "操作成功!", ".");

        }
    }
}

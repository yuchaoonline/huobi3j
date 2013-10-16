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
using ADeeWu.HuoBi3J.Libary;
using System.IO;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.My.Corp.CorpImage.Albums
{
    public partial class Del : Class.PageBase_MyCorp 
    {

        ADeeWu.HuoBi3J.DAL.CI_Albums  dal = new ADeeWu.HuoBi3J.DAL.CI_Albums();

        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                        //删除商家相册信息
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

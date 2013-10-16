using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web
{
    public partial class Tips : System.Web.UI.Page
    {
        protected Class.Tips tips = null;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            tips = Class.Tips.GetTips();
            Class.Tips.ClearTips();
            if (tips == null)
            {
                tips = new ADeeWu.HuoBi3J.Web.Class.Tips("", "", "", "");
            }

            //DataBase db = DataBase.Context;
          
           
            //db.Select("select * from Users where id=@id");


            //string s = ADeeWu.HuoBi3J.Libary.Security.DESEncrypt.Encrypto("http://forumn.lidas.us/topics?id=1", "1ff8e4fe-c9d6-41e0-8922-b902938e3c71");
            //string s2 = ADeeWu.HuoBi3J.Libary.Security.DESEncrypt.Decrypto(s);
        }

        


    }
}

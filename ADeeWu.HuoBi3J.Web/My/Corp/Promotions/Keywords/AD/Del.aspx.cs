using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.SQL;
using System.Data;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.My.Corp.Promotions.Keywords.AD
{
    public partial class Del : Class.PageBase_MyCorp
    {
        public override string FunctionCode
        {
            get
            {
                return "Corp-Promotions-Keywords-AD-Del";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                long id = WebUtility.GetRequestLong("id", 0);
                if (id == 0)
                {
                    WebUtility.ShowAndGoBack(this, "参数错误！");
                    return;
                }
                DAL.CP_Keyword_AD adDAL = new DAL.CP_Keyword_AD();
                if (adDAL.Delete(id) > 0)
                {
                    WebUtility.ShowAndTopRedirect(this, "删除成功！","Default.aspx");
                    return;
                }
                else
                {
                    WebUtility.ShowAndGoBack(this, "删除失败！");
                    return;
                }
            }
        }
    }
}
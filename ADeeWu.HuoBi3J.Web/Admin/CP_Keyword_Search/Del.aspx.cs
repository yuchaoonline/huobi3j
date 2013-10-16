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
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.Admin.CP_Keyword_Search
{

    /// <summary>
    /// 
    /// </summary>
    public partial class Del : PageBase
    {
        public override string PageID
        {
            get
            {
                return "012003";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                long id = WebUtility.GetRequestLong("id", 0);
                if (id == 0)
                {
                    WebUtility.ShowAndGoBack(this, "参数有误！");
                    return;
                }
                if (new DAL.CP_Keyword_Result().Exist("KeywordID=" + id))
                {
                    WebUtility.ShowAndGoBack(this, "该关键字包含搜索结果，请删除关键字再进行！");
                    return;
                }
                if (new DAL.CP_Keyword_AD_Auction().Exist("keywordID=" + id))
                {
                    WebUtility.ShowAndGoBack(this, "该关键字有竞价记录，无法进行删除操作！");
                    return;
                }
                if (new DAL.CP_Keyword_Search().Delete(id) > 0)
                {
                    WebUtility.ShowMsg(this, "删除成功！", "List.aspx");
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

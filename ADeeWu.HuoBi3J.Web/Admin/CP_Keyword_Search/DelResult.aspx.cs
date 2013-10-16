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
    public partial class DelResult : PageBase
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
                long keywordid = WebUtility.GetRequestLong("keywordid",0);
                if (id == 0||keywordid==0)
                {
                    WebUtility.ShowAndGoBack(this, "参数有误！");
                    return;
                }
                new DAL.CP_Keyword_Result_Click().Delete("KeywordResultID = " + id);
                if (new DAL.CP_Keyword_Result().Delete(id) > 0)
                {
                    WebUtility.ShowMsg(this, "删除成功！", "Result.aspx?id=" + keywordid);
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

using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Web.Class;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.My.Corp.Promotions.Keywords.AD
{
    public partial class ADLog : PageBase_MyCorp
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                long pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("pagesize", GlobalParameter.DataList_PageSize);
                long pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("page", 1);
                long id = WebUtility.GetRequestLong("id", 0);
                if (id == 0)
                {
                    WebUtility.ShowAndGoBack(this, "参数有误！");
                    return;
                }

                DataBase db = DataBase.Create();
                this.rpADList.DataSource = db.Select("select l.*, s.keyword, u.loginname from dbo.CP_Keyword_AD_Log l left join dbo.CP_Keyword_Search s on l.keywordid = s.id left join dbo.Users u on s.userid = u.id where l.adid = " + id);
                this.rpADList.DataBind();
            }
        }
    }
}
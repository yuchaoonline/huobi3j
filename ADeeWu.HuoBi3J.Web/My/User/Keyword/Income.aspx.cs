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
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.My.User.Keyword
{
    public partial class Income : Class.PageBase_MyUser
    {

        public override string FunctionCode
        {
            get
            {
                return "My-User-Keyword-Income";
            }
        }

        public string keyword = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            long pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("pagesize", GlobalParameter.DataList_PageSize);
            long pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("page", 1);

            if (!IsPostBack)
            {
                long id = WebUtility.GetRequestLong("id", 0);
                keyword = WebUtility.GetRequestStr("keyword", "");
                if (id == 0)
                {
                    WebUtility.ShowAndGoBack(this, "参数错误！");
                    return;
                }
                DAL.CP_Keyword_AD_Log logDAL = new DAL.CP_Keyword_AD_Log();
                logDAL.EnableRecordCount = true;
                rpResultList.DataSource = logDAL.Select(pageSize, pageIndex, "keywordid=" + id, "");
                rpResultList.DataBind();

                this.Pager1.PageIndex = (int)pageIndex;
                this.Pager1.PageSize = (int)pageSize;
                this.Pager1.TotalRecords =(int) logDAL.RecordCount;
            }
        }

        public string GetADName(object _id)
        {
            long id = Utility.GetLong(_id, 0);
            if (id == 0) return "";
            Model.CP_Keyword_AD ad = new DAL.CP_Keyword_AD().GetEntity(id);
            if (ad == null || ad.ID == 0) return "";
            return ad.Name;
        }
    }
}
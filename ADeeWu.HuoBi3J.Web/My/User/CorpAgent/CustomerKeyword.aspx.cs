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
using System.Collections.Generic;
using System.Text;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.My.User.CorpAgent
{
    public partial class CustomerKeyword : ADeeWu.HuoBi3J.Web.Class.PageBase_MyUser
    {

        public override string FunctionCode
        {
            get
            {
                return "My-User-CorpAgent-CustomerKeyword";
            }
        }

        DAL.CP_Keyword_Search dal = new ADeeWu.HuoBi3J.DAL.CP_Keyword_Search();
        DataBase db = DataBase.Create();

        protected void Page_Load(object sender, EventArgs e)
        {
            long pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("pagesize", GlobalParameter.DataList_PageSize);
            long pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("page", 1);
            long id = WebUtility.GetRequestLong("id", 0);
            if (id == 0)
            {
                WebUtility.ShowMsg(this, "参数错误！", "CustomerBenefit.aspx");
            }

            if (!IsPostBack)
            {
                dal.EnableRecordCount = true;
                this.gvData.DataSource = dal.Select(pageSize, pageIndex, "userid = " + id, "CreateTime desc");
                this.gvData.DataBind();
                this.Pager1.PageIndex = (int)pageIndex;
                this.Pager1.PageSize = (int)pageSize;
                this.Pager1.TotalRecords = (int)dal.RecordCount;
            }
        }

        public string IsHidden(object obj)
        {
            if (obj.ToString().ToLower() == "true")
                return "是";
            else
                return "否";
        }
    }
}

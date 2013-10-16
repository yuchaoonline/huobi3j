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
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Web.Class;

namespace ADeeWu.HuoBi3J.Web.My.User.Center.KeyManage
{
    public partial class Default : Class.PageBase_MyQualifiedAgents
    {
        DataBase db = DataBase.Create();

        public override string FunctionCode
        {
            get
            {
                return base.FunctionCode;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            long pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("pagesize", GlobalParameter.DataList_PageSize);
            long pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("page", 1);

            if (!IsPostBack)
            {
                db.EnableRecordCount = true;
                db.Parameters.Append("uid", QualifiedAgentSession.QualifiedAgent.UserID);
                this.gvData.DataSource = db.Select(pageSize, pageIndex, "vw_Center_Key_Manage", "id", "uid=@uid", "");
                this.gvData.DataBind();
                this.Pager1.PageIndex = (int)pageIndex;
                this.Pager1.PageSize = (int)pageSize;
                this.Pager1.TotalRecords = (int)db.RecordCount;
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
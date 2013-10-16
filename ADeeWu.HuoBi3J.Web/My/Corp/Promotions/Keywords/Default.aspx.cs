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

namespace ADeeWu.HuoBi3J.Web.My.Corp.Promotions.Keywords
{
    public partial class Default : Class.PageBase_MyCorp_Promotions
    {

        public override string FunctionCode
        {
            get
            {
                return "Corp-Promotions-Keywords-Default";
            }
        }

        DAL.CP_Keywords dal = new ADeeWu.HuoBi3J.DAL.CP_Keywords();
        DataBase db = DataBase.Create();

        protected void Page_Load(object sender, EventArgs e)
        {
            long pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("pagesize", GlobalParameter.DataList_PageSize);
            long pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("page", 1);

            if (!IsPostBack)
            {
                dal.EnableRecordCount = true;
                this.gvData.DataSource = dal.Select(pageSize, pageIndex, "PromotionID=" + this.LoginUser.PromotionID, "VisitCount desc");
                this.gvData.DataBind();
                this.Pager1.PageIndex = (int)pageIndex;
                this.Pager1.PageSize = (int)pageSize;
                this.Pager1.TotalRecords = (int)dal.RecordCount;
            }
        }

        protected object GetTopCoins(string keyword)
        {
            db.Parameters.Clear();
            db.Parameters.Append("@keyword",keyword);
            return db.ExecuteScalar("select top 1 coins from CP_Keywords where keyword=@keyword order by coins desc");
        }
    }
}

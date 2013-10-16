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

namespace ADeeWu.HuoBi3J.Web.Admin.CP_KeywordIndex
{

    /// <summary>
    /// 
    /// </summary>
    public partial class List : PageBase
    {
        ADeeWu.HuoBi3J.DAL.Corporations dal = new ADeeWu.HuoBi3J.DAL.Corporations();


        public override string PageID
        {
            get
            {
                return "012003";
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {

            DataBase db = DataBase.Create();
            
            long pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("pagesize", PageBase.DataList_PageSize);
            long pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("page", 1);

            string promotionTitle = Utility.GetStr(Request.QueryString["title"], this.txtTitle.Text, "", true);
            string corpName = Utility.GetStr(Request.QueryString["corp"], this.txtCorp.Text, "", true);
            string keyword = Utility.GetStr(Request.QueryString["keyword"], this.txtKeywords.Text, "", true);
            int numIsHidden = Utility.GetInt(Request.QueryString["hidden"], this.ddlHidden.SelectedValue, -1);
            int numIsRankIndex = Utility.GetInt(Request.QueryString["rankindex"], this.ddlIsRankIndex.SelectedValue, -1);

            StringBuilder builderWhere = new StringBuilder();

            if (promotionTitle != "")
            {
                builderWhere.Append(" and Title like @Title");
                db.Parameters.Append("@Title", string.Format("%{0}%", promotionTitle));
                this.Pager1.AppendUrlParam("title", promotionTitle);
                this.txtTitle.Text = promotionTitle;
            }

            if (corpName != "")
            {
                builderWhere.Append(" and CorpName like @CorpName");
                db.Parameters.Append("@CorpName", string.Format("%{0}%", corpName));
                this.Pager1.AppendUrlParam("corp", corpName);
                this.txtCorp.Text = corpName;
            }

            if (keyword != "")
            {
                builderWhere.Append(" and Keyword like @Keyword");
                db.Parameters.Append("@Keyword", string.Format("%{0}%", keyword));
                this.Pager1.AppendUrlParam("keyword", keyword);
                this.txtKeywords.Text = keyword;
            }



            if (numIsHidden == 0 || numIsHidden == 1)
            {
                builderWhere.Append(" and KeywordIsHidden=@KeywordIsHidden");
                db.Parameters.Append("@KeywordIsHidden", numIsHidden);
                this.Pager1.AppendUrlParam("hidden", numIsHidden.ToString());
                this.ddlHidden.SelectedValue = numIsHidden.ToString();
            }

            if (numIsRankIndex == 0 || numIsRankIndex == 1)
            {
                builderWhere.Append(" and IsRankIndex=@IsRankIndex");
                db.Parameters.Append("@IsRankIndex", numIsRankIndex);
                this.Pager1.AppendUrlParam("rankindex", numIsRankIndex.ToString());
                this.ddlIsRankIndex.SelectedValue = numIsRankIndex.ToString();
            }

            string where = "" + (
                   (builderWhere.Length > 0) ? builderWhere.ToString().Substring(4) : string.Empty
            );


            db.EnableRecordCount = true;
            this.gvData.DataSource = db.Select(pageSize, pageIndex, "vw_CP_KeywordIndex", "id", where, "sequence asc");
            this.gvData.DataBind();
            this.Pager1.PageSize = ADeeWu.HuoBi3J.Libary.Utility.GetInt(pageSize, 0);
            this.Pager1.PageIndex = ADeeWu.HuoBi3J.Libary.Utility.GetInt(pageIndex, 0);
            this.Pager1.TotalRecords = ADeeWu.HuoBi3J.Libary.Utility.GetInt(db.RecordCount, 0);
            db.EnableRecordCount = false;
            

        }
    }
}

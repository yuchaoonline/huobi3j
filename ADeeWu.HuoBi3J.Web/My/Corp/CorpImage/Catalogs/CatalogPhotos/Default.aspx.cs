using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Libary;
using System.Text;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.My.Corp.CorpImage.Catalogs.CatalogPhotos
{
    public partial class Default : ADeeWu.HuoBi3J.Web.Class.PageBase_MyCorp
    {
        DataBase db = DataBase.Create();
        long pageSize = 20;
        long pageIndex = 1;

        string title = string.Empty;
        protected long catalogsID = 0;
        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            pageSize = Utility.GetLong(Request["pagesize"], 20, 5, 20);
            pageIndex = WebUtility.GetRequestInt("page", 1);
            catalogsID = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0);
            if (!IsPostBack)//获取外部参数
            {
                title = WebUtility.GetUrlStr("title", "");
                bindData();
            }

            
        }

        void bindData()
        {
            StringBuilder builderWhere = new StringBuilder();
            builderWhere.Append(" CorpID=@CorpID");
            db.Parameters.Append("@CorpID", LoginUser.CorpID);

            if (catalogsID > 0)
            {
                builderWhere.AppendFormat(" and CatalogsID=@CatalogsID");
                db.Parameters.Append("@CatalogsID", catalogsID);
                this.Pager1.AppendUrlParam("catalogsID", catalogsID.ToString());
            }

            if (title != "")
            {
                builderWhere.Append(" and Title like @title");
                db.Parameters.Append("@title", string.Format("%{0}%", title));
                this.Pager1.AppendUrlParam("title", title);
                this.txtTitle.Text = title;
            }


            db.EnableRecordCount = true;
            this.gvData.DataSource = db.Select(pageSize, pageIndex, "vw_CI_CatalogPhotos", "ID", builderWhere.ToString(), "Sequence DESC ");
            this.gvData.DataBind();
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            pageIndex = 1;
            title = Utility.GetStr(Request.QueryString["title"], this.txtTitle.Text, "", true);
            bindData();
        }


    }
}

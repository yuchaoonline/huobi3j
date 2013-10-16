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

namespace ADeeWu.HuoBi3J.Web.My.Corp.CorpImage.Albums.Photos
{
    public partial class Default : ADeeWu.HuoBi3J.Web.Class.PageBase_MyCorp
    {
        DataBase db = DataBase.Create();
        long pageSize = 20;
        long pageIndex = 1;
        long id = 0;
        string title = string.Empty;
       
        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            pageSize = Utility.GetLong(Request["pagesize"], 20, 5, 20);
            pageIndex = WebUtility.GetRequestInt("page", 1);
            id = WebUtility.GetRequestLong("id", 0);

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


            if (id !=0)
            {
                builderWhere.Append(" and AlbumID = @AlbumID");
                db.Parameters.Append("@AlbumID", id);
                this.Pager1.AppendUrlParam("AlbumID", id.ToString());
               
            }

            if (title != "")
            {
                builderWhere.Append(" and Title like @title");
                db.Parameters.Append("@title", string.Format("%{0}%", title));
                this.Pager1.AppendUrlParam("title", title);
                this.txtTitle.Text = title;
            }

            db.EnableRecordCount = true;
            this.gvData.DataSource = db.Select(pageSize, pageIndex, "vw_CI_Photos", "ID", builderWhere.ToString(), "Sequence DESC ");
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

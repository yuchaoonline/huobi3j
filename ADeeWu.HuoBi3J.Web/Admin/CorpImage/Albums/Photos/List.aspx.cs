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

namespace ADeeWu.HuoBi3J.Web.Admin.CorpImage.Albums.Photos
{


    public partial class List : PageBase
    {

        


        public override string PageID
        {
            get
            {
                return "020003";
            }
        }

        DataBase db = DataBase.Create();

        long pageSize = 20;
        long pageIndex = 1;

        protected long corpID = 0;
        protected long albumID = 0;

        string title = string.Empty;
        int checkState = -1;

        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            pageSize = Utility.GetLong(Request["pagesize"], 20, 5, 20);
            pageIndex = WebUtility.GetRequestInt("page", 1);

            if (!IsPostBack)//获取外部参数
            {
                title = WebUtility.GetUrlStr("title", "");
                corpID = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("corpID", 0);
                albumID = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("albumID", 0);
                checkState = WebUtility.GetRequestInt("checkState", -1);
                bindData();
            }

        }

        /// <summary>
        /// 邦定数据
        /// </summary>
        void bindData()
        {
            StringBuilder builderWhere = new StringBuilder();
            builderWhere.Append(" 1=1 ");

            if (checkState > -1)
            {
                builderWhere.Append(" and CheckState=@CheckState");
                db.Parameters.Append("@CheckState", checkState);
                this.Pager1.AppendUrlParam("checkState", checkState.ToString());
                this.ddlCheckState.SelectedValue = checkState.ToString();
            }
           
            if (albumID > 0)
            {
                builderWhere.AppendFormat(" and AlbumID=@AlbumID");
                db.Parameters.Append("@AlbumID", albumID);
                this.Pager1.AppendUrlParam("albumID", albumID.ToString());
            
            }


            if (corpID > 0)
            {
                builderWhere.AppendFormat(" and CorpID=@CorpID");
                db.Parameters.Append("@CorpID", corpID);
                this.Pager1.AppendUrlParam("corpID", corpID.ToString());
            }

            if (title != "")
            {
                builderWhere.Append(" and Title like @title");
                db.Parameters.Append("@title", string.Format("%{0}%", title));
                this.Pager1.AppendUrlParam("title", title);
                this.txtTitle.Text = title;
            }

            db.EnableRecordCount = true;

            //邦定数据并分页
            this.gvData.DataSource = this.gvData.DataSource = db.Select(pageSize, pageIndex, "vw_CI_Photos_Admin", "ID", builderWhere.ToString(), "Sequence DESC ");
            this.gvData.DataBind();
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            pageIndex = 1;
            title = Utility.GetStr(Request.QueryString["title"], this.txtTitle.Text, "", true);
            corpID = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("corpID", 0);
            albumID = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("albumID", 0);
            checkState = ADeeWu.HuoBi3J.Libary.Utility.GetInt(Request.QueryString["checkState"], this.ddlCheckState.SelectedValue, -1);
            bindData();
        }

    }
}

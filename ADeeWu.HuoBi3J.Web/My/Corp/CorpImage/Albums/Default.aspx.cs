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

namespace ADeeWu.HuoBi3J.Web.My.Corp.CorpImage.Albums
{
    public partial class Default : ADeeWu.HuoBi3J.Web.Class.PageBase_MyCorp
    {

        ADeeWu.HuoBi3J.DAL.CI_Albums dalAlbums = new ADeeWu.HuoBi3J.DAL.CI_Albums();
        long pageSize = 20;
        long pageIndex = 1;

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
            dalAlbums.Parameters.Append("@CorpID", this.LoginUser.CorpID);

            if (title != "")
            {
                builderWhere.Append(" and Title like @title");
                dalAlbums.Parameters.Append("@title", string.Format("%{0}%", title));
                this.Pager1.AppendUrlParam("title", title);
                this.txtTitle.Text = title;
            }

            dalAlbums.EnableRecordCount = true;

            //邦定数据并分页
            this.gvData.DataSource = dalAlbums.Select(pageSize, pageIndex, builderWhere.ToString(), "Sequence DESC ");
            this.gvData.DataBind();
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)dalAlbums.RecordCount;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            pageIndex = 1;
            title = Utility.GetStr(Request.QueryString["title"], this.txtTitle.Text, "", true);
            bindData();
        }

        
    }
}

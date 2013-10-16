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
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.Admin.CorpImage.Videos
{


    public partial class List : PageBase
    {
        DataBase db = DataBase.Create();

        long pageSize = 20;
        long pageIndex = 1;

        protected long corpID = 0;

        string title = string.Empty;


        public override string PageID
        {
            get
            {
                return "019003";
            }
        }



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
                corpID = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("corpid", 0);
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
            this.gvData.DataSource = this.gvData.DataSource = db.Select(pageSize, pageIndex, "vw_CI_Videos_Admin", "ID", builderWhere.ToString(), "Sequence DESC ");
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
            bindData();
        }

    }
}

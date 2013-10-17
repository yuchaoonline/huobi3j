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
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web
{
    public partial class selectUIN : System.Web.UI.Page
    {
        DataBase db = DataBase.Create();
    
        protected void Page_Load(object sender, EventArgs e)
        {
            int pageIndex = WebUtility.UpdateRequestInt("page", 1, true);
            int pageSize = 15;

            string key = WebUtility.UpdateRequestStr("key", "", true);
            string where = " HasUsed=@HasUsed";
            db.Parameters.Append("@HasUsed", false);
            //todo:update  排序按照钱来排序
            if(key!="")
            {
                where += " and UIN like @uin ";
                db.Parameters.Append("@uin", string.Format("%{0}%", key));
            }

            db.EnableRecordCount = true;
            this.rptData.DataSource = db.Select(pageSize, pageIndex, "IM_UINS", "ID", where, " IsRecommend desc,Sequence desc ");
            this.rptData.DataBind();

            this.Pager1.PageSize = pageSize;
            this.Pager1.PageIndex = pageIndex;
            this.Pager1.UrlFormatString = "?page={pagenum}";
            this.Pager1.OtherFormatString = string.Empty;
            this.Pager1.TotalRecords = Convert.ToInt32(db.RecordCount.ToString());
        }
        
    }
}

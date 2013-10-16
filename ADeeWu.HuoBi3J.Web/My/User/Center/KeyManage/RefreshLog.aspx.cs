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
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.My.User.Center.KeyManage
{
    public partial class RefreshLog : Class.PageBase_MyUser
    {
        public override string FunctionCode
        {
            get
            {
                return "My-User-Center-KeyManage-RefreshLog";
            }
        }

        public static string keyword = "";
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                long pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("pagesize", GlobalParameter.DataList_PageSize);
                long pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("page", 1);
                keyword = WebUtility.GetRequestStr("keyword","");
                long id = WebUtility.GetRequestLong("id", 0);
                if (id == 0)
                {
                    WebUtility.ShowMsg("参数错误！");
                    return;
                }
                DAL.Center_Key_Refresh refreshDAL = new DAL.Center_Key_Refresh();
                refreshDAL.Parameters.Append("kid", id);
                refreshDAL.Parameters.Append("uid", LoginUser.UserID);
                refreshDAL.EnableRecordCount = true;
                rpResultList.DataSource = refreshDAL.Select(pageSize, pageIndex, "kid=@kid and uid = @uid", "lasttime desc");
                rpResultList.DataBind();

                this.Pager1.PageIndex = (int)pageIndex;
                this.Pager1.PageSize = (int)pageSize;
                this.Pager1.TotalRecords = (int)refreshDAL.RecordCount;
                this.Pager1.AppendUrlParam("keyword", keyword);
                this.Pager1.AppendUrlParam("id", id.ToString());
            }
        }
    }
}
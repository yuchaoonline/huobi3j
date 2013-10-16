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
using System.Text;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.My.User.Houses
{
    public partial class Fav_Houses :Class.PageBase_MyUser
    {

        public override string FunctionCode
        {
            get
            {
                return "My-User-Houses-Favs";
            }
        }
        
        DataBase db = DataBase.Create();

        long pageSize = 20;
        long pageIndex = 1;
        string note = string.Empty;
        int houseStruct = -1;
        DateTime? beginTime = null;
        DateTime? endTime = null;

        protected void Page_Load(object sender, EventArgs e)
        {

            pageSize = Utility.GetLong(Request["pagesize"], 20, 5, 20);
            pageIndex = WebUtility.GetRequestInt("page", 1);

            if (!IsPostBack)//获取外部参数
            {
               
                note = WebUtility.GetRequestStr("note", "");
                houseStruct = WebUtility.GetRequestInt("houseStruct", -1);
                beginTime = Utility.GetDateTime(Request.QueryString["beginTime"], null);
                endTime = Utility.GetDateTime(Request.QueryString["endTime"], null);
                bindData();
            }

            
        }

        void bindData()
        {
            long realBusinessUserID = this.GetRealBusinessUserID();

            StringBuilder builderWhere = new StringBuilder();
            builderWhere.Append(" UserID=@UserID ");
            db.Parameters.Append("@UserID", realBusinessUserID);



            db.EnableRecordCount = true;
            this.gvData.DataSource = db.Select(pageSize, pageIndex,
                    "vw_Houses_SeekerFavs", "ID", builderWhere.ToString(), "FavTime desc"
               );

            this.gvData.DataBind();
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }









    }
}

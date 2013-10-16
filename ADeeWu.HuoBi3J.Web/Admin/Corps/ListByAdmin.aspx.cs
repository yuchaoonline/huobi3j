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

namespace ADeeWu.HuoBi3J.Web.Admin.Corps
{
    public partial class ListByAdmin : PageBase
    {
        

        public override string PageID
        {
            get
            {
                return "002013";
            }
        }

        protected DataBase db = DataBase.Create();
        protected long pageSize = 20;
        protected long pageIndex = 1;

        protected long callingID = 0;
        protected long provinceID = 0;
        protected long cityID = 0;
        protected long areaID = 0;
        protected long adminUserID = -1;
        protected int checkState = -1;
        protected string corpName = string.Empty;
        
        

        protected void Page_Load(object sender, EventArgs e)
        {

            pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("pagesize", PageBase.DataList_PageSize);
            pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("page", 1);

            if (!IsPostBack)
            {
                ADeeWu.HuoBi3J.DAL.Corporations dal = new ADeeWu.HuoBi3J.DAL.Corporations();
                ADeeWu.HuoBi3J.DAL.Admin_Users dalAdmins = new ADeeWu.HuoBi3J.DAL.Admin_Users();

                this.ddlAdminUser.DataSource = dalAdmins.Select(-1, -1);
                this.ddlAdminUser.DataTextField = "loginName";
                this.ddlAdminUser.DataValueField = "id";
                this.ddlAdminUser.DataBind();
                this.ddlAdminUser.Items.Insert(0, new ListItem("所有", "-1"));


                callingID = WebUtility.GetRequestLong("callingid", 0);
                provinceID = WebUtility.GetRequestLong("provinceid", 0);
                cityID = WebUtility.GetRequestLong("cityid", 0);
                areaID = WebUtility.GetRequestLong("areaid", 0);
                adminUserID = WebUtility.GetRequestLong("adminUserID", -1);
                checkState = WebUtility.GetRequestInt("state", -1);
                corpName = WebUtility.GetRequestStr("corpName", "");
                
                bindData();
            }

            
            
        }



        protected void bindData()
        {
            StringBuilder builderWhere = new StringBuilder();

            if (adminUserID > -1)
            {
                builderWhere.Append(" and AdminUserID=@AdminUserID");
                db.Parameters.Append("@AdminUserID", this.LoginUser.UserID);
                this.Pager1.AppendUrlParam("adminUserID", adminUserID.ToString());
                this.ddlAdminUser.SelectedValue = adminUserID.ToString();
            }

            if (corpName.Length > 0)
            {
                builderWhere.Append(" and CorpName like @CorpName");
                db.Parameters.Append("@CorpName", string.Format("%{0}%", corpName));
                this.Pager1.AppendUrlParam("corpName", corpName);
                this.txtCorpName.Text = corpName;
            }

            if (callingID > 0)
            {
                builderWhere.Append(" and CallingID=@CallingID");
                db.Parameters.Append("@CallingID", callingID);
                this.Pager1.AppendUrlParam("calling01", callingID.ToString());
                this.syncSelectorCalling.SelectedValue = callingID.ToString();
            }

            if (provinceID > 0)
            {
                builderWhere.Append(" and ProvinceID=@ProvinceID");
                db.Parameters.Append("@ProvinceID", provinceID);
                this.Pager1.AppendUrlParam("province", provinceID.ToString());
            }

            if (cityID > 0)
            {
                builderWhere.Append(" and CityID=@CityID");
                db.Parameters.Append("@CityID", cityID);
                this.Pager1.AppendUrlParam("city", cityID.ToString());
            }
            if (areaID > 0)
            {
                builderWhere.Append(" and AreaID=@AreaID");
                db.Parameters.Append("@AreaID", areaID);
                this.Pager1.AppendUrlParam("area", areaID.ToString());
            }

            this.syncSelectorLocation.Values = new string[]{
                provinceID.ToString(),cityID.ToString(),areaID.ToString()
            };

            if (checkState > -1)
            {
                builderWhere.Append(" and CheckState=@CheckState");
                db.Parameters.Append("@CheckState", checkState);
                this.Pager1.AppendUrlParam("checkState", checkState.ToString());
                this.ddlCheckState.SelectedValue = checkState.ToString();
            }

            string where = " 1=1 " + (
                    (builderWhere.Length > 0) ? builderWhere.ToString().Substring(1) : string.Empty
            );

            db.EnableRecordCount = true;
            this.gvData.DataSource = db.Select(pageSize, pageIndex, "vw_Admin_Corporations", "id", where, "CreateTime desc");
            this.gvData.DataBind();
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
            this.db.EnableRecordCount = false;
            this.litNumOfCorps.Text = db.RecordCount.ToString();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            pageIndex = 1;
            callingID = Utility.GetLong(Request["calllingid"], this.syncSelectorCalling.SelectedValue, 0);
            string[] location = this.syncSelectorLocation.Values;
            provinceID = Utility.GetLong(Request["provinceid"], location[0], 0);
            cityID = Utility.GetLong(Request["cityid"], location[1], 0);
            areaID = Utility.GetLong(Request["areaid"], location[2], 0);
            adminUserID = Utility.GetLong(Request["adminUserID"], this.ddlAdminUser.SelectedValue, -1);
            checkState = Utility.GetInt(Request["state"], this.ddlCheckState.SelectedValue, -1);
            corpName = Utility.GetStr(Request["corpName"], this.txtCorpName.Text, "", true);
            bindData();
        }


    }
}
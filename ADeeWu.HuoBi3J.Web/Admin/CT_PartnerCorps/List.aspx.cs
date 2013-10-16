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

namespace ADeeWu.HuoBi3J.Web.Admin.CT_PartnerCorps
{

    /// <summary>
    /// 查询当前登陆管理员所有商家数据
    /// </summary>
    public partial class List : PageBase
    {
        DataBase db = DataBase.Create();

        public override string PageID
        {
            get
            {
                return "008003";
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            long pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("pagesize", PageBase.DataList_PageSize);
            long pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("page", 1);


            string corpName = ADeeWu.HuoBi3J.Libary.Utility.GetStr(Request.QueryString["corp"], Request.Form["corp"], "", true);
            long calling01 = ADeeWu.HuoBi3J.Libary.Utility.GetLong(Request.QueryString["calling01"], Request.Form["calling01"], -1);
            long calling02 = ADeeWu.HuoBi3J.Libary.Utility.GetLong(Request.QueryString["calling02"], Request.Form["calling01"], -1);
            long province = ADeeWu.HuoBi3J.Libary.Utility.GetLong(Request.QueryString["province"], Request.Form["province"], -1);
            long city = ADeeWu.HuoBi3J.Libary.Utility.GetLong(Request.QueryString["city"], Request.Form["city"], -1);
            long area = ADeeWu.HuoBi3J.Libary.Utility.GetLong(Request.QueryString["area"], Request.Form["area"], -1);
            int state = ADeeWu.HuoBi3J.Libary.Utility.GetInt(Request.QueryString["state"], Request.Form["state"], -1); 



            StringBuilder builderWhere = new StringBuilder();

         
            
            if (corpName != "")
            {
                builderWhere.Append(" and CorpName like @Name");
                db.Parameters.Append("@Name", string.Format("%{0}%", corpName));
                this.Pager1.AppendUrlParam("corp", corpName);
            }

            if (calling01 > 0 || calling02 > 0)
            {
                builderWhere.Append(" and CallingID=@CallingID");
                if (calling02 > 0)
                {
                    db.Parameters.Append("@CallingID", calling02);
                    this.Pager1.AppendUrlParam("calling02", calling02.ToString());
                }
                else
                {
                    db.Parameters.Append("@CallingID", calling01);
                    this.Pager1.AppendUrlParam("calling01", calling01.ToString());
                }
                
            }

            if (province > 0)
            {
                builderWhere.Append(" and ProvinceID=@ProvinceID");
                db.Parameters.Append("@ProvinceID", province);
                this.Pager1.AppendUrlParam("province", province.ToString());
            }
            if (city > 0)
            {
                builderWhere.Append(" and CityID=@CityID");
                db.Parameters.Append("@CityID", city);
                this.Pager1.AppendUrlParam("city", city.ToString());
            }
            if (area > 0)
            {
                builderWhere.Append(" and AreaID=@AreaID");
                db.Parameters.Append("@AreaID", area);
                this.Pager1.AppendUrlParam("area", area.ToString());
            }

            if (state >= 0)
            {
                builderWhere.Append(" and CheckState=@CheckState");
                db.Parameters.Append("@CheckState", state);
                this.Pager1.AppendUrlParam("state", state.ToString());
            }

            string where = string.Format(" CorpAdminUserID = {0}", base.LoginUser.UserID) + (
                    (builderWhere.Length > 0) ? builderWhere.ToString().Substring(1) : string.Empty
            );


            this.syncSelectorCalling.Values = new string[]
            {
                calling01.ToString(),calling02.ToString()
            };
            this.syncSelectorLocation.Values = new string[]
            {
                province.ToString(),city.ToString(),area.ToString()
            };
            this.state.Value = state.ToString();
            this.corp.Value = corpName;

            db.EnableRecordCount = true;
            this.gvData.DataSource = db.Select(pageSize, pageIndex, "vw_CT_PartnerCorps", "ID", where, "CreateTime desc");
            this.gvData.DataBind();
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
            db.EnableRecordCount = false;

        }
    }
}

using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using System.Data;
using ADeeWu.HuoBi3J.Web.Class;

namespace ADeeWu.HuoBi3J.Web.Center
{
    public partial class Location : System.Web.UI.Page
    {
        static long _pageIndex;
        static long _pageSize;
        static int _aid;
        static int _cid;
        static int _pid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _pageIndex = WebUtility.GetRequestLong("page", 1);
                _pageSize = Utility.GetLong(Request["pagesize"], 20, 5, 40);
                _aid = WebUtility.GetRequestInt("aid", -1);
                _cid = WebUtility.GetRequestInt("cid", -1);
                _pid = WebUtility.GetRequestInt("pid", -1);

                BandData(null, _pageIndex, _pageSize, _pid, _cid, _aid);
            }
        }

        private void BandData(string bname,long pageIndex,long pageSize,int pid,int cid,int aid)
        {
            var db = DataBase.Create();
            var db2 = DataBase.Create();
            var strWhere = "";
            if (aid != -1)
            {
                this.Pager1.AppendUrlParam("aid", aid.ToString());
                db.Parameters.Append("areaid", aid);
                db2.Parameters.Append("areaid", aid);
                strWhere = "areaid=@areaid";
            }
            else if (cid != -1)
            {
                this.Pager1.AppendUrlParam("cid", cid.ToString());
                db.Parameters.Append("cityid", cid);
                db2.Parameters.Append("cityid", cid);
                strWhere = "cityid=@cityid";
            }
            else
            {
                this.Pager1.AppendUrlParam("pid", pid.ToString());
                db.Parameters.Append("provinceid", pid);
                db2.Parameters.Append("provinceid", pid);
                strWhere = "provinceid=@provinceid";
            }

            var locations = db.Select("vw_Location", strWhere, "");
            if (locations == null || locations.Rows.Count <= 0) return;
            var location = locations.Rows[0];
            var strLocation = "";
            if (aid != -1)
            {
                strLocation = Helper.GetLocation(location["AreaID"], location["Area"], location["CityID"], location["City"], location["ProvinceID"], location["Province"], "-");
            }
            else if (cid != -1)
            {
                strLocation = Helper.GetLocation(location["CityID"], location["City"], location["ProvinceID"], location["Province"], "-");
            }
            else
            {
                strLocation = Helper.GetLocation(location["ProvinceID"], location["Province"]);
            }
            litLocation.Text = strLocation;

            if (!string.IsNullOrWhiteSpace(bname))
            {
                if (string.IsNullOrWhiteSpace(strWhere))
                {
                    strWhere = string.Format("bname like '%{0}%'", bname);
                }
                else
                {
                    strWhere += string.Format(" and bname like '%{0}%'", bname);
                }
            }

            db2.EnableRecordCount = true;
            var businessCircles = db2.Select(pageSize, pageIndex, "vw_BusinessCircle", "bid", strWhere, "");

            rpResult.DataSource = businessCircles;
            rpResult.DataBind();

            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db2.RecordCount;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BandData(txtName.Text, _pageIndex, _pageSize, _pid, _cid, _aid);
        }
    }
}
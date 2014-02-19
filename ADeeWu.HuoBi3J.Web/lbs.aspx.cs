using ADee.Project.LBS.BLL;
using ADee.Project.LBS.Entity;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Web.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web
{
    public partial class lbs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var method = Request["method"];
                if (method == "upload")
                {
                    Upload();
                }
                if (method == "delete")
                {
                    Delete();
                }
            }
        }

        private void Delete()
        {
            var poibll = new PoiBLL();
            for (int i = 0; i < 92; i++)
            {
                var lists = poibll.List<ADeeWu.HuoBi3J.Libary.LBSHelper.ProductPoi>("49566", new Dictionary<string, string>());
                if (lists != null && lists.pois != null && lists.pois.Count > 0)
                    foreach (var poi in lists.pois)
                    {
                        poibll.Delete(new List<string> { poi.id }, "49566");
                    }
            }

        }

        private void Upload()
        {
            var lists = DataBase.Create().Select(string.Format("select top 1000 * from vw_Key_Product"));
            if (lists == null || lists.Rows.Count <= 0) return;

            foreach (DataRow item in lists.Rows)
            {
                try
                {
                    var poiBLL = new PoiBLL();
                    var dic = new Dictionary<string, string>();
                    dic.Add("Price", item["Price"].ToString());
                    dic.Add("Description", item["Description"].ToString());
                    dic.Add("BName", item["BName"].ToString());
                    dic.Add("CompanyName", item["CompanyName"].ToString());
                    dic.Add("Phone", item["Phone"].ToString());
                    dic.Add("Phone", item["Phone"].ToString());
                    dic.Add("SalemanMemo", item["SalemanMemo"].ToString());
                    dic.Add("QQ", item["QQ"].ToString());
                    dic.Add("SelectType", item["SelectType"].ToString());
                    dic.Add("SelectPrice", item["SelectPrice"].ToString());
                    dic.Add("SelectSize", item["SelectSize"].ToString());
                    dic.Add("KID", item["KID"].ToString());
                    dic.Add("AID", item["AID"].ToString());
                    dic.Add("CreateUserID", item["CreateUserID"].ToString());

                    poiBLL.Create(Utility.GetFloat(item["PositionX"], 0f), Utility.GetFloat(item["PositionY"], 0f), ADee.Project.LBS.Entity.CoordType.BaiduEncrypt, "49566", dic, item["SimpleDesc"].ToString(), item["CompanyAddress"].ToString(), item["KName"].ToString());
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
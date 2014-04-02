using ADee.Project.LBS.BLL;
using ADee.Project.LBS.Entity;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Web.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
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

                Response.Write("Start!" + DateTime.Now.ToString());

                if (method == "upload")
                {
                    Upload();
                }
                if (method == "delete")
                {
                    Delete();
                }
                if (method == "list")
                {
                    List();
                }

                Response.Write("\r\nOK!" + DateTime.Now.ToString());
            }
        }

        private void Delete()
        {
            var poibll = new PoiBLL();
            while (true)
            {
                var lists = poibll.List<ADeeWu.HuoBi3J.Libary.LBSHelper.ProductPoi>("49566", new Dictionary<string, string>());
                if (lists != null && lists.pois != null && lists.pois.Count > 0)
                    foreach (var poi in lists.pois)
                    {
                        poibll.Delete(new List<string> { poi.id }, "49566");
                    }
                else break;
            }
            Response.Write("OK");
        }

        private void List()
        {
            var datas = new List<ADeeWu.HuoBi3J.Libary.LBSHelper.ProductPoi>();

            var poiBLL = new PoiBLL();
            var pagesize = 200;
            var pageindex = 0;

            while (true)
            {
                try
                {
                    var results = poiBLL.List<ADeeWu.HuoBi3J.Libary.LBSHelper.ProductPoi>("49566", new Dictionary<string, string>(), "", "", "", pageindex, pagesize);
                    if (results.status != 0 || results.pois == null || results.pois.Count <= 0) break;

                    datas.AddRange(results.pois);
                    pageindex++;
                }
                catch
                {
                    break;
                }
            }

            File.AppendAllText(@"d:\\data.txt", JsonConvert.SerializeObject(datas));
        }

        private void Upload()
        {
            var poiBLL = new PoiBLL();
            var msg = DateTime.Now.ToString();

            var pois = JsonConvert.DeserializeObject<List<ADeeWu.HuoBi3J.Libary.LBSHelper.ProductPoi>>(File.ReadAllText(@"d:\\data.txt"));

            foreach (ADeeWu.HuoBi3J.Libary.LBSHelper.ProductPoi item in pois)
            {
                try
                {
                    var dic = new Dictionary<string, string>();
                    if (item.Price > 0)
                        dic.Add("Price", item.Price.ToString());
                    if (!string.IsNullOrWhiteSpace(item.Description))
                        dic.Add("Description", item.Description);
                    if (!string.IsNullOrWhiteSpace(item.CompanyName))
                        dic.Add("CompanyName", item.CompanyName);
                    if (!string.IsNullOrWhiteSpace(item.Phone))
                        dic.Add("Phone", item.Phone);
                    if (!string.IsNullOrWhiteSpace(item.SalemanMemo))
                        dic.Add("SalemanMemo", item.SalemanMemo);
                    if (!string.IsNullOrWhiteSpace(item.QQ))
                        dic.Add("QQ", item.QQ);
                    if (!string.IsNullOrWhiteSpace(item.KName))
                        dic.Add("KName", item.KName);
                    if (item.KID > 0)
                        dic.Add("KID", item.KID.ToString());
                    if (item.CreateUserID > 0)
                        dic.Add("CreateUserID", item.CreateUserID.ToString());
                    if (!string.IsNullOrWhiteSpace(item.SelectTypeID))
                        dic.Add("SelectTypeID", item.SelectTypeID);
                    if (!string.IsNullOrWhiteSpace(item.SelectPriceID))
                        dic.Add("SelectPriceID", item.SelectPriceID);
                    if (!string.IsNullOrWhiteSpace(item.SelectSizeID))
                        dic.Add("SelectSizeID", item.SelectSizeID);
                    if (!string.IsNullOrWhiteSpace(item.SelectType))
                        dic.Add("SelectType", item.SelectType);
                    if (!string.IsNullOrWhiteSpace(item.SelectPrice))
                        dic.Add("SelectPrice", item.SelectPrice);
                    if (!string.IsNullOrWhiteSpace(item.SelectSize))
                        dic.Add("SelectSize", item.SelectSize);

                    poiBLL.Create(item.location[1], item.location[0], ADee.Project.LBS.Entity.CoordType.BaiduEncrypt, "58781", dic, item.title, item.address, item.tags);
                }
                catch
                {
                    msg += Environment.NewLine + item.id;
                }
            }

            msg += Environment.NewLine + DateTime.Now.ToString();
            litText.Text = msg;
        }
    }
}
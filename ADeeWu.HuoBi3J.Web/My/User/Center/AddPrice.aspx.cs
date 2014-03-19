using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Web.Class;
using System.Data;
using System.Linq;
using Newtonsoft.Json;
using ADee.Project.LBS.BLL;

namespace ADeeWu.HuoBi3J.Web.My.User.Center
{
    public partial class AddPrice : Class.PageBase_CircleSaleMan
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var method = WebUtility.GetRequestStr("method", string.Empty);
                if (string.IsNullOrWhiteSpace(method))
                    Search();
                else
                    Save();
            }
        }

        private void Search()
        {

        }

        private void Save()
        {
            var result = "";
            if (LoginUser == null)
            {
                result = JsonConvert.SerializeObject(new { statue = false, msg = "请登录！" });
            }
            else
            {
                var txtPrice = WebUtility.GetRequestStr("price", "");
                var txtSimpleDesc = WebUtility.GetRequestStr("simpledesc", "");
                var txtDesc = WebUtility.GetRequestStr("description", "");

                if (string.IsNullOrWhiteSpace(txtPrice))
                {
                    WebUtility.ShowMsg("价格不能为空！");
                    return;
                }

                if (!Utility.IsFloat(txtPrice))
                {
                    WebUtility.ShowMsg("价格格式不正确！");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPrice))
                {
                    WebUtility.ShowMsg("商品简单描述不能为空！");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDesc))
                {
                    WebUtility.ShowMsg("商品详情描述不能为空！");
                    return;
                }

                if (txtDesc.Length>200)
                {
                    WebUtility.ShowMsg("商品详情描述长度应小于200！");
                    return;
                }

                var db = DataBase.Create();
                var salemanTB = db.Select("select * from vw_Key_CircleSaleMan where UserID = " + LoginUser.UserID);
                if (salemanTB.Rows.Count <= 0) throw new Exception("商家未找到！");
                var saleman = salemanTB.Rows[0];

                var dic = new Dictionary<string, string>();
                dic.Add("Description", txtDesc);
                dic.Add("Price", txtPrice);
                dic.Add("CreateUserID", LoginUser.UserID.ToString());
                dic.Add("CompanyName", saleman["CompanyName"].ToString());
                dic.Add("SalemanMemo", saleman["Memo"].ToString());
                dic.Add("QQ", saleman["QQ"].ToString());
                dic.Add("Phone", saleman["Phone"].ToString());

                var poiBLL = new PoiBLL();
                try
                {
                    var id = poiBLL.Create(
                        Utility.GetFloat(saleman["PositionX"], 0f),
                        Utility.GetFloat(saleman["PositionY"], 0f),
                        ADee.Project.LBS.Entity.CoordType.BaiduEncrypt,
                        ADee.Project.LBS.Common.ConfigHelper.GeoProductTableID,
                        dic,
                        txtSimpleDesc,
                        saleman["CompanyAddress"].ToString(),
                        txtSimpleDesc);

                    if (!string.IsNullOrWhiteSpace(id)) 
                        result = JsonConvert.SerializeObject(new { statue = true });
                    else
                        result = JsonConvert.SerializeObject(new { statue = false, msg = "添加失败！" });
                }
                catch
                {
                    result = JsonConvert.SerializeObject(new { statue = false, msg = "添加失败！" });
                }
            }

            Response.Write(result);
            Response.Flush();
            Response.End();
        }
    }
}
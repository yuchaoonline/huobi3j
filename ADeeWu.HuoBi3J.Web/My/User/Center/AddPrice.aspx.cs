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
                {
                    Response.Write(Save());
                    Response.Flush();
                    Response.End();
                }
            }
        }

        private void Search()
        {

        }

        private string Save()
        {
            if (LoginUser == null)
            {
                return JsonConvert.SerializeObject(new { statue = false, msg = "请登录！" });
            }
            else
            {
                var txtPrice = WebUtility.GetRequestStr("price", "");
                var txtSimpleDesc = WebUtility.GetRequestStr("simpledesc", "");
                var txtDesc = WebUtility.GetRequestStr("description", "");

                if (string.IsNullOrWhiteSpace(txtPrice))
                {
                    return JsonConvert.SerializeObject(new { statue = false, msg = "价格不能为空！" });
                }

                if (!Utility.IsFloat(txtPrice))
                {
                    return JsonConvert.SerializeObject(new { statue = false, msg = "价格格式不正确！" });
                }

                if (string.IsNullOrWhiteSpace(txtPrice))
                {
                    return JsonConvert.SerializeObject(new { statue = false, msg = "商品简单描述不能为空！" });
                }

                if (string.IsNullOrWhiteSpace(txtDesc))
                {
                    return JsonConvert.SerializeObject(new { statue = false, msg = "商品详情描述不能为空！" });
                }

                if (txtDesc.Length>200)
                {
                    return JsonConvert.SerializeObject(new { statue = false, msg = "商品详情描述长度应小于200！" });
                }

                var db = DataBase.Create();
                var salemanTB = db.Select("select * from vw_Key_CircleSaleMan where UserID = " + LoginUser.UserID);
                if (salemanTB.Rows.Count <= 0) return JsonConvert.SerializeObject(new { statue = false, msg = "商家未找到！" });
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
                        return JsonConvert.SerializeObject(new { statue = true });
                    else
                        return JsonConvert.SerializeObject(new { statue = false, msg = "添加失败！" });
                }
                catch
                {
                    return JsonConvert.SerializeObject(new { statue = false, msg = "添加失败！" });
                }
            }
        }
    }
}
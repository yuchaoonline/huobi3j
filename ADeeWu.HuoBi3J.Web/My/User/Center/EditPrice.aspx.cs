using ADee.Project.LBS.BLL;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Web.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.My.User.Center
{
    public partial class EditPrice : PageBase_CircleSaleMan
    {
        int id = 0;
        public ADeeWu.HuoBi3J.Libary.LBSHelper.ProductPoi product;
        PoiBLL poiBLL = new PoiBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = WebUtility.GetRequestInt("id", -1);
                if (id == -1)
                {
                    WebUtility.ShowAndGoBack(this, "参数有误！");
                    return;
                }

                var method = WebUtility.GetRequestStr("method", string.Empty);
                if (string.IsNullOrWhiteSpace(method))
                    Search();
                else
                    Save();
            }
        }

        private void Search()
        {
            if (LoginUser == null)
            {
                WebUtility.ShowMsg(this, "请登录！", "/login.aspx?url=" + Request.RawUrl);
                return;
            }

            product = poiBLL.Details<ADeeWu.HuoBi3J.Libary.LBSHelper.ProductPoi>(id, ADee.Project.LBS.Common.ConfigHelper.GeoProductTableID).poi;
        }

        private void Save()
        {
            var result = "";
            if (LoginUser == null)
            {
                result = Newtonsoft.Json.JsonConvert.SerializeObject(new { statue = false, msg = "请登录！" });
            }
            else
            {
                var id = WebUtility.GetRequestInt("id", 0);
                var txtPrice = WebUtility.GetRequestStr("price", "");
                var txtSimpleDesc = WebUtility.GetRequestStr("simpledesc", "");
                var txtOldSimpleDesc = WebUtility.GetRequestStr("oldsimpledesc", "");
                var tags = WebUtility.GetRequestStr("tags", "");
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

                var dic = new Dictionary<string, string>();
                dic.Add("Description", txtDesc);
                dic.Add("Price", txtPrice);

                var newTags = "";
                if (string.IsNullOrWhiteSpace(tags))
                    newTags = txtSimpleDesc;
                else
                {
                    if (!string.IsNullOrWhiteSpace(txtOldSimpleDesc))
                        newTags = tags.Replace(txtOldSimpleDesc, txtSimpleDesc);
                    else
                        newTags = tags + " " + txtSimpleDesc;
                }

                try
                {
                    poiBLL.Update(
                        id,
                        ADee.Project.LBS.Common.ConfigHelper.GeoProductTableID, 
                        ADee.Project.LBS.Entity.CoordType.BaiduEncrypt, 
                        dic,
                        txtSimpleDesc, 
                        newTags);
                    result = JsonConvert.SerializeObject(new { statue = true });
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
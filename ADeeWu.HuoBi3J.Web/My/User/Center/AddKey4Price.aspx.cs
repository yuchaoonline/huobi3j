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
using ADee.Project.LBS.Common;

namespace ADeeWu.HuoBi3J.Web.My.User.Center
{
    public partial class AddKey4Price : Class.PageBase_CircleSaleMan
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
            var kid = WebUtility.GetRequestInt("kid", -1);
            var id = WebUtility.GetRequestInt("id", -1);
            if (kid == -1 || id == -1)
            {
                WebUtility.ShowAndGoBack(this, "参数有误！");
                return;
            }

            if (LoginUser == null)
            {
                WebUtility.ShowMsg(this, "请登录！", "/login.aspx?url=" + Request.RawUrl);
                return;
            }

            var productPoi = new PoiBLL().Details<ADeeWu.HuoBi3J.Libary.LBSHelper.ProductPoi>(id, ADee.Project.LBS.Common.ConfigHelper.GeoProductTableID).poi;
            litTitle.Text = productPoi.title;
            litPrice.Text = productPoi.Price.ToString("F2");

            var key = new DAL.Key().GetEntity(kid);
            litKey.Text = key.Name;

            var attributes = new DAL.Key_Attribute().GetEntityList("", new string[] { "kid" }, new object[] { kid });
            ddlType.DataSource = attributes.Where(p => p.DataType == "SelectType").Select(p => new { ID = p.ID, Value = p.DataValue });
            ddlType.DataTextField = "Value";
            ddlType.DataValueField = "ID";
            ddlType.DataBind();
            ddlType.AppendDataBoundItems = true;
            ddlType.Items.Insert(0, new ListItem(""));

            ddlPrice.DataSource = attributes.Where(p => p.DataType == "SelectPrice").Select(p => new { ID = p.ID, Value = p.DataValue });
            ddlPrice.DataTextField = "Value";
            ddlPrice.DataValueField = "ID";
            ddlPrice.DataBind();
            ddlPrice.AppendDataBoundItems = true;
            ddlPrice.Items.Insert(0, new ListItem(""));

            ddlSize.DataSource = attributes.Where(p => p.DataType == "SelectSize").Select(p => new { ID = p.ID, Value = p.DataValue });
            ddlSize.DataTextField = "Value";
            ddlSize.DataValueField = "ID";
            ddlSize.DataBind();
            ddlSize.AppendDataBoundItems = true;
            ddlSize.Items.Insert(0, new ListItem(""));

            var viewPrice = new DAL.Key_ViewPrice().GetEntity(new string[] { "KID" }, new object[] { kid });
            if (viewPrice != null && viewPrice.ID > 0)
                litmsg.Text = string.Format("该关键字每次点击扣费 {0} 元，每条信息当天点击 量达到 {1} 次后当日不再计费！", viewPrice.Count, viewPrice.Price);
            else
                litmsg.Text = "请注意，该关键字的报价点击免费，有可能会在未来收费";
        }

        private void Save()
        {
            var kid = WebUtility.GetRequestInt("kid", -1);
            var id = WebUtility.GetRequestInt("id", -1);
            if (kid == -1 || id == -1)
            {
                WebUtility.ShowAndGoBack(this, "参数有误！");
                return;
            }

            var result = "";
            if (LoginUser == null)
            {
                result = JsonConvert.SerializeObject(new { statue = false, msg = "请登录！" });
            }
            else
            {
                var selecttype = WebUtility.GetRequestStr("selecttype", "");
                var selectprice = WebUtility.GetRequestStr("selectprice", "");
                var selectsize = WebUtility.GetRequestStr("selectsize", "");
                var selecttypeid = WebUtility.GetRequestStr("selecttypeid", "");
                var selectpriceid = WebUtility.GetRequestStr("selectpriceid", "");
                var selectsizeid = WebUtility.GetRequestStr("selectsizeid", "");

                var key = new DAL.Key().GetEntity(kid);
                if (key == null) return;
                
                var dic = new Dictionary<string, string>();
                dic.Add("KID", kid.ToString());
                dic.Add("SelectType", selecttype);
                dic.Add("SelectPrice", selectprice);
                dic.Add("SelectSize", selectsize);
                dic.Add("SelectTypeID", selecttypeid);
                dic.Add("SelectPriceID", selectpriceid);
                dic.Add("SelectSizeID", selectsizeid);
                dic.Add("KName", key.Name);

                var poiBLL = new PoiBLL();
                var productPoi = poiBLL.Details<ADeeWu.HuoBi3J.Libary.LBSHelper.ProductPoi>(id, ConfigHelper.GeoProductTableID);
                if (productPoi.status != 0) return;
                try
                {
                    var tags = productPoi.poi.title+" "+key.Name;
                    if(!string.IsNullOrWhiteSpace(productPoi.poi.BName)) tags+=" "+productPoi.poi.BName;
                    poiBLL.Update(id, ADee.Project.LBS.Common.ConfigHelper.GeoProductTableID, ADee.Project.LBS.Entity.CoordType.BaiduEncrypt, dic, "", tags);
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
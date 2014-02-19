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
    public partial class EditPrice4Key : PageBase_CircleSaleMan
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

            DataBase db = DataBase.Create();

            db.Parameters.Append("kid", product.KID);
            var keys = db.Select("vw_Keys", "kid=@kid", "");
            rpKey.DataSource = keys;
            rpKey.DataBind();

            var attributes = new DAL.Key_Attribute().GetEntityList("", new string[] { "kid" }, new object[] { product.KID });
            ddlType.DataSource = attributes.Where(p => p.DataType == "SelectType").Select(p => new { ID = p.ID, Value = p.DataValue });
            ddlType.DataTextField = "Value";
            ddlType.DataValueField = "ID";
            ddlType.DataBind();
            ddlType.AppendDataBoundItems = true;
            ddlType.Items.Insert(0, new ListItem(""));
            ddlType.SelectedValue = product.SelectTypeID;

            ddlPrice.DataSource = attributes.Where(p => p.DataType == "SelectPrice").Select(p => new { ID = p.ID, Value = p.DataValue });
            ddlPrice.DataTextField = "Value";
            ddlPrice.DataValueField = "ID";
            ddlPrice.DataBind();
            ddlPrice.AppendDataBoundItems = true;
            ddlPrice.Items.Insert(0, new ListItem(""));
            ddlPrice.SelectedValue = product.SelectPriceID;

            ddlSize.DataSource = attributes.Where(p => p.DataType == "SelectSize").Select(p => new { ID = p.ID, Value = p.DataValue });
            ddlSize.DataTextField = "Value";
            ddlSize.DataValueField = "ID";
            ddlSize.DataBind();
            ddlSize.AppendDataBoundItems = true;
            ddlSize.Items.Insert(0, new ListItem(""));
            ddlSize.SelectedValue = product.SelectSizeID;
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
                var kid = WebUtility.GetRequestInt("kid", 0);
                var txtPrice = WebUtility.GetRequestStr("price", "");
                var txtSimpleDesc = WebUtility.GetRequestStr("simpledesc", "");
                var txtDesc = WebUtility.GetRequestStr("description", "");
                var selecttype = WebUtility.GetRequestStr("selecttype", "");
                var selectprice = WebUtility.GetRequestStr("selectprice", "");
                var selectsize = WebUtility.GetRequestStr("selectsize", "");
                var selecttypeid = WebUtility.GetRequestStr("selecttypeid", "");
                var selectpriceid = WebUtility.GetRequestStr("selectpriceid", "");
                var selectsizeid = WebUtility.GetRequestStr("selectsizeid", "");

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

                var dic = new Dictionary<string, string>();
                dic.Add("Description", txtDesc);
                dic.Add("Price", txtPrice);
                dic.Add("SelectType", selecttype);
                dic.Add("SelectPrice", selectprice);
                dic.Add("SelectSize", selectsize);
                dic.Add("SelectTypeID", selecttypeid);
                dic.Add("SelectPriceID", selectpriceid);
                dic.Add("SelectSizeID", selectsizeid);

                try
                {
                    poiBLL.Update(id, ADee.Project.LBS.Common.ConfigHelper.GeoProductTableID, ADee.Project.LBS.Entity.CoordType.BaiduEncrypt, dic, txtSimpleDesc);
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
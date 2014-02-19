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
    public partial class AddPrice4Key : Class.PageBase_CircleSaleMan
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
            if (kid == -1)
            {
                WebUtility.ShowAndGoBack(this, "参数有误！");
                return;
            }

            if (LoginUser == null)
            {
                WebUtility.ShowMsg(this, "请登录！", "/login.aspx?url=" + Request.RawUrl);
                return;
            }

            DataBase db = DataBase.Create();

            db.Parameters.Append("kid", kid);
            var keys = db.Select("vw_Keys", "kid=@kid", "");
            rpKey.DataSource = keys;
            rpKey.DataBind();

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
        }

        private void Save()
        {
            var kid = WebUtility.GetRequestInt("kid", -1);
            if (kid == -1)
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

                var db = DataBase.Create();
                var keyTB = db.Select("select * from vw_Keys where kid = " + kid);
                if (keyTB.Rows.Count <= 0) throw new Exception("关键字未找到！");
                var key = keyTB.Rows[0];
                var salemanTB = db.Select("select * from vw_CircleSaleMan where UserID = " + LoginUser.UserID);
                if (salemanTB.Rows.Count <= 0) throw new Exception("商家未找到！");
                var saleman = salemanTB.Rows[0];

                var dic = new Dictionary<string, string>();
                dic.Add("KID", kid.ToString());
                dic.Add("Description", txtDesc);
                dic.Add("Price", txtPrice);
                dic.Add("SelectType", selecttype);
                dic.Add("SelectPrice", selectprice);
                dic.Add("SelectSize", selectsize);
                dic.Add("SelectTypeID", selecttypeid);
                dic.Add("SelectPriceID", selectpriceid);
                dic.Add("SelectSizeID", selectsizeid);
                dic.Add("CreateUserID", LoginUser.UserID.ToString());
                dic.Add("KName", key["KName"].ToString());
                dic.Add("BName", key["BName"].ToString());
                dic.Add("CompanyName", saleman["CompanyName"].ToString());
                dic.Add("SalemanMemo", saleman["Memo"].ToString());
                dic.Add("QQ", saleman["QQ"].ToString());
                dic.Add("Phone", saleman["Phone"].ToString());
                dic.Add("AID", key["AID"].ToString());

                var poiBLL = new PoiBLL();
                try
                {
                    var id = poiBLL.Create(Utility.GetFloat(saleman["PositionX"], 0f), Utility.GetFloat(saleman["PositionY"], 0f), ADee.Project.LBS.Entity.CoordType.BaiduEncrypt, ADee.Project.LBS.Common.ConfigHelper.GeoProductTableID, dic, txtSimpleDesc, saleman["CompanyAddress"].ToString(), key["KName"].ToString());

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
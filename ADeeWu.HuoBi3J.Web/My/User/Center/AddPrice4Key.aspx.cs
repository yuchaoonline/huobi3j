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
using LitJson;

namespace ADeeWu.HuoBi3J.Web.My.User.Center
{
    public partial class AddPrice4Key : Class.PageBase_CircleSaleMan
    {
        int kid = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                kid = WebUtility.GetRequestInt("kid", -1);
                if (kid == -1)
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

            var pageIndex = WebUtility.GetRequestLong("page", 1);
            var pageSize = Utility.GetLong(Request["pagesize"], 10, 5, 40);

            DataBase db = DataBase.Create();

            db.Parameters.Append("kid", kid);
            var keys = db.Select("vw_Keys", "kid=@kid", "");
            rpKey.DataSource = keys;
            rpKey.DataBind();

            db.Parameters.Append("kid", kid);
            var dtAttributes = db.Select("Key_Attribute", "kid=@kid", "");
            var keyType = new List<string>();
            var KeySize = new List<string>();
            var KeyPrice = new List<string>();
            foreach (DataRow item in dtAttributes.Rows)
            {
                keyType.Add(item["KeyType"].ToString());
                KeySize.Add(item["KeySize"].ToString());
                KeyPrice.Add(item["KeyPrice"].ToString());
            }
            litPrice.Text = "<li class='item'><a href='#' class='selectPrice'>无</a></li>";
            litSize.Text = "<li class='item'><a href='#' class='selectSize'>无</a></li>";
            litType.Text = "<li class='item'><a href='#' class='selectType'>无</a></li>";

            litPrice.Text += string.Join("", KeyPrice.Select(p => "<li class='item'><a href='#' class='selectPrice'>" + p + "</a></li>"));
            litSize.Text += string.Join("", KeySize.Select(p => "<li class='item'><a href='#' class='selectSize'>" + p + "</a></li>"));
            litType.Text += string.Join("", keyType.Select(p => "<li class='item'><a href='#' class='selectType'>" + p + "</a></li>"));
        }

        private void Save()
        {
            var result = "";
            if (LoginUser == null)
            {
                result = JsonMapper.ToJson(new { statue = false, msg = "请登录！" });
            }
            else
            {
                var txtPrice = WebUtility.GetRequestStr("price", "");
                var txtSimpleDesc = WebUtility.GetRequestStr("simpledesc", "");
                var txtDesc = WebUtility.GetRequestStr("description", "");
                var selectAttribute = WebUtility.GetRequestStr("selectattribute", "");

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

                var attribute = new Model.Key_Product
                {
                    KID = kid,
                    Description = txtDesc,
                    Price = Utility.GetDecimal(txtPrice, 0),
                    SelectAttribute = selectAttribute,
                    SimpleDesc = txtSimpleDesc,
                    CreateUserID = LoginUser.UserID,
                };


                if (new DAL.Key_Product().Add(attribute) > 0)
                {
                    result = JsonMapper.ToJson(new { statue = true });
                }
                else
                {
                    result = JsonMapper.ToJson(new { statue = false, msg = "添加失败！" });
                }
            }

            Response.Write(result);
            Response.Flush();
            Response.End();
        }
    }
}
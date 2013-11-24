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
        public Model.Key_Product product;

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

            product = new DAL.Key_Product().GetEntity(id);
            
            DataBase db = DataBase.Create();

            db.Parameters.Append("kid", product.KID);
            var keys = db.Select("vw_Keys", "kid=@kid", "");
            rpKey.DataSource = keys;
            rpKey.DataBind();

            litPrice.Text = "<li class='item'><a href='#' class='selectPrice'>无</a></li>";
            litSize.Text = "<li class='item'><a href='#' class='selectSize'>无</a></li>";
            litType.Text = "<li class='item'><a href='#' class='selectType'>无</a></li>";

            var attribute = new DAL.Key_Attribute().GetEntity("kid=" + product.KID);
            litPrice.Text += string.Join("", attribute.KeyPrice.Split(new char[] { ';' }).Select(p => "<li class='item'><a href='#' class='selectPrice'>" + p + "</a></li>"));
            litSize.Text += string.Join("", attribute.KeySize.Split(new char[] { ';' }).Select(p => "<li class='item'><a href='#' class='selectSize'>" + p + "</a></li>"));
            litType.Text += string.Join("", attribute.KeyType.Split(new char[] { ';' }).Select(p => "<li class='item'><a href='#' class='selectType'>" + p + "</a></li>"));
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
                var selectprice = WebUtility.GetRequestStr("selecprice", "");
                var selectsize = WebUtility.GetRequestStr("selectsize", "");

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
                    ID=id,
                    KID = kid,
                    Description = txtDesc,
                    Price = Utility.GetDecimal(txtPrice, 0),
                    SelectType=selecttype,
                    SelectPrice=selectprice,
                    SelectSize = selectsize,
                    SimpleDesc = txtSimpleDesc,
                    CreateUserID = LoginUser.UserID,
                };


                if (new DAL.Key_Product().Update(attribute) > 0)
                {
                    result = JsonConvert.SerializeObject(new { statue = true });
                }
                else
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
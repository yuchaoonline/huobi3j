using ADeeWu.HuoBi3J.Web.Class;
using ADeeWu.HuoBi3J.Libary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.My.Corp.GroupBuy
{
    public partial class Edit : PageBase_MyCorp
    {
        DAL.GroupBuy_Category categoryDAL = new DAL.GroupBuy_Category();
        DAL.GroupBuy_Product productDAL = new DAL.GroupBuy_Product();
        DAL.HotPlace hotPlaceDAL = new DAL.HotPlace();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BandData();
            }
        }

        private void BandData()
        {
            var id = WebUtility.GetRequestInt("id", 0);
            if (id <= 0) return;
            var product = productDAL.GetEntity(id);
            if (product == null) return;

            hfID.Value = id.ToString();
            txtBuyLink.Text = product.BuyLink;
            txtTitle.Text = product.Title;
            syncSelectorLocation.SelectedValue = product.AreaID.ToString();
            ddlCategory.SelectedValue = product.Category;
            txtSummary.Text = product.Summary.Value.ToString();
            txtPrice.Text = product.Price.Value.ToString();
            txtMarketPrice.Text = product.MarketPrice.ToString();
            dtsEndDate.Text = product.PassDate.Value.AddDays(product.SaleDay.Value).ToString("yyyy/MM/dd");
            if (product.PassDate.HasValue)
            {
                dtsPassDate.Text = product.PassDate.Value.ToString("yyyy/MM/dd");
            }
            txtDetail.Value = product.Detail;
            txtRemind.Value = product.Remind;
            txtProductIntro.Value = product.ProductIntro;
            txtSellerIntro.Value = product.SellerIntro;
            txtMapLocation.Text = product.MapLocation;

            if (product.HotPlaceID.HasValue)
            {
                var hotplace = hotPlaceDAL.GetEntity(product.HotPlaceID.Value);
                if (hotplace != null)
                {
                    txtHotPlace.Text = hotplace.Name;
                }
            }

            var categorys = categoryDAL.GetEntityList("", new string[] { }, new string[] { });
            ddlCategory.DataSource = categorys;
            ddlCategory.DataTextField = "Name";
            ddlCategory.DataValueField = "Name";
            ddlCategory.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            #region 验证非空
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                WebUtility.ShowMsg("标题不能为空！");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDetail.Value))
            {
                WebUtility.ShowMsg("详情不能为空！");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtRemind.Value))
            {
                WebUtility.ShowMsg("温馨提示不能为空！");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSummary.Text))
            {
                WebUtility.ShowMsg("预订数不能为空！");
                return;
            }
            if (!Utility.IsNumeric(txtSummary.Text))
            {
                WebUtility.ShowMsg("预订数应为数字！");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                WebUtility.ShowMsg("单价不能为空！");
                return;
            }
            if (!Utility.IsFloat(txtPrice.Text))
            {
                WebUtility.ShowMsg("单价应为数字！");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSellerIntro.Value))
            {
                WebUtility.ShowMsg("商家介绍不能为空！");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMapLocation.Text))
            {
                WebUtility.ShowMsg("商家位置不能为空！");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtProductIntro.Value))
            {
                WebUtility.ShowMsg("商品介绍不能为空！");
                return;
            }
            if (string.IsNullOrWhiteSpace(syncSelectorLocation.SelectedValue))
            {
                WebUtility.ShowMsg("未选择发布地区！");
                return;
            }
            if (string.IsNullOrWhiteSpace(dtsPassDate.Text))
            {
                WebUtility.ShowMsg("请选择开始预订时间！");
                return;
            }
            if (!Utility.IsDateTime(dtsPassDate.Text))
            {
                WebUtility.ShowMsg("预订时间不合法");
                return;
            }
            if (string.IsNullOrWhiteSpace(dtsEndDate.Text))
            {
                WebUtility.ShowMsg("请选择结束时间！");
                return;
            }
            if (!Utility.IsDateTime(dtsEndDate.Text))
            {
                WebUtility.ShowMsg("结束时间不合法！");
                return;
            }
            var saleday = Utility.GetDateTime(dtsEndDate.Text, DateTime.Now).Value.DayOfYear - Utility.GetDateTime(dtsPassDate.Text, DateTime.Now).Value.DayOfYear;
            if (saleday <= 0)
            {
                WebUtility.ShowMsg("结束时间应大于开始时间！");
                return;
            }
            if (string.IsNullOrWhiteSpace(ddlCategory.SelectedValue))
            {
                WebUtility.ShowMsg("请选择返现分类！");
                return;
            }
            if (string.IsNullOrWhiteSpace(syncSelectorLocation.SelectedValue) || syncSelectorLocation.SelectedValue == "-1")
            {
                WebUtility.ShowMsg("请选择发布地！");
                return;
            }
            #endregion
            var filename = hfPhoto.Value;
            if (fuPhoto.HasFile)
            {
                filename = fuPhoto.GetUploadedFilePath();
            }
            var product = new Model.GroupBuy_Product
            {
                ID = Utility.GetInt(hfID.Value,0),
                CreateUserID = (int)LoginUser.UserID,
                AreaID = Utility.GetInt(syncSelectorLocation.SelectedValue, 0),
                Category = ddlCategory.SelectedValue,
                CreateDate = DateTime.Now,
                Detail = txtDetail.Value,
                IsExpire = false,
                IsPass = false,
                MapLocation = txtMapLocation.Text,
                MarketPrice = Utility.GetDecimal(txtMarketPrice.Text, 0),
                Photo = filename,
                Price = Utility.GetDecimal(txtPrice.Text, 0),
                Remind = txtRemind.Value,
                SaleDay = saleday,
                SellerIntro = txtSellerIntro.Value,
                Summary = Utility.GetInt(txtSummary.Text, 0),
                Title = txtTitle.Text,
                BusinessCircle = string.Empty,
                ProductIntro = txtProductIntro.Value,
                PassDate = Utility.GetDateTime(dtsPassDate.Text, DateTime.Now),
                BuyLink = txtBuyLink.Text,
            };

            #region 热闹圈处理
            if (!string.IsNullOrWhiteSpace(txtHotPlace.Text))
            {
                var hotplaceDAL = new DAL.HotPlace();
                var hotPlace = hotplaceDAL.GetEntity("name = '" + txtHotPlace.Text + "'");
                if (hotPlace != null)
                {
                    product.HotPlaceID = hotPlace.ID;
                }
                else
                {
                    var newID = hotplaceDAL.Add(new Model.HotPlace
                    {
                        Name = txtHotPlace.Text
                    });
                    product.HotPlaceID = (int)newID;
                }
            }
            #endregion

            var pid = productDAL.Update(product);
            if (pid > 0)
            {
                fuPhoto.Save();
                WebUtility.ShowMsg(this, "提交成功！", Request.RawUrl);
                return;
            }
            else
            {
                WebUtility.ShowMsg("提交失败，请重试！");
                return;
            }
        }
    }
}
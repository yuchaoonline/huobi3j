using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Web.Class;

namespace ADeeWu.HuoBi3J.Web.Center
{
    public partial class AddProduct : PageBase
    {
        private const decimal benifit = 0.1m;

        public int UserID
        {
            get
            {
                UserSession session = UserSession.GetSession();
                if (session == null) return 0;
                return Utility.GetInt(session.UserID, 0);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (LoginUser == null)
                {
                    Response.Redirect("/Login.aspx?url=" + Request.RawUrl);
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                WebUtility.ShowMsg("商品名称不能为空！");
                return;
            }
            if (string.IsNullOrWhiteSpace(syncSelectorShopProductCategories.SelectedValue))
            {
                WebUtility.ShowMsg("请选择商品分类！");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtContent.Text))
            {
                WebUtility.ShowMsg("商品内容不能为空！");
                return;
            }
            if (this.filePicture.HasFile)
            {
                if (!this.filePicture.ValidFileExt())
                {
                    WebUtility.ShowMsg(this, "不允许上传非法文件,只允许文件类型:" + this.filePicture.AllowFileExt.Replace("|", ""));
                    return;
                }

                if (!this.filePicture.ValidFileSize())
                {
                    WebUtility.ShowMsg(this, "上传文件已超出大小:" + (int)(this.filePicture.AllowFileSize / 1024) + "KB,请将图片处理后再重新上传");
                    return;
                }
            }

            var product = new Model.Center_Products
            {
                CategoryID =Utility.GetLong( syncSelectorShopProductCategories.SelectedValue,-1),
                Name = txtProductName.Text,
                Content = txtContent.Text,
                CreateTime = DateTime.Now,
                Picture = filePicture.GetUploadedFilePath(),
            };

            if (new DAL.Center_Products().Add(product) > 0)
            {
                filePicture.Save();

                #region 兼职人员添加发放0.1元酬金
                var userDAL = new DAL.Users();
                var user = userDAL.GetEntity(LoginUser.UserID);
                user.Money += benifit;
                userDAL.Update(user);

                if (QualifiedAgentSession.IsQualifiedAgent)
                {
                    var dealDAL = new DAL.User_DealHistories();
                    var dealHistory = new Model.User_DealHistories
                    {
                        UserID = LoginUser.UserID,
                        CreateTime = DateTime.Now,
                        Notes = string.Format("添加商品：{0} 获得酬金{1}", product.Name, benifit),
                        InMoney = 0.1M,
                        OutMoney = 0,
                        Balance = user.Money,
                    };
                    dealDAL.Add(dealHistory);
                } 
                #endregion

                WebUtility.ShowMsg(this, "添加成功！", Request.RawUrl);
                return;
            }
            else
            {
                WebUtility.ShowMsg(this, "添加失败，请重试！");
            }
        }
    }
}
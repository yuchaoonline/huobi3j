using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.My.Corp.Shop
{
    public partial class Default : ADeeWu.HuoBi3J.Web.Class.PageBase_MyCorp
    {

        DAL.Shops dalShop = new ADeeWu.HuoBi3J.DAL.Shops();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                //this.fileLogo.UploadRoot = this.LoginUser.CorpUploadFilePath;

                Model.Shops ent = dalShop.GetEntity(new string[] { "CorpID" }, this.LoginUser.CorpID);
                if (this.LoginUser.IsShopSeller)
                {
                    this.ph01.Visible = true;
                    this.ph02.Visible = false;
                    if (ent != null)
                    {
                        this.txtShopName.Text = ent.Name;
                        this.txtContact.Text = WebUtility.ToTextAreaContent(ent.Contact);
                        this.txtAfterSaleService.Text = WebUtility.ToTextAreaContent(ent.AfterSaleService);
                        this.txtAgentShopAddress.Text = ent.AgentShopAddress;
                        //this.liteShopLogo.Text = ent.Logo;

                        //foreach (string s in ent.DeliveryTypeList.Split(','))
                        //{
                        //    if (s == "0")
                        //    {
                        //        this.chkDeilveryType01.Checked = true;
                        //    }
                        //    else if (s == "1")
                        //    {
                        //        this.chkDeilveryType02.Checked = true;
                        //    }
                        //    else if (s == "2")
                        //    {
                        //        this.chkDeilveryType03.Checked = true;
                        //    }
                        //    else if (s == "3")
                        //    {
                        //        this.chkDeilveryType04.Checked = true;
                        //    }
                        //}
                    }
                }
                else
                {
                    this.ph01.Visible = false;
                    this.ph02.Visible = true;
                    if (ent != null)
                    {
                        this.txtShopName_2.Text = ent.Name;
                        this.txtContact_2.Text = WebUtility.ToTextAreaContent(ent.Contact);
                        this.txtAfterSaleService_2.Text = WebUtility.ToTextAreaContent(ent.AfterSaleService);
                        this.txtAgentShopAddress_2.Text = ent.AgentShopAddress;
                        //this.liteShopLogo.Text = ent.Logo;

                        this.lblTips.Text = "您的商铺还没有正式开张，请耐心等候。修改资料需要重新审核！";

                        foreach (string s in ent.DeliveryTypeList.Split(','))
                        {
                            if (s == "0")
                            {
                                this.chkDeilveryType01_2.Checked = true;
                            }
                            else if (s == "1")
                            {
                                this.chkDeilveryType02_2.Checked = true;
                            }
                            else if (s == "2")
                            {
                                this.chkDeilveryType03_2.Checked = true;
                            }
                            else if (s == "3")
                            {
                                this.chkDeilveryType04_2.Checked = true;
                            }
                        }
                    }
                    else
                    {
                        
                        this.lblTips.Text = "您还没有申请开通营销商铺，请填写以下信息。开通商铺后立即可以发布您的商品。";
                        this.txtShopName_2.Text = this.LoginUser.CorpName;
                    }
                }
            }
        }

       

        //修改商铺信息
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.Shops ent = dalShop.GetEntity(new string[] { "CorpID" }, this.LoginUser.CorpID);
            if (ent != null)
            {
                //ent.Name = this.txtShopName.Text; 商铺名称不能修改
                ent.Contact = WebUtility.GetTextAreaContent(this.txtContact.Text);
                ent.AfterSaleService = WebUtility.GetTextAreaContent(this.txtAfterSaleService.Text);
                ent.AgentShopAddress = this.txtAgentShopAddress.Text;

                //if (this.fileLogo.HasFile)
                //{
                //    if (!this.fileLogo.ValidFileExt())
                //    {
                //        WebUtility.ShowMsg(this, "商铺Logo不允许上传非法文件,只允许文件类型:" + this.fileLogo.AllowFileExt.Replace("|", ""));
                //        return;
                //    }

                //    if (!this.fileLogo.ValidFileSize())
                //    {
                //        WebUtility.ShowMsg(this, "商铺Logo上传文件已超出大小:" + (int)(this.fileLogo.AllowFileSize / 1024) + "KB,请将图片处理后再重新上传");
                //        return;
                //    }
                //    ent.Logo = this.fileLogo.GetUploadedFilePath();
                //}

                //设置送货方式
                //CheckBox[] chkList = new CheckBox[]{
                //this.chkDeilveryType01,this.chkDeilveryType02,this.chkDeilveryType03,this.chkDeilveryType04
                //};

                //StringBuilder builder = new StringBuilder();
                //for (int i = 0; i < chkList.Length; i++)
                //{
                //    CheckBox chk = chkList[i];
                //    if (chk.Checked)
                //    {
                //        builder.AppendFormat(",{0}", i);
                //    }
                //}
                //ent.DeliveryTypeList = builder.Length > 0 ? builder.ToString().Substring(1) : "";

                if (dalShop.Update(ent) > 0)
                {
                    //if (this.fileLogo.HasFile)
                    //{
                    //    this.fileLogo.Save();
                    //}
                    WebUtility.ShowMsg(this, "操作成功！");
                    return;
                }
                else
                {
                    WebUtility.ShowMsg(this, "操作失败，请稍后再试！或与我们联系！");
                    return;
                }
            }
        }

        //申请商铺开通
        protected void btnSubmit_Click_2(object sender, EventArgs e)
        {
            Model.Shops ent = dalShop.GetEntity(new string[] { "CorpID" }, this.LoginUser.CorpID);
            bool isExisit = (ent != null);
            if (ent == null)
            {
                ent = new ADeeWu.HuoBi3J.Model.Shops();
                ent.CorpID = this.LoginUser.CorpID;
                ent.CorpUserID = this.LoginUser.CorpUserID;
                ent.CreateTime = DateTime.Now;
                ent.CheckState = 0;
            }

            ent.Name = this.txtShopName_2.Text;
            ent.Contact = WebUtility.GetTextAreaContent(this.txtContact_2.Text);
            ent.AfterSaleService = WebUtility.GetTextAreaContent(this.txtAfterSaleService_2.Text);
            ent.AgentShopAddress = this.txtAgentShopAddress_2.Text;
            ent.CheckState = 0;

            //通过审核后才可以上传Logo
            //if (this.fileLogo.HasFile)
            //{
            //    if (!this.fileLogo.ValidFileExt())
            //    {
            //        WebUtility.ShowMsg(this, "商铺Logo不允许上传非法文件,只允许文件类型:" + this.fileLogo.AllowFileExt.Replace("|", ""));
            //        return;
            //    }

            //    if (!this.fileLogo.ValidFileSize())
            //    {
            //        WebUtility.ShowMsg(this, "商铺Logo上传文件已超出大小:" + this.fileLogo.AllowFileSize + "Bytes,请将图片处理后再重新上传");
            //        return;
            //    }
            //    ent.Logo = this.fileLogo.GetUploadedFilePath();
            //}

            //设置送货方式
            CheckBox[] chkList = new CheckBox[]{
                this.chkDeilveryType01_2,this.chkDeilveryType02_2,this.chkDeilveryType03_2,this.chkDeilveryType04_2
            };

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < chkList.Length; i++)
            {
                CheckBox chk = chkList[i];
                if (chk.Checked)
                {
                    builder.AppendFormat(",{0}", i);
                }
            }
            ent.DeliveryTypeList = builder.Length > 0 ? builder.ToString().Substring(1) : "";

            if (isExisit)
            {
                if (dalShop.Update(ent) > 0)
                {
                    WebUtility.ShowMsg(this, "操作成功，我们将尽快为您处理！");
                    return;
                }
                else
                {
                    WebUtility.ShowMsg(this, "操作失败，请稍后再试！或与我们联系！");
                    return;
                }
            }
            else
            {
                if (dalShop.Add(ent) > 0)
                {
                    WebUtility.ShowMsg(this, "操作成功，我们将尽快为您处理！");
                    return;
                }
                else
                {
                    WebUtility.ShowMsg(this, "操作失败，请稍后再试！或与我们联系！");
                    return;
                }
            }
            
            
        }
        
    }
}

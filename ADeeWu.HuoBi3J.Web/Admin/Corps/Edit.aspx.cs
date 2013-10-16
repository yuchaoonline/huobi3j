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
using System.Collections.Generic;
using System.Text;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.Admin.Corps
{
    public partial class Edit : PageBase
    {


        public override string PageID
        {
            get
            {
                return "002002";
            }
        }

        ADeeWu.HuoBi3J.DAL.Corporations dalCorp = new ADeeWu.HuoBi3J.DAL.Corporations();
        ADeeWu.HuoBi3J.DAL.Provinces dalProvince = new ADeeWu.HuoBi3J.DAL.Provinces();
        ADeeWu.HuoBi3J.DAL.Citys dalCity = new ADeeWu.HuoBi3J.DAL.Citys();
        ADeeWu.HuoBi3J.DAL.Areas dalArea = new ADeeWu.HuoBi3J.DAL.Areas();
        ADeeWu.HuoBi3J.DAL.Callings dalCallings = new ADeeWu.HuoBi3J.DAL.Callings();
        ADeeWu.HuoBi3J.DAL.Admin_Users dalAdminUser = new ADeeWu.HuoBi3J.DAL.Admin_Users();

        protected long corpID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            corpID = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id",0);
            if (corpID == 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "错误参数传递", "list.aspx");
                return;
            }

            if (!IsPostBack)
            {


                ADeeWu.HuoBi3J.Model.Corporations corp = dalCorp.GetEntity(corpID);
                this.txtName.Text = corp.CorpName;
                this.txtLinkMan.Text = corp.LinkMan;
                this.txtTel.Text = corp.Tel;
                this.txtIntro.Text = WebUtility.ToTextAreaContent(corp.Intro);
                this.txtAddress.Text = corp.Address;

                this.ddlCheckState.SelectedValue = corp.CheckState.ToString();
                this.syncSelectorCalling.SelectedValue = corp.CallingID.ToString();
                this.syncSelectorLocation.Values = new string[]{ corp.ProvinceID.ToString(), corp.CityID.ToString(), corp.AreaID.ToString() };
               
                this.litCrateTime.Text = corp.CreateTime.ToString();
                this.litModifyTime.Text = corp.ModifyTime.ToString();

                Model.Admin_Users adminUser = dalAdminUser.GetEntity(corp.AdminUserID);
                if (adminUser != null)
                {
                    txtAdminUsers.Text = adminUser.LoginName;
                }

                Model.CA_QualifiedAgentBusiness qualifiedAgentBusiness = new DAL.CA_QualifiedAgentBusiness().GetEntity("CustomerUserID = " + corp.UserID);
                if (qualifiedAgentBusiness != null)
                {
                    Model.Users user = new DAL.Users().GetEntity("ID = " + qualifiedAgentBusiness.AgentUserID);
                    if (user != null)
                    {
                        LitUpUIN.Text = user.UIN;
                    }
                }
            }
            
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            ADeeWu.HuoBi3J.Model.Corporations entCorp = dalCorp.GetEntity(corpID);

            string intro = WebUtility.GetTextAreaContent(this.txtIntro.Text);
            string address = this.txtAddress.Text.Trim();
            string name = this.txtName.Text.Trim();
            string linkMan = this.txtLinkMan.Text.Trim();
            string tel = this.txtTel.Text.Trim();


            if (name.Length == 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写商家名称!");
                return;
            }

            if (linkMan.Length == 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写联系人!");
                return;
            }

            if (tel.Length == 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写联系电话!");
                return;
            }

            if (string.Compare(name, entCorp.CorpName, true) != 0 && dalCorp.Exist("CorpName", name))
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(string.Format("商家:'{0}'已存在!", name));
                return;
            }

            if (address.Length == 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写商家地址!");
                return;
            }

            if (!string.IsNullOrEmpty(txtAdminUsers.Text))
            {
                Model.Admin_Users adminUser = dalAdminUser.GetEntity("LoginName = '" + txtAdminUsers.Text + "'");
                if (adminUser == null)
                {
                    WebUtility.ShowMsg("业务员名称错误！");
                    return;
                }
                else
                {
                    entCorp.AdminUserID = adminUser.ID;
                }
            }

            //if (offerPercent < 0 || offerPercent > 100)
            //{
            //    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写正确商家所提供的提成百分比!");
            //    return;
            //}

            long callingID = ADeeWu.HuoBi3J.Libary.Utility.GetLong(this.syncSelectorCalling.SelectedValue, -1);
            string[] locationValues = this.syncSelectorLocation.Values;

            long provinceID = ADeeWu.HuoBi3J.Libary.Utility.GetLong(locationValues[0], -1);
            long cityID = ADeeWu.HuoBi3J.Libary.Utility.GetLong(locationValues[1], -1);
            long areaID = ADeeWu.HuoBi3J.Libary.Utility.GetLong(locationValues[2], -1);

            
            string province = string.Empty;
            if(provinceID>0){
                ADeeWu.HuoBi3J.Model.Provinces entProvince =  dalProvince.GetEntity(provinceID);
                if(entProvince!=null){
                    province = entProvince.Name;
                }
            }
            string city = string.Empty;
            if (cityID > 0)
            {
                ADeeWu.HuoBi3J.Model.Citys entCity = dalCity.GetEntity(cityID);
                if (entCity != null)
                {
                    city = entCity.Name;
                }
            }
            string area = string.Empty;
            if (areaID > 0)
            {
                ADeeWu.HuoBi3J.Model.Areas entArea = dalArea.GetEntity(areaID);
                if (entArea != null)
                {
                    area = entArea.Name;
                }
            }

            string calling = string.Empty;
            if (callingID > 0)
            {
                ADeeWu.HuoBi3J.Model.Callings entCalling = dalCallings.GetEntity(callingID);
                if (entCalling != null)
                {
                    if (entCalling.ParentID > 0)
                    {
                        ADeeWu.HuoBi3J.Model.Callings entParentCalling = dalCallings.GetEntity(entCalling.ParentID);
                        if (entParentCalling != null)
                        {
                            calling = entParentCalling.Name;
                        }
                    }
                    calling +=" " +entCalling.Name;
                    calling = calling.Trim();
                }
            }

            entCorp.CallingID = callingID;
            entCorp.Calling = calling;


            entCorp.ProvinceID = provinceID;
            entCorp.Province = province;
            entCorp.City = city;
            entCorp.CityID = cityID;
            entCorp.Area = area;
            entCorp.AreaID = areaID;

            entCorp.LinkMan = linkMan;
            entCorp.Tel = tel;
 
            entCorp.Intro = intro;
            entCorp.CorpName = name;
            entCorp.Address = address;
            entCorp.CheckState = ADeeWu.HuoBi3J.Libary.Utility.GetInt(this.ddlCheckState.SelectedValue, 0);
            entCorp.ModifyTime = DateTime.Now;

            if (dalCorp.Update(entCorp) > 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowPageSelector(this, "修改成功!继续修改请选择\"是\"", "#", "List.aspx");
            }
        }

    }
}

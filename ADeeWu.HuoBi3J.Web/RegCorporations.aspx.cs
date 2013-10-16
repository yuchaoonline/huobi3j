using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ADeeWu.HuoBi3J.SQL.ParameterCollection;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Libary;


namespace ADeeWu.HuoBi3J.Web
{
    public partial class RegCorporations : ADeeWu.HuoBi3J.Web.Class.PageBase
    {
        DAL.Corporations dalCorp = new ADeeWu.HuoBi3J.DAL.Corporations();
        DAL.Provinces dalProvince = new ADeeWu.HuoBi3J.DAL.Provinces();
        DAL.Citys dalCity = new ADeeWu.HuoBi3J.DAL.Citys();
        DAL.Areas dalArea = new ADeeWu.HuoBi3J.DAL.Areas();
        DAL.Callings dalCallings = new ADeeWu.HuoBi3J.DAL.Callings();
        DAL.Users dalUser = new ADeeWu.HuoBi3J.DAL.Users();
        DAL.CA_QualifiedAgentBusiness dalQualifiedAgentBus = new ADeeWu.HuoBi3J.DAL.CA_QualifiedAgentBusiness();
        DataBase db = DataBase.Create();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.LoginUser == null)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "请先登陆个人用户帐号后在注册商家帐号(开通商家服务功能)","/login.aspx");
                return;
            }
            else
            {
                if (dalCorp.Exist("UserID", this.LoginUser.UserID))
                {
                    Class.Tips.SetTips("您已提交商家注册信息", "如果您的申请还没有通过审核,请耐心等候或直接与我们联系!", "/My/User/","点击返回用户中心");
                    Class.Tips.Show();
                }
            }
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {

            string validateCode = Session["CheckCode"] as string;
            if (validateCode == null)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("验证码丢失,请重新点击验证码图片!");
                return;
            }


            if (txtValidCode.Text.Trim().ToLower() != Session["CheckCode"].ToString().ToLower())
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("验证码错误!");
                return;
            }

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
            if (dalCorp.Exist("CorpName", name))
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(string.Format("商家:'{0}'已被注册!", name));
                return;
            }
            if (linkMan.Length == 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写联系人!");
                return;
            }

            if (tel.Length == 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写公司联系电话!");
                return;
            }

            long callingID = ADeeWu.HuoBi3J.Libary.Utility.GetLong(this.syncSelectorCalling.SelectedValue, -1);
            
            string[] locationValues = this.syncSelectorLocation.Values;

            long provinceID = ADeeWu.HuoBi3J.Libary.Utility.GetLong(locationValues[0], -1);
            long cityID = ADeeWu.HuoBi3J.Libary.Utility.GetLong(locationValues[1], -1);
            long areaID = ADeeWu.HuoBi3J.Libary.Utility.GetLong(locationValues[2], -1);

            //if (provinceID == -1)
            //{
            //    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请选择行业!");
            //    return;
            //}
            //if (callingID == -1)
            //{
            //    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请选择省份!");
            //    return;
            //}
            //if (cityID == -1)
            //{
            //    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请选择城市!");
            //    return;
            //}
            //if (areaID == -1)
            //{
            //    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请选择地区!");
            //    return;
            //}
            if (address.Length == 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写商家地址!");
                return;
            }
        
            if (intro.Length==0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写公司简介!");
                return;
            }
          
            string province = string.Empty;
            if (provinceID > 0)
            {
                ADeeWu.HuoBi3J.Model.Provinces entProvince = dalProvince.GetEntity(provinceID);
                if (entProvince != null)
                {
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
                    calling += " " + entCalling.Name;
                    calling = calling.Trim();
                }
            }


            ADeeWu.HuoBi3J.Model.Corporations entCorp = new ADeeWu.HuoBi3J.Model.Corporations();
            entCorp.UserID = base.LoginUser.UserID;
            entCorp.CallingID = callingID;
            entCorp.Calling = calling;

            entCorp.ProvinceID = provinceID;
            entCorp.Province = province;
            entCorp.City = city;
            entCorp.CityID = cityID;
            entCorp.Area = area;
            entCorp.AreaID = areaID;
            entCorp.Address = address;

            entCorp.CorpName = name;
            entCorp.Intro = intro;
            entCorp.LinkMan = linkMan;
            entCorp.Tel = tel;
            entCorp.Property = this.ddlProperty.SelectedValue;
            entCorp.Employee = this.ddlEmployees.SelectedValue;
            
            
            entCorp.AdminUserID =0;//todo:update
            entCorp.CheckState = 0;//todo:update
            entCorp.CreateTime = DateTime.Now;
            entCorp.ModifyTime = DateTime.Now;

            if (dalCorp.Add(entCorp) > 0)
            {
                //关联营销代理商
                string agentUIN = WebUtility.GetRequestStr("agent", "");
                if (agentUIN.Length > 0)
                {
                   
                    //判断用户是否存在
                    Model.Users entAgent = dalUser.GetEntity(new string[] { "UIN" }, agentUIN);
                    if (entAgent != null)
                    {
                        //判断是否存在该代理商，或该代理是否已通过审核
                        if (db.Exist("select ID from CA_QualifiedAgents where UserID={0} and CheckState=1",entAgent.ID))
                        {
                            //关联代理商与商家的关系
                            //判断是否已存在 "个人用户"　关联记录

                            Model.CA_QualifiedAgentBusiness entBus = dalQualifiedAgentBus.GetEntity(new string[] { "AgentUserID", "CustomerUserID" }, entAgent.ID, entCorp.UserID);
                            if (entBus == null)
                            {
                                entBus = new ADeeWu.HuoBi3J.Model.CA_QualifiedAgentBusiness();
                                entBus.CustomerCorpID = entCorp.ID;
                                entBus.CustomerUserID = entCorp.UserID;
                                entBus.CreateTime = DateTime.Now;
                                entBus.AgentUserID = entAgent.ID;
                                dalQualifiedAgentBus.Add(entBus);
                            }
                            else
                            {
                                entBus.CustomerCorpID = entCorp.ID;
                                entBus.CustomerUserID = entCorp.UserID;
                                //entBus.CreateTime = DateTime.Now;
                                entBus.ModifyTime = DateTime.Now;
                                entBus.AgentUserID = entAgent.ID;
                                dalQualifiedAgentBus.Update(entBus);
                            }
                                
                               
                        
                        }
                    }
                   
                   
                    
                }

                //设置用户类型
                db.Parameters.Clear();
                db.Parameters.Append("@UserID", base.LoginUser.UserID);
                db.ExecuteSql("update Users set userType=1 where ID = @UserID");
                
                
                //更新当前会话为商家用户登陆
                Model.Users newUser = dalUser.GetEntity(this.LoginUser.UserID);
                Class.UserSession.SaveSession(Class.UserSession.BuildSession(newUser));

                Class.Tips tips = new ADeeWu.HuoBi3J.Web.Class.Tips("恭喜您已注册商家帐号!", "请耐心等待审核,通过审核后立即可以使用商家功能.详情请与我们联系!", "/My/User/", "进入我的个人管理中心!");
                Class.Tips.SetTips(tips);
                Class.Tips.Show();

                
            }
        }
    }
}

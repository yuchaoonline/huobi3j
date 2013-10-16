using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.My.Corp
{
    public partial class Default : Class.PageBase_MyCorp
    {

        public override string FunctionCode
        {
            get
            {
                return "Corp-Default";
            }
        }

        protected Model.Corporations entCorp = null;
        DAL.Corporations dalCorp = new ADeeWu.HuoBi3J.DAL.Corporations();
        DataBase db = DataBase.Create();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.entCorp = dalCorp.GetEntity(this.LoginUser.CorpID);
                if (this.entCorp != null)
                {
                    //动态信息
                    this.liteNumOfCashTickets.Text = Utility.GetInt(db.ExecuteScalar("select count(id) from CT_CashTickets where CorpID={0}", this.LoginUser.CorpID), 0).ToString();
                    this.liteNumOfPromotionKeys.Text = Utility.GetInt(db.ExecuteScalar("select count(id) from CP_Keywords where PromotionID={0}", this.LoginUser.PromotionID), 0).ToString();
                   
                    this.liteNumOfJobs.Text = Utility.GetInt(db.ExecuteScalar("select count(id) from Jobs where CorpID={0}", this.LoginUser.CorpID), 0).ToString();
                    this.liteNumOfProducts.Text =  Utility.GetInt(db.ExecuteScalar("select count(id) from Shop_Products where CorpID={0}", this.LoginUser.CorpID), 0).ToString();
                    this.liteOrders.Text = Utility.GetInt(db.ExecuteScalar("select count(id) from Shop_Orders where SellerCorpID={0}", this.LoginUser.CorpID), 0).ToString();
                    


                    //公司信息
                    this.txtAddress.Text = entCorp.Address;
                    this.txtCorpName.Text = entCorp.CorpName;
                    this.txtIntro.Text = WebUtility.ToTextAreaContent(entCorp.Intro);
                    this.txtLinkMan.Text = entCorp.LinkMan;
                    this.txtTel.Text = entCorp.Tel;

                    this.txtLat.Text = entCorp.Lat.ToString();
                    this.txtLng.Text = entCorp.Lng.ToString();
                    
                    this.syncSelectorLocation.Values = new string[]{
                        entCorp.ProvinceID.ToString(),entCorp.CityID.ToString(),entCorp.AreaID.ToString()
                    };
                    this.syncSelectorCalling.SelectedValue = entCorp.CallingID.ToString();
                    this.ddlEmployees.SelectedValue = entCorp.Employee;
                    this.ddlProperty.SelectedValue = entCorp.Property;
                }
            }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            this.entCorp = dalCorp.GetEntity(this.LoginUser.CorpID);
            if (this.entCorp != null)
            {
                this.entCorp.Address = this.txtAddress.Text.Trim();
                //this.entCorp.CorpName = this.txtCorpName.Text.Trim();
                this.entCorp.Intro = WebUtility.GetTextAreaContent(this.txtIntro.Text);
                this.entCorp.LinkMan = this.txtLinkMan.Text.Trim();
                this.entCorp.Tel = this.txtTel.Text.Trim();

                this.entCorp.Lat = Utility.GetDecimal(this.txtLat.Text, 9999);
                this.entCorp.Lng = Utility.GetDecimal(this.txtLng.Text, 9999);

                string[] location = this.syncSelectorLocation.Values;
                long provinceId = Utility.GetLong(location[0], 0);
                long cityId = Utility.GetLong(location[1], 0);
                long areaId = Utility.GetLong(location[2], 0);
                string province = Utility.GetStr(db.ExecuteScalar("select name from Provinces where ID={0}", provinceId));
                string city = Utility.GetStr(db.ExecuteScalar("select name from Citys where ID={0}", cityId));
                string area = Utility.GetStr(db.ExecuteScalar("select name from Areas where ID={0}", areaId));

                this.entCorp.Province = province;
                this.entCorp.City = city;
                this.entCorp.Area = area;
                this.entCorp.ProvinceID = provinceId;
                this.entCorp.CityID = cityId;
                this.entCorp.AreaID = areaId;

                long callingId = Utility.GetLong(this.syncSelectorCalling.SelectedValue,0);
                this.entCorp.CallingID = callingId;
                this.entCorp.Calling = Utility.GetStr(db.ExecuteScalar("select name from Callings where ID={0}", callingId));

                this.entCorp.Employee = this.ddlEmployees.SelectedValue;
                this.entCorp.Property = this.ddlProperty.SelectedValue;
                this.entCorp.ModifyTime = DateTime.Now;

                if (dalCorp.Update(entCorp) > 0)
                {
                    WebUtility.ShowMsg(this, "操作成功!");
                }
            }
        }
    }
}

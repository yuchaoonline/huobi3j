using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.My.User
{
    public partial class Default : Class.PageBase_MyUser
    {

        public override string FunctionCode
        {
            get
            {
                return "My-User-Default";
            }
        }

        protected Model.Users entUser = null;
        DAL.Users dalUser = new ADeeWu.HuoBi3J.DAL.Users();
        DataBase db = DataBase.Create();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.entUser = dalUser.GetEntity(this.LoginUser.UserID);
                if (this.entUser != null)
                {
                    this.txtName.Text = entUser.LoginName;
                    this.txtTel.Text = entUser.Tel;
                    this.txtEmail.Text = entUser.Email;

                    this.syncSelectorLocation.Values = new string[]{
                        entUser.ProvinceID.ToString(),entUser.CityID.ToString(),entUser.AreaID.ToString()
                    };

                    this.txtAlipayAccount.Text = entUser.AlipayAccount;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            this.entUser = dalUser.GetEntity(this.LoginUser.UserID);
            if (entUser != null)
            {
                this.entUser.Name = this.txtName.Text.Trim();
                this.entUser.Tel = this.txtTel.Text.Trim();
                this.entUser.Email = this.txtEmail.Text.Trim();
                this.entUser.AlipayAccount = this.txtAlipayAccount.Text.Trim();

                string[] location = this.syncSelectorLocation.Values;
                long provinceId = Utility.GetLong(location[0], 0);
                long cityId = Utility.GetLong(location[1], 0);
                long areaId = Utility.GetLong(location[2], 0);
                string province = Utility.GetStr(db.ExecuteScalar("select name from Provinces where ID={0}", provinceId));
                string city = Utility.GetStr(db.ExecuteScalar("select name from Citys where ID={0}", cityId));
                string area = Utility.GetStr(db.ExecuteScalar("select name from Areas where ID={0}", areaId));

                this.entUser.ProvinceID = provinceId;
                this.entUser.CityID = cityId;
                this.entUser.AreaID = areaId;
                this.entUser.Province = province;
                this.entUser.City = city;
                this.entUser.Area = area;

                if (this.dalUser.Update(entUser) > 0)
                {
                    WebUtility.ShowMsg(this, "操作成功!");
                }
            }
        }
    }
}

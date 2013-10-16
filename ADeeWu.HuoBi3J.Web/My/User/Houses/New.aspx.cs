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
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.My.User.Houses
{
    public partial class New : Class.PageBase_MyUser
    {

        public override string FunctionCode
        {
            get
            {
                return "My-User-Houses-New";
            }
        }

        ADeeWu.HuoBi3J.DAL.HouseInfos dalhouse = new ADeeWu.HuoBi3J.DAL.HouseInfos();
        protected void Page_Load(object sender, EventArgs e)
        {
             
        }
      
       
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string title = this.txtTitle.Value.Trim();
            int property = 0;
            if (radProperity01.Checked)
            {
                property = 0;
            }
            else if (radProperity02.Checked)
            {
                property = 1;
            }
            else if (radProperity03.Checked)
            {
                property = 2;
            }

            string[] locationIDs = this.syncSelectorLocation.Values;
            long provinceID = Utility.GetLong(locationIDs[0], 0);
            long cityID = Utility.GetLong(locationIDs[1], 0);
            long areaID = Utility.GetLong(locationIDs[2], 0);

            string[] locationTexts = this.syncSelectorLocation.Texts;
            string province = Utility.GetStr(locationTexts[0], "");
            string city = Utility.GetStr(locationTexts[1], "");
            string area = Utility.GetStr(locationTexts[2], "");


            string addree = this.txtAddress.Value.Trim();
            string busline = this.txtBusline.Value.Trim();
            string housetype = this.ddlHouseType.SelectedValue;
            string housestruts = this.ddlHousestrcts.SelectedValue;
            string map = this.txtMap.Value.Trim();
            string price = this.txtPrice.Value.Trim();
            DateTime? expire = Utility.GetDateTime(this.txtExpire.Text, null);

            string content = WebUtility.GetTextAreaContent(this.txtContent.Text);

            double housemap = 0;
            decimal houseprice = 0;

            
            if (title == "")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写房源信息标题!");
                return;
            }
            else if (title.Length > 30)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("标题不能超过30个字!");
                return;
            }
            if (provinceID == -1)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请选择房屋所在省份!");
                return;
            }
            if (cityID == -1)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请选择房屋所在城市!");
                return;
            }
            if (areaID == -1)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请选择房屋所在区域!");
                return;
            }
            if (addree.Length == 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写房屋地址!");
                return;
            }

            //if (busline.Length == 0)
            //{
            //    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写房屋附近公交路线或地铁路写，如果没有请填写：无！");
            //    return;
            //}
            if (map.Length == 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写房屋面积！");
                return;
            }
            else
            {
                if (!double.TryParse(map, out housemap))
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写正确的房屋面积，如：120");
                    return;
                }
            }

            if (!decimal.TryParse(price, out houseprice))
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写正确的房屋租金，如：120");
                return;
            }
            double x = 0, y = 0;
            string strx = this.txtLat.Value.Trim();
            string stry = this.txtLng.Value.Trim();
            if (strx != "" && stry != "")
            {
                if (!double.TryParse(strx, out x))
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写正确的经度！");
                    return;
                }
                if (!double.TryParse(stry, out y))
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写正确的纬度！");
                    return;
                }
            }
            else
            { 
               if((stry == "" && strx != "") || (stry != "" && strx == ""))
               {

                   ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请正确填写经度纬度信息！");
                   return;
               }
            }
            if (!expire.HasValue)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请选择正确的房源信息过期时间，比如：2010/3/3");
                return;
            }
            if (content.Length == 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写详细的房屋描述，如房屋已使用年限。");
                return;
            }


            long realBusinessUserID = this.GetRealBusinessUserID();

            ADeeWu.HuoBi3J.Model.HouseInfos houseInfo = new ADeeWu.HuoBi3J.Model.HouseInfos();
           
            houseInfo.ProvinceID = provinceID;
            houseInfo.CityID = cityID;
            houseInfo.AreaID = areaID;
            houseInfo.Province = province;
            houseInfo.City = city;
            houseInfo.Area = area;
            houseInfo.Address = addree;

            houseInfo.AreaSize = housemap;
            houseInfo.BusLine = busline;
            houseInfo.CheckState =1;

            houseInfo.Content = content;
            houseInfo.CreateTime = DateTime.Now;
            houseInfo.EndTime = expire.Value;
            string type = "";
            if (radProperity01.Checked)
            {
                type = "C";
            }
            else if (radProperity02.Checked)
            {
                type = "Q";
            }
            else if (radProperity03.Checked)
            {
                type = "H";
            }

            do
            {
                                          
                houseInfo.HomeCode = type + realBusinessUserID + DateTime.Now.ToString("yyyyMMddHHmmss");
            } while (dalhouse.Exist("HomeCode", houseInfo.HomeCode));
            houseInfo.HouseStructText = this.ddlHousestrcts.SelectedItem.Text;
            houseInfo.HouseStructValue = int.Parse(this.ddlHousestrcts.SelectedValue);
            houseInfo.HouseType = int.Parse(this.ddlHouseType.SelectedValue);
            houseInfo.Price = houseprice;
            houseInfo.Properity = property;
            houseInfo.Title = title;
            houseInfo.UpdateTime = DateTime.Now;
            houseInfo.UserID = realBusinessUserID;
            houseInfo.LinkEmail = LinkEmail.Value.Trim();
            houseInfo.LinkName = LinkName.Value;
            houseInfo.LinkPhone = LinkPhone.Value;
            long id = dalhouse.Add(houseInfo);
            if (id > 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this,"发布成功，房源编号为：" + houseInfo.HomeCode,"Default.aspx");
                return;
            }
        }

    }
}


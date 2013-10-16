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
    public partial class Edit : Class.PageBase_MyUser
    {

        public override string FunctionCode
        {
            get
            {
                return "My-User-Houses-Edit";
            }
        }

        
        ADeeWu.HuoBi3J.DAL.HouseInfos dal = new ADeeWu.HuoBi3J.DAL.HouseInfos();
        long id = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ADeeWu.HuoBi3J.Model.HouseInfos entity = dal.GetEntity(new string[] { "ID", "UserID" }, id, this.GetRealBusinessUserID());

                if (entity != null)
                {
                    this.txtAddrees.Value = entity.Address;
                    this.txtBusline.Value = entity.BusLine;
                    this.txtContent.Text = WebUtility.ToTextAreaContent(entity.Content);
                    this.txtMap.Value = entity.AreaSize.ToString();
                    this.txtExpire.Text = entity.EndTime.ToString("yyyy/MM/dd");
                    this.txtPrice.Value = string.Format("{0:0.00}", entity.Price);
                    this.txtTitle.Value = entity.Title;
                    switch (entity.Properity)
                    {
                        case 0:
                            radProperity01.Checked = true;
                            break;
                        case 1:
                            radProperity02.Checked = true;
                            break;
                        default:
                            radProperity03.Checked = true;
                            break;

                    }
                    this.ddlHousestrcts.SelectedValue = entity.HouseStructValue.ToString();
                    this.ddlHouseType.SelectedValue = entity.HouseType.ToString();

                    this.syncSelectorLocation.Values = new string[]{
                        entity.ProvinceID.ToString(),
                        entity.CityID.ToString(),
                        entity.AreaID.ToString()
                    };

                    this.lblVisitCount.Text = entity.VisitCount + "次";
                    this.txtLinkEmail.Value = entity.LinkEmail;
                    this.txtLinkName.Value = entity.LinkName;
                    this.txtLinkPhone.Value = entity.LinkPhone;
                    this.txtLat.Value = entity.Lat.ToString();
                    this.txtLng.Value = entity.Lng.ToString();
                }
                
                 
            }
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

            string addree = this.txtAddrees.Value.Trim();
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
                if ((stry == "" && strx != "") || (stry != "" && strx == ""))
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
            ADeeWu.HuoBi3J.Model.HouseInfos houseInfo = dal.GetEntity(ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0));
            houseInfo.ProvinceID = provinceID;
            houseInfo.CityID = cityID;
            houseInfo.AreaID = areaID;
            houseInfo.Address = addree;
          
            houseInfo.AreaSize = housemap;
            houseInfo.BusLine = busline;
            //houseInfo.CheckState = 0;

            houseInfo.Content = content;
            houseInfo.EndTime = expire.Value;

            houseInfo.HouseStructText = this.ddlHousestrcts.SelectedItem.Text;
            houseInfo.HouseStructValue = int.Parse(this.ddlHousestrcts.SelectedValue);

            houseInfo.HouseType = int.Parse(this.ddlHouseType.SelectedValue);
            houseInfo.Price = houseprice;
            houseInfo.Properity = property;
            
            houseInfo.Title = title;
            houseInfo.UpdateTime = DateTime.Now;

            houseInfo.LinkEmail = this.txtLinkEmail.Value.Trim();
            houseInfo.LinkName = this.txtLinkName.Value;
            houseInfo.LinkPhone = this.txtLinkPhone.Value;
            
            int count = dal.Update(houseInfo);

            if (count > 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowAndTopRedirect(this, "信息修改成功！", "Default.aspx");
                return;
            }
        }

        protected void btnEnd_Click(object sender, EventArgs e)
        {
            int count = dal.Update("CheckState", "4", " ID=" + Request.QueryString["id"]);
            if (count > 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "该房源信息已经标记为失效", "Default.aspx");
                return;
            }

        }

        
        protected void btnDel_Click(object sender, EventArgs e)
        {
             int count=dal.Delete(long.Parse(Request.QueryString["id"]));
             if (count > 0)
             {
                 ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "该房源信息已经删除！", "Default.aspx");
                 return;
             }
             else
             {
                 ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "删除失败！", "Default.aspx");
                 return;
             }
        }

        

    }
}

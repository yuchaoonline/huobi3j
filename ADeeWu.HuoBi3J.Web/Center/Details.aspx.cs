using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Web.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.Center
{
    public partial class Details : System.Web.UI.Page
    {
        DataBase db = DataBase.Create();
        DAL.Corporations corDAL = new DAL.Corporations();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BandData();
                AddClickCount();
            }
        }

        private void BandData()
        {
            var id = WebUtility.GetRequestInt("id",0);
            if(id==0)return;

            var product = db.Select("vw_key_product", "id = " + id, "price asc");
             rpResult.DataSource = product;
             rpResult.DataBind();
        }

        private void AddClickCount()
        {
            try
            {
                var id = WebUtility.GetRequestInt("id", 0);
                if (id == 0) return;

                new DAL.Common_Count_Click().Add(new Model.Common_Count_Click
                {
                    CreateDate = DateTime.Now,
                    DataID = id,
                    DataType = "center_product",
                    IP = Request.UserHostAddress,
                });
            }
            catch
            {

            }
        }

        public string GetDecimal(object obj, int length)
        {
            return decimal.Round(Utility.GetDecimal(obj, 0), length).ToString();
        }

        protected void rpResult_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var rpOtherPrice = (Repeater)e.Item.FindControl("rpOtherPrice");
            var datarowview = (DataRowView)e.Item.DataItem;
            var userid = Utility.GetInt(datarowview["createuserid"], 0);

            rpOtherPrice.DataSource = db.Select(string.Format("select top 10 * from vw_key_product where createuserid = {0} and pname='{1}' and cname='{2}' order by price asc", userid, AccountHelper.Province, AccountHelper.City));
            rpOtherPrice.DataBind();
        }
    }
}
using ADee.Project.LBS.BLL;
using ADee.Project.LBS.Entity;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Web.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web
{
    public partial class lbs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var method = Request["method"];

                Response.Write("Start!" + DateTime.Now.ToString());

                if (method == "upload")
                {
                    Upload();
                }
                if (method == "delete")
                {
                    Delete();
                }
                if (method == "combine")
                {
                    Combine();
                }
                if (method == "attr")
                {
                    ConvertData();
                }

                Response.Write("\r\nOK!" + DateTime.Now.ToString());
            }
        }

        private void Delete()
        {
            var poibll = new PoiBLL();
            while (true)
            {
                var lists = poibll.List<ADeeWu.HuoBi3J.Libary.LBSHelper.ProductPoi>("49566", new Dictionary<string, string>());
                if (lists != null && lists.pois != null && lists.pois.Count > 0)
                    foreach (var poi in lists.pois)
                    {
                        poibll.Delete(new List<string> { poi.id }, "49566");
                    }
                else break;
            }
            Response.Write("OK");
        }

        private void Upload()
        {
            var db = DataBase.Create();
            var poiBLL = new PoiBLL();
            litText.Text = DateTime.Now.ToString();
            var sql = @"
               SELECT p.ID,
                            p.Price ,
                            p.SimpleDesc ,
                            p.Description ,
                            p.CreateUserID ,
                            p.SelectType ,
		                    p.SelectPrice ,
                            p.SelectSize ,
		                    (SELECT ID FROM dbo.Key_Attribute WHERE KID = p.KID AND DataType='SelectType' AND DataValue=p.SelectType) AS SelectTypeID,
		                    (SELECT ID FROM dbo.Key_Attribute WHERE KID = p.KID AND DataType='SelectPrice' AND DataValue=p.SelectPrice) AS SelectPriceID,
		                    (SELECT ID FROM dbo.Key_Attribute WHERE KID = p.KID AND DataType='SelectSize' AND DataValue=p.SelectSize) AS SelectSizeID,
                            k.Name ,
                            k.KID ,
                            c.CompanyName ,
                            c.CompanyAddress ,
                            c.PositionX ,
                            c.PositionY ,
                            c.Phone ,
                            c.Memo ,
                            c.QQ
                    FROM    dbo.Key_Product p
                            LEFT JOIN dbo.[Key] k ON p.KID = k.KID
                            LEFT JOIN dbo.CA_CircleSaleMan c ON c.UserID = p.CreateUserID
            ";
            var rows = db.Select(sql);
            if (rows == null || rows.Rows.Count <= 0) return;

            foreach (DataRow item in rows.Rows)
            {
                var id = Utility.GetInt(item["id"], 0);
                try
                {
                    var dic = new Dictionary<string, string>();
                    dic.Add("Price", item["Price"].ToString());
                    dic.Add("Description", item["Description"].ToString());
                    //dic.Add("BName", item["BName"].ToString());
                    dic.Add("CompanyName", item["CompanyName"].ToString());
                    dic.Add("Phone", item["Phone"].ToString());
                    dic.Add("SalemanMemo", item["Memo"].ToString());
                    dic.Add("QQ", item["QQ"].ToString());
                    dic.Add("KName", item["Name"].ToString());
                    dic.Add("KID", item["KID"].ToString());
                    dic.Add("CreateUserID", item["CreateUserID"].ToString());
                    dic.Add("SelectTypeID", item["SelectTypeID"].ToString());
                    dic.Add("SelectPriceID", item["SelectPriceID"].ToString());
                    dic.Add("SelectSizeID", item["SelectSizeID"].ToString());
                    dic.Add("SelectType", item["SelectType"].ToString());
                    dic.Add("SelectPrice", item["SelectPrice"].ToString());
                    dic.Add("SelectSize", item["SelectSize"].ToString());

                    poiBLL.Create(Utility.GetFloat(item["PositionX"], 0f), Utility.GetFloat(item["PositionY"], 0f), ADee.Project.LBS.Entity.CoordType.BaiduEncrypt, "49566", dic, item["SimpleDesc"].ToString(), item["CompanyAddress"].ToString(), item["SimpleDesc"].ToString() + " " + item["Name"].ToString());
                }
                catch (Exception ex)
                {
                    litText.Text += Environment.NewLine + id;
                }
            }

            litText.Text += Environment.NewLine + DateTime.Now.ToString();
        }

        private void ConvertData()
        {
            var db = DataBase.Create();
            var attrDAL = new DAL.Key_Attribute();
            var kids = db.Select("select Distinct(kid) from key_attribute2");
            if(kids==null || kids.Rows.Count<=0)return;

            foreach (DataRow kidRow in kids.Rows)
            {
                var kid = Utility.GetInt(kidRow[0], 0);
                if (kid <= 0) continue;

                var attrs = db.Select("select * from key_attribute2 where kid = " + kid);
                if (attrs == null || attrs.Rows.Count <= 0) continue;

                var keyType = "";
                var keyPrice = "";
                var keySize = "";
                foreach (DataRow attrRow in attrs.Rows)
                {
                    if (!attrRow.IsNull("KeyType"))
                        keyType +=";"+ attrRow["KeyType"].ToString();
                    if (!attrRow.IsNull("KeyPrice"))
                        keyPrice += ";" + attrRow["KeyPrice"].ToString();
                    if (!attrRow.IsNull("KeySize"))
                        keySize += ";" + attrRow["KeySize"].ToString();
                }

                var keyTypes = keyType.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Distinct();
                var keyPrices = keyPrice.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Distinct();
                var keySizes = keySize.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Distinct();

                //db.ExecuteSql("delete key_attribute2 where kid = " + kid);

                //db.Parameters.Append("kid", kid);
                //db.Parameters.Append("keytype", string.Join(";", keyTypes));
                //db.Parameters.Append("keyprice", string.Join(";", keyPrices));
                //db.Parameters.Append("keysize", string.Join(";", keySizes));
                //db.ExecuteSql("insert into key_attribute2(kid,keytype,keyprice,keysize) values (@kid,@keytype,@keyprice,@keysize)");

                foreach (var key in keyTypes)
                {
                    attrDAL.Add(new Model.Key_Attribute
                    {
                        KID = kid,
                        DataType = "SelectType",
                        DataValue = key,
                    });
                }
                foreach (var price in keyPrices)
                {
                    attrDAL.Add(new Model.Key_Attribute
                    {
                        KID = kid,
                        DataType = "SelectPrice",
                        DataValue = price,
                    });
                }
                foreach (var size in keySizes)
                {
                    attrDAL.Add(new Model.Key_Attribute
                    {
                        KID = kid,
                        DataType = "SelectSize",
                        DataValue = size,
                    });
                }
            }
        }

        private void Combine()
        {
            var db = DataBase.Create();
            var knames = db.Select("SELECT DISTINCT(Name) AS countname FROM dbo.[Key]");
            foreach (DataRow name in knames.Rows)
            {
                var kidRows = db.Select(string.Format("select kid from [key] where name='{0}'", name[0]));
                var kids = new List<int>();
                foreach (DataRow item in kidRows.Rows)
                {
                    kids.Add(Utility.GetInt(item["kid"], 0));
                }
                if (!kids.Any() || kids.Count == 1) continue;

                var minkid = kids.Min();
                var otherkids = kids.Where(p => p != minkid).ToList();
                var strOtherkids = string.Join(",", otherkids);
                //key_user
                db.ExecuteSql(string.Format("update key_user set kid = {0} where kid in ({1})", minkid, strOtherkids));
                //key_product
                db.ExecuteSql(string.Format("update Key_Product set kid = {0} where kid in ({1})", minkid, strOtherkids));
                //key_attribute
                db.ExecuteSql(string.Format("update Key_Attribute2 set kid={0} where kid in ({1})", minkid, strOtherkids));                
                //db.ExecuteSql(string.Format("delete Key_Attribute where kid in ({0})", strOtherkids));
                //Center_Key_Refresh
                db.ExecuteSql(string.Format("update Center_Key_Refresh set kid = {0} where kid in ({1})", minkid, strOtherkids));
                //Center_Key_Manage
                db.ExecuteSql(string.Format("update Center_Key_Manage set kid = {0} where kid in ({1})", minkid, strOtherkids));
                //Center_Info
                db.ExecuteSql(string.Format("update Center_Info set DataID = {0} where DataID in ({1}) and InfoType = 2", minkid, strOtherkids));
                //Center_HotKey_Ext
                db.ExecuteSql(string.Format("update Center_HotKey_Ext set kid = {0} where kid in ({1})", minkid, strOtherkids));
                //Center_HotKey_Ext
                db.ExecuteSql(string.Format("delete [Key] where kid in ({0})", strOtherkids));
            }

            ConvertData();
        }
    }
}
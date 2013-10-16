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
using ADeeWu.HuoBi3J.SQL;
using System.Text;

namespace ADeeWu.HuoBi3J.Web.My.Corp.Shop.Products
{
    public partial class Edit : ADeeWu.HuoBi3J.Web.Class.PageBase_MyCorp_Shop
    {
        DataBase db = DataBase.Create();
        DAL.Shop_ProductCategories dalPCategories = new ADeeWu.HuoBi3J.DAL.Shop_ProductCategories();
        DAL.Shop_CPCategories dalCPCategories = new ADeeWu.HuoBi3J.DAL.Shop_CPCategories();
        DAL.Shop_PInCPCategories dalPInCPCategories = new ADeeWu.HuoBi3J.DAL.Shop_PInCPCategories();
        DAL.Shop_PC_Attrs dalPC_Attrs = new ADeeWu.HuoBi3J.DAL.Shop_PC_Attrs();
        DAL.Shop_PC_Attr_Options dalPC_Attr_Options = new ADeeWu.HuoBi3J.DAL.Shop_PC_Attr_Options();
        DAL.Shop_ProductAttrs dalProductAttrs = new ADeeWu.HuoBi3J.DAL.Shop_ProductAttrs();
        DAL.Shop_Products dalProducts = new ADeeWu.HuoBi3J.DAL.Shop_Products();

      
        protected long productId = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0);

      
        protected void Page_Load(object sender, EventArgs e)
        {
               if(!IsPostBack)
               {
                   //基本设置
                   this.revTxtPrice.ValidationExpression = ADeeWu.HuoBi3J.Libary.Validator.NumericeWithoutSymbolPattern;
                   this.revTxtSequence.ValidationExpression = ADeeWu.HuoBi3J.Libary.Validator.IntegerWithoutSymbolPattern;
                   this.revTxtStock.ValidationExpression = ADeeWu.HuoBi3J.Libary.Validator.IntegerWithoutSymbolPattern;
                   this.filePicture0.UploadRoot = this.LoginUser.CorpUploadFilePath;
                   
                   ADeeWu.HuoBi3J.Model.Shop_Products entity = dalProducts.GetEntity(new string[] { "ID", "CorpID" }, productId, this.LoginUser.CorpID);
                   //产品信息设置
                   if (entity != null)
                   {
                       this.txtProductName.Text = entity.Name;
                       this.txtSequence.Text = entity.Sequence.ToString();
                       this.IsHidden.Checked = entity.IsHidden;
                       this.IsRecommend.Checked = entity.IsRecommend;
                       this.txtPrice.Text = string.Format("{0:0.00}", Utility.GetStr(entity.Price));
                       this.txtStock.Text = Utility.GetStr(entity.Stock);
                       //this.txtSummary.Text = Utility.GetStr(entity.Summary);
                       this.txtContent.Value = Utility.GetStr(entity.Content);
                       this.syncSelectorLocation.Values = new string[]{
                           entity.ProvinceID.ToString(),
                           entity.CityID.ToString(),
                           entity.AreaID.ToString()
                       };

                       this.chkHasContract.Checked = entity.HasContract;

                       if (entity.UsePriceForReturn)
                       {
                           this.rbtnPrice1.Checked = true;
                           this.rbtnPrice2.Checked = false;
                           this.txtPrice.Text = entity.Price.ToString();
                           this.txtReturnPrecent.Text = string.Empty;
                       }
                       else
                       {
                           this.rbtnPrice1.Checked = false;
                           this.rbtnPrice2.Checked = true;
                           this.txtPrice.Text = string.Empty;
                           this.txtReturnPrecent.Text = entity.ReturnPrecent.ToString();
                       }

                       
                       this.txtFloatPrice.Text = entity.FloatPrice;
                       this.txtSaleTime.Text = entity.SaleTime;
                       this.txtSaleAddress.Text = entity.SaleAddress;


                       //绑定商品分类的属性模板
                       bindCategoryAttribute(entity.ID, entity.CategoryID);


                       //显示商品分类
                       bindCategory(entity.CategoryID);


                       bindCustomCategories();
                   }
                   else
                   {
                       Class.Tips.SetTips("没有找到商品", "无法找到该商品信息,可能该商品已被删除", "/My/Corp/Shop/Products/", "继续查看已发布的商品");
                       Class.Tips.Show();
                   }
               }
        }


        /// <summary>
        /// 绑定显示的产品分类
        /// </summary>
        private bool bindCategory(long categoryId)
        {
            Model.Shop_ProductCategories entPCate = dalPCategories.GetEntity(categoryId);
            if (entPCate == null) return false;
            if (entPCate.Depth <= 0)
            {
                this.liteProductCategory.Text = entPCate.Name;
                return true;
            }

            StringBuilder whereBuilder = new StringBuilder();
            foreach (string s in entPCate.ParentPath.Split(','))
            {
                long parentId = Utility.GetLong(s, 0);
                if (parentId > 0)
                {
                    whereBuilder.Append(" or ID=" + parentId);
                }
            }
            if (whereBuilder.Length > 0)
            {
                DataTable dt = dalPCategories.Select(whereBuilder.ToString().Substring(4), "Depth asc");
                if (dt.Rows.Count == 0)
                {
                    this.liteProductCategory.Text = entPCate.Name;
                }
                else
                {
                    string[] categoryNames = new string[dt.Rows.Count + 1];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        categoryNames[i] = dt.Rows[i]["Name"].ToString();
                    }
                    categoryNames[categoryNames.Length - 1] = entPCate.Name;
                    this.liteProductCategory.Text = string.Join(" &gt; ", categoryNames);
                }
            }

            return true;
        }
 

        /// <summary>
        /// 绑定商品分类的属性模板
        /// </summary>
        private void bindCategoryAttribute(long productId,long categoryId)
        {
            DataTable src = db.Select(@"
SELECT A.*,B.AttrOptionIDList,B.CustomValue,B.ProductID
FROM Shop_PC_Attrs AS A LEFT JOIN 
     (select * from Shop_ProductAttrs where ProductID={0}) AS B ON B.AttrID = A.ID
WHERE A.CategoryID = {1}
ORDER BY A.Sequence
     ",
      productId,
      categoryId
      );
            if (src.Rows.Count > 0) 
            {
                this.rpAttributes.DataSource = src;
                this.rpAttributes.DataBind();

            }else{//没有找到定制属性模板,查找引用属性模板
                long attrTplCategoryId = Utility.GetLong(db.ExecuteScalar("select AttrTplCateID from Shop_ProductCategories where ID={0}", categoryId), 0);
                if (attrTplCategoryId <= 0) return;
                bindCategoryAttribute(productId, attrTplCategoryId);//递归调用
            }
        }



        private void bindCustomCategories()
        {

            //在Shop_PInCPCategories表中
            //每个产品与每一个自定义分类的关系只存在一条记录


            string sql = @"
SELECT  A.ID, A.ShopID, A.Name, A.ItemCount, A.ParentID, A.Depth, A.ImgUrl, A.ShowImg, A.Sequence, A.IsHidden, A.CreateTime, A.ModifyTime,B.ProductID
FROM    dbo.Shop_CPCategories AS A LEFT OUTER JOIN
        ( select * from  dbo.Shop_PInCPCategories where ProductID={0} ) AS B ON B.CPCategoryID = A.ID
WHERE A.ShopID={1} and A.Depth={2}
ORDER BY A.Sequence";

            DataTable dtCustomCategories01 = db.Select(sql, productId, this.LoginUser.ShopID, 0);
            DataTable dtCustomCategories02 = db.Select(sql, productId, this.LoginUser.ShopID, 1);
            DataSet ds = new DataSet();
            dtCustomCategories01.TableName = "table01";
            dtCustomCategories01.PrimaryKey = new DataColumn[] { dtCustomCategories01.Columns["ID"] };
            dtCustomCategories02.TableName = "table02";
            dtCustomCategories02.PrimaryKey = new DataColumn[] { dtCustomCategories02.Columns["ID"] };
            ds.Tables.Add(dtCustomCategories01);
            ds.Tables.Add(dtCustomCategories02);
            DataRelation dataRelation = new DataRelation("InnerJoinRelation", dtCustomCategories01.Columns["ID"], dtCustomCategories02.Columns["ParentID"], false);
            
            ds.Relations.Add(dataRelation);
            this.rpCPCategories.DataSource = dtCustomCategories01;
            this.rpCPCategories.DataBind();
        }


        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveData();
        }


     
        private void SaveData()
        {
            ADeeWu.HuoBi3J.Model.Shop_Products entProduct = dalProducts.GetEntity(new string[] { "ID", "CorpID" }, productId, this.LoginUser.CorpID);
            if (entProduct == null)
            {
                Class.Tips.SetTips("没有找到商品", "无法找到该商品信息,可能该商品已被删除", "/My/Corp/Shop/Products/", "继续查看已发布的商品");
                Class.Tips.Show();
            }
            
            
            string name = txtProductName.Text.Trim();
            string content = txtContent.Value.Trim();
            int sequence = Utility.GetInt(txtSequence.Text.Trim(), 0);
            string[] locationValues = this.syncSelectorLocation.Values;
            string[] locationTexts = this.syncSelectorLocation.Texts;

            long provinceID = Utility.GetLong(locationValues[0], 0);
            long cityID = Utility.GetLong(locationValues[1], 0);
            long areaID = Utility.GetLong(locationValues[2], 0);

            string province = Utility.GetStr(locationTexts[0], "");
            string city = Utility.GetStr(locationTexts[1], "");
            string area = Utility.GetStr(locationTexts[2], "");

            AttrValue[] attrValues = Newtonsoft.Json.JsonConvert.DeserializeObject<AttrValue[]>(this.hfAttributeData.Value);

            
            if (name.Length == 0)
            {
                WebUtility.ShowMsg(this, "请填写商品名称！");
                return;
            }

            if (content.Length == 0)
            {
                WebUtility.ShowMsg(this, "请填写商品详细描述内容！");
                return;
            }



            if (this.filePicture0.HasFile)
            {
                if (!this.filePicture0.ValidFileExt())
                {
                    WebUtility.ShowMsg(this, "不允许上传非法文件,只允许文件类型:" + this.filePicture0.AllowFileExt.Replace("|", ""));
                    return;
                }

                if (!this.filePicture0.ValidFileSize())
                {
                    WebUtility.ShowMsg(this, "上传文件已超出大小:" + (int)(this.filePicture0.AllowFileSize / 1024) + "KB,请将图片处理后再重新上传");
                    return;
                }

            }


            //商品属性验证
            Model.Shop_PC_Attrs[] entPCAttrs = dalPC_Attrs.GetEntityList("Sequence", new string[] { "CategoryID" }, entProduct.CategoryID);
            //从数据库中查找商品分类属性列表,并检查必须填写的属性是否已经设置 有效值(预设的值)
            foreach (Model.Shop_PC_Attrs entAttr in entPCAttrs)
            {
                if (entAttr.IsValueRequire)
                {
                    if (attrValues == null || attrValues.Length == 0)
                    {
                        WebUtility.ShowMsg(this, "请设置必须填写的属性!");
                        return;//退出函数
                    }
                    else
                    {
                        bool hasValue = false;
                        foreach (AttrValue attrValue in attrValues)
                        {
                            if (attrValue.attrId == entAttr.ID)
                            {
                                hasValue = true;
                            }
                        }
                        if (!hasValue)
                        {
                            WebUtility.ShowMsg(this, "请设置必须填写的属性!");
                            return;//退出函数
                        }
                    }
                }
            }


            
            entProduct.Name  = name;
            entProduct.Sequence = sequence;
            entProduct.IsHidden = IsHidden.Checked;
            entProduct.IsRecommend = IsRecommend.Checked;
            entProduct.Stock = Utility.GetInt(this.txtStock.Text, 0);
            //entProduct.Summary = Utility.GetStr(this.txtSummary.Text);
            entProduct.Content = this.txtContent.Value;
            //product.CategoryID = productCategoryID; //商品分类不能修改

            entProduct.ProvinceID = provinceID;
            entProduct.CityID = cityID;
            entProduct.AreaID = areaID;
            entProduct.Province = province;
            entProduct.City = city;
            entProduct.Area = area;

            entProduct.UsePriceForReturn = this.rbtnPrice1.Checked;
            if (entProduct.UsePriceForReturn)
            {
                entProduct.Price = Utility.GetDecimal(txtPrice.Text, 0);
                entProduct.ReturnPrecent = 0;
            }
            else
            {
                entProduct.Price = 0;
                entProduct.ReturnPrecent = ADeeWu.HuoBi3J.Libary.Utility.GetInt(txtReturnPrecent.Text, 0);
            }

            entProduct.FloatPrice = this.txtFloatPrice.Text.Trim();
            entProduct.SaleAddress = this.txtSaleAddress.Text.Trim();
            entProduct.SaleTime = this.txtSaleTime.Text.Trim();
            entProduct.HasContract = this.chkHasContract.Checked;

            entProduct.ModifyTime = DateTime.Now;

            if (this.filePicture0.HasFile)
            {
                entProduct.Picture0 = filePicture0.GetUploadedFilePath();
            }

            if (dalProducts.Update(entProduct) > 0) 
            {
                if (filePicture0.HasFile)
                {
                    filePicture0.Save();
                }

                //删除当前产品在ER表商铺自定义商品分类中的所有记录
                dalPInCPCategories.Delete("ProductID=" + productId + " and ShopID=" + this.LoginUser.ShopID);


                #region 商品重新归类(商铺自定义商品分类)
                foreach (RepeaterItem item in this.rpCPCategories.Items)
                {
                    //一级分类
                    HtmlInputCheckBox chk01 = item.FindControl("chkCategoryID") as HtmlInputCheckBox;
                    if (chk01.Checked)
                    {
                        long categoryID = Utility.GetLong(chk01.Value, 0);
                        setProductCustomCategory(entProduct.ID, categoryID);
                    }

                    //二级分类
                    Repeater rpSubCategory = item.FindControl("rpCPCategories02") as Repeater;
                    if (rpSubCategory != null && rpSubCategory.Items.Count > 0)
                    {
                        foreach (RepeaterItem item02 in rpSubCategory.Items)
                        {
                            HtmlInputCheckBox chk = item02.FindControl("chkCategoryID") as HtmlInputCheckBox;
                            if (chk.Checked)
                            {
                                long categoryID = Utility.GetLong(chk.Value, 0);
                                setProductCustomCategory(entProduct.ID, categoryID);
                            }
                        }
                    }
                }
                #endregion

                #region 商品属性设置保存
                if (attrValues != null && attrValues.Length > 0)
                {
                    foreach (AttrValue attrValue in attrValues)
                    {
                        Model.Shop_PC_Attrs entPCAttr = dalPC_Attrs.GetEntity(attrValue.attrId);
                        bool update = true;

                        if (entPCAttr != null)//判断商品分类是否存在该属性
                        {
                            switch (entPCAttr.ValueType)
                            {
                                case 0://只可填写属性

                                    Model.Shop_ProductAttrs entProductAttr01 = dalProductAttrs.GetEntity(new string[] { "AttrID", "ProductID" }, entPCAttr.ID, productId);
                                    if (entProductAttr01 == null)
                                    {
                                        update = false;
                                        entProductAttr01 = new ADeeWu.HuoBi3J.Model.Shop_ProductAttrs();
                                    }
                                    entProductAttr01.AttrID = entPCAttr.ID;
                                    entProductAttr01.CustomValue = attrValue.value;
                                    entProductAttr01.ProductID = entProduct.ID;

                                    if (!update)
                                    {
                                        dalProductAttrs.Add(entProductAttr01);
                                    }
                                    else
                                    {
                                        dalProductAttrs.Update(entProductAttr01);
                                    }

                                    break;
                                case 1://只可单选属性

                                    if (attrValue.value.IndexOf('.') <= -1)
                                    {
                                        long optionId = Utility.GetLong(attrValue.value, 0);
                                        if (optionId > 0 && dalPC_Attr_Options.Exist("id", optionId))//判断值是否有效
                                        {
                                            Model.Shop_ProductAttrs entProductAttr02 = dalProductAttrs.GetEntity(new string[] { "AttrID", "ProductID" }, entPCAttr.ID, productId);
                                            if (entProductAttr02 == null)
                                            {
                                                update = false;
                                                entProductAttr02 = new ADeeWu.HuoBi3J.Model.Shop_ProductAttrs();
                                            }
                                            entProductAttr02.AttrID = entPCAttr.ID;
                                            entProductAttr02.AttrOptionIDList = optionId + ",";
                                            entProductAttr02.ProductID = entProduct.ID;

                                            if (!update)
                                            {
                                                dalProductAttrs.Add(entProductAttr02);
                                            }
                                            else
                                            {
                                                dalProductAttrs.Update(entProductAttr02);
                                            }
                                        }
                                    }

                                    break;
                                case 2://略

                                    break;
                                case 3://多选属性
                                    StringBuilder optionListBuilder = new StringBuilder();
                                    //判断每个属性的可选值是否有效
                                    string[] attrOptions = attrValue.value.Split(',');
                                    foreach (string attrOption in attrOptions)
                                    {
                                        long optionId = Utility.GetLong(attrOption, 0);
                                        if (optionId > 0 && dalPC_Attr_Options.Exist("ID", optionId))
                                        {
                                            optionListBuilder.AppendFormat("{0},", optionId);
                                        }
                                    }
                                    if (optionListBuilder.Length > 0)
                                    {
                                        Model.Shop_ProductAttrs entProductAttr03 = dalProductAttrs.GetEntity(new string[] { "AttrID", "ProductID" }, entPCAttr.ID, productId);
                                        if (entProductAttr03 == null)
                                        {
                                            update = false;
                                            entProductAttr03 = new ADeeWu.HuoBi3J.Model.Shop_ProductAttrs();
                                        }
                                        entProductAttr03.AttrID = entPCAttr.ID;
                                        entProductAttr03.AttrOptionIDList = optionListBuilder.ToString();
                                        entProductAttr03.ProductID = entProduct.ID;

                                        if (!update)
                                        {
                                            dalProductAttrs.Add(entProductAttr03);
                                        }
                                        else
                                        {
                                            dalProductAttrs.Update(entProductAttr03);
                                        }
                                    }
                                    break;
                            }//switch

                        }//if(entPCAttr!=null)

                    }//foreach
                }//if (attrValues.Length > 0)
                #endregion

                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "更新产品成功!", "Default.aspx");
                return;
            }
            else
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "更新产品失败!");
            }  


        }


        protected void rpCPCategories_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater rpCategories = sender as Repeater;
            DataTable dt = rpCategories.DataSource as DataTable;
            long categoryID = Utility.GetLong(dt.Rows[e.Item.ItemIndex]["ID"], 0);
            Repeater rpCategories02 = e.Item.FindControl("rpCPCategories02") as Repeater;
            DataRow row = ((DataRowView)e.Item.DataItem).Row;
            DataRow[] childRows = row.GetChildRows("InnerJoinRelation");
            if (childRows.Length > 0)
            {
                //HtmlInputCheckBox chkCategoryID = e.Item.FindControl("chkCategoryID") as HtmlInputCheckBox;
                //chkCategoryID.Disabled = true;
                rpCategories02.DataSource = childRows;
                rpCategories02.DataBind();
            }
        }

        /// <summary>
        /// 设置商品所属自定义分类
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="customCategoryID"></param>
        private void setProductCustomCategory(long productID, long customCategoryID)
        {
            Model.Shop_PInCPCategories ent = new ADeeWu.HuoBi3J.Model.Shop_PInCPCategories();
            ent.CPCategoryID = customCategoryID;
            ent.ProductID = productID;
            ent.ShopID = this.LoginUser.ShopID;
            dalPInCPCategories.Add(ent);
        }


        /// <summary>
        /// rpAttributes绑定时使用,用于输出属性的可选列表
        /// </summary>
        /// <param name="attrId"></param>
        /// <returns></returns>
        protected string GetAttrOptions(long attrId)
        {
            string beginTag = "<ul style='display:none'>";
            string endTag = "</ul>";

            DataTable dtAttrOptions = dalPC_Attr_Options.Select("AttrId=" + attrId, "Sequence asc");
            StringBuilder optionBuilder = new StringBuilder();
            for (int i = 0; i < dtAttrOptions.Rows.Count; i++)
            {
                optionBuilder.AppendFormat("<li value=\"{0}\">{1}</li>\r\n", dtAttrOptions.Rows[i]["ID"], dtAttrOptions.Rows[i]["Value"]);
            }
            return beginTag + "\r\n" + optionBuilder.ToString() + "\r\n" + endTag;
        }

    }
}

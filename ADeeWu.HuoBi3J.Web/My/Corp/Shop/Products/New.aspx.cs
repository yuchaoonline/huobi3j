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


    public class AttrValue
    {
        private long _attrId = 0;

        public long attrId
        {
            get { return _attrId; }
            set { _attrId = value; }
        }

        private string _value = string.Empty;

        public string value
        {
            get { return _value; }
            set { _value = value; }
        }
        
    }


    public partial class New : ADeeWu.HuoBi3J.Web.Class.PageBase_MyCorp_Shop
    {

        DataBase db = DataBase.Create();
        DAL.Shop_ProductCategories dalPCategories = new ADeeWu.HuoBi3J.DAL.Shop_ProductCategories();
        DAL.Shop_CPCategories dalCPCategories = new ADeeWu.HuoBi3J.DAL.Shop_CPCategories();
        DAL.Shop_PInCPCategories dalPInCPCategories = new ADeeWu.HuoBi3J.DAL.Shop_PInCPCategories();
        DAL.Shop_PC_Attrs dalPC_Attrs = new ADeeWu.HuoBi3J.DAL.Shop_PC_Attrs();
        DAL.Shop_PC_Attr_Options dalPC_Attr_Options = new ADeeWu.HuoBi3J.DAL.Shop_PC_Attr_Options();
        DAL.Shop_ProductAttrs dalProductAttrs = new ADeeWu.HuoBi3J.DAL.Shop_ProductAttrs();
        DAL.Shop_Products dalProducts = new ADeeWu.HuoBi3J.DAL.Shop_Products();

        protected long categoryId = 0;//产品分类ID
        
        protected void Page_Load(object sender, EventArgs e)
        {



            if (!IsPostBack)
            {

                categoryId = WebUtility.GetFormLong("cid", 0);
                ViewState["CategoryID"] = categoryId;

                if (categoryId <= 0 || !bindCategory(categoryId) 
                    //|| !bindCategoryAttribute(categoryId)
                    )
                {
                    showTips();
                    return;
                }


                bindCategoryAttribute(categoryId);

                bindCustomCategories();

                

                //基本设置
                this.revTxtPrice.ValidationExpression = ADeeWu.HuoBi3J.Libary.Validator.NumericeWithoutSymbolPattern;
                this.revTxtSequence.ValidationExpression = ADeeWu.HuoBi3J.Libary.Validator.IntegerWithoutSymbolPattern;
                this.revTxtStock.ValidationExpression = ADeeWu.HuoBi3J.Libary.Validator.IntegerWithoutSymbolPattern;
                this.filePicture0.UploadRoot = this.LoginUser.CorpUploadFilePath;
                this.txtSequence.Text = (Utility.GetInt(db.ExecuteScalar("select count(id) from Shop_Products where CorpID=" + this.LoginUser.CorpID), 0) + 1).ToString();

            }
            else
            {
                categoryId = Utility.GetLong(ViewState["CategoryID"], 0);
                if (categoryId <= 0)
                {
                    showTips();
                    return;
                }

            }
        }

        private void showTips()
        {
            Response.Redirect("SelectCategory.aspx");
            
            //Class.Tips tips = new ADeeWu.HuoBi3J.Web.Class.Tips(
            //    "请选择商品分类",
            //    "您还没有选择商品所属分类,请选择后才发布商品!",
            //    "/My/Corp/Shop/Products/SelectCategory.aspx",
            //    "请点击这里选择商品分类"
            //    );
            //Class.Tips.SetTips(tips);
            //Class.Tips.Show();
        }

        /// <summary>
        /// 绑定商品分类的属性模板
        /// </summary>
        private bool bindCategoryAttribute(long categoryId)
        {
            //查找该产品分类的定制属性模板
            DataTable src = dalPC_Attrs.Select("CategoryID=" + categoryId, "Sequence asc");
            if (src.Rows.Count == 0)//当前没有定制属性模板,查找该分类是否有引用其他分类的属性模板
            {
                long attrTplCategoryId = Utility.GetLong(db.ExecuteScalar("select AttrTplCateID from Shop_ProductCategories where ID={0}", categoryId), 0);
                if (attrTplCategoryId <= 0) return false;

                return bindCategoryAttribute(attrTplCategoryId);//递归调用
            }
            this.rpAttributes.DataSource = src;
            this.rpAttributes.DataBind();
            return true;
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
        /// 绑定客户商铺自定义分类
        /// </summary>
        private void bindCustomCategories()
        {
            DataTable dtCustomCategories01 = dalCPCategories.Select("ShopID=" + this.LoginUser.ShopID + " and Depth=0", "Sequence");
            DataTable dtCustomCategories02 = dalCPCategories.Select("ShopID=" + this.LoginUser.ShopID + " and Depth=1", "Sequence");
            DataSet ds = new DataSet();
            ds.Tables.Add(dtCustomCategories01);
            ds.Tables.Add(dtCustomCategories02);
            DataRelation dataRelation = new DataRelation("InnerJoinRelation", dtCustomCategories01.Columns["ID"], dtCustomCategories02.Columns["ParentID"]);
            ds.Relations.Add(dataRelation);
            this.rpCPCategories.DataSource = dtCustomCategories01;
            this.rpCPCategories.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (categoryId <= 0)
            {
                WebUtility.ShowMsg(this, "您还没有选择商品所属分类,请选择后才发布商品!", "SelectCategory.aspx");
                return;
            }

            SaveData();
        }

        /// <summary>
        /// 发布产品
        /// </summary>
        private void SaveData()
        {
            string name = txtProductName.Text.Trim();
            string content = txtContent.Value.Trim();
            int sequence= Utility.GetInt(txtSequence.Text.Trim(),0);
            long productCategoryID = categoryId;
            string[] locationValues = this.syncSelectorLocation.Values;
            string[] locationTexts = this.syncSelectorLocation.Texts;

            long provinceID = Utility.GetLong(locationValues[0], 0);
            long cityID = Utility.GetLong(locationValues[1], 0);
            long areaID = Utility.GetLong(locationValues[2], 0);

            string province = Utility.GetStr(locationTexts[0], "");
            string city = Utility.GetStr(locationTexts[1], "");
            string area = Utility.GetStr(locationTexts[2], "");

            //如果提交的商品属性值设置数据不包含商品分类应有的所有属性,则按照提交的数据为准
            AttrValue[] attrValues = Newtonsoft.Json.JsonConvert.DeserializeObject<AttrValue[]>(this.hfAttributeData.Value);

            if (name.Length==0)
            {
                WebUtility.ShowMsg(this,"请填写商品名称！");
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
            Model.Shop_PC_Attrs[] entPCAttrs = dalPC_Attrs.GetEntityList("Sequence", new string[] { "CategoryID" }, categoryId);
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
                        bool hasValue= false;
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

            

            
            Model.Shop_Products product = new Model.Shop_Products();
            product.CorpID = this.LoginUser.CorpID;
            product.CorpUserID = this.LoginUser.CorpUserID;
            product.ShopID = this.LoginUser.ShopID;
            product.Name = name;
            product.Sequence = sequence;
            product.IsHidden = IsHidden.Checked;
            product.IsRecommend = IsRecommend.Checked;
           
            product.Stock = Utility.GetInt(this.txtStock.Text, 0);
            //product.Summary = Utility.GetStr(this.txtSummary.Text);
            product.Content = this.txtContent.Value;
            product.CheckState = 1;//默认通过审核
            product.CategoryID = productCategoryID;

            product.ProvinceID = provinceID;
            product.CityID = cityID;
            product.AreaID = areaID;
            product.Province = province;
            product.City = city;
            product.Area = area;

            product.UsePriceForReturn = this.rbtnPrice1.Checked;
            if (product.UsePriceForReturn)
            {
                product.Price = Utility.GetDecimal(txtPrice.Text, 0);
                product.ReturnPrecent = 0;
            }
            else
            {
                product.Price = 0;
                product.ReturnPrecent = ADeeWu.HuoBi3J.Libary.Utility.GetInt(txtReturnPrecent.Text, 0);
            }

            product.FloatPrice = this.txtFloatPrice.Text.Trim();
            product.SaleAddress = this.txtSaleAddress.Text.Trim();
            product.SaleTime = this.txtSaleTime.Text.Trim();
            product.HasContract = this.chkHasContract.Checked;
            
            if (filePicture0.HasFile)
            {
                product.Picture0 = filePicture0.GetUploadedFilePath();
            }


            
            
            product.CreateTime = DateTime.Now;
            product.ModifyTime = DateTime.Now;

            if (dalProducts.Add(product) > 0)
            {
                if (filePicture0.HasFile)
                {
                    filePicture0.Save();
                }

                #region 商品归类(商铺自定义商品分类)
                foreach (RepeaterItem item in this.rpCPCategories.Items)
                {
                    //一级分类
                    HtmlInputCheckBox chk01 = item.FindControl("chkCategoryID") as HtmlInputCheckBox;
                    if (chk01.Checked)
                    {
                        long categoryID = Utility.GetLong(chk01.Value, 0);
                        setProductCustomCategory(product.ID, categoryID);
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
                                setProductCustomCategory(product.ID, categoryID);
                            }
                        }
                    }
                }
                #endregion

                #region 商品属性设置保存
                if (attrValues.Length > 0)
                {
                    foreach (AttrValue attrValue in attrValues)
                    {
                        Model.Shop_PC_Attrs entPCAttr = dalPC_Attrs.GetEntity(attrValue.attrId);
                        if (entPCAttr != null)//判断商品分类是否存在该属性
                        {
                            
                            switch (entPCAttr.ValueType)
                            {
                                case 0://只可填写属性
                                    Model.Shop_ProductAttrs entProductAttr01 = new ADeeWu.HuoBi3J.Model.Shop_ProductAttrs();
                                    entProductAttr01.AttrID = entPCAttr.ID;
                                    entProductAttr01.CustomValue = attrValue.value;
                                    entProductAttr01.ProductID = product.ID;
                                    dalProductAttrs.Add(entProductAttr01);
                                    break;
                                case 1://只可单选属性
                                    if (attrValue.value.IndexOf('.') <= -1)
                                    {
                                        long optionId = Utility.GetLong(attrValue.value, 0);
                                        if (optionId > 0 && dalPC_Attr_Options.Exist("id", optionId))//判断值是否有效
                                        {                                           
                                            Model.Shop_ProductAttrs entProductAttr02 = new ADeeWu.HuoBi3J.Model.Shop_ProductAttrs();
                                            entProductAttr02.AttrID = entPCAttr.ID;
                                            entProductAttr02.AttrOptionIDList = optionId + ",";
                                            entProductAttr02.ProductID = product.ID;
                                            dalProductAttrs.Add(entProductAttr02);

                                            //更新该属性选值的商品统计数量
                                            db.ExecuteSql("update Shop_PC_Attr_Options set ItemCount=ItemCount+1 where ID={0}", optionId);
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
                                                //更新该属性选值的商品统计数量
                                                db.ExecuteSql("update Shop_PC_Attr_Options set ItemCount=ItemCount+1 where ID={0}", optionId);
                                            }
                                        }
                                        if (optionListBuilder.Length > 0)
                                        {
                                            Model.Shop_ProductAttrs entProductAttr03 = new ADeeWu.HuoBi3J.Model.Shop_ProductAttrs();
                                            entProductAttr03.AttrID = entPCAttr.ID;
                                            entProductAttr03.AttrOptionIDList = optionListBuilder.ToString();
                                            entProductAttr03.ProductID = product.ID;
                                            dalProductAttrs.Add(entProductAttr03);
                                        }
                                    break;
                            }//switch
                            
                        }//if(entPCAttr!=null)
                        
                    }//foreach
                }//if (attrValues.Length > 0)
                #endregion


                
                
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "发布产品成功!", "Default.aspx");


                return;
            }
            else {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "发布产品失败!");
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
            if(childRows.Length>0){
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
        /// 用于动态渲染产品属性输入控件[暂不用,用javascript 代替]
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        //protected string RenderAttributeInput(long id,int valueType,string name)
        //{
        //    switch (valueType)
        //    {
        //        case 0://只可填写
        //            return string.Format("<input type=\"text\" id=\"txtAttr_{0}\"", id);
        //        case 1://只可选择
        //            DataTable dtAttrOptions = dalPC_Attr_Options.Select("AttrId=" + id, "Sequence asc");
        //            string beginTag =string.Format("<select id=\"selAttr_{0}\">", id);
        //            string endTag = "</select>";
        //            if (dtAttrOptions.Rows.Count == 0)
        //            {
        //                return beginTag + endTag;
        //            }
        //            else
        //            {
        //                StringBuilder optionBuilder = new StringBuilder();
        //                for (int i = 0; i < dtAttrOptions.Rows.Count; i++)
        //                {
        //                    optionBuilder.AppendFormat("<option value=\"{0}\">{1}</option>\r\n", dtAttrOptions.Rows[i]["ID"], dtAttrOptions.Rows[i]["Value"]);
        //                }
        //                return beginTag + "\r\n" + optionBuilder.ToString() + "\r\n" + endTag;
        //            }
        //        case 2://可选择可填写
                    
        //        default:
        //            return string.Empty;
        //    }
        //}

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

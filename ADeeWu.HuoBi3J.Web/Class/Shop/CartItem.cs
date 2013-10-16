// File:    CartItem.cs
// Author:  Administrator
// Created: 2010年5月25日 9:51:23
// Purpose: Definition of Class CartItem

using System;

namespace ADeeWu.HuoBi3J.Class.Shop
{
    /// <summary>
    /// 表示购物车上的商品
    /// </summary>
    public class CartItem
    {
        private long productID;
        private string productName;
        private long quantity;
        private decimal price;
        private string imgUrl;


        
        /// <summary>
        /// 商品唯一标识ID
        /// </summary>
        public long ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        /// <summary>
        /// 商品数量(订购数量)
        /// </summary>
        public long Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        /// <summary>
        /// 商品图片
        /// </summary>
        public string ImgUrl
        {
            get { return imgUrl; }
            set { imgUrl = value; }
        }


        public CartItem(long productID, string productName, long quantity, decimal price, string imgUrl)
        {
            this.productID = productID;
            this.productName = productName;
            this.quantity = quantity;
            this.price = price;
            this.imgUrl = imgUrl;
        }
    }
}
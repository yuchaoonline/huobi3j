// File:    CartItem.cs
// Author:  Administrator
// Created: 2010��5��25�� 9:51:23
// Purpose: Definition of Class CartItem

using System;

namespace ADeeWu.HuoBi3J.Class.Shop
{
    /// <summary>
    /// ��ʾ���ﳵ�ϵ���Ʒ
    /// </summary>
    public class CartItem
    {
        private long productID;
        private string productName;
        private long quantity;
        private decimal price;
        private string imgUrl;


        
        /// <summary>
        /// ��ƷΨһ��ʶID
        /// </summary>
        public long ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        /// <summary>
        /// ��Ʒ����
        /// </summary>
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        /// <summary>
        /// ��Ʒ����(��������)
        /// </summary>
        public long Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        /// <summary>
        /// ��Ʒ�۸�
        /// </summary>
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        /// <summary>
        /// ��ƷͼƬ
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
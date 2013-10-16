// File:    SessionCart.cs
// Author:  Administrator
// Created: 2010年5月25日 9:51:23
// Purpose: Definition of Class SessionCart

using System;
using System.Collections.Generic;

namespace ADeeWu.HuoBi3J.Class.Shop
{
   /// 使用Session来实现购物车
   public class SessionCart : Cart
   {
       private Dictionary<long, CartItem> items = new Dictionary<long, CartItem>();

       public override CartItem[] GetAll()
       {
          CartItem[] ret = new CartItem[this.items.Count];
          int i = 0;
          foreach (KeyValuePair<long,CartItem> item in this.items)
          {
              ret[i++] = item.Value;
          }
          return ret;
      }
      
     
      public override CartItem GetItem(long productID)
      {
          return this.items.ContainsKey(productID) ? this.items[productID] : null;
      }

     
      public override CartItem AppendItem(CartItem item)
      {
          CartItem existItem = GetItem(item.ProductID);
          if (existItem != null)
          {
              existItem.ProductName = item.ProductName;
              existItem.ImgUrl = item.ImgUrl;
              existItem.Quantity = item.Quantity;
              existItem.Price = item.Price;
          }
          else
          {
              existItem = item;
              this.items.Add(item.ProductID, existItem);
          }
          return existItem;
      }

      public override CartItem IncreaseQuantity(long productID, long quantityToIncrase)
      {
          CartItem existItem = GetItem(productID);
          if (existItem == null) return null;
          existItem.Quantity += quantityToIncrase;
          return existItem;
      }

      public override CartItem DecreaseQuantity(long productID, long quantityToDecrease)
      {
          CartItem existItem = GetItem(productID);
          if (existItem == null) return null;
          existItem.Quantity -= quantityToDecrease;
          if (existItem.Quantity <= 0) return RemoveItem(productID);
          return existItem;
      }
      
      
      public override CartItem RemoveItem(long productID)
      {
          CartItem item = null;
          if (this.items.ContainsKey(productID))
          {
              item = this.items[productID];
          }
          this.items.Remove(productID);
          return item;
      }
      
      public override void Clear()
      {
          this.items.Clear();
      }
   
   }
}
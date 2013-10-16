// File:    Cart.cs
// Author:  Administrator
// Created: 2010年5月25日 9:51:23
// Purpose: Definition of Class Cart

using System;
using System.Web;

namespace ADeeWu.HuoBi3J.Class.Shop
{
   public abstract class Cart
   {
      /// 获取当前用户购物车上的所有商品
      public abstract CartItem[] GetAll();
      
      /// 根据商品唯一标识ID 获取购物车上的商品
      public abstract CartItem GetItem(long productID);
      
      /// 向购物车追加一个新的商品,并返回新的商品
      /// 如果购物车已有同一个商品,则将指定的覆盖原有的
      public abstract CartItem AppendItem(CartItem item);

      /// <summary>
      /// 增加购物车上的商品数量
      /// </summary>
      /// <param name="productID"></param>
      /// <param name="quantityToIncrease"></param>
      /// <returns></returns>
      public abstract CartItem IncreaseQuantity(long productID, long quantityToIncrease);

      /// <summary>
      /// 减少购物车上的商品数量,当商品数量为0时,自动清除该记录
      /// </summary>
      /// <param name="productID"></param>
      /// <param name="quantityToDecrease"></param>
      /// <returns></returns>
      public abstract CartItem DecreaseQuantity(long productID, long quantityToDecrease);


      /// 根据产品ID移除购物车上的商品,并且返回该移除的商品,当没有找到商品时应该返回NULL值
      public abstract CartItem RemoveItem(long productID);
      
      /// 清除购物车上的所有商品
      public abstract void Clear();
      
      /// 获取当前HTTP连接的购物车
      /// 从当前Session 里获取,如果购物车还没有创建
      /// 则根据当前用户浏览器环境创建一个购物车
      /// 如果用户浏览器已禁止了Cookie 则创建SessionCart,否则使用CookieCart
      public static Cart CurrentCart
      {
          get {
              if(HttpContext.Current==null) return null;

              Cart cart = HttpContext.Current.Session["ShopCart"] as Cart;
              if (cart == null)
              {
                  //if (HttpContext.Current.Request.Browser.Cookies)
                  //{
                  //    cart = new CookieCart();
                  //}
                  //else
                  //{
                      cart = new SessionCart();
                  //}
                  HttpContext.Current.Session["ShopCart"] = cart;
              }
              return cart;
          }
      }
   
   }
}
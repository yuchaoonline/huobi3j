// File:    Cart.cs
// Author:  Administrator
// Created: 2010��5��25�� 9:51:23
// Purpose: Definition of Class Cart

using System;
using System.Web;

namespace ADeeWu.HuoBi3J.Class.Shop
{
   public abstract class Cart
   {
      /// ��ȡ��ǰ�û����ﳵ�ϵ�������Ʒ
      public abstract CartItem[] GetAll();
      
      /// ������ƷΨһ��ʶID ��ȡ���ﳵ�ϵ���Ʒ
      public abstract CartItem GetItem(long productID);
      
      /// ���ﳵ׷��һ���µ���Ʒ,�������µ���Ʒ
      /// ������ﳵ����ͬһ����Ʒ,��ָ���ĸ���ԭ�е�
      public abstract CartItem AppendItem(CartItem item);

      /// <summary>
      /// ���ӹ��ﳵ�ϵ���Ʒ����
      /// </summary>
      /// <param name="productID"></param>
      /// <param name="quantityToIncrease"></param>
      /// <returns></returns>
      public abstract CartItem IncreaseQuantity(long productID, long quantityToIncrease);

      /// <summary>
      /// ���ٹ��ﳵ�ϵ���Ʒ����,����Ʒ����Ϊ0ʱ,�Զ�����ü�¼
      /// </summary>
      /// <param name="productID"></param>
      /// <param name="quantityToDecrease"></param>
      /// <returns></returns>
      public abstract CartItem DecreaseQuantity(long productID, long quantityToDecrease);


      /// ���ݲ�ƷID�Ƴ����ﳵ�ϵ���Ʒ,���ҷ��ظ��Ƴ�����Ʒ,��û���ҵ���ƷʱӦ�÷���NULLֵ
      public abstract CartItem RemoveItem(long productID);
      
      /// ������ﳵ�ϵ�������Ʒ
      public abstract void Clear();
      
      /// ��ȡ��ǰHTTP���ӵĹ��ﳵ
      /// �ӵ�ǰSession ���ȡ,������ﳵ��û�д���
      /// ����ݵ�ǰ�û��������������һ�����ﳵ
      /// ����û�������ѽ�ֹ��Cookie �򴴽�SessionCart,����ʹ��CookieCart
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
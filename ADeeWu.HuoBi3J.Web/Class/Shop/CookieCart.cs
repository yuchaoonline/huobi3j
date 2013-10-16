// File:    CookieCart.cs
// Author:  Administrator
// Created: 2010年5月25日 9:51:23
// Purpose: Definition of Class CookieCart

using System;
using System.Web;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Class.Shop
{

    /*
     
     ShopCart
        -- ProductID : ProductID,ProductName,Quantity,Price,ImgUrl
        -- 01 : "01,产品名称,20,20.00,http://xxx/1.jpg"
     
     */
    /// 使用Cookie 来实现购物车
   public class CookieCart : Cart
   {
       private readonly string cookieKey = "ShopCart";
       private HttpContext context = HttpContext.Current;

       public override CartItem[] GetAll()
       {
           HttpCookie cookie = GetShopCartCookie();
           if (cookie == null) return new CartItem[0];
           CartItem[] ret = new CartItem[cookie.Values.Count];
           for (int i = 0; i < cookie.Values.Count; i++)
           {
               ret[i] = ParseToItem(cookie.Values[i]);
           }
           return ret;
       }

       public override CartItem GetItem(long productID)
       {
           HttpCookie cookie = GetShopCartCookie();
           if (cookie == null) return null;
           for (int i = 0; i < cookie.Values.Keys.Count; i++)
           {
               string key = cookie.Values.Keys[i];
               if (productID == Utility.GetLong(key, 0))
                   return ParseToItem(cookie.Values[key]);
           }
           return null;
       }

       public override CartItem AppendItem(CartItem item)
       {
           HttpCookie responseCookie = context.Response.Cookies[cookieKey];
           if (responseCookie == null)
           {
               responseCookie = GetShopCartCookie();
           }

           if (responseCookie == null)
           {
               responseCookie = new HttpCookie(cookieKey);
               context.Response.Cookies.Add(responseCookie);
           }

           responseCookie.Values.Remove(item.ProductID.ToString());
           responseCookie.Values.Add(item.ProductID.ToString(), ToCookieString(item));
           
         
           return item;
       }

       public override CartItem IncreaseQuantity(long productID, long quantityToIncrease)
       {
           CartItem existItem = GetItem(productID);
           if (existItem == null) return null;
           existItem.Quantity += quantityToIncrease;
           return AppendItem(existItem);
       }

       public override CartItem DecreaseQuantity(long productID, long quantityToDecrease)
       {
           CartItem existItem = GetItem(productID);
           if (existItem == null) return null;
           existItem.Quantity -= quantityToDecrease;
           return AppendItem(existItem);
       }

       public override CartItem RemoveItem(long productID)
       {
           throw new NotImplementedException();
       }

       public override void Clear()
       {
           
       }

       private HttpCookie GetShopCartCookie()
       {
           return context.Request.Cookies.Get(cookieKey);
       }
       
       public string ToCookieString(CartItem item)
       {
           string s = string.Format("{0},{1},{2},{3},{4}",
               item.ProductID,
               HttpUtility.UrlEncode(item.ProductName),
               item.Quantity,
               item.Price,
               HttpUtility.UrlEncode(item.ImgUrl)
               );
           return s;
       }

       public CartItem ParseToItem(string cookieString)
       {
           string[] s = cookieString.Split(',');
           if (s.Length != 5) return null;
           long productID = Utility.GetLong(s[0], 0);
           string productName = HttpUtility.UrlDecode(Utility.GetStr(s[1], ""));
           long quantity = Utility.GetLong(s[2],0);
           decimal price = Utility.GetDecimal(s[3], 0);
           string imgUrl = HttpUtility.UrlDecode(Utility.GetStr(s[4], ""));
           if (productID <= 0) return null;
           return new CartItem(productID, productName, quantity, price, imgUrl);
       }

   }
}
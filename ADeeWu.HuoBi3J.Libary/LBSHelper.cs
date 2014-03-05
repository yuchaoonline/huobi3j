using ADee.Project.LBS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADeeWu.HuoBi3J.Libary
{
    public class LBSHelper
    {
        public class ProductPoi : Poi
        {
            public double Price { get; set; }
            public string Description { get; set; }
            public string BName { get; set; }
            public string CompanyName { get; set; }
            public string Phone { get; set; }
            public string SalemanMemo { get; set; }
            public string QQ { get; set; }
            public string SelectType { get; set; }
            public string SelectPrice { get; set; }
            public string SelectSize { get; set; }
            public string SelectTypeID { get; set; }
            public string SelectPriceID { get; set; }
            public string SelectSizeID { get; set; }
            public string KName { get; set; }
            public int KID { get; set; }
            public int CreateUserID { get; set; }
        }

        public class ProductContent : Content
        {
            public double Price { get; set; }
            public string Description { get; set; }
            public string BName { get; set; }
            public string CompanyName { get; set; }
            public string Phone { get; set; }
            public string SalemanMemo { get; set; }
            public string QQ { get; set; }
            public string SelectType { get; set; }
            public int SelectTypeID { get; set; }
            public string SelectPrice { get; set; }
            public int SelectPriceID { get; set; }
            public string SelectSize { get; set; }
            public int SelectSizeID { get; set; }
            public string KName { get; set; }
            public int KID { get; set; }
            public int AID { get; set; }
            public int CreateUserID { get; set; }
        }
    }
}

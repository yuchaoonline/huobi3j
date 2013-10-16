
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Shop_Products{

	#region Fields
	private long _ID = 0L;
	private long _ShopID = 0L;
	private long _CorpID = 0L;
	private long _CorpUserID = 0L;
	private long _CategoryID = 0L;
	private int _Stock = 0;
	private int _SaleOut = 0;
	private string _Name = String.Empty;
	private string _Summary = String.Empty;
	private string _Keywords = String.Empty;
	private string _Content = String.Empty;
	private decimal _Price = 0M;
	private int _ReturnPrecent = 0;
	private bool _UsePriceForReturn = false;
	private string _FloatPrice = String.Empty;
	private string _Picture0 = String.Empty;
	private string _Picture1 = String.Empty;
	private string _PictureList = String.Empty;
	private string _SaleTime = String.Empty;
	private string _SaleAddress = String.Empty;
	private bool _HasContract = false;
	private long _ProvinceID = 0L;
	private long _CityID = 0L;
	private long _AreaID = 0L;
	private string _Province = String.Empty;
	private string _City = String.Empty;
	private string _Area = String.Empty;
	private bool _IsHidden = false;
	private bool _IsRecommend = false;
	private int _Sequence = 0;
	private int _VisitCount = 0;
	private int _CheckState = 0;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	private DateTime _ModifyTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public Shop_Products()
	{
	}
	
	public Shop_Products
	(
		long iD,
			long shopID,
			long corpID,
			long corpUserID,
			long categoryID,
			int stock,
			int saleOut,
			string name,
			string summary,
			string keywords,
			string content,
			decimal price,
			int returnPrecent,
			bool usePriceForReturn,
			string floatPrice,
			string picture0,
			string picture1,
			string pictureList,
			string saleTime,
			string saleAddress,
			bool hasContract,
			long provinceID,
			long cityID,
			long areaID,
			string province,
			string city,
			string area,
			bool isHidden,
			bool isRecommend,
			int sequence,
			int visitCount,
			int checkState,
			DateTime createTime,
			DateTime modifyTime
	)
	{
		_ID                = iD;
			_ShopID            = shopID;
			_CorpID            = corpID;
			_CorpUserID        = corpUserID;
			_CategoryID        = categoryID;
			_Stock             = stock;
			_SaleOut           = saleOut;
			_Name              = name;
			_Summary           = summary;
			_Keywords          = keywords;
			_Content           = content;
			_Price             = price;
			_ReturnPrecent     = returnPrecent;
			_UsePriceForReturn = usePriceForReturn;
			_FloatPrice        = floatPrice;
			_Picture0          = picture0;
			_Picture1          = picture1;
			_PictureList       = pictureList;
			_SaleTime          = saleTime;
			_SaleAddress       = saleAddress;
			_HasContract       = hasContract;
			_ProvinceID        = provinceID;
			_CityID            = cityID;
			_AreaID            = areaID;
			_Province          = province;
			_City              = city;
			_Area              = area;
			_IsHidden          = isHidden;
			_IsRecommend       = isRecommend;
			_Sequence          = sequence;
			_VisitCount        = visitCount;
			_CheckState        = checkState;
			_CreateTime        = createTime;
			_ModifyTime        = modifyTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long ShopID { set{ _ShopID = value; } get{ return _ShopID; }}
	public long CorpID { set{ _CorpID = value; } get{ return _CorpID; }}
	public long CorpUserID { set{ _CorpUserID = value; } get{ return _CorpUserID; }}
	public long CategoryID { set{ _CategoryID = value; } get{ return _CategoryID; }}
	public int Stock { set{ _Stock = value; } get{ return _Stock; }}
	public int SaleOut { set{ _SaleOut = value; } get{ return _SaleOut; }}
	public string Name { set{ _Name = value; } get{ return _Name; }}
	public string Summary { set{ _Summary = value; } get{ return _Summary; }}
	public string Keywords { set{ _Keywords = value; } get{ return _Keywords; }}
	public string Content { set{ _Content = value; } get{ return _Content; }}
	public decimal Price { set{ _Price = value; } get{ return _Price; }}
	public int ReturnPrecent { set{ _ReturnPrecent = value; } get{ return _ReturnPrecent; }}
	public bool UsePriceForReturn { set{ _UsePriceForReturn = value; } get{ return _UsePriceForReturn; }}
	public string FloatPrice { set{ _FloatPrice = value; } get{ return _FloatPrice; }}
	public string Picture0 { set{ _Picture0 = value; } get{ return _Picture0; }}
	public string Picture1 { set{ _Picture1 = value; } get{ return _Picture1; }}
	public string PictureList { set{ _PictureList = value; } get{ return _PictureList; }}
	public string SaleTime { set{ _SaleTime = value; } get{ return _SaleTime; }}
	public string SaleAddress { set{ _SaleAddress = value; } get{ return _SaleAddress; }}
	public bool HasContract { set{ _HasContract = value; } get{ return _HasContract; }}
	public long ProvinceID { set{ _ProvinceID = value; } get{ return _ProvinceID; }}
	public long CityID { set{ _CityID = value; } get{ return _CityID; }}
	public long AreaID { set{ _AreaID = value; } get{ return _AreaID; }}
	public string Province { set{ _Province = value; } get{ return _Province; }}
	public string City { set{ _City = value; } get{ return _City; }}
	public string Area { set{ _Area = value; } get{ return _Area; }}
	public bool IsHidden { set{ _IsHidden = value; } get{ return _IsHidden; }}
	public bool IsRecommend { set{ _IsRecommend = value; } get{ return _IsRecommend; }}
	public int Sequence { set{ _Sequence = value; } get{ return _Sequence; }}
	public int VisitCount { set{ _VisitCount = value; } get{ return _VisitCount; }}
	public int CheckState { set{ _CheckState = value; } get{ return _CheckState; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public DateTime ModifyTime { set{ _ModifyTime = value; } get{ return _ModifyTime; }}
}
}


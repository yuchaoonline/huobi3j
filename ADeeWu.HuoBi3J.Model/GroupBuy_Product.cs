
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class GroupBuy_Product{

	#region Fields
	private int _ID = 0;
	private string _Title = null;
	private string _Detail = null;
	private string _Remind = null;
	private string _Photo = null;
	private string _SellerIntro = null;
	private string _MapLocation = null;
	private long? _AreaID = null;
	private string _BusinessCircle = null;
	private string _Category = null;
	private int? _Summary = null;
	private decimal? _Price = null;
	private decimal? _MarketPrice = null;
	private int? _SaleDay = null;
	private DateTime? _CreateDate = null;
	private DateTime? _PassDate = null;
	private bool? _IsPass = null;
	private bool? _IsExpire = null;
	private int? _HotPlaceID = null;
	private int _CreateUserID = 0;
	private string _ProductIntro = null;
	private int _OrderCount = 0;
	private string _BuyLink = null;
	private int _SaleCount = 0;
	#endregion
	
	#region Contructors
	public GroupBuy_Product()
	{
	}
	
	public GroupBuy_Product
	(
		int iD,
			string title,
			string detail,
			string remind,
			string photo,
			string sellerIntro,
			string mapLocation,
			long areaID,
			string businessCircle,
			string category,
			int summary,
			decimal price,
			decimal marketPrice,
			int saleDay,
			DateTime createDate,
			DateTime passDate,
			bool isPass,
			bool isExpire,
			int hotPlaceID,
			int createUserID,
			string productIntro,
			int orderCount,
			string buyLink,
			int saleCount
	)
	{
		_ID             = iD;
			_Title          = title;
			_Detail         = detail;
			_Remind         = remind;
			_Photo          = photo;
			_SellerIntro    = sellerIntro;
			_MapLocation    = mapLocation;
			_AreaID         = areaID;
			_BusinessCircle = businessCircle;
			_Category       = category;
			_Summary        = summary;
			_Price          = price;
			_MarketPrice    = marketPrice;
			_SaleDay        = saleDay;
			_CreateDate     = createDate;
			_PassDate       = passDate;
			_IsPass         = isPass;
			_IsExpire       = isExpire;
			_HotPlaceID     = hotPlaceID;
			_CreateUserID   = createUserID;
			_ProductIntro   = productIntro;
			_OrderCount     = orderCount;
			_BuyLink        = buyLink;
			_SaleCount      = saleCount;
			
	}
	#endregion
		
	public int ID { set{ _ID = value; } get{ return _ID; }}
	public string Title { set{ _Title = value; } get{ return _Title; }}
	public string Detail { set{ _Detail = value; } get{ return _Detail; }}
	public string Remind { set{ _Remind = value; } get{ return _Remind; }}
	public string Photo { set{ _Photo = value; } get{ return _Photo; }}
	public string SellerIntro { set{ _SellerIntro = value; } get{ return _SellerIntro; }}
	public string MapLocation { set{ _MapLocation = value; } get{ return _MapLocation; }}
	public long? AreaID { set{ _AreaID = value; } get{ return _AreaID; }}
	public string BusinessCircle { set{ _BusinessCircle = value; } get{ return _BusinessCircle; }}
	public string Category { set{ _Category = value; } get{ return _Category; }}
	public int? Summary { set{ _Summary = value; } get{ return _Summary; }}
	public decimal? Price { set{ _Price = value; } get{ return _Price; }}
	public decimal? MarketPrice { set{ _MarketPrice = value; } get{ return _MarketPrice; }}
	public int? SaleDay { set{ _SaleDay = value; } get{ return _SaleDay; }}
	public DateTime? CreateDate { set{ _CreateDate = value; } get{ return _CreateDate; }}
	public DateTime? PassDate { set{ _PassDate = value; } get{ return _PassDate; }}
	public bool? IsPass { set{ _IsPass = value; } get{ return _IsPass; }}
	public bool? IsExpire { set{ _IsExpire = value; } get{ return _IsExpire; }}
	public int? HotPlaceID { set{ _HotPlaceID = value; } get{ return _HotPlaceID; }}
	public int CreateUserID { set{ _CreateUserID = value; } get{ return _CreateUserID; }}
	public string ProductIntro { set{ _ProductIntro = value; } get{ return _ProductIntro; }}
	public int OrderCount { set{ _OrderCount = value; } get{ return _OrderCount; }}
	public string BuyLink { set{ _BuyLink = value; } get{ return _BuyLink; }}
	public int SaleCount { set{ _SaleCount = value; } get{ return _SaleCount; }}
}
}


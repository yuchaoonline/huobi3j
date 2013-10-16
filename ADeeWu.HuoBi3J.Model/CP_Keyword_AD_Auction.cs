
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class CP_Keyword_AD_Auction{

	#region Fields
	private long _ID = 0L;
	private long? _Keyword_AD_ID = null;
	private decimal? _ClickPrice = null;
	private long? _UserID = null;
	private long? _KeywordID = null;
	private decimal? _TotalPrice = null;
	private long? _ProvinceID = null;
	private long? _CityID = null;
	private long? _AreaID = null;
	private decimal? _TotalPriceDay = null;
	private bool? _IsPause = null;
	#endregion
	
	#region Contructors
	public CP_Keyword_AD_Auction()
	{
	}
	
	public CP_Keyword_AD_Auction
	(
		long iD,
			long keyword_AD_ID,
			decimal clickPrice,
			long userID,
			long keywordID,
			decimal totalPrice,
			long provinceID,
			long cityID,
			long areaID,
			decimal totalPriceDay,
			bool isPause
	)
	{
		_ID            = iD;
			_Keyword_AD_ID = keyword_AD_ID;
			_ClickPrice    = clickPrice;
			_UserID        = userID;
			_KeywordID     = keywordID;
			_TotalPrice    = totalPrice;
			_ProvinceID    = provinceID;
			_CityID        = cityID;
			_AreaID        = areaID;
			_TotalPriceDay = totalPriceDay;
			_IsPause       = isPause;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long? Keyword_AD_ID { set{ _Keyword_AD_ID = value; } get{ return _Keyword_AD_ID; }}
	public decimal? ClickPrice { set{ _ClickPrice = value; } get{ return _ClickPrice; }}
	public long? UserID { set{ _UserID = value; } get{ return _UserID; }}
	public long? KeywordID { set{ _KeywordID = value; } get{ return _KeywordID; }}
	public decimal? TotalPrice { set{ _TotalPrice = value; } get{ return _TotalPrice; }}
	public long? ProvinceID { set{ _ProvinceID = value; } get{ return _ProvinceID; }}
	public long? CityID { set{ _CityID = value; } get{ return _CityID; }}
	public long? AreaID { set{ _AreaID = value; } get{ return _AreaID; }}
	public decimal? TotalPriceDay { set{ _TotalPriceDay = value; } get{ return _TotalPriceDay; }}
	public bool? IsPause { set{ _IsPause = value; } get{ return _IsPause; }}
}
}


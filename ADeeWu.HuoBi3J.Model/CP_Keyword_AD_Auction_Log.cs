
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class CP_Keyword_AD_Auction_Log{

	#region Fields
	private long _ID = 0L;
	private long? _Keyword_AD_ID = null;
	private long? _Keyword_Auction_ID = null;
	private decimal? _ClickPrice = null;
	private decimal? _CostMoney = null;
	private DateTime? _CreateTime = null;
	#endregion
	
	#region Contructors
	public CP_Keyword_AD_Auction_Log()
	{
	}
	
	public CP_Keyword_AD_Auction_Log
	(
		long iD,
			long keyword_AD_ID,
			long keyword_Auction_ID,
			decimal clickPrice,
			decimal costMoney,
			DateTime createTime
	)
	{
		_ID                 = iD;
			_Keyword_AD_ID      = keyword_AD_ID;
			_Keyword_Auction_ID = keyword_Auction_ID;
			_ClickPrice         = clickPrice;
			_CostMoney          = costMoney;
			_CreateTime         = createTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long? Keyword_AD_ID { set{ _Keyword_AD_ID = value; } get{ return _Keyword_AD_ID; }}
	public long? Keyword_Auction_ID { set{ _Keyword_Auction_ID = value; } get{ return _Keyword_Auction_ID; }}
	public decimal? ClickPrice { set{ _ClickPrice = value; } get{ return _ClickPrice; }}
	public decimal? CostMoney { set{ _CostMoney = value; } get{ return _CostMoney; }}
	public DateTime? CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
}
}


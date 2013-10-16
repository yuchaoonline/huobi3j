
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class CP_Keyword_AD_Log{

	#region Fields
	private long _ID = 0L;
	private string _ClickIP = null;
	private decimal? _ClickPrice = null;
	private long? _ADID = null;
	private long? _KeywordID = null;
	private DateTime? _CreateTime = null;
	#endregion
	
	#region Contructors
	public CP_Keyword_AD_Log()
	{
	}
	
	public CP_Keyword_AD_Log
	(
		long iD,
			string clickIP,
			decimal clickPrice,
			long aDID,
			long keywordID,
			DateTime createTime
	)
	{
		_ID         = iD;
			_ClickIP    = clickIP;
			_ClickPrice = clickPrice;
			_ADID       = aDID;
			_KeywordID  = keywordID;
			_CreateTime = createTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public string ClickIP { set{ _ClickIP = value; } get{ return _ClickIP; }}
	public decimal? ClickPrice { set{ _ClickPrice = value; } get{ return _ClickPrice; }}
	public long? ADID { set{ _ADID = value; } get{ return _ADID; }}
	public long? KeywordID { set{ _KeywordID = value; } get{ return _KeywordID; }}
	public DateTime? CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
}
}


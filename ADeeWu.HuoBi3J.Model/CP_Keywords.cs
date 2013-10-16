
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class CP_Keywords{

	#region Fields
	private long _ID = 0L;
	private long _UserID = 0L;
	private long _PromotionID = 0L;
	private string _Keyword = String.Empty;
	private int _Coins = 0;
	private int _VisitCount = 0;
	private int _CheckState = 0;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	private DateTime _ModifyTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public CP_Keywords()
	{
	}
	
	public CP_Keywords
	(
		long iD,
			long userID,
			long promotionID,
			string keyword,
			int coins,
			int visitCount,
			int checkState,
			DateTime createTime,
			DateTime modifyTime
	)
	{
		_ID          = iD;
			_UserID      = userID;
			_PromotionID = promotionID;
			_Keyword     = keyword;
			_Coins       = coins;
			_VisitCount  = visitCount;
			_CheckState  = checkState;
			_CreateTime  = createTime;
			_ModifyTime  = modifyTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long UserID { set{ _UserID = value; } get{ return _UserID; }}
	public long PromotionID { set{ _PromotionID = value; } get{ return _PromotionID; }}
	public string Keyword { set{ _Keyword = value; } get{ return _Keyword; }}
	public int Coins { set{ _Coins = value; } get{ return _Coins; }}
	public int VisitCount { set{ _VisitCount = value; } get{ return _VisitCount; }}
	public int CheckState { set{ _CheckState = value; } get{ return _CheckState; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public DateTime ModifyTime { set{ _ModifyTime = value; } get{ return _ModifyTime; }}
}
}


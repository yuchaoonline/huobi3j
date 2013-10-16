
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Forum_AuctionLog{

	#region Fields
	private long _ID = 0L;
	private long? _AuctionID = null;
	private long? _UserID = null;
	private DateTime? _DateTime = null;
	private int? _Score = null;
	private bool? _IsWin = null;
	#endregion
	
	#region Contructors
	public Forum_AuctionLog()
	{
	}
	
	public Forum_AuctionLog
	(
		long iD,
			long auctionID,
			long userID,
			DateTime dateTime,
			int score,
			bool isWin
	)
	{
		_ID        = iD;
			_AuctionID = auctionID;
			_UserID    = userID;
			_DateTime  = dateTime;
			_Score     = score;
			_IsWin     = isWin;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long? AuctionID { set{ _AuctionID = value; } get{ return _AuctionID; }}
	public long? UserID { set{ _UserID = value; } get{ return _UserID; }}
	public DateTime? DateTime { set{ _DateTime = value; } get{ return _DateTime; }}
	public int? Score { set{ _Score = value; } get{ return _Score; }}
	public bool? IsWin { set{ _IsWin = value; } get{ return _IsWin; }}
}
}


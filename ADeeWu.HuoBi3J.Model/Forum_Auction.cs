
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Forum_Auction{

	#region Fields
	private long _ID = 0L;
	private int? _Money = null;
	private int? _Score = null;
	private int? _JoinCount = null;
	private DateTime? _StartTime = null;
	private DateTime? _EndTime = null;
	private long? _OwnerID = null;
	private string _Content = null;
	private string _Title = null;
	private bool? _IsPay = null;
	#endregion
	
	#region Contructors
	public Forum_Auction()
	{
	}
	
	public Forum_Auction
	(
		long iD,
			int money,
			int score,
			int joinCount,
			DateTime startTime,
			DateTime endTime,
			long ownerID,
			string content,
			string title,
			bool isPay
	)
	{
		_ID        = iD;
			_Money     = money;
			_Score     = score;
			_JoinCount = joinCount;
			_StartTime = startTime;
			_EndTime   = endTime;
			_OwnerID   = ownerID;
			_Content   = content;
			_Title     = title;
			_IsPay     = isPay;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public int? Money { set{ _Money = value; } get{ return _Money; }}
	public int? Score { set{ _Score = value; } get{ return _Score; }}
	public int? JoinCount { set{ _JoinCount = value; } get{ return _JoinCount; }}
	public DateTime? StartTime { set{ _StartTime = value; } get{ return _StartTime; }}
	public DateTime? EndTime { set{ _EndTime = value; } get{ return _EndTime; }}
	public long? OwnerID { set{ _OwnerID = value; } get{ return _OwnerID; }}
	public string Content { set{ _Content = value; } get{ return _Content; }}
	public string Title { set{ _Title = value; } get{ return _Title; }}
	public bool? IsPay { set{ _IsPay = value; } get{ return _IsPay; }}
}
}



using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class IM_FriendApps{

	#region Fields
	private long _ID = 0L;
	private long _FromUserID = 0L;
	private string _FromUIN = String.Empty;
	private long _ToUserID = 0L;
	private string _ToUIN = String.Empty;
	private string _Message = String.Empty;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public IM_FriendApps()
	{
	}
	
	public IM_FriendApps
	(
		long iD,
			long fromUserID,
			string fromUIN,
			long toUserID,
			string toUIN,
			string message,
			DateTime createTime
	)
	{
		_ID         = iD;
			_FromUserID = fromUserID;
			_FromUIN    = fromUIN;
			_ToUserID   = toUserID;
			_ToUIN      = toUIN;
			_Message    = message;
			_CreateTime = createTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long FromUserID { set{ _FromUserID = value; } get{ return _FromUserID; }}
	public string FromUIN { set{ _FromUIN = value; } get{ return _FromUIN; }}
	public long ToUserID { set{ _ToUserID = value; } get{ return _ToUserID; }}
	public string ToUIN { set{ _ToUIN = value; } get{ return _ToUIN; }}
	public string Message { set{ _Message = value; } get{ return _Message; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
}
}


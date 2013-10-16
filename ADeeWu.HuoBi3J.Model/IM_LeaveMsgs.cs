
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class IM_LeaveMsgs{

	#region Fields
	private long _ID = 0L;
	private string _FromUIN = String.Empty;
	private long _FromUserID = 0L;
	private string _ToUIN = String.Empty;
	private long _ToUserID = 0L;
	private string _Content = String.Empty;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public IM_LeaveMsgs()
	{
	}
	
	public IM_LeaveMsgs
	(
		long iD,
			string fromUIN,
			long fromUserID,
			string toUIN,
			long toUserID,
			string content,
			DateTime createTime
	)
	{
		_ID         = iD;
			_FromUIN    = fromUIN;
			_FromUserID = fromUserID;
			_ToUIN      = toUIN;
			_ToUserID   = toUserID;
			_Content    = content;
			_CreateTime = createTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public string FromUIN { set{ _FromUIN = value; } get{ return _FromUIN; }}
	public long FromUserID { set{ _FromUserID = value; } get{ return _FromUserID; }}
	public string ToUIN { set{ _ToUIN = value; } get{ return _ToUIN; }}
	public long ToUserID { set{ _ToUserID = value; } get{ return _ToUserID; }}
	public string Content { set{ _Content = value; } get{ return _Content; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
}
}


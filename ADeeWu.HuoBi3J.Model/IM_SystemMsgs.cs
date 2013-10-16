
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class IM_SystemMsgs{

	#region Fields
	private long _ID = 0L;
	private string _Title = String.Empty;
	private string _Content = String.Empty;
	private string _ToUIN = String.Empty;
	private long _ToUserID = 0L;
	private string _MessageName = String.Empty;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public IM_SystemMsgs()
	{
	}
	
	public IM_SystemMsgs
	(
		long iD,
			string title,
			string content,
			string toUIN,
			long toUserID,
			string messageName,
			DateTime createTime
	)
	{
		_ID          = iD;
			_Title       = title;
			_Content     = content;
			_ToUIN       = toUIN;
			_ToUserID    = toUserID;
			_MessageName = messageName;
			_CreateTime  = createTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public string Title { set{ _Title = value; } get{ return _Title; }}
	public string Content { set{ _Content = value; } get{ return _Content; }}
	public string ToUIN { set{ _ToUIN = value; } get{ return _ToUIN; }}
	public long ToUserID { set{ _ToUserID = value; } get{ return _ToUserID; }}
	public string MessageName { set{ _MessageName = value; } get{ return _MessageName; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
}
}


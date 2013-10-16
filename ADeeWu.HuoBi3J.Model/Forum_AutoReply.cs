
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Forum_AutoReply{

	#region Fields
	private long _ID = 0L;
	private long? _UserID = null;
	private string _Content = null;
	private DateTime? _CreateTime = null;
	#endregion
	
	#region Contructors
	public Forum_AutoReply()
	{
	}
	
	public Forum_AutoReply
	(
		long iD,
			long userID,
			string content,
			DateTime createTime
	)
	{
		_ID         = iD;
			_UserID     = userID;
			_Content    = content;
			_CreateTime = createTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long? UserID { set{ _UserID = value; } get{ return _UserID; }}
	public string Content { set{ _Content = value; } get{ return _Content; }}
	public DateTime? CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
}
}


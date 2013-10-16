
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class AttentionQuestion{

	#region Fields
	private long _ID = 0L;
	private long? _UID = null;
	private long? _QID = null;
	private bool? _IsRead = null;
	private DateTime? _CreateTime = null;
	private bool? _IsReply = null;
	#endregion
	
	#region Contructors
	public AttentionQuestion()
	{
	}
	
	public AttentionQuestion
	(
		long iD,
			long uID,
			long qID,
			bool isRead,
			DateTime createTime,
			bool isReply
	)
	{
		_ID         = iD;
			_UID        = uID;
			_QID        = qID;
			_IsRead     = isRead;
			_CreateTime = createTime;
			_IsReply    = isReply;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long? UID { set{ _UID = value; } get{ return _UID; }}
	public long? QID { set{ _QID = value; } get{ return _QID; }}
	public bool? IsRead { set{ _IsRead = value; } get{ return _IsRead; }}
	public DateTime? CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public bool? IsReply { set{ _IsReply = value; } get{ return _IsReply; }}
}
}


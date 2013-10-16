
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class UserKey{

	#region Fields
	private long _UKID = 0L;
	private long? _KID = null;
	private long? _UID = null;
	private DateTime? _CreateTime = null;
	private bool _IsGoOn = false;
	#endregion
	
	#region Contructors
	public UserKey()
	{
	}
	
	public UserKey
	(
		long uKID,
			long kID,
			long uID,
			DateTime createTime,
			bool isGoOn
	)
	{
		_UKID       = uKID;
			_KID        = kID;
			_UID        = uID;
			_CreateTime = createTime;
			_IsGoOn     = isGoOn;
			
	}
	#endregion
		
	public long UKID { set{ _UKID = value; } get{ return _UKID; }}
	public long? KID { set{ _KID = value; } get{ return _KID; }}
	public long? UID { set{ _UID = value; } get{ return _UID; }}
	public DateTime? CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public bool IsGoOn { set{ _IsGoOn = value; } get{ return _IsGoOn; }}
}
}


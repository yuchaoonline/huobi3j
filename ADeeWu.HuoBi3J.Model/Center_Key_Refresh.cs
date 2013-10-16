
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Center_Key_Refresh{

	#region Fields
	private long _ID = 0L;
	private long? _KID = null;
	private long? _UID = null;
	private DateTime? _LastTime = null;
	#endregion
	
	#region Contructors
	public Center_Key_Refresh()
	{
	}
	
	public Center_Key_Refresh
	(
		long iD,
			long kID,
			long uID,
			DateTime lastTime
	)
	{
		_ID       = iD;
			_KID      = kID;
			_UID      = uID;
			_LastTime = lastTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long? KID { set{ _KID = value; } get{ return _KID; }}
	public long? UID { set{ _UID = value; } get{ return _UID; }}
	public DateTime? LastTime { set{ _LastTime = value; } get{ return _LastTime; }}
}
}


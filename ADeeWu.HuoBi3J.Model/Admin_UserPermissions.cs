
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Admin_UserPermissions{

	#region Fields
	private long _ID = 0L;
	private long? _PageID = null;
	private long? _AdminID = null;
	private int _CheckState = 0;
	#endregion
	
	#region Contructors
	public Admin_UserPermissions()
	{
	}
	
	public Admin_UserPermissions
	(
		long iD,
			long pageID,
			long adminID,
			int checkState
	)
	{
		_ID         = iD;
			_PageID     = pageID;
			_AdminID    = adminID;
			_CheckState = checkState;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long? PageID { set{ _PageID = value; } get{ return _PageID; }}
	public long? AdminID { set{ _AdminID = value; } get{ return _AdminID; }}
	public int CheckState { set{ _CheckState = value; } get{ return _CheckState; }}
}
}



using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Admin_RolePermissions{

	#region Fields
	private long _ID = 0L;
	private long? _RoleID = null;
	private long? _PageID = null;
	private int _CheckState = 0;
	#endregion
	
	#region Contructors
	public Admin_RolePermissions()
	{
	}
	
	public Admin_RolePermissions
	(
		long iD,
			long roleID,
			long pageID,
			int checkState
	)
	{
		_ID         = iD;
			_RoleID     = roleID;
			_PageID     = pageID;
			_CheckState = checkState;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long? RoleID { set{ _RoleID = value; } get{ return _RoleID; }}
	public long? PageID { set{ _PageID = value; } get{ return _PageID; }}
	public int CheckState { set{ _CheckState = value; } get{ return _CheckState; }}
}
}


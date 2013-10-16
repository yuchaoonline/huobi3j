
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Admin_UserInRoles{

	#region Fields
	private long _ID = 0L;
	private long? _RoleID = null;
	private long? _AdminID = null;
	#endregion
	
	#region Contructors
	public Admin_UserInRoles()
	{
	}
	
	public Admin_UserInRoles
	(
		long iD,
			long roleID,
			long adminID
	)
	{
		_ID      = iD;
			_RoleID  = roleID;
			_AdminID = adminID;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long? RoleID { set{ _RoleID = value; } get{ return _RoleID; }}
	public long? AdminID { set{ _AdminID = value; } get{ return _AdminID; }}
}
}



using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class CA_RolePermissions{

	#region Fields
	private long _ID = 0L;
	private long _ManagerCorpID = 0L;
	private long? _RoleID = null;
	private long? _FunctionID = null;
	private int _AuthorizeState = 0;
	#endregion
	
	#region Contructors
	public CA_RolePermissions()
	{
	}
	
	public CA_RolePermissions
	(
		long iD,
			long managerCorpID,
			long roleID,
			long functionID,
			int authorizeState
	)
	{
		_ID             = iD;
			_ManagerCorpID  = managerCorpID;
			_RoleID         = roleID;
			_FunctionID     = functionID;
			_AuthorizeState = authorizeState;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long ManagerCorpID { set{ _ManagerCorpID = value; } get{ return _ManagerCorpID; }}
	public long? RoleID { set{ _RoleID = value; } get{ return _RoleID; }}
	public long? FunctionID { set{ _FunctionID = value; } get{ return _FunctionID; }}
	public int AuthorizeState { set{ _AuthorizeState = value; } get{ return _AuthorizeState; }}
}
}



using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Admin_Roles{

	#region Fields
	private long _ID = 0L;
	private string _RoleName = String.Empty;
	private string _Description = String.Empty;
	#endregion
	
	#region Contructors
	public Admin_Roles()
	{
	}
	
	public Admin_Roles
	(
		long iD,
			string roleName,
			string description
	)
	{
		_ID          = iD;
			_RoleName    = roleName;
			_Description = description;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public string RoleName { set{ _RoleName = value; } get{ return _RoleName; }}
	public string Description { set{ _Description = value; } get{ return _Description; }}
}
}


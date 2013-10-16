
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class CA_Roles{

	#region Fields
	private long _ID = 0L;
	private long _ManagerCorpID = 0L;
	private string _RoleName = String.Empty;
	private string _Description = String.Empty;
	#endregion
	
	#region Contructors
	public CA_Roles()
	{
	}
	
	public CA_Roles
	(
		long iD,
			long managerCorpID,
			string roleName,
			string description
	)
	{
		_ID            = iD;
			_ManagerCorpID = managerCorpID;
			_RoleName      = roleName;
			_Description   = description;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long ManagerCorpID { set{ _ManagerCorpID = value; } get{ return _ManagerCorpID; }}
	public string RoleName { set{ _RoleName = value; } get{ return _RoleName; }}
	public string Description { set{ _Description = value; } get{ return _Description; }}
}
}


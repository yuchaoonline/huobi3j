
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class CA_UserPermissions{

	#region Fields
	private long _ID = 0L;
	private long? _CorpAgentID = null;
	private long? _PageID = null;
	private long _UserID = 0L;
	private int _AuthorizeState = 0;
	private long _ManagerCorpID = 0L;
	#endregion
	
	#region Contructors
	public CA_UserPermissions()
	{
	}
	
	public CA_UserPermissions
	(
		long iD,
			long corpAgentID,
			long pageID,
			long userID,
			int authorizeState,
			long managerCorpID
	)
	{
		_ID             = iD;
			_CorpAgentID    = corpAgentID;
			_PageID         = pageID;
			_UserID         = userID;
			_AuthorizeState = authorizeState;
			_ManagerCorpID  = managerCorpID;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long? CorpAgentID { set{ _CorpAgentID = value; } get{ return _CorpAgentID; }}
	public long? PageID { set{ _PageID = value; } get{ return _PageID; }}
	public long UserID { set{ _UserID = value; } get{ return _UserID; }}
	public int AuthorizeState { set{ _AuthorizeState = value; } get{ return _AuthorizeState; }}
	public long ManagerCorpID { set{ _ManagerCorpID = value; } get{ return _ManagerCorpID; }}
}
}


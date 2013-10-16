
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class CorpAgents{

	#region Fields
	private long _ID = 0L;
	private long _AgentCorpID = 0L;
	private long _RoleID = 0L;
	private long _UserID = 0L;
	private long _ManageProvinceID = 0L;
	private long _ManageCityID = 0L;
	private long _ManageAreaID = 0L;
	private int _CheckState = 0;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	private DateTime _ModifyTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public CorpAgents()
	{
	}
	
	public CorpAgents
	(
		long iD,
			long agentCorpID,
			long roleID,
			long userID,
			long manageProvinceID,
			long manageCityID,
			long manageAreaID,
			int checkState,
			DateTime createTime,
			DateTime modifyTime
	)
	{
		_ID               = iD;
			_AgentCorpID      = agentCorpID;
			_RoleID           = roleID;
			_UserID           = userID;
			_ManageProvinceID = manageProvinceID;
			_ManageCityID     = manageCityID;
			_ManageAreaID     = manageAreaID;
			_CheckState       = checkState;
			_CreateTime       = createTime;
			_ModifyTime       = modifyTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long AgentCorpID { set{ _AgentCorpID = value; } get{ return _AgentCorpID; }}
	public long RoleID { set{ _RoleID = value; } get{ return _RoleID; }}
	public long UserID { set{ _UserID = value; } get{ return _UserID; }}
	public long ManageProvinceID { set{ _ManageProvinceID = value; } get{ return _ManageProvinceID; }}
	public long ManageCityID { set{ _ManageCityID = value; } get{ return _ManageCityID; }}
	public long ManageAreaID { set{ _ManageAreaID = value; } get{ return _ManageAreaID; }}
	public int CheckState { set{ _CheckState = value; } get{ return _CheckState; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public DateTime ModifyTime { set{ _ModifyTime = value; } get{ return _ModifyTime; }}
}
}


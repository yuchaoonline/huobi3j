
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class CA_QuaAgentInCorps{

	#region Fields
	private long _ID = 0L;
	private long _UserID = 0L;
	private long _CorpID = 0L;
	private int _CheckState = 0;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	private DateTime _ModifyTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public CA_QuaAgentInCorps()
	{
	}
	
	public CA_QuaAgentInCorps
	(
		long iD,
			long userID,
			long corpID,
			int checkState,
			DateTime createTime,
			DateTime modifyTime
	)
	{
		_ID         = iD;
			_UserID     = userID;
			_CorpID     = corpID;
			_CheckState = checkState;
			_CreateTime = createTime;
			_ModifyTime = modifyTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long UserID { set{ _UserID = value; } get{ return _UserID; }}
	public long CorpID { set{ _CorpID = value; } get{ return _CorpID; }}
	public int CheckState { set{ _CheckState = value; } get{ return _CheckState; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public DateTime ModifyTime { set{ _ModifyTime = value; } get{ return _ModifyTime; }}
}
}


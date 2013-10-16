
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class CA_QualifiedAgentBusiness{

	#region Fields
	private long _ID = 0L;
	private long _AgentUserID = 0L;
	private long _CustomerCorpID = 0L;
	private long _CustomerUserID = 0L;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	private DateTime? _ModifyTime = null;
	#endregion
	
	#region Contructors
	public CA_QualifiedAgentBusiness()
	{
	}
	
	public CA_QualifiedAgentBusiness
	(
		long iD,
			long agentUserID,
			long customerCorpID,
			long customerUserID,
			DateTime createTime,
			DateTime modifyTime
	)
	{
		_ID             = iD;
			_AgentUserID    = agentUserID;
			_CustomerCorpID = customerCorpID;
			_CustomerUserID = customerUserID;
			_CreateTime     = createTime;
			_ModifyTime     = modifyTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long AgentUserID { set{ _AgentUserID = value; } get{ return _AgentUserID; }}
	public long CustomerCorpID { set{ _CustomerCorpID = value; } get{ return _CustomerCorpID; }}
	public long CustomerUserID { set{ _CustomerUserID = value; } get{ return _CustomerUserID; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public DateTime? ModifyTime { set{ _ModifyTime = value; } get{ return _ModifyTime; }}
}
}


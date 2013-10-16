
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Forum_CoinLog{

	#region Fields
	private long _ID = 0L;
	private long? _CustomerUserID = null;
	private long? _AgentUserID = null;
	private int? _Score = null;
	private DateTime? _CreateTime = null;
	#endregion
	
	#region Contructors
	public Forum_CoinLog()
	{
	}
	
	public Forum_CoinLog
	(
		long iD,
			long customerUserID,
			long agentUserID,
			int score,
			DateTime createTime
	)
	{
		_ID             = iD;
			_CustomerUserID = customerUserID;
			_AgentUserID    = agentUserID;
			_Score          = score;
			_CreateTime     = createTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long? CustomerUserID { set{ _CustomerUserID = value; } get{ return _CustomerUserID; }}
	public long? AgentUserID { set{ _AgentUserID = value; } get{ return _AgentUserID; }}
	public int? Score { set{ _Score = value; } get{ return _Score; }}
	public DateTime? CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
}
}


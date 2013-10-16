
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class CA_CorpAgentInCorps{

	#region Fields
	private long _ID = 0L;
	private long _CorpAgentID = 0L;
	private long _CorpID = 0L;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public CA_CorpAgentInCorps()
	{
	}
	
	public CA_CorpAgentInCorps
	(
		long iD,
			long corpAgentID,
			long corpID,
			DateTime createTime
	)
	{
		_ID          = iD;
			_CorpAgentID = corpAgentID;
			_CorpID      = corpID;
			_CreateTime  = createTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long CorpAgentID { set{ _CorpAgentID = value; } get{ return _CorpAgentID; }}
	public long CorpID { set{ _CorpID = value; } get{ return _CorpID; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
}
}


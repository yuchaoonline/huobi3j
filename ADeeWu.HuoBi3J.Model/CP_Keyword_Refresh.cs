
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class CP_Keyword_Refresh{

	#region Fields
	private long _ID = 0L;
	private long? _KeywordID = null;
	private DateTime? _LastTime = null;
	#endregion
	
	#region Contructors
	public CP_Keyword_Refresh()
	{
	}
	
	public CP_Keyword_Refresh
	(
		long iD,
			long keywordID,
			DateTime lastTime
	)
	{
		_ID        = iD;
			_KeywordID = keywordID;
			_LastTime  = lastTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long? KeywordID { set{ _KeywordID = value; } get{ return _KeywordID; }}
	public DateTime? LastTime { set{ _LastTime = value; } get{ return _LastTime; }}
}
}


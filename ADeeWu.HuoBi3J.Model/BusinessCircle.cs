
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class BusinessCircle{

	#region Fields
	private long _BID = 0L;
	private long? _AID = null;
	private string _BName = null;
	private DateTime? _CreateTime = null;
	#endregion
	
	#region Contructors
	public BusinessCircle()
	{
	}
	
	public BusinessCircle
	(
		long bID,
			long aID,
			string bName,
			DateTime createTime
	)
	{
		_BID        = bID;
			_AID        = aID;
			_BName      = bName;
			_CreateTime = createTime;
			
	}
	#endregion
		
	public long BID { set{ _BID = value; } get{ return _BID; }}
	public long? AID { set{ _AID = value; } get{ return _AID; }}
	public string BName { set{ _BName = value; } get{ return _BName; }}
	public DateTime? CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
}
}


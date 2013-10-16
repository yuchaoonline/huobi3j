
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Question{

	#region Fields
	private long _QID = 0L;
	private string _Title = null;
	private long? _KID = null;
	private long? _UID = null;
	private DateTime? _CreateTime = null;
	private long? _BID = null;
	private long? _AID = null;
	private long? _CID = null;
	private long? _PID = null;
	#endregion
	
	#region Contructors
	public Question()
	{
	}
	
	public Question
	(
		long qID,
			string title,
			long kID,
			long uID,
			DateTime createTime,
			long bID,
			long aID,
			long cID,
			long pID
	)
	{
		_QID        = qID;
			_Title      = title;
			_KID        = kID;
			_UID        = uID;
			_CreateTime = createTime;
			_BID        = bID;
			_AID        = aID;
			_CID        = cID;
			_PID        = pID;
			
	}
	#endregion
		
	public long QID { set{ _QID = value; } get{ return _QID; }}
	public string Title { set{ _Title = value; } get{ return _Title; }}
	public long? KID { set{ _KID = value; } get{ return _KID; }}
	public long? UID { set{ _UID = value; } get{ return _UID; }}
	public DateTime? CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public long? BID { set{ _BID = value; } get{ return _BID; }}
	public long? AID { set{ _AID = value; } get{ return _AID; }}
	public long? CID { set{ _CID = value; } get{ return _CID; }}
	public long? PID { set{ _PID = value; } get{ return _PID; }}
}
}


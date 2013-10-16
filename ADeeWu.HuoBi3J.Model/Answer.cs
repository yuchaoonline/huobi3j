
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Answer{

	#region Fields
	private long _AID = 0L;
	private string _Content = null;
	private long? _QID = null;
	private long? _UID = null;
	private DateTime? _CreateTime = null;
	#endregion
	
	#region Contructors
	public Answer()
	{
	}
	
	public Answer
	(
		long aID,
			string content,
			long qID,
			long uID,
			DateTime createTime
	)
	{
		_AID        = aID;
			_Content    = content;
			_QID        = qID;
			_UID        = uID;
			_CreateTime = createTime;
			
	}
	#endregion
		
	public long AID { set{ _AID = value; } get{ return _AID; }}
	public string Content { set{ _Content = value; } get{ return _Content; }}
	public long? QID { set{ _QID = value; } get{ return _QID; }}
	public long? UID { set{ _UID = value; } get{ return _UID; }}
	public DateTime? CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
}
}


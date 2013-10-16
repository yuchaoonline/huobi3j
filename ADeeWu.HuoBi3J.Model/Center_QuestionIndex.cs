
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Center_QuestionIndex{

	#region Fields
	private long _ID = 0L;
	private long? _QID = null;
	private DateTime? _CreateTime = null;
	#endregion
	
	#region Contructors
	public Center_QuestionIndex()
	{
	}
	
	public Center_QuestionIndex
	(
		long iD,
			long qID,
			DateTime createTime
	)
	{
		_ID         = iD;
			_QID        = qID;
			_CreateTime = createTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long? QID { set{ _QID = value; } get{ return _QID; }}
	public DateTime? CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
}
}


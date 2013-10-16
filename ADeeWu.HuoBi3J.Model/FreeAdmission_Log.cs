
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class FreeAdmission_Log{

	#region Fields
	private int _ID = 0;
	private int? _UserID = null;
	private int? _FreeAdmissionID = null;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public FreeAdmission_Log()
	{
	}
	
	public FreeAdmission_Log
	(
		int iD,
			int userID,
			int freeAdmissionID,
			DateTime createTime
	)
	{
		_ID              = iD;
			_UserID          = userID;
			_FreeAdmissionID = freeAdmissionID;
			_CreateTime      = createTime;
			
	}
	#endregion
		
	public int ID { set{ _ID = value; } get{ return _ID; }}
	public int? UserID { set{ _UserID = value; } get{ return _UserID; }}
	public int? FreeAdmissionID { set{ _FreeAdmissionID = value; } get{ return _FreeAdmissionID; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
}
}


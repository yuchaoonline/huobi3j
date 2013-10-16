
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Forum_Users{

	#region Fields
	private long _ID = 0L;
	private long? _UserID = null;
	private DateTime? _CreateTime = null;
	private bool? _IsValid = null;
	private string _Mobile = null;
	#endregion
	
	#region Contructors
	public Forum_Users()
	{
	}
	
	public Forum_Users
	(
		long iD,
			long userID,
			DateTime createTime,
			bool isValid,
			string mobile
	)
	{
		_ID         = iD;
			_UserID     = userID;
			_CreateTime = createTime;
			_IsValid    = isValid;
			_Mobile     = mobile;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long? UserID { set{ _UserID = value; } get{ return _UserID; }}
	public DateTime? CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public bool? IsValid { set{ _IsValid = value; } get{ return _IsValid; }}
	public string Mobile { set{ _Mobile = value; } get{ return _Mobile; }}
}
}


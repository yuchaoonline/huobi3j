
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Forum_MyFans{

	#region Fields
	private long _ID = 0L;
	private long? _UserID = null;
	private long? _FansID = null;
	private DateTime? _CreateDate = null;
	#endregion
	
	#region Contructors
	public Forum_MyFans()
	{
	}
	
	public Forum_MyFans
	(
		long iD,
			long userID,
			long fansID,
			DateTime createDate
	)
	{
		_ID         = iD;
			_UserID     = userID;
			_FansID     = fansID;
			_CreateDate = createDate;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long? UserID { set{ _UserID = value; } get{ return _UserID; }}
	public long? FansID { set{ _FansID = value; } get{ return _FansID; }}
	public DateTime? CreateDate { set{ _CreateDate = value; } get{ return _CreateDate; }}
}
}



using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class IM_UserInGroups{

	#region Fields
	private long _ID = 0L;
	private string _MemberUIN = String.Empty;
	private long _MemberUserID = 0L;
	private string _GroupUIN = String.Empty;
	private long _GroupID = 0L;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public IM_UserInGroups()
	{
	}
	
	public IM_UserInGroups
	(
		long iD,
			string memberUIN,
			long memberUserID,
			string groupUIN,
			long groupID,
			DateTime createTime
	)
	{
		_ID           = iD;
			_MemberUIN    = memberUIN;
			_MemberUserID = memberUserID;
			_GroupUIN     = groupUIN;
			_GroupID      = groupID;
			_CreateTime   = createTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public string MemberUIN { set{ _MemberUIN = value; } get{ return _MemberUIN; }}
	public long MemberUserID { set{ _MemberUserID = value; } get{ return _MemberUserID; }}
	public string GroupUIN { set{ _GroupUIN = value; } get{ return _GroupUIN; }}
	public long GroupID { set{ _GroupID = value; } get{ return _GroupID; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
}
}


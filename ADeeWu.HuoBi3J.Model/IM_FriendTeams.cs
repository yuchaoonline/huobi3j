
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class IM_FriendTeams{

	#region Fields
	private long _ID = 0L;
	private long? _UserID = null;
	private string _UIN = String.Empty;
	private string _TeamName = String.Empty;
	private int _Sequence = 0;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public IM_FriendTeams()
	{
	}
	
	public IM_FriendTeams
	(
		long iD,
			long userID,
			string uIN,
			string teamName,
			int sequence,
			DateTime createTime
	)
	{
		_ID         = iD;
			_UserID     = userID;
			_UIN        = uIN;
			_TeamName   = teamName;
			_Sequence   = sequence;
			_CreateTime = createTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long? UserID { set{ _UserID = value; } get{ return _UserID; }}
	public string UIN { set{ _UIN = value; } get{ return _UIN; }}
	public string TeamName { set{ _TeamName = value; } get{ return _TeamName; }}
	public int Sequence { set{ _Sequence = value; } get{ return _Sequence; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
}
}


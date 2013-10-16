
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class IM_Friends{

	#region Fields
	private long _ID = 0L;
	private long _UserID = 0L;
	private string _UserUIN = String.Empty;
	private long _FriendUserID = 0L;
	private string _FriendUIN = String.Empty;
	private string _Alias = String.Empty;
	private int _CheckState = 0;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public IM_Friends()
	{
	}
	
	public IM_Friends
	(
		long iD,
			long userID,
			string userUIN,
			long friendUserID,
			string friendUIN,
			string alias,
			int checkState,
			DateTime createTime
	)
	{
		_ID           = iD;
			_UserID       = userID;
			_UserUIN      = userUIN;
			_FriendUserID = friendUserID;
			_FriendUIN    = friendUIN;
			_Alias        = alias;
			_CheckState   = checkState;
			_CreateTime   = createTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long UserID { set{ _UserID = value; } get{ return _UserID; }}
	public string UserUIN { set{ _UserUIN = value; } get{ return _UserUIN; }}
	public long FriendUserID { set{ _FriendUserID = value; } get{ return _FriendUserID; }}
	public string FriendUIN { set{ _FriendUIN = value; } get{ return _FriendUIN; }}
	public string Alias { set{ _Alias = value; } get{ return _Alias; }}
	public int CheckState { set{ _CheckState = value; } get{ return _CheckState; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
}
}


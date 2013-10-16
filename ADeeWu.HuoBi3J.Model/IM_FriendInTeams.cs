
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class IM_FriendInTeams{

	#region Fields
	private long _ID = 0L;
	private long _MeUserID = 0L;
	private string _MeUIN = String.Empty;
	private long _FriendUserID = 0L;
	private string _FriendUIN = String.Empty;
	private long _FriendTeamID = 0L;
	#endregion
	
	#region Contructors
	public IM_FriendInTeams()
	{
	}
	
	public IM_FriendInTeams
	(
		long iD,
			long meUserID,
			string meUIN,
			long friendUserID,
			string friendUIN,
			long friendTeamID
	)
	{
		_ID           = iD;
			_MeUserID     = meUserID;
			_MeUIN        = meUIN;
			_FriendUserID = friendUserID;
			_FriendUIN    = friendUIN;
			_FriendTeamID = friendTeamID;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long MeUserID { set{ _MeUserID = value; } get{ return _MeUserID; }}
	public string MeUIN { set{ _MeUIN = value; } get{ return _MeUIN; }}
	public long FriendUserID { set{ _FriendUserID = value; } get{ return _FriendUserID; }}
	public string FriendUIN { set{ _FriendUIN = value; } get{ return _FriendUIN; }}
	public long FriendTeamID { set{ _FriendTeamID = value; } get{ return _FriendTeamID; }}
}
}


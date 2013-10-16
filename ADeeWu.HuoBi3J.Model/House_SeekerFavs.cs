
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class House_SeekerFavs{

	#region Fields
	private long _ID = 0L;
	private long? _UserID = null;
	private long? _HouseID = null;
	private string _Note = String.Empty;
	private string _Link = String.Empty;
	private DateTime? _FavTime = null;
	#endregion
	
	#region Contructors
	public House_SeekerFavs()
	{
	}
	
	public House_SeekerFavs
	(
		long iD,
			long userID,
			long houseID,
			string note,
			string link,
			DateTime favTime
	)
	{
		_ID      = iD;
			_UserID  = userID;
			_HouseID = houseID;
			_Note    = note;
			_Link    = link;
			_FavTime = favTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long? UserID { set{ _UserID = value; } get{ return _UserID; }}
	public long? HouseID { set{ _HouseID = value; } get{ return _HouseID; }}
	public string Note { set{ _Note = value; } get{ return _Note; }}
	public string Link { set{ _Link = value; } get{ return _Link; }}
	public DateTime? FavTime { set{ _FavTime = value; } get{ return _FavTime; }}
}
}


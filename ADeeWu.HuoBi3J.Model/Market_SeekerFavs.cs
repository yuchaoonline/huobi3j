
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Market_SeekerFavs{

	#region Fields
	private long _ID = 0L;
	private long _MarketInfoID = 0L;
	private long _UserID = 0L;
	private string _Notes = String.Empty;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public Market_SeekerFavs()
	{
	}
	
	public Market_SeekerFavs
	(
		long iD,
			long marketInfoID,
			long userID,
			string notes,
			DateTime createTime
	)
	{
		_ID           = iD;
			_MarketInfoID = marketInfoID;
			_UserID       = userID;
			_Notes        = notes;
			_CreateTime   = createTime;
			
	}
	#endregion
		
public long ID 
{
 set{ _ID = value; }
 get{ return _ID; }
}
public long MarketInfoID 
{
 set{ _MarketInfoID = value; }
 get{ return _MarketInfoID; }
}
public long UserID 
{
 set{ _UserID = value; }
 get{ return _UserID; }
}
public string Notes 
{
 set{ _Notes = value; }
 get{ return _Notes; }
}
public DateTime CreateTime 
{
 set{ _CreateTime = value; }
 get{ return _CreateTime; }
}
}
}


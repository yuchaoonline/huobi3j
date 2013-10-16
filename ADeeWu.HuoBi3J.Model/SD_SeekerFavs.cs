
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class SD_SeekerFavs{

	#region Fields
	private long _ID = 0L;
	private long _UserID = 0L;
	private long _SupplyDemandID = 0L;
	private string _Notes = String.Empty;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	private DateTime _ModifyTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public SD_SeekerFavs()
	{
	}
	
	public SD_SeekerFavs
	(
		long iD,
			long userID,
			long supplyDemandID,
			string notes,
			DateTime createTime,
			DateTime modifyTime
	)
	{
		_ID             = iD;
			_UserID         = userID;
			_SupplyDemandID = supplyDemandID;
			_Notes          = notes;
			_CreateTime     = createTime;
			_ModifyTime     = modifyTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long UserID { set{ _UserID = value; } get{ return _UserID; }}
	public long SupplyDemandID { set{ _SupplyDemandID = value; } get{ return _SupplyDemandID; }}
	public string Notes { set{ _Notes = value; } get{ return _Notes; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public DateTime ModifyTime { set{ _ModifyTime = value; } get{ return _ModifyTime; }}
}
}



using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class SD_Bidders{

	#region Fields
	private long _ID = 0L;
	private long _UserID = 0L;
	private long _SupplyDemandID = 0L;
	private int _Status = 0;
	private string _Content = String.Empty;
	private int _VisitCount = 0;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	private DateTime _ModifyTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public SD_Bidders()
	{
	}
	
	public SD_Bidders
	(
		long iD,
			long userID,
			long supplyDemandID,
			int status,
			string content,
			int visitCount,
			DateTime createTime,
			DateTime modifyTime
	)
	{
		_ID             = iD;
			_UserID         = userID;
			_SupplyDemandID = supplyDemandID;
			_Status         = status;
			_Content        = content;
			_VisitCount     = visitCount;
			_CreateTime     = createTime;
			_ModifyTime     = modifyTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long UserID { set{ _UserID = value; } get{ return _UserID; }}
	public long SupplyDemandID { set{ _SupplyDemandID = value; } get{ return _SupplyDemandID; }}
	public int Status { set{ _Status = value; } get{ return _Status; }}
	public string Content { set{ _Content = value; } get{ return _Content; }}
	public int VisitCount { set{ _VisitCount = value; } get{ return _VisitCount; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public DateTime ModifyTime { set{ _ModifyTime = value; } get{ return _ModifyTime; }}
}
}


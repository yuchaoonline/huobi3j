
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class User_PointsHistories{

	#region Fields
	private long _ID = 0L;
	private long? _UserID = null;
	private int _InPoint = 0;
	private int _OutPoint = 0;
	private int _Remain = 0;
	private string _Notes = String.Empty;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public User_PointsHistories()
	{
	}
	
	public User_PointsHistories
	(
		long iD,
			long userID,
			int inPoint,
			int outPoint,
			int remain,
			string notes,
			DateTime createTime
	)
	{
		_ID         = iD;
			_UserID     = userID;
			_InPoint    = inPoint;
			_OutPoint   = outPoint;
			_Remain     = remain;
			_Notes      = notes;
			_CreateTime = createTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long? UserID { set{ _UserID = value; } get{ return _UserID; }}
	public int InPoint { set{ _InPoint = value; } get{ return _InPoint; }}
	public int OutPoint { set{ _OutPoint = value; } get{ return _OutPoint; }}
	public int Remain { set{ _Remain = value; } get{ return _Remain; }}
	public string Notes { set{ _Notes = value; } get{ return _Notes; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
}
}


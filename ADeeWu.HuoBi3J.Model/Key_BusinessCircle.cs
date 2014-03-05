
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Key_BusinessCircle{

	#region Fields
	private long _BID = 0L;
	private string _BName = null;
	private DateTime? _CreateTime = null;
	private double? _Lat = null;
	private double? _Lng = null;
	#endregion
	
	#region Contructors
	public Key_BusinessCircle()
	{
	}
	
	public Key_BusinessCircle
	(
		long bID,
			string bName,
			DateTime createTime,
			double lat,
			double lng
	)
	{
		_BID        = bID;
			_BName      = bName;
			_CreateTime = createTime;
			_Lat        = lat;
			_Lng        = lng;
			
	}
	#endregion
		
	public long BID { set{ _BID = value; } get{ return _BID; }}
	public string BName { set{ _BName = value; } get{ return _BName; }}
	public DateTime? CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public double? Lat { set{ _Lat = value; } get{ return _Lat; }}
	public double? Lng { set{ _Lng = value; } get{ return _Lng; }}
}
}


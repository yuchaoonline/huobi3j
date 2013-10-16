
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Center_Key_Log{

	#region Fields
	private long _ID = 0L;
	private long? _UID = null;
	private long? _KID = null;
	private double? _Price = null;
	private DateTime? _CreateTime = null;
	private string _Remark = null;
	#endregion
	
	#region Contructors
	public Center_Key_Log()
	{
	}
	
	public Center_Key_Log
	(
		long iD,
			long uID,
			long kID,
			double price,
			DateTime createTime,
			string remark
	)
	{
		_ID         = iD;
			_UID        = uID;
			_KID        = kID;
			_Price      = price;
			_CreateTime = createTime;
			_Remark     = remark;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long? UID { set{ _UID = value; } get{ return _UID; }}
	public long? KID { set{ _KID = value; } get{ return _KID; }}
	public double? Price { set{ _Price = value; } get{ return _Price; }}
	public DateTime? CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public string Remark { set{ _Remark = value; } get{ return _Remark; }}
}
}


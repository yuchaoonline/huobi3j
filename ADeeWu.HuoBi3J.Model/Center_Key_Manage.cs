
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Center_Key_Manage{

	#region Fields
	private int _ID = 0;
	private int? _UID = null;
	private int? _KID = null;
	private DateTime? _CreatTime = null;
	private double? _Price = null;
	private bool? _IsGoOn = null;
	#endregion
	
	#region Contructors
	public Center_Key_Manage()
	{
	}
	
	public Center_Key_Manage
	(
		int iD,
			int uID,
			int kID,
			DateTime creatTime,
			double price,
			bool isGoOn
	)
	{
		_ID        = iD;
			_UID       = uID;
			_KID       = kID;
			_CreatTime = creatTime;
			_Price     = price;
			_IsGoOn    = isGoOn;
			
	}
	#endregion
		
	public int ID { set{ _ID = value; } get{ return _ID; }}
	public int? UID { set{ _UID = value; } get{ return _UID; }}
	public int? KID { set{ _KID = value; } get{ return _KID; }}
	public DateTime? CreatTime { set{ _CreatTime = value; } get{ return _CreatTime; }}
	public double? Price { set{ _Price = value; } get{ return _Price; }}
	public bool? IsGoOn { set{ _IsGoOn = value; } get{ return _IsGoOn; }}
}
}


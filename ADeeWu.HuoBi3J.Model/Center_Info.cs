
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Center_Info{

	#region Fields
	private int _ID = 0;
	private int? _UserID = null;
	private int? _InfoType = null;
	private int? _DataID = null;
	#endregion
	
	#region Contructors
	public Center_Info()
	{
	}
	
	public Center_Info
	(
		int iD,
			int userID,
			int infoType,
			int dataID
	)
	{
		_ID       = iD;
			_UserID   = userID;
			_InfoType = infoType;
			_DataID   = dataID;
			
	}
	#endregion
		
	public int ID { set{ _ID = value; } get{ return _ID; }}
	public int? UserID { set{ _UserID = value; } get{ return _UserID; }}
	public int? InfoType { set{ _InfoType = value; } get{ return _InfoType; }}
	public int? DataID { set{ _DataID = value; } get{ return _DataID; }}
}
}


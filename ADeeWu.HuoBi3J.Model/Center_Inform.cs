
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Center_Inform{

	#region Fields
	private int _ID = 0;
	private int? _ContentID = null;
	private DateTime? _CreateTime = null;
	private int? _InformType = null;
	#endregion
	
	#region Contructors
	public Center_Inform()
	{
	}
	
	public Center_Inform
	(
		int iD,
			int contentID,
			DateTime createTime,
			int informType
	)
	{
		_ID         = iD;
			_ContentID  = contentID;
			_CreateTime = createTime;
			_InformType = informType;
			
	}
	#endregion
		
	public int ID { set{ _ID = value; } get{ return _ID; }}
	public int? ContentID { set{ _ContentID = value; } get{ return _ContentID; }}
	public DateTime? CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public int? InformType { set{ _InformType = value; } get{ return _InformType; }}
}
}


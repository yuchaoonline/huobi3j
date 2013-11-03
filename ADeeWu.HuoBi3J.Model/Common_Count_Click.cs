
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Common_Count_Click{

	#region Fields
	private int _ID = 0;
	private DateTime? _CreateDate = null;
	private string _DataType = null;
	private int? _DataID = null;
	private string _IP = null;
	#endregion
	
	#region Contructors
	public Common_Count_Click()
	{
	}
	
	public Common_Count_Click
	(
		int iD,
			DateTime createDate,
			string dataType,
			int dataID,
			string iP
	)
	{
		_ID         = iD;
			_CreateDate = createDate;
			_DataType   = dataType;
			_DataID     = dataID;
			_IP         = iP;
			
	}
	#endregion
		
	public int ID { set{ _ID = value; } get{ return _ID; }}
	public DateTime? CreateDate { set{ _CreateDate = value; } get{ return _CreateDate; }}
	public string DataType { set{ _DataType = value; } get{ return _DataType; }}
	public int? DataID { set{ _DataID = value; } get{ return _DataID; }}
	public string IP { set{ _IP = value; } get{ return _IP; }}
}
}


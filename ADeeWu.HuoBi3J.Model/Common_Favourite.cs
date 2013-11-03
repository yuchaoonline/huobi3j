
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Common_Favourite{

	#region Fields
	private int _ID = 0;
	private DateTime? _CreateDate = null;
	private int? _DataID = null;
	private string _DataType = null;
	private string _Memo = null;
	private int? _UserID = null;
	#endregion
	
	#region Contructors
	public Common_Favourite()
	{
	}
	
	public Common_Favourite
	(
		int iD,
			DateTime createDate,
			int dataID,
			string dataType,
			string memo,
			int userID
	)
	{
		_ID         = iD;
			_CreateDate = createDate;
			_DataID     = dataID;
			_DataType   = dataType;
			_Memo       = memo;
			_UserID     = userID;
			
	}
	#endregion
		
	public int ID { set{ _ID = value; } get{ return _ID; }}
	public DateTime? CreateDate { set{ _CreateDate = value; } get{ return _CreateDate; }}
	public int? DataID { set{ _DataID = value; } get{ return _DataID; }}
	public string DataType { set{ _DataType = value; } get{ return _DataType; }}
	public string Memo { set{ _Memo = value; } get{ return _Memo; }}
	public int? UserID { set{ _UserID = value; } get{ return _UserID; }}
}
}


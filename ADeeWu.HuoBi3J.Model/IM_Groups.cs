
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class IM_Groups{

	#region Fields
	private long _ID = 0L;
	private string _UIN = String.Empty;
	private string _Name = String.Empty;
	private string _AdminUIN = String.Empty;
	private long _AdminUserID = 0L;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public IM_Groups()
	{
	}
	
	public IM_Groups
	(
		long iD,
			string uIN,
			string name,
			string adminUIN,
			long adminUserID,
			DateTime createTime
	)
	{
		_ID          = iD;
			_UIN         = uIN;
			_Name        = name;
			_AdminUIN    = adminUIN;
			_AdminUserID = adminUserID;
			_CreateTime  = createTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public string UIN { set{ _UIN = value; } get{ return _UIN; }}
	public string Name { set{ _Name = value; } get{ return _Name; }}
	public string AdminUIN { set{ _AdminUIN = value; } get{ return _AdminUIN; }}
	public long AdminUserID { set{ _AdminUserID = value; } get{ return _AdminUserID; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
}
}


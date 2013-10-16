
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Key{

	#region Fields
	private long _KID = 0L;
	private string _Name = null;
	private long? _BID = null;
	private DateTime? _CreateTime = null;
	private bool _IsDefault = false;
	#endregion
	
	#region Contructors
	public Key()
	{
	}
	
	public Key
	(
		long kID,
			string name,
			long bID,
			DateTime createTime,
			bool isDefault
	)
	{
		_KID        = kID;
			_Name       = name;
			_BID        = bID;
			_CreateTime = createTime;
			_IsDefault  = isDefault;
			
	}
	#endregion
		
	public long KID { set{ _KID = value; } get{ return _KID; }}
	public string Name { set{ _Name = value; } get{ return _Name; }}
	public long? BID { set{ _BID = value; } get{ return _BID; }}
	public DateTime? CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public bool IsDefault { set{ _IsDefault = value; } get{ return _IsDefault; }}
}
}



using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Shop_PC_Attrs{

	#region Fields
	private long _ID = 0L;
	private long _CategoryID = 0L;
	private string _Name = String.Empty;
	private int _ValueType = 0;
	private bool _IsValueRequire = false;
	private int _Sequence = 0;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	private DateTime _ModifyTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public Shop_PC_Attrs()
	{
	}
	
	public Shop_PC_Attrs
	(
		long iD,
			long categoryID,
			string name,
			int valueType,
			bool isValueRequire,
			int sequence,
			DateTime createTime,
			DateTime modifyTime
	)
	{
		_ID             = iD;
			_CategoryID     = categoryID;
			_Name           = name;
			_ValueType      = valueType;
			_IsValueRequire = isValueRequire;
			_Sequence       = sequence;
			_CreateTime     = createTime;
			_ModifyTime     = modifyTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long CategoryID { set{ _CategoryID = value; } get{ return _CategoryID; }}
	public string Name { set{ _Name = value; } get{ return _Name; }}
	public int ValueType { set{ _ValueType = value; } get{ return _ValueType; }}
	public bool IsValueRequire { set{ _IsValueRequire = value; } get{ return _IsValueRequire; }}
	public int Sequence { set{ _Sequence = value; } get{ return _Sequence; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public DateTime ModifyTime { set{ _ModifyTime = value; } get{ return _ModifyTime; }}
}
}



using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Shop_PC_Attr_Options{

	#region Fields
	private long _ID = 0L;
	private long _AttrID = 0L;
	private string _Value = String.Empty;
	private int _ItemCount = 0;
	private int _Sequence = 0;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	private DateTime _ModifyTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public Shop_PC_Attr_Options()
	{
	}
	
	public Shop_PC_Attr_Options
	(
		long iD,
			long attrID,
			string value,
			int itemCount,
			int sequence,
			DateTime createTime,
			DateTime modifyTime
	)
	{
		_ID         = iD;
			_AttrID     = attrID;
			_Value      = value;
			_ItemCount  = itemCount;
			_Sequence   = sequence;
			_CreateTime = createTime;
			_ModifyTime = modifyTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long AttrID { set{ _AttrID = value; } get{ return _AttrID; }}
	public string Value { set{ _Value = value; } get{ return _Value; }}
	public int ItemCount { set{ _ItemCount = value; } get{ return _ItemCount; }}
	public int Sequence { set{ _Sequence = value; } get{ return _Sequence; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public DateTime ModifyTime { set{ _ModifyTime = value; } get{ return _ModifyTime; }}
}
}


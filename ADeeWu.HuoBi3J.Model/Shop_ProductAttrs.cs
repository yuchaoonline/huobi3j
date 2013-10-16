
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Shop_ProductAttrs{

	#region Fields
	private long _ID = 0L;
	private long _ProductID = 0L;
	private long _AttrID = 0L;
	private string _AttrOptionIDList = String.Empty;
	private string _CustomValue = String.Empty;
	#endregion
	
	#region Contructors
	public Shop_ProductAttrs()
	{
	}
	
	public Shop_ProductAttrs
	(
		long iD,
			long productID,
			long attrID,
			string attrOptionIDList,
			string customValue
	)
	{
		_ID               = iD;
			_ProductID        = productID;
			_AttrID           = attrID;
			_AttrOptionIDList = attrOptionIDList;
			_CustomValue      = customValue;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long ProductID { set{ _ProductID = value; } get{ return _ProductID; }}
	public long AttrID { set{ _AttrID = value; } get{ return _AttrID; }}
	public string AttrOptionIDList { set{ _AttrOptionIDList = value; } get{ return _AttrOptionIDList; }}
	public string CustomValue { set{ _CustomValue = value; } get{ return _CustomValue; }}
}
}


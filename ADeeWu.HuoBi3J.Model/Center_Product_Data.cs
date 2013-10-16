
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Center_Product_Data{

	#region Fields
	private int _ID = 0;
	private int? _ProductID = null;
	private int? _DataID = null;
	private int? _TypeID = null;
	#endregion
	
	#region Contructors
	public Center_Product_Data()
	{
	}
	
	public Center_Product_Data
	(
		int iD,
			int productID,
			int dataID,
			int typeID
	)
	{
		_ID        = iD;
			_ProductID = productID;
			_DataID    = dataID;
			_TypeID    = typeID;
			
	}
	#endregion
		
	public int ID { set{ _ID = value; } get{ return _ID; }}
	public int? ProductID { set{ _ProductID = value; } get{ return _ProductID; }}
	public int? DataID { set{ _DataID = value; } get{ return _DataID; }}
	public int? TypeID { set{ _TypeID = value; } get{ return _TypeID; }}
}
}


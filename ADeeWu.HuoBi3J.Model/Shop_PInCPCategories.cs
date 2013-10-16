
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Shop_PInCPCategories{

	#region Fields
	private long _ID = 0L;
	private long _ShopID = 0L;
	private long _CPCategoryID = 0L;
	private long _ProductID = 0L;
	#endregion
	
	#region Contructors
	public Shop_PInCPCategories()
	{
	}
	
	public Shop_PInCPCategories
	(
		long iD,
			long shopID,
			long cPCategoryID,
			long productID
	)
	{
		_ID           = iD;
			_ShopID       = shopID;
			_CPCategoryID = cPCategoryID;
			_ProductID    = productID;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long ShopID { set{ _ShopID = value; } get{ return _ShopID; }}
	public long CPCategoryID { set{ _CPCategoryID = value; } get{ return _CPCategoryID; }}
	public long ProductID { set{ _ProductID = value; } get{ return _ProductID; }}
}
}


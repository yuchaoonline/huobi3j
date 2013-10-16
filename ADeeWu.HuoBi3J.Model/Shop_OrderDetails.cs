
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Shop_OrderDetails{

	#region Fields
	private long _ID = 0L;
	private long _OrderID = 0L;
	private long _SellerCorpID = 0L;
	private long _SellerUserID = 0L;
	private long _BuyerUserID = 0L;
	private long _ProductID = 0L;
	private string _ProductName = String.Empty;
	private decimal _NowPrice = 0M;
	private int _Quantity = 0;
	private string _Note = String.Empty;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	private DateTime _ModifyTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public Shop_OrderDetails()
	{
	}
	
	public Shop_OrderDetails
	(
		long iD,
			long orderID,
			long sellerCorpID,
			long sellerUserID,
			long buyerUserID,
			long productID,
			string productName,
			decimal nowPrice,
			int quantity,
			string note,
			DateTime createTime,
			DateTime modifyTime
	)
	{
		_ID           = iD;
			_OrderID      = orderID;
			_SellerCorpID = sellerCorpID;
			_SellerUserID = sellerUserID;
			_BuyerUserID  = buyerUserID;
			_ProductID    = productID;
			_ProductName  = productName;
			_NowPrice     = nowPrice;
			_Quantity     = quantity;
			_Note         = note;
			_CreateTime   = createTime;
			_ModifyTime   = modifyTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long OrderID { set{ _OrderID = value; } get{ return _OrderID; }}
	public long SellerCorpID { set{ _SellerCorpID = value; } get{ return _SellerCorpID; }}
	public long SellerUserID { set{ _SellerUserID = value; } get{ return _SellerUserID; }}
	public long BuyerUserID { set{ _BuyerUserID = value; } get{ return _BuyerUserID; }}
	public long ProductID { set{ _ProductID = value; } get{ return _ProductID; }}
	public string ProductName { set{ _ProductName = value; } get{ return _ProductName; }}
	public decimal NowPrice { set{ _NowPrice = value; } get{ return _NowPrice; }}
	public int Quantity { set{ _Quantity = value; } get{ return _Quantity; }}
	public string Note { set{ _Note = value; } get{ return _Note; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public DateTime ModifyTime { set{ _ModifyTime = value; } get{ return _ModifyTime; }}
}
}


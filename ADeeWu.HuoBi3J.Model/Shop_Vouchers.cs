
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Shop_Vouchers{

	#region Fields
	private long _ID = 0L;
	private long _SellerCorpID = 0L;
	private long _SellerUserID = 0L;
	private long _BuyerUserID = 0L;
	private string _Title = String.Empty;
	private string _Content = String.Empty;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	private DateTime _ModifyTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public Shop_Vouchers()
	{
	}
	
	public Shop_Vouchers
	(
		long iD,
			long sellerCorpID,
			long sellerUserID,
			long buyerUserID,
			string title,
			string content,
			DateTime createTime,
			DateTime modifyTime
	)
	{
		_ID           = iD;
			_SellerCorpID = sellerCorpID;
			_SellerUserID = sellerUserID;
			_BuyerUserID  = buyerUserID;
			_Title        = title;
			_Content      = content;
			_CreateTime   = createTime;
			_ModifyTime   = modifyTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long SellerCorpID { set{ _SellerCorpID = value; } get{ return _SellerCorpID; }}
	public long SellerUserID { set{ _SellerUserID = value; } get{ return _SellerUserID; }}
	public long BuyerUserID { set{ _BuyerUserID = value; } get{ return _BuyerUserID; }}
	public string Title { set{ _Title = value; } get{ return _Title; }}
	public string Content { set{ _Content = value; } get{ return _Content; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public DateTime ModifyTime { set{ _ModifyTime = value; } get{ return _ModifyTime; }}
}
}


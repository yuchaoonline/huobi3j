
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Shop_Orders{

	#region Fields
	private long _ID = 0L;
	private string _OrderCode = String.Empty;
	private long _SellerCorpID = 0L;
	private long _SellerUserID = 0L;
	private long _CorpAgentID = 0L;
	private long _BuyerUserID = 0L;
	private decimal _SubTotal = 0M;
	private decimal _Freight = 0M;
	private int _OrderState = 0;
	private bool _HasPaid = false;
	private int _DeliveryType = 0;
	private string _Receiver = String.Empty;
	private long _ProvinceID = 0L;
	private long _CityID = 0L;
	private long _AreaID = 0L;
	private string _Address = String.Empty;
	private string _ZipCode = String.Empty;
	private string _Note = String.Empty;
	private DateTime? _DeliveryTime = null;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	private DateTime _ModifyTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public Shop_Orders()
	{
	}
	
	public Shop_Orders
	(
		long iD,
			string orderCode,
			long sellerCorpID,
			long sellerUserID,
			long corpAgentID,
			long buyerUserID,
			decimal subTotal,
			decimal freight,
			int orderState,
			bool hasPaid,
			int deliveryType,
			string receiver,
			long provinceID,
			long cityID,
			long areaID,
			string address,
			string zipCode,
			string note,
			DateTime deliveryTime,
			DateTime createTime,
			DateTime modifyTime
	)
	{
		_ID           = iD;
			_OrderCode    = orderCode;
			_SellerCorpID = sellerCorpID;
			_SellerUserID = sellerUserID;
			_CorpAgentID  = corpAgentID;
			_BuyerUserID  = buyerUserID;
			_SubTotal     = subTotal;
			_Freight      = freight;
			_OrderState   = orderState;
			_HasPaid      = hasPaid;
			_DeliveryType = deliveryType;
			_Receiver     = receiver;
			_ProvinceID   = provinceID;
			_CityID       = cityID;
			_AreaID       = areaID;
			_Address      = address;
			_ZipCode      = zipCode;
			_Note         = note;
			_DeliveryTime = deliveryTime;
			_CreateTime   = createTime;
			_ModifyTime   = modifyTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public string OrderCode { set{ _OrderCode = value; } get{ return _OrderCode; }}
	public long SellerCorpID { set{ _SellerCorpID = value; } get{ return _SellerCorpID; }}
	public long SellerUserID { set{ _SellerUserID = value; } get{ return _SellerUserID; }}
	public long CorpAgentID { set{ _CorpAgentID = value; } get{ return _CorpAgentID; }}
	public long BuyerUserID { set{ _BuyerUserID = value; } get{ return _BuyerUserID; }}
	public decimal SubTotal { set{ _SubTotal = value; } get{ return _SubTotal; }}
	public decimal Freight { set{ _Freight = value; } get{ return _Freight; }}
	public int OrderState { set{ _OrderState = value; } get{ return _OrderState; }}
	public bool HasPaid { set{ _HasPaid = value; } get{ return _HasPaid; }}
	public int DeliveryType { set{ _DeliveryType = value; } get{ return _DeliveryType; }}
	public string Receiver { set{ _Receiver = value; } get{ return _Receiver; }}
	public long ProvinceID { set{ _ProvinceID = value; } get{ return _ProvinceID; }}
	public long CityID { set{ _CityID = value; } get{ return _CityID; }}
	public long AreaID { set{ _AreaID = value; } get{ return _AreaID; }}
	public string Address { set{ _Address = value; } get{ return _Address; }}
	public string ZipCode { set{ _ZipCode = value; } get{ return _ZipCode; }}
	public string Note { set{ _Note = value; } get{ return _Note; }}
	public DateTime? DeliveryTime { set{ _DeliveryTime = value; } get{ return _DeliveryTime; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public DateTime ModifyTime { set{ _ModifyTime = value; } get{ return _ModifyTime; }}
}
}


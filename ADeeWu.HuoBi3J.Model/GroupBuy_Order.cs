
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class GroupBuy_Order{

	#region Fields
	private int _ID = 0;
	private int? _OrderUserID = null;
	private int? _OrderProductID = null;
	private string _Title = null;
	private DateTime? _OrderDate = null;
	private decimal? _Price = null;
	private string _SellerName = null;
	private string _SellerTel = null;
	private string _InformTel = null;
	private string _Code = null;
	private bool _IsUse = false;
	#endregion
	
	#region Contructors
	public GroupBuy_Order()
	{
	}
	
	public GroupBuy_Order
	(
		int iD,
			int orderUserID,
			int orderProductID,
			string title,
			DateTime orderDate,
			decimal price,
			string sellerName,
			string sellerTel,
			string informTel,
			string code,
			bool isUse
	)
	{
		_ID             = iD;
			_OrderUserID    = orderUserID;
			_OrderProductID = orderProductID;
			_Title          = title;
			_OrderDate      = orderDate;
			_Price          = price;
			_SellerName     = sellerName;
			_SellerTel      = sellerTel;
			_InformTel      = informTel;
			_Code           = code;
			_IsUse          = isUse;
			
	}
	#endregion
		
	public int ID { set{ _ID = value; } get{ return _ID; }}
	public int? OrderUserID { set{ _OrderUserID = value; } get{ return _OrderUserID; }}
	public int? OrderProductID { set{ _OrderProductID = value; } get{ return _OrderProductID; }}
	public string Title { set{ _Title = value; } get{ return _Title; }}
	public DateTime? OrderDate { set{ _OrderDate = value; } get{ return _OrderDate; }}
	public decimal? Price { set{ _Price = value; } get{ return _Price; }}
	public string SellerName { set{ _SellerName = value; } get{ return _SellerName; }}
	public string SellerTel { set{ _SellerTel = value; } get{ return _SellerTel; }}
	public string InformTel { set{ _InformTel = value; } get{ return _InformTel; }}
	public string Code { set{ _Code = value; } get{ return _Code; }}
	public bool IsUse { set{ _IsUse = value; } get{ return _IsUse; }}
}
}


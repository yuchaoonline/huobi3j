
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Coupons_CashWhenFee_Condition{

	#region Fields
	private int _ID = 0;
	private int? _SaleManUserID = null;
	private decimal? _Money = null;
	private string _Memo = null;
	private bool? _IsShow = null;
	private DateTime? _CreateTime = null;
	#endregion
	
	#region Contructors
	public Coupons_CashWhenFee_Condition()
	{
	}
	
	public Coupons_CashWhenFee_Condition
	(
		int iD,
			int saleManUserID,
			decimal money,
			string memo,
			bool isShow,
			DateTime createTime
	)
	{
		_ID            = iD;
			_SaleManUserID = saleManUserID;
			_Money         = money;
			_Memo          = memo;
			_IsShow        = isShow;
			_CreateTime    = createTime;
			
	}
	#endregion
		
	public int ID { set{ _ID = value; } get{ return _ID; }}
	public int? SaleManUserID { set{ _SaleManUserID = value; } get{ return _SaleManUserID; }}
	public decimal? Money { set{ _Money = value; } get{ return _Money; }}
	public string Memo { set{ _Memo = value; } get{ return _Memo; }}
	public bool? IsShow { set{ _IsShow = value; } get{ return _IsShow; }}
	public DateTime? CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
}
}


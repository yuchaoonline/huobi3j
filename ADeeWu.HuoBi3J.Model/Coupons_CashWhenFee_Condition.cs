
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Coupons_CashWhenFee_Condition{

	#region Fields
	private int _ID = 0;
	private int? _SalemanUserID = null;
	private decimal? _Money = null;
	private string _Memo = null;
	#endregion
	
	#region Contructors
	public Coupons_CashWhenFee_Condition()
	{
	}
	
	public Coupons_CashWhenFee_Condition
	(
		int iD,
			int salemanUserID,
			decimal money,
			string memo
	)
	{
		_ID            = iD;
			_SalemanUserID = salemanUserID;
			_Money         = money;
			_Memo          = memo;
			
	}
	#endregion
		
	public int ID { set{ _ID = value; } get{ return _ID; }}
	public int? SalemanUserID { set{ _SalemanUserID = value; } get{ return _SalemanUserID; }}
	public decimal? Money { set{ _Money = value; } get{ return _Money; }}
	public string Memo { set{ _Memo = value; } get{ return _Memo; }}
}
}


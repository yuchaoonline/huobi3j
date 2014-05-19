
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Coupons_CashWhenFee_Code{

	#region Fields
	private int _ID = 0;
	private int? _Coupons_ListID = null;
	private string _Code = null;
	#endregion
	
	#region Contructors
	public Coupons_CashWhenFee_Code()
	{
	}
	
	public Coupons_CashWhenFee_Code
	(
		int iD,
			int coupons_ListID,
			string code
	)
	{
		_ID             = iD;
			_Coupons_ListID = coupons_ListID;
			_Code           = code;
			
	}
	#endregion
		
	public int ID { set{ _ID = value; } get{ return _ID; }}
	public int? Coupons_ListID { set{ _Coupons_ListID = value; } get{ return _Coupons_ListID; }}
	public string Code { set{ _Code = value; } get{ return _Code; }}
}
}


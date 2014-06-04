
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Coupons_CashWhenFee{

	#region Fields
	private int _ID = 0;
	private decimal? _Money = null;
	private decimal? _Fee = null;
	private int? _CreateUserID = null;
	private DateTime? _StartDate = null;
	private DateTime? _EndDate = null;
	private DateTime? _CreateDate = null;
	#endregion
	
	#region Contructors
	public Coupons_CashWhenFee()
	{
	}
	
	public Coupons_CashWhenFee
	(
		int iD,
			decimal money,
			decimal fee,
			int createUserID,
			DateTime startDate,
			DateTime endDate,
			DateTime createDate
	)
	{
		_ID           = iD;
			_Money        = money;
			_Fee          = fee;
			_CreateUserID = createUserID;
			_StartDate    = startDate;
			_EndDate      = endDate;
			_CreateDate   = createDate;
			
	}
	#endregion
		
	public int ID { set{ _ID = value; } get{ return _ID; }}
	public decimal? Money { set{ _Money = value; } get{ return _Money; }}
	public decimal? Fee { set{ _Fee = value; } get{ return _Fee; }}
	public int? CreateUserID { set{ _CreateUserID = value; } get{ return _CreateUserID; }}
	public DateTime? StartDate { set{ _StartDate = value; } get{ return _StartDate; }}
	public DateTime? EndDate { set{ _EndDate = value; } get{ return _EndDate; }}
	public DateTime? CreateDate { set{ _CreateDate = value; } get{ return _CreateDate; }}
}
}


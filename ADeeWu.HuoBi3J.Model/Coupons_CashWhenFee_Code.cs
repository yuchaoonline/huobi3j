
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Coupons_CashWhenFee_Code{

	#region Fields
	private int _ID = 0;
	private decimal? _Fee = null;
	private decimal? _Money = null;
	private int? _Count = null;
	private int? _UseCount = null;
	private int? _UserID = null;
	private int? _SaleManUserID = null;
	private DateTime? _StartDate = null;
	private DateTime? _EndDate = null;
	private DateTime? _CreateTime = null;
	private decimal _OriginalMoney = 0M;
	#endregion
	
	#region Contructors
	public Coupons_CashWhenFee_Code()
	{
	}
	
	public Coupons_CashWhenFee_Code
	(
		int iD,
			decimal fee,
			decimal money,
			int count,
			int useCount,
			int userID,
			int saleManUserID,
			DateTime startDate,
			DateTime endDate,
			DateTime createTime,
			decimal originalMoney
	)
	{
		_ID            = iD;
			_Fee           = fee;
			_Money         = money;
			_Count         = count;
			_UseCount      = useCount;
			_UserID        = userID;
			_SaleManUserID = saleManUserID;
			_StartDate     = startDate;
			_EndDate       = endDate;
			_CreateTime    = createTime;
			_OriginalMoney = originalMoney;
			
	}
	#endregion
		
	public int ID { set{ _ID = value; } get{ return _ID; }}
	public decimal? Fee { set{ _Fee = value; } get{ return _Fee; }}
	public decimal? Money { set{ _Money = value; } get{ return _Money; }}
	public int? Count { set{ _Count = value; } get{ return _Count; }}
	public int? UseCount { set{ _UseCount = value; } get{ return _UseCount; }}
	public int? UserID { set{ _UserID = value; } get{ return _UserID; }}
	public int? SaleManUserID { set{ _SaleManUserID = value; } get{ return _SaleManUserID; }}
	public DateTime? StartDate { set{ _StartDate = value; } get{ return _StartDate; }}
	public DateTime? EndDate { set{ _EndDate = value; } get{ return _EndDate; }}
	public DateTime? CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public decimal OriginalMoney { set{ _OriginalMoney = value; } get{ return _OriginalMoney; }}
}
}


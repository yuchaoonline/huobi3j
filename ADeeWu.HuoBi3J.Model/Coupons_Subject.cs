
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Coupons_Subject{

	#region Fields
	private int _ID = 0;
	private string _Name = null;
	private decimal? _Money = null;
	private bool? _IsMoney = null;
	private DateTime? _StartDate = null;
	private DateTime? _EndDate = null;
	private bool? _Inactive = null;
	#endregion
	
	#region Contructors
	public Coupons_Subject()
	{
	}
	
	public Coupons_Subject
	(
		int iD,
			string name,
			decimal money,
			bool isMoney,
			DateTime startDate,
			DateTime endDate,
			bool inactive
	)
	{
		_ID        = iD;
			_Name      = name;
			_Money     = money;
			_IsMoney   = isMoney;
			_StartDate = startDate;
			_EndDate   = endDate;
			_Inactive  = inactive;
			
	}
	#endregion
		
	public int ID { set{ _ID = value; } get{ return _ID; }}
	public string Name { set{ _Name = value; } get{ return _Name; }}
	public decimal? Money { set{ _Money = value; } get{ return _Money; }}
	public bool? IsMoney { set{ _IsMoney = value; } get{ return _IsMoney; }}
	public DateTime? StartDate { set{ _StartDate = value; } get{ return _StartDate; }}
	public DateTime? EndDate { set{ _EndDate = value; } get{ return _EndDate; }}
	public bool? Inactive { set{ _Inactive = value; } get{ return _Inactive; }}
}
}


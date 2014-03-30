
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Coupons_Subject{

	#region Fields
	private int _ID = 0;
	private string _Name = null;
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
			DateTime startDate,
			DateTime endDate,
			bool inactive
	)
	{
		_ID        = iD;
			_Name      = name;
			_StartDate = startDate;
			_EndDate   = endDate;
			_Inactive  = inactive;
			
	}
	#endregion
		
	public int ID { set{ _ID = value; } get{ return _ID; }}
	public string Name { set{ _Name = value; } get{ return _Name; }}
	public DateTime? StartDate { set{ _StartDate = value; } get{ return _StartDate; }}
	public DateTime? EndDate { set{ _EndDate = value; } get{ return _EndDate; }}
	public bool? Inactive { set{ _Inactive = value; } get{ return _Inactive; }}
}
}


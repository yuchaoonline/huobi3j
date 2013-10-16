
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class FreeAdmission{

	#region Fields
	private int _ID = 0;
	private string _SeqNo = null;
	private string _SeqPwd = null;
	private DateTime _StartDate = new DateTime(1900,1,1);
	private DateTime _EndDate = new DateTime(1900,1,1);
	private decimal _Money = 0M;
	private int _TotalCount = 0;
	private int _ApplyCount = 0;
	#endregion
	
	#region Contructors
	public FreeAdmission()
	{
	}
	
	public FreeAdmission
	(
		int iD,
			string seqNo,
			string seqPwd,
			DateTime startDate,
			DateTime endDate,
			decimal money,
			int totalCount,
			int applyCount
	)
	{
		_ID         = iD;
			_SeqNo      = seqNo;
			_SeqPwd     = seqPwd;
			_StartDate  = startDate;
			_EndDate    = endDate;
			_Money      = money;
			_TotalCount = totalCount;
			_ApplyCount = applyCount;
			
	}
	#endregion
		
	public int ID { set{ _ID = value; } get{ return _ID; }}
	public string SeqNo { set{ _SeqNo = value; } get{ return _SeqNo; }}
	public string SeqPwd { set{ _SeqPwd = value; } get{ return _SeqPwd; }}
	public DateTime StartDate { set{ _StartDate = value; } get{ return _StartDate; }}
	public DateTime EndDate { set{ _EndDate = value; } get{ return _EndDate; }}
	public decimal Money { set{ _Money = value; } get{ return _Money; }}
	public int TotalCount { set{ _TotalCount = value; } get{ return _TotalCount; }}
	public int ApplyCount { set{ _ApplyCount = value; } get{ return _ApplyCount; }}
}
}


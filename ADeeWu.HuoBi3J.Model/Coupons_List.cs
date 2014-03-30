
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Coupons_List{

	#region Fields
	private int _ID = 0;
	private int? _SubjectID = null;
	private decimal? _Money = null;
	private bool? _IsMoney = null;
	private string _Password = null;
	private DateTime? _StartDate = null;
	private DateTime? _EndDate = null;
	private bool? _IsUse = null;
	private int? _UserID = null;
	private DateTime? _UseDate = null;
	private string _Memo = null;
	private bool _Inactive = false;
	#endregion
	
	#region Contructors
	public Coupons_List()
	{
	}
	
	public Coupons_List
	(
		int iD,
			int subjectID,
			decimal money,
			bool isMoney,
			string password,
			DateTime startDate,
			DateTime endDate,
			bool isUse,
			int userID,
			DateTime useDate,
			string memo,
			bool inactive
	)
	{
		_ID        = iD;
			_SubjectID = subjectID;
			_Money     = money;
			_IsMoney   = isMoney;
			_Password  = password;
			_StartDate = startDate;
			_EndDate   = endDate;
			_IsUse     = isUse;
			_UserID    = userID;
			_UseDate   = useDate;
			_Memo      = memo;
			_Inactive  = inactive;
			
	}
	#endregion
		
	public int ID { set{ _ID = value; } get{ return _ID; }}
	public int? SubjectID { set{ _SubjectID = value; } get{ return _SubjectID; }}
	public decimal? Money { set{ _Money = value; } get{ return _Money; }}
	public bool? IsMoney { set{ _IsMoney = value; } get{ return _IsMoney; }}
	public string Password { set{ _Password = value; } get{ return _Password; }}
	public DateTime? StartDate { set{ _StartDate = value; } get{ return _StartDate; }}
	public DateTime? EndDate { set{ _EndDate = value; } get{ return _EndDate; }}
	public bool? IsUse { set{ _IsUse = value; } get{ return _IsUse; }}
	public int? UserID { set{ _UserID = value; } get{ return _UserID; }}
	public DateTime? UseDate { set{ _UseDate = value; } get{ return _UseDate; }}
	public string Memo { set{ _Memo = value; } get{ return _Memo; }}
	public bool Inactive { set{ _Inactive = value; } get{ return _Inactive; }}
}
}


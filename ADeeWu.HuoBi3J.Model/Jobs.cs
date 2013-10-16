
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Jobs{

	#region Fields
	private long _ID = 0L;
	private long _CorpID = 0L;
	private string _Title = String.Empty;
	private string _Summary = String.Empty;
	private string _Content = String.Empty;
	private string _Province = String.Empty;
	private string _City = String.Empty;
	private string _Area = String.Empty;
	private long _ProvinceID = 0L;
	private long _CityID = 0L;
	private long _AreaID = 0L;
	private string _Address = String.Empty;
	private long _CategoryID = 0L;
	private long _CallingID = 0L;
	private int _Sex = 0;
	private int _Education = 0;
	private int _Exp = 0;
	private DateTime _EndTime = new DateTime(1900,1,1);
	private DateTime _CreateTime = new DateTime(1900,1,1);
	private DateTime _ModifyTime = new DateTime(1900,1,1);
	private DateTime _RefreshTime = new DateTime(1900,1,1);
	private int _CheckState = 0;
	private int _WorkType = 0;
	private double _MonthlyPay = 0D;
	private int _JobCount = 0;
	private string _LinkName = String.Empty;
	private string _LinkPhone = String.Empty;
	private string _LinkEmail = String.Empty;
	private int _VisitCount = 0;
	private string _AgeArea = String.Empty;
	#endregion
	
	#region Contructors
	public Jobs()
	{
	}
	
	public Jobs
	(
		long iD,
			long corpID,
			string title,
			string summary,
			string content,
			string province,
			string city,
			string area,
			long provinceID,
			long cityID,
			long areaID,
			string address,
			long categoryID,
			long callingID,
			int sex,
			int education,
			int exp,
			DateTime endTime,
			DateTime createTime,
			DateTime modifyTime,
			DateTime refreshTime,
			int checkState,
			int workType,
			double monthlyPay,
			int jobCount,
			string linkName,
			string linkPhone,
			string linkEmail,
			int visitCount,
			string ageArea
	)
	{
		_ID          = iD;
			_CorpID      = corpID;
			_Title       = title;
			_Summary     = summary;
			_Content     = content;
			_Province    = province;
			_City        = city;
			_Area        = area;
			_ProvinceID  = provinceID;
			_CityID      = cityID;
			_AreaID      = areaID;
			_Address     = address;
			_CategoryID  = categoryID;
			_CallingID   = callingID;
			_Sex         = sex;
			_Education   = education;
			_Exp         = exp;
			_EndTime     = endTime;
			_CreateTime  = createTime;
			_ModifyTime  = modifyTime;
			_RefreshTime = refreshTime;
			_CheckState  = checkState;
			_WorkType    = workType;
			_MonthlyPay  = monthlyPay;
			_JobCount    = jobCount;
			_LinkName    = linkName;
			_LinkPhone   = linkPhone;
			_LinkEmail   = linkEmail;
			_VisitCount  = visitCount;
			_AgeArea     = ageArea;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long CorpID { set{ _CorpID = value; } get{ return _CorpID; }}
	public string Title { set{ _Title = value; } get{ return _Title; }}
	public string Summary { set{ _Summary = value; } get{ return _Summary; }}
	public string Content { set{ _Content = value; } get{ return _Content; }}
	public string Province { set{ _Province = value; } get{ return _Province; }}
	public string City { set{ _City = value; } get{ return _City; }}
	public string Area { set{ _Area = value; } get{ return _Area; }}
	public long ProvinceID { set{ _ProvinceID = value; } get{ return _ProvinceID; }}
	public long CityID { set{ _CityID = value; } get{ return _CityID; }}
	public long AreaID { set{ _AreaID = value; } get{ return _AreaID; }}
	public string Address { set{ _Address = value; } get{ return _Address; }}
	public long CategoryID { set{ _CategoryID = value; } get{ return _CategoryID; }}
	public long CallingID { set{ _CallingID = value; } get{ return _CallingID; }}
	public int Sex { set{ _Sex = value; } get{ return _Sex; }}
	public int Education { set{ _Education = value; } get{ return _Education; }}
	public int Exp { set{ _Exp = value; } get{ return _Exp; }}
	public DateTime EndTime { set{ _EndTime = value; } get{ return _EndTime; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public DateTime ModifyTime { set{ _ModifyTime = value; } get{ return _ModifyTime; }}
	public DateTime RefreshTime { set{ _RefreshTime = value; } get{ return _RefreshTime; }}
	public int CheckState { set{ _CheckState = value; } get{ return _CheckState; }}
	public int WorkType { set{ _WorkType = value; } get{ return _WorkType; }}
	public double MonthlyPay { set{ _MonthlyPay = value; } get{ return _MonthlyPay; }}
	public int JobCount { set{ _JobCount = value; } get{ return _JobCount; }}
	public string LinkName { set{ _LinkName = value; } get{ return _LinkName; }}
	public string LinkPhone { set{ _LinkPhone = value; } get{ return _LinkPhone; }}
	public string LinkEmail { set{ _LinkEmail = value; } get{ return _LinkEmail; }}
	public int VisitCount { set{ _VisitCount = value; } get{ return _VisitCount; }}
	public string AgeArea { set{ _AgeArea = value; } get{ return _AgeArea; }}
}
}


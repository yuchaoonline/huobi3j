
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class CA_QualifiedAgents{

	#region Fields
	private long _ID = 0L;
	private long _UserID = 0L;
	private string _RealName = String.Empty;
	private string _Sex = String.Empty;
	private DateTime _Birthday = new DateTime(1900,1,1);
	private long _ProvinceID = 0L;
	private long _CityID = 0L;
	private long _AreaID = 0L;
	private string _Address = String.Empty;
	private string _ZipCode = String.Empty;
	private string _School = String.Empty;
	private string _Speciality = String.Empty;
	private string _Skill = String.Empty;
	private int _Education = 0;
	private int _WorkExp = 0;
	private string _Note = String.Empty;
	private int _VisitCount = 0;
	private bool _IsHidden = false;
	private int _CheckState = 0;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	private DateTime _ModifyTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public CA_QualifiedAgents()
	{
	}
	
	public CA_QualifiedAgents
	(
		long iD,
			long userID,
			string realName,
			string sex,
			DateTime birthday,
			long provinceID,
			long cityID,
			long areaID,
			string address,
			string zipCode,
			string school,
			string speciality,
			string skill,
			int education,
			int workExp,
			string note,
			int visitCount,
			bool isHidden,
			int checkState,
			DateTime createTime,
			DateTime modifyTime
	)
	{
		_ID         = iD;
			_UserID     = userID;
			_RealName   = realName;
			_Sex        = sex;
			_Birthday   = birthday;
			_ProvinceID = provinceID;
			_CityID     = cityID;
			_AreaID     = areaID;
			_Address    = address;
			_ZipCode    = zipCode;
			_School     = school;
			_Speciality = speciality;
			_Skill      = skill;
			_Education  = education;
			_WorkExp    = workExp;
			_Note       = note;
			_VisitCount = visitCount;
			_IsHidden   = isHidden;
			_CheckState = checkState;
			_CreateTime = createTime;
			_ModifyTime = modifyTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long UserID { set{ _UserID = value; } get{ return _UserID; }}
	public string RealName { set{ _RealName = value; } get{ return _RealName; }}
	public string Sex { set{ _Sex = value; } get{ return _Sex; }}
	public DateTime Birthday { set{ _Birthday = value; } get{ return _Birthday; }}
	public long ProvinceID { set{ _ProvinceID = value; } get{ return _ProvinceID; }}
	public long CityID { set{ _CityID = value; } get{ return _CityID; }}
	public long AreaID { set{ _AreaID = value; } get{ return _AreaID; }}
	public string Address { set{ _Address = value; } get{ return _Address; }}
	public string ZipCode { set{ _ZipCode = value; } get{ return _ZipCode; }}
	public string School { set{ _School = value; } get{ return _School; }}
	public string Speciality { set{ _Speciality = value; } get{ return _Speciality; }}
	public string Skill { set{ _Skill = value; } get{ return _Skill; }}
	public int Education { set{ _Education = value; } get{ return _Education; }}
	public int WorkExp { set{ _WorkExp = value; } get{ return _WorkExp; }}
	public string Note { set{ _Note = value; } get{ return _Note; }}
	public int VisitCount { set{ _VisitCount = value; } get{ return _VisitCount; }}
	public bool IsHidden { set{ _IsHidden = value; } get{ return _IsHidden; }}
	public int CheckState { set{ _CheckState = value; } get{ return _CheckState; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public DateTime ModifyTime { set{ _ModifyTime = value; } get{ return _ModifyTime; }}
}
}


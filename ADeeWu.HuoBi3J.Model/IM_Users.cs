
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class IM_Users{

	#region Fields
	private long _ID = 0L;
	private string _UIN = String.Empty;
	private long _UserID = 0L;
	private string _NickName = String.Empty;
	private string _HeadPic = String.Empty;
	private string _Sex = String.Empty;
	private string _SignText = String.Empty;
	private DateTime? _Birthday = null;
	private string _Tel = String.Empty;
	private string _Email = String.Empty;
	private long _ProvinceID = 0L;
	private long _CityID = 0L;
	private long _AreaID = 0L;
	private string _Province = String.Empty;
	private string _City = String.Empty;
	private string _Area = String.Empty;
	private string _Profession = String.Empty;
	private string _School = String.Empty;
	private string _HomePage = String.Empty;
	private string _Introduce = String.Empty;
	private int _CheckState = 0;
	private DateTime _LastLoginTime = new DateTime(1900,1,1);
	private string _LastLoginIP = String.Empty;
	private int _LoginTimes = 0;
	private int _LoginState = 0;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	private DateTime _ModifyTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public IM_Users()
	{
	}
	
	public IM_Users
	(
		long iD,
			string uIN,
			long userID,
			string nickName,
			string headPic,
			string sex,
			string signText,
			DateTime birthday,
			string tel,
			string email,
			long provinceID,
			long cityID,
			long areaID,
			string province,
			string city,
			string area,
			string profession,
			string school,
			string homePage,
			string introduce,
			int checkState,
			DateTime lastLoginTime,
			string lastLoginIP,
			int loginTimes,
			int loginState,
			DateTime createTime,
			DateTime modifyTime
	)
	{
		_ID            = iD;
			_UIN           = uIN;
			_UserID        = userID;
			_NickName      = nickName;
			_HeadPic       = headPic;
			_Sex           = sex;
			_SignText      = signText;
			_Birthday      = birthday;
			_Tel           = tel;
			_Email         = email;
			_ProvinceID    = provinceID;
			_CityID        = cityID;
			_AreaID        = areaID;
			_Province      = province;
			_City          = city;
			_Area          = area;
			_Profession    = profession;
			_School        = school;
			_HomePage      = homePage;
			_Introduce     = introduce;
			_CheckState    = checkState;
			_LastLoginTime = lastLoginTime;
			_LastLoginIP   = lastLoginIP;
			_LoginTimes    = loginTimes;
			_LoginState    = loginState;
			_CreateTime    = createTime;
			_ModifyTime    = modifyTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public string UIN { set{ _UIN = value; } get{ return _UIN; }}
	public long UserID { set{ _UserID = value; } get{ return _UserID; }}
	public string NickName { set{ _NickName = value; } get{ return _NickName; }}
	public string HeadPic { set{ _HeadPic = value; } get{ return _HeadPic; }}
	public string Sex { set{ _Sex = value; } get{ return _Sex; }}
	public string SignText { set{ _SignText = value; } get{ return _SignText; }}
	public DateTime? Birthday { set{ _Birthday = value; } get{ return _Birthday; }}
	public string Tel { set{ _Tel = value; } get{ return _Tel; }}
	public string Email { set{ _Email = value; } get{ return _Email; }}
	public long ProvinceID { set{ _ProvinceID = value; } get{ return _ProvinceID; }}
	public long CityID { set{ _CityID = value; } get{ return _CityID; }}
	public long AreaID { set{ _AreaID = value; } get{ return _AreaID; }}
	public string Province { set{ _Province = value; } get{ return _Province; }}
	public string City { set{ _City = value; } get{ return _City; }}
	public string Area { set{ _Area = value; } get{ return _Area; }}
	public string Profession { set{ _Profession = value; } get{ return _Profession; }}
	public string School { set{ _School = value; } get{ return _School; }}
	public string HomePage { set{ _HomePage = value; } get{ return _HomePage; }}
	public string Introduce { set{ _Introduce = value; } get{ return _Introduce; }}
	public int CheckState { set{ _CheckState = value; } get{ return _CheckState; }}
	public DateTime LastLoginTime { set{ _LastLoginTime = value; } get{ return _LastLoginTime; }}
	public string LastLoginIP { set{ _LastLoginIP = value; } get{ return _LastLoginIP; }}
	public int LoginTimes { set{ _LoginTimes = value; } get{ return _LoginTimes; }}
	public int LoginState { set{ _LoginState = value; } get{ return _LoginState; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public DateTime ModifyTime { set{ _ModifyTime = value; } get{ return _ModifyTime; }}
}
}


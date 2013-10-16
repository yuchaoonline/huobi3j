
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Users{

	#region Fields
	private long _ID = 0L;
	private int _UserType = 0;
	private string _UIN = String.Empty;
	private string _LoginName = String.Empty;
	private string _LoginPwd = String.Empty;
	private decimal _Money = 0M;
	private decimal _Coins = 0;
	private int _Points = 0;
	private string _AlipayAccount = String.Empty;
	private long _ProvinceID = 0L;
	private long _CityID = 0L;
	private long _AreaID = 0L;
	private string _Province = String.Empty;
	private string _City = String.Empty;
	private string _Area = String.Empty;
	private int _CheckState = 0;
	private string _LastLoginIP = String.Empty;
	private DateTime _LastLogin = new DateTime(1900,1,1);
	private int _LoginTimes = 0;
	private DateTime _RegTime = new DateTime(1900,1,1);
	private string _Name = String.Empty;
	private string _Tel = String.Empty;
	private string _Email = String.Empty;
	#endregion
	
	#region Contructors
	public Users()
	{
	}
	
	public Users
	(
		long iD,
			int userType,
			string uIN,
			string loginName,
			string loginPwd,
			decimal money,
			int coins,
			int points,
			string alipayAccount,
			long provinceID,
			long cityID,
			long areaID,
			string province,
			string city,
			string area,
			int checkState,
			string lastLoginIP,
			DateTime lastLogin,
			int loginTimes,
			DateTime regTime,
			string name,
			string tel,
			string email
	)
	{
		_ID            = iD;
			_UserType      = userType;
			_UIN           = uIN;
			_LoginName     = loginName;
			_LoginPwd      = loginPwd;
			_Money         = money;
			_Coins         = coins;
			_Points        = points;
			_AlipayAccount = alipayAccount;
			_ProvinceID    = provinceID;
			_CityID        = cityID;
			_AreaID        = areaID;
			_Province      = province;
			_City          = city;
			_Area          = area;
			_CheckState    = checkState;
			_LastLoginIP   = lastLoginIP;
			_LastLogin     = lastLogin;
			_LoginTimes    = loginTimes;
			_RegTime       = regTime;
			_Name          = name;
			_Tel           = tel;
			_Email         = email;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public int UserType { set{ _UserType = value; } get{ return _UserType; }}
	public string UIN { set{ _UIN = value; } get{ return _UIN; }}
	public string LoginName { set{ _LoginName = value; } get{ return _LoginName; }}
	public string LoginPwd { set{ _LoginPwd = value; } get{ return _LoginPwd; }}
	public decimal Money { set{ _Money = value; } get{ return _Money; }}
	public decimal Coins { set{ _Coins = value; } get{ return _Coins; }}
	public int Points { set{ _Points = value; } get{ return _Points; }}
	public string AlipayAccount { set{ _AlipayAccount = value; } get{ return _AlipayAccount; }}
	public long ProvinceID { set{ _ProvinceID = value; } get{ return _ProvinceID; }}
	public long CityID { set{ _CityID = value; } get{ return _CityID; }}
	public long AreaID { set{ _AreaID = value; } get{ return _AreaID; }}
	public string Province { set{ _Province = value; } get{ return _Province; }}
	public string City { set{ _City = value; } get{ return _City; }}
	public string Area { set{ _Area = value; } get{ return _Area; }}
	public int CheckState { set{ _CheckState = value; } get{ return _CheckState; }}
	public string LastLoginIP { set{ _LastLoginIP = value; } get{ return _LastLoginIP; }}
	public DateTime LastLogin { set{ _LastLogin = value; } get{ return _LastLogin; }}
	public int LoginTimes { set{ _LoginTimes = value; } get{ return _LoginTimes; }}
	public DateTime RegTime { set{ _RegTime = value; } get{ return _RegTime; }}
	public string Name { set{ _Name = value; } get{ return _Name; }}
	public string Tel { set{ _Tel = value; } get{ return _Tel; }}
	public string Email { set{ _Email = value; } get{ return _Email; }}
}
}


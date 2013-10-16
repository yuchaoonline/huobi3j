
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Corporations{

	#region Fields
	private long _ID = 0L;
	private long _UserID = 0L;
	private string _CorpName = String.Empty;
	private string _Intro = String.Empty;
	private string _LinkMan = String.Empty;
	private string _Tel = String.Empty;
	private string _Property = String.Empty;
	private string _Employee = String.Empty;
	private long _CallingID = 0L;
	private string _Calling = String.Empty;
	private long _ProvinceID = 0L;
	private long _CityID = 0L;
	private long _AreaID = 0L;
	private string _Province = String.Empty;
	private string _City = String.Empty;
	private string _Area = String.Empty;
	private string _Address = String.Empty;
	private string _Service = String.Empty;
	private decimal _Lat = 0M;
	private decimal _Lng = 0M;
	private int _CheckState = 0;
	private int _VisitCount = 0;
	private long _AdminUserID = 0L;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	private DateTime _ModifyTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public Corporations()
	{
	}
	
	public Corporations
	(
		long iD,
			long userID,
			string corpName,
			string intro,
			string linkMan,
			string tel,
			string property,
			string employee,
			long callingID,
			string calling,
			long provinceID,
			long cityID,
			long areaID,
			string province,
			string city,
			string area,
			string address,
			string service,
			decimal lat,
			decimal lng,
			int checkState,
			int visitCount,
			long adminUserID,
			DateTime createTime,
			DateTime modifyTime
	)
	{
		_ID          = iD;
			_UserID      = userID;
			_CorpName    = corpName;
			_Intro       = intro;
			_LinkMan     = linkMan;
			_Tel         = tel;
			_Property    = property;
			_Employee    = employee;
			_CallingID   = callingID;
			_Calling     = calling;
			_ProvinceID  = provinceID;
			_CityID      = cityID;
			_AreaID      = areaID;
			_Province    = province;
			_City        = city;
			_Area        = area;
			_Address     = address;
			_Service     = service;
			_Lat         = lat;
			_Lng         = lng;
			_CheckState  = checkState;
			_VisitCount  = visitCount;
			_AdminUserID = adminUserID;
			_CreateTime  = createTime;
			_ModifyTime  = modifyTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long UserID { set{ _UserID = value; } get{ return _UserID; }}
	public string CorpName { set{ _CorpName = value; } get{ return _CorpName; }}
	public string Intro { set{ _Intro = value; } get{ return _Intro; }}
	public string LinkMan { set{ _LinkMan = value; } get{ return _LinkMan; }}
	public string Tel { set{ _Tel = value; } get{ return _Tel; }}
	public string Property { set{ _Property = value; } get{ return _Property; }}
	public string Employee { set{ _Employee = value; } get{ return _Employee; }}
	public long CallingID { set{ _CallingID = value; } get{ return _CallingID; }}
	public string Calling { set{ _Calling = value; } get{ return _Calling; }}
	public long ProvinceID { set{ _ProvinceID = value; } get{ return _ProvinceID; }}
	public long CityID { set{ _CityID = value; } get{ return _CityID; }}
	public long AreaID { set{ _AreaID = value; } get{ return _AreaID; }}
	public string Province { set{ _Province = value; } get{ return _Province; }}
	public string City { set{ _City = value; } get{ return _City; }}
	public string Area { set{ _Area = value; } get{ return _Area; }}
	public string Address { set{ _Address = value; } get{ return _Address; }}
	public string Service { set{ _Service = value; } get{ return _Service; }}
	public decimal Lat { set{ _Lat = value; } get{ return _Lat; }}
	public decimal Lng { set{ _Lng = value; } get{ return _Lng; }}
	public int CheckState { set{ _CheckState = value; } get{ return _CheckState; }}
	public int VisitCount { set{ _VisitCount = value; } get{ return _VisitCount; }}
	public long AdminUserID { set{ _AdminUserID = value; } get{ return _AdminUserID; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public DateTime ModifyTime { set{ _ModifyTime = value; } get{ return _ModifyTime; }}
}
}


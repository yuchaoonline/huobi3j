
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class HouseInfos{

	#region Fields
	private long _ID = 0L;
	private long _UserID = 0L;
	private string _HomeCode = String.Empty;
	private string _Title = String.Empty;
	private string _Content = String.Empty;
	private int _Properity = 0;
	private int _HouseType = 0;
	private int _HouseStructValue = 0;
	private string _HouseStructText = String.Empty;
	private string _Province = String.Empty;
	private string _City = String.Empty;
	private string _Area = String.Empty;
	private long _ProvinceID = 0L;
	private long _CityID = 0L;
	private long _AreaID = 0L;
	private string _Address = String.Empty;
	private string _BusLine = String.Empty;
	private double _AreaSize = 0D;
	private decimal? _Price = null;
	private DateTime _EndTime = new DateTime(1900,1,1);
	private int _CheckState = 0;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	private DateTime _UpdateTime = new DateTime(1900,1,1);
	private int _VisitCount = 0;
	private double _Lat = 0D;
	private double _Lng = 0D;
	private string _LinkName = String.Empty;
	private string _LinkPhone = String.Empty;
	private string _LinkEmail = String.Empty;
	#endregion
	
	#region Contructors
	public HouseInfos()
	{
	}
	
	public HouseInfos
	(
		long iD,
			long userID,
			string homeCode,
			string title,
			string content,
			int properity,
			int houseType,
			int houseStructValue,
			string houseStructText,
			string province,
			string city,
			string area,
			long provinceID,
			long cityID,
			long areaID,
			string address,
			string busLine,
			double areaSize,
			decimal price,
			DateTime endTime,
			int checkState,
			DateTime createTime,
			DateTime updateTime,
			int visitCount,
			double lat,
			double lng,
			string linkName,
			string linkPhone,
			string linkEmail
	)
	{
		_ID               = iD;
			_UserID           = userID;
			_HomeCode         = homeCode;
			_Title            = title;
			_Content          = content;
			_Properity        = properity;
			_HouseType        = houseType;
			_HouseStructValue = houseStructValue;
			_HouseStructText  = houseStructText;
			_Province         = province;
			_City             = city;
			_Area             = area;
			_ProvinceID       = provinceID;
			_CityID           = cityID;
			_AreaID           = areaID;
			_Address          = address;
			_BusLine          = busLine;
			_AreaSize         = areaSize;
			_Price            = price;
			_EndTime          = endTime;
			_CheckState       = checkState;
			_CreateTime       = createTime;
			_UpdateTime       = updateTime;
			_VisitCount       = visitCount;
			_Lat              = lat;
			_Lng              = lng;
			_LinkName         = linkName;
			_LinkPhone        = linkPhone;
			_LinkEmail        = linkEmail;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long UserID { set{ _UserID = value; } get{ return _UserID; }}
	public string HomeCode { set{ _HomeCode = value; } get{ return _HomeCode; }}
	public string Title { set{ _Title = value; } get{ return _Title; }}
	public string Content { set{ _Content = value; } get{ return _Content; }}
	public int Properity { set{ _Properity = value; } get{ return _Properity; }}
	public int HouseType { set{ _HouseType = value; } get{ return _HouseType; }}
	public int HouseStructValue { set{ _HouseStructValue = value; } get{ return _HouseStructValue; }}
	public string HouseStructText { set{ _HouseStructText = value; } get{ return _HouseStructText; }}
	public string Province { set{ _Province = value; } get{ return _Province; }}
	public string City { set{ _City = value; } get{ return _City; }}
	public string Area { set{ _Area = value; } get{ return _Area; }}
	public long ProvinceID { set{ _ProvinceID = value; } get{ return _ProvinceID; }}
	public long CityID { set{ _CityID = value; } get{ return _CityID; }}
	public long AreaID { set{ _AreaID = value; } get{ return _AreaID; }}
	public string Address { set{ _Address = value; } get{ return _Address; }}
	public string BusLine { set{ _BusLine = value; } get{ return _BusLine; }}
	public double AreaSize { set{ _AreaSize = value; } get{ return _AreaSize; }}
	public decimal? Price { set{ _Price = value; } get{ return _Price; }}
	public DateTime EndTime { set{ _EndTime = value; } get{ return _EndTime; }}
	public int CheckState { set{ _CheckState = value; } get{ return _CheckState; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public DateTime UpdateTime { set{ _UpdateTime = value; } get{ return _UpdateTime; }}
	public int VisitCount { set{ _VisitCount = value; } get{ return _VisitCount; }}
	public double Lat { set{ _Lat = value; } get{ return _Lat; }}
	public double Lng { set{ _Lng = value; } get{ return _Lng; }}
	public string LinkName { set{ _LinkName = value; } get{ return _LinkName; }}
	public string LinkPhone { set{ _LinkPhone = value; } get{ return _LinkPhone; }}
	public string LinkEmail { set{ _LinkEmail = value; } get{ return _LinkEmail; }}
}
}


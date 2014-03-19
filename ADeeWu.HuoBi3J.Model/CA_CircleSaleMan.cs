
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Key_CircleSaleMan{

	#region Fields
	private long _ID = 0L;
	private string _Name = null;
	private long? _UserID = null;
	private string _QQ = null;
	private string _Phone = null;
	private string _CompanyName = null;
	private string _CompanyAddress = null;
	private string _Job = null;
	private double? _PositionX = null;
	private double? _PositionY = null;
	private int? _CheckState = null;
	private DateTime? _ModifyTime = null;
	private DateTime? _CreateTime = null;
	private string _Memo = null;
	#endregion
	
	#region Contructors
	public Key_CircleSaleMan()
	{
	}
	
	public Key_CircleSaleMan
	(
		long iD,
			string name,
			long userID,
			string qQ,
			string phone,
			string companyName,
			string companyAddress,
			string job,
			double positionX,
			double positionY,
			int checkState,
			DateTime modifyTime,
			DateTime createTime,
			string memo
	)
	{
		_ID             = iD;
			_Name           = name;
			_UserID         = userID;
			_QQ             = qQ;
			_Phone          = phone;
			_CompanyName    = companyName;
			_CompanyAddress = companyAddress;
			_Job            = job;
			_PositionX      = positionX;
			_PositionY      = positionY;
			_CheckState     = checkState;
			_ModifyTime     = modifyTime;
			_CreateTime     = createTime;
			_Memo           = memo;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public string Name { set{ _Name = value; } get{ return _Name; }}
	public long? UserID { set{ _UserID = value; } get{ return _UserID; }}
	public string QQ { set{ _QQ = value; } get{ return _QQ; }}
	public string Phone { set{ _Phone = value; } get{ return _Phone; }}
	public string CompanyName { set{ _CompanyName = value; } get{ return _CompanyName; }}
	public string CompanyAddress { set{ _CompanyAddress = value; } get{ return _CompanyAddress; }}
	public string Job { set{ _Job = value; } get{ return _Job; }}
	public double? PositionX { set{ _PositionX = value; } get{ return _PositionX; }}
	public double? PositionY { set{ _PositionY = value; } get{ return _PositionY; }}
	public int? CheckState { set{ _CheckState = value; } get{ return _CheckState; }}
	public DateTime? ModifyTime { set{ _ModifyTime = value; } get{ return _ModifyTime; }}
	public DateTime? CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public string Memo { set{ _Memo = value; } get{ return _Memo; }}
}
}



using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Key_QR_Log{

	#region Fields
	private int _ID = 0;
	private int? _UserID = null;
	private DateTime? _CreateDate = null;
	private int? _SaleManUserID = null;
	private int? _Coin = null;
	private string _Demo = null;
	#endregion
	
	#region Contructors
	public Key_QR_Log()
	{
	}
	
	public Key_QR_Log
	(
		int iD,
			int userID,
			DateTime createDate,
			int saleManUserID,
			int coin,
			string demo
	)
	{
		_ID            = iD;
			_UserID        = userID;
			_CreateDate    = createDate;
			_SaleManUserID = saleManUserID;
			_Coin          = coin;
			_Demo          = demo;
			
	}
	#endregion
		
	public int ID { set{ _ID = value; } get{ return _ID; }}
	public int? UserID { set{ _UserID = value; } get{ return _UserID; }}
	public DateTime? CreateDate { set{ _CreateDate = value; } get{ return _CreateDate; }}
	public int? SaleManUserID { set{ _SaleManUserID = value; } get{ return _SaleManUserID; }}
	public int? Coin { set{ _Coin = value; } get{ return _Coin; }}
	public string Demo { set{ _Demo = value; } get{ return _Demo; }}
}
}


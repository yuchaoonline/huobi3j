
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Coupons_CashWhenFee_ShareFriendLog{

	#region Fields
	private int _ID = 0;
	private int? _CodeID = null;
	private int? _UserID = null;
	private DateTime? _DateTime = null;
	#endregion
	
	#region Contructors
	public Coupons_CashWhenFee_ShareFriendLog()
	{
	}
	
	public Coupons_CashWhenFee_ShareFriendLog
	(
		int iD,
			int codeID,
			int userID,
			DateTime dateTime
	)
	{
		_ID       = iD;
			_CodeID   = codeID;
			_UserID   = userID;
			_DateTime = dateTime;
			
	}
	#endregion
		
	public int ID { set{ _ID = value; } get{ return _ID; }}
	public int? CodeID { set{ _CodeID = value; } get{ return _CodeID; }}
	public int? UserID { set{ _UserID = value; } get{ return _UserID; }}
	public DateTime? DateTime { set{ _DateTime = value; } get{ return _DateTime; }}
}
}


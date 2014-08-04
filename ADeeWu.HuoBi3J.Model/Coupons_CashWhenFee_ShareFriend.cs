
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Coupons_CashWhenFee_ShareFriend{

	#region Fields
	private int _ID = 0;
	private int? _CodeID = null;
	private DateTime? _DateTime = null;
	private int? _ShareType = null;
	#endregion
	
	#region Contructors
	public Coupons_CashWhenFee_ShareFriend()
	{
	}
	
	public Coupons_CashWhenFee_ShareFriend
	(
		int iD,
			int codeID,
			DateTime dateTime,
			int shareType
	)
	{
		_ID        = iD;
			_CodeID    = codeID;
			_DateTime  = dateTime;
			_ShareType = shareType;
			
	}
	#endregion
		
	public int ID { set{ _ID = value; } get{ return _ID; }}
	public int? CodeID { set{ _CodeID = value; } get{ return _CodeID; }}
	public DateTime? DateTime { set{ _DateTime = value; } get{ return _DateTime; }}
	public int? ShareType { set{ _ShareType = value; } get{ return _ShareType; }}
}
}


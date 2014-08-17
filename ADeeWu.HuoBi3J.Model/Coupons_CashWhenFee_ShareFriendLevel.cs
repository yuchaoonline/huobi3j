
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Coupons_CashWhenFee_ShareFriendLevel{

	#region Fields
	private int _ID = 0;
	private string _Count = null;
	private decimal? _Money = null;
	private int? _CodeID = null;
	#endregion
	
	#region Contructors
	public Coupons_CashWhenFee_ShareFriendLevel()
	{
	}
	
	public Coupons_CashWhenFee_ShareFriendLevel
	(
		int iD,
			string count,
			decimal money,
			int codeID
	)
	{
		_ID     = iD;
			_Count  = count;
			_Money  = money;
			_CodeID = codeID;
			
	}
	#endregion
		
	public int ID { set{ _ID = value; } get{ return _ID; }}
	public string Count { set{ _Count = value; } get{ return _Count; }}
	public decimal? Money { set{ _Money = value; } get{ return _Money; }}
	public int? CodeID { set{ _CodeID = value; } get{ return _CodeID; }}
}
}


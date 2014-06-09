
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Coupons_CashWhenFee_CodeLog{

	#region Fields
	private int _ID = 0;
	private string _UseCode = null;
	private int? _CodeID = null;
	private int? _UseCount = null;
	private DateTime? _CreateTime = null;
	#endregion
	
	#region Contructors
	public Coupons_CashWhenFee_CodeLog()
	{
	}
	
	public Coupons_CashWhenFee_CodeLog
	(
		int iD,
			string useCode,
			int codeID,
			int useCount,
			DateTime createTime
	)
	{
		_ID         = iD;
			_UseCode    = useCode;
			_CodeID     = codeID;
			_UseCount   = useCount;
			_CreateTime = createTime;
			
	}
	#endregion
		
	public int ID { set{ _ID = value; } get{ return _ID; }}
	public string UseCode { set{ _UseCode = value; } get{ return _UseCode; }}
	public int? CodeID { set{ _CodeID = value; } get{ return _CodeID; }}
	public int? UseCount { set{ _UseCount = value; } get{ return _UseCount; }}
	public DateTime? CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
}
}


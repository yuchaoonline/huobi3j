
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class User_DealHistories{

	#region Fields
	private long _ID = 0L;
	private long? _UserID = null;
	private decimal _InMoney = 0M;
	private decimal _OutMoney = 0M;
	private decimal _Balance = 0M;
	private string _Notes = String.Empty;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public User_DealHistories()
	{
	}
	
	public User_DealHistories
	(
		long iD,
			long userID,
			decimal inMoney,
			decimal outMoney,
			decimal balance,
			string notes,
			DateTime createTime
	)
	{
		_ID         = iD;
			_UserID     = userID;
			_InMoney    = inMoney;
			_OutMoney   = outMoney;
			_Balance    = balance;
			_Notes      = notes;
			_CreateTime = createTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long? UserID { set{ _UserID = value; } get{ return _UserID; }}
	public decimal InMoney { set{ _InMoney = value; } get{ return _InMoney; }}
	public decimal OutMoney { set{ _OutMoney = value; } get{ return _OutMoney; }}
	public decimal Balance { set{ _Balance = value; } get{ return _Balance; }}
	public string Notes { set{ _Notes = value; } get{ return _Notes; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
}
}


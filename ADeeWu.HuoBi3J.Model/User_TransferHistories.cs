
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class User_TransferHistories{

	#region Fields
	private long _ID = 0L;
	private long? _UserID = null;
	private string _AlipayAccount = String.Empty;
	private decimal _Money = 0M;
	private string _Notes = String.Empty;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public User_TransferHistories()
	{
	}
	
	public User_TransferHistories
	(
		long iD,
			long userID,
			string alipayAccount,
			decimal money,
			string notes,
			DateTime createTime
	)
	{
		_ID            = iD;
			_UserID        = userID;
			_AlipayAccount = alipayAccount;
			_Money         = money;
			_Notes         = notes;
			_CreateTime    = createTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long? UserID { set{ _UserID = value; } get{ return _UserID; }}
	public string AlipayAccount { set{ _AlipayAccount = value; } get{ return _AlipayAccount; }}
	public decimal Money { set{ _Money = value; } get{ return _Money; }}
	public string Notes { set{ _Notes = value; } get{ return _Notes; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
}
}


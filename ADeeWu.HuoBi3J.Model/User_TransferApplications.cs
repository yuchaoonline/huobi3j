
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class User_TransferApplications{

	#region Fields
	private long _ID = 0L;
	private long _UserID = 0L;
	private decimal _TransferMoney = 0M;
	private string _AlipayAccount = String.Empty;
	private int _CheckState = 0;
	private string _Notes = String.Empty;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	private DateTime _ModifyTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public User_TransferApplications()
	{
	}
	
	public User_TransferApplications
	(
		long iD,
			long userID,
			decimal transferMoney,
			string alipayAccount,
			int checkState,
			string notes,
			DateTime createTime,
			DateTime modifyTime
	)
	{
		_ID            = iD;
			_UserID        = userID;
			_TransferMoney = transferMoney;
			_AlipayAccount = alipayAccount;
			_CheckState    = checkState;
			_Notes         = notes;
			_CreateTime    = createTime;
			_ModifyTime    = modifyTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long UserID { set{ _UserID = value; } get{ return _UserID; }}
	public decimal TransferMoney { set{ _TransferMoney = value; } get{ return _TransferMoney; }}
	public string AlipayAccount { set{ _AlipayAccount = value; } get{ return _AlipayAccount; }}
	public int CheckState { set{ _CheckState = value; } get{ return _CheckState; }}
	public string Notes { set{ _Notes = value; } get{ return _Notes; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public DateTime ModifyTime { set{ _ModifyTime = value; } get{ return _ModifyTime; }}
}
}


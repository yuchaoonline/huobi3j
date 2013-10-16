
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class CT_CashTickets{

	#region Fields
	private long _ID = 0L;
	private string _SerialNum = String.Empty;
	private string _ValidCode = String.Empty;
	private long _CorpID = 0L;
	private string _Summary = String.Empty;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	private int _CheckState = 0;
	private DateTime _ModifyTime = new DateTime(1900,1,1);
	private double _Money = 0D;
	#endregion
	
	#region Contructors
	public CT_CashTickets()
	{
	}
	
	public CT_CashTickets
	(
		long iD,
			string serialNum,
			string validCode,
			long corpID,
			string summary,
			DateTime createTime,
			int checkState,
			DateTime modifyTime,
			double money
	)
	{
		_ID         = iD;
			_SerialNum  = serialNum;
			_ValidCode  = validCode;
			_CorpID     = corpID;
			_Summary    = summary;
			_CreateTime = createTime;
			_CheckState = checkState;
			_ModifyTime = modifyTime;
			_Money      = money;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public string SerialNum { set{ _SerialNum = value; } get{ return _SerialNum; }}
	public string ValidCode { set{ _ValidCode = value; } get{ return _ValidCode; }}
	public long CorpID { set{ _CorpID = value; } get{ return _CorpID; }}
	public string Summary { set{ _Summary = value; } get{ return _Summary; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public int CheckState { set{ _CheckState = value; } get{ return _CheckState; }}
	public DateTime ModifyTime { set{ _ModifyTime = value; } get{ return _ModifyTime; }}
	public double Money { set{ _Money = value; } get{ return _Money; }}
}
}


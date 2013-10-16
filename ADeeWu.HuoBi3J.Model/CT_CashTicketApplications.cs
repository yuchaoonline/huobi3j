
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class CT_CashTicketApplications{

	#region Fields
	private long _ID = 0L;
	private long _UserID = 0L;
	private long _CorpID = 0L;
	private long _CashTicketID = 0L;
	private string _SerialNum = String.Empty;
	private string _ValidCode = String.Empty;
	private string _CorpName = String.Empty;
	private DateTime _CostDate = new DateTime(1900,1,1);
	private decimal _ReturnMoney = 0M;
	private string _Summary = String.Empty;
	private int _CheckState = 0;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	private DateTime _ModifyTime = new DateTime(1900,1,1);
	private string _Notes = String.Empty;
	#endregion
	
	#region Contructors
	public CT_CashTicketApplications()
	{
	}
	
	public CT_CashTicketApplications
	(
		long iD,
			long userID,
			long corpID,
			long cashTicketID,
			string serialNum,
			string validCode,
			string corpName,
			DateTime costDate,
			decimal returnMoney,
			string summary,
			int checkState,
			DateTime createTime,
			DateTime modifyTime,
			string notes
	)
	{
		_ID           = iD;
			_UserID       = userID;
			_CorpID       = corpID;
			_CashTicketID = cashTicketID;
			_SerialNum    = serialNum;
			_ValidCode    = validCode;
			_CorpName     = corpName;
			_CostDate     = costDate;
			_ReturnMoney  = returnMoney;
			_Summary      = summary;
			_CheckState   = checkState;
			_CreateTime   = createTime;
			_ModifyTime   = modifyTime;
			_Notes        = notes;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long UserID { set{ _UserID = value; } get{ return _UserID; }}
	public long CorpID { set{ _CorpID = value; } get{ return _CorpID; }}
	public long CashTicketID { set{ _CashTicketID = value; } get{ return _CashTicketID; }}
	public string SerialNum { set{ _SerialNum = value; } get{ return _SerialNum; }}
	public string ValidCode { set{ _ValidCode = value; } get{ return _ValidCode; }}
	public string CorpName { set{ _CorpName = value; } get{ return _CorpName; }}
	public DateTime CostDate { set{ _CostDate = value; } get{ return _CostDate; }}
	public decimal ReturnMoney { set{ _ReturnMoney = value; } get{ return _ReturnMoney; }}
	public string Summary { set{ _Summary = value; } get{ return _Summary; }}
	public int CheckState { set{ _CheckState = value; } get{ return _CheckState; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public DateTime ModifyTime { set{ _ModifyTime = value; } get{ return _ModifyTime; }}
	public string Notes { set{ _Notes = value; } get{ return _Notes; }}
}
}


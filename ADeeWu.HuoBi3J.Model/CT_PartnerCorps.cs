
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class CT_PartnerCorps{

	#region Fields
	private long _ID = 0L;
	private long _CorpID = 0L;
	private int _OfferPercent = 0;
	private string _Contract = String.Empty;
	private long _AdminUserID = 0L;
	private int _CheckState = 0;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	private DateTime _ModifyTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public CT_PartnerCorps()
	{
	}
	
	public CT_PartnerCorps
	(
		long iD,
			long corpID,
			int offerPercent,
			string contract,
			long adminUserID,
			int checkState,
			DateTime createTime,
			DateTime modifyTime
	)
	{
		_ID           = iD;
			_CorpID       = corpID;
			_OfferPercent = offerPercent;
			_Contract     = contract;
			_AdminUserID  = adminUserID;
			_CheckState   = checkState;
			_CreateTime   = createTime;
			_ModifyTime   = modifyTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long CorpID { set{ _CorpID = value; } get{ return _CorpID; }}
	public int OfferPercent { set{ _OfferPercent = value; } get{ return _OfferPercent; }}
	public string Contract { set{ _Contract = value; } get{ return _Contract; }}
	public long AdminUserID { set{ _AdminUserID = value; } get{ return _AdminUserID; }}
	public int CheckState { set{ _CheckState = value; } get{ return _CheckState; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public DateTime ModifyTime { set{ _ModifyTime = value; } get{ return _ModifyTime; }}
}
}


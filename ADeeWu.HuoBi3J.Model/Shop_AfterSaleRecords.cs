
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Shop_AfterSaleRecords{

	#region Fields
	private long _ID = 0L;
	private long _OrderDetailID = 0L;
	private long _ServerCorpID = 0L;
	private long _ServerCorpAgentID = 0L;
	private int _Result = 0;
	private string _Note = String.Empty;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	private DateTime _ModifyTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public Shop_AfterSaleRecords()
	{
	}
	
	public Shop_AfterSaleRecords
	(
		long iD,
			long orderDetailID,
			long serverCorpID,
			long serverCorpAgentID,
			int result,
			string note,
			DateTime createTime,
			DateTime modifyTime
	)
	{
		_ID                = iD;
			_OrderDetailID     = orderDetailID;
			_ServerCorpID      = serverCorpID;
			_ServerCorpAgentID = serverCorpAgentID;
			_Result            = result;
			_Note              = note;
			_CreateTime        = createTime;
			_ModifyTime        = modifyTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long OrderDetailID { set{ _OrderDetailID = value; } get{ return _OrderDetailID; }}
	public long ServerCorpID { set{ _ServerCorpID = value; } get{ return _ServerCorpID; }}
	public long ServerCorpAgentID { set{ _ServerCorpAgentID = value; } get{ return _ServerCorpAgentID; }}
	public int Result { set{ _Result = value; } get{ return _Result; }}
	public string Note { set{ _Note = value; } get{ return _Note; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public DateTime ModifyTime { set{ _ModifyTime = value; } get{ return _ModifyTime; }}
}
}


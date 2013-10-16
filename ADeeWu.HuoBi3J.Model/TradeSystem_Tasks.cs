
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class TradeSystem_Tasks{

	#region Fields
	private long _ID = 0L;
	private decimal _TotalFee = 0M;
	private long _FromUserID = 0L;
	private long _ToUserID = 0L;
	private int? _TaskState = null;
	private string _Notes = String.Empty;
	private string _Result = String.Empty;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	private DateTime? _ModifyTime = null;
	#endregion
	
	#region Contructors
	public TradeSystem_Tasks()
	{
	}
	
	public TradeSystem_Tasks
	(
		long iD,
			decimal totalFee,
			long fromUserID,
			long toUserID,
			int taskState,
			string notes,
			string result,
			DateTime createTime,
			DateTime modifyTime
	)
	{
		_ID         = iD;
			_TotalFee   = totalFee;
			_FromUserID = fromUserID;
			_ToUserID   = toUserID;
			_TaskState  = taskState;
			_Notes      = notes;
			_Result     = result;
			_CreateTime = createTime;
			_ModifyTime = modifyTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public decimal TotalFee { set{ _TotalFee = value; } get{ return _TotalFee; }}
	public long FromUserID { set{ _FromUserID = value; } get{ return _FromUserID; }}
	public long ToUserID { set{ _ToUserID = value; } get{ return _ToUserID; }}
	public int? TaskState { set{ _TaskState = value; } get{ return _TaskState; }}
	public string Notes { set{ _Notes = value; } get{ return _Notes; }}
	public string Result { set{ _Result = value; } get{ return _Result; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public DateTime? ModifyTime { set{ _ModifyTime = value; } get{ return _ModifyTime; }}
}
}


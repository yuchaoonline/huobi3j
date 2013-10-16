
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class TradeSystem_AlipayTrades{

	#region Fields
	private long _ID = 0L;
	private string _OrderCode = String.Empty;
	private string _AlipayOrder = String.Empty;
	private long _UserID = 0L;
	private decimal _TotalFee = 0M;
	private string _Notes = String.Empty;
	private int _OrderState = 0;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	private DateTime? _ModifyTime = null;
	#endregion
	
	#region Contructors
	public TradeSystem_AlipayTrades()
	{
	}
	
	public TradeSystem_AlipayTrades
	(
		long iD,
			string orderCode,
			string alipayOrder,
			long userID,
			decimal totalFee,
			string notes,
			int orderState,
			DateTime createTime,
			DateTime modifyTime
	)
	{
		_ID          = iD;
			_OrderCode   = orderCode;
			_AlipayOrder = alipayOrder;
			_UserID      = userID;
			_TotalFee    = totalFee;
			_Notes       = notes;
			_OrderState  = orderState;
			_CreateTime  = createTime;
			_ModifyTime  = modifyTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public string OrderCode { set{ _OrderCode = value; } get{ return _OrderCode; }}
	public string AlipayOrder { set{ _AlipayOrder = value; } get{ return _AlipayOrder; }}
	public long UserID { set{ _UserID = value; } get{ return _UserID; }}
	public decimal TotalFee { set{ _TotalFee = value; } get{ return _TotalFee; }}
	public string Notes { set{ _Notes = value; } get{ return _Notes; }}
	public int OrderState { set{ _OrderState = value; } get{ return _OrderState; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public DateTime? ModifyTime { set{ _ModifyTime = value; } get{ return _ModifyTime; }}
}
}


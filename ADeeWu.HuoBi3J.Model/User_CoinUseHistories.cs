
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class User_CoinUseHistories{

	#region Fields
	private long _ID = 0L;
	private long? _UserID = null;
	private decimal _InCoin = 0M;
	private decimal _OutCoin = 0M;
	private decimal _Remain = 0M;
	private string _Notes = String.Empty;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public User_CoinUseHistories()
	{
	}
	
	public User_CoinUseHistories
	(
		long iD,
			long userID,
			decimal inCoin,
			decimal outCoin,
			decimal remain,
			string notes,
			DateTime createTime
	)
	{
		_ID         = iD;
			_UserID     = userID;
			_InCoin     = inCoin;
			_OutCoin    = outCoin;
			_Remain     = remain;
			_Notes      = notes;
			_CreateTime = createTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long? UserID { set{ _UserID = value; } get{ return _UserID; }}
	public decimal InCoin { set{ _InCoin = value; } get{ return _InCoin; }}
	public decimal OutCoin { set{ _OutCoin = value; } get{ return _OutCoin; }}
	public decimal Remain { set{ _Remain = value; } get{ return _Remain; }}
	public string Notes { set{ _Notes = value; } get{ return _Notes; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
}
}


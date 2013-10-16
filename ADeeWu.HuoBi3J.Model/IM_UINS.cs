
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class IM_UINS{

	#region Fields
	private long _ID = 0L;
	private string _UIN = String.Empty;
	private bool _HasUsed = false;
	private bool _IsRecommend = false;
	private int _Sequence = 0;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public IM_UINS()
	{
	}
	
	public IM_UINS
	(
		long iD,
			string uIN,
			bool hasUsed,
			bool isRecommend,
			int sequence,
			DateTime createTime
	)
	{
		_ID          = iD;
			_UIN         = uIN;
			_HasUsed     = hasUsed;
			_IsRecommend = isRecommend;
			_Sequence    = sequence;
			_CreateTime  = createTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public string UIN { set{ _UIN = value; } get{ return _UIN; }}
	public bool HasUsed { set{ _HasUsed = value; } get{ return _HasUsed; }}
	public bool IsRecommend { set{ _IsRecommend = value; } get{ return _IsRecommend; }}
	public int Sequence { set{ _Sequence = value; } get{ return _Sequence; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
}
}


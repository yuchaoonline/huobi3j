
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class CP_KeywordIndex{

	#region Fields
	private long _ID = 0L;
	private string _Keyword = String.Empty;
	private long _PromotionID = 0L;
	private bool _IsHidden = false;
	private bool _IsRankIndex = false;
	private int _Sequence = 0;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public CP_KeywordIndex()
	{
	}
	
	public CP_KeywordIndex
	(
		long iD,
			string keyword,
			long promotionID,
			bool isHidden,
			bool isRankIndex,
			int sequence,
			DateTime createTime
	)
	{
		_ID          = iD;
			_Keyword     = keyword;
			_PromotionID = promotionID;
			_IsHidden    = isHidden;
			_IsRankIndex = isRankIndex;
			_Sequence    = sequence;
			_CreateTime  = createTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public string Keyword { set{ _Keyword = value; } get{ return _Keyword; }}
	public long PromotionID { set{ _PromotionID = value; } get{ return _PromotionID; }}
	public bool IsHidden { set{ _IsHidden = value; } get{ return _IsHidden; }}
	public bool IsRankIndex { set{ _IsRankIndex = value; } get{ return _IsRankIndex; }}
	public int Sequence { set{ _Sequence = value; } get{ return _Sequence; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
}
}


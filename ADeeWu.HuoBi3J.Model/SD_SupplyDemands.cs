
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class SD_SupplyDemands{

	#region Fields
	private long _ID = 0L;
	private long _UserID = 0L;
	private long _BidderID = 0L;
	private int _Status = 0;
	private string _Title = String.Empty;
	private string _Summary = String.Empty;
	private string _Content = String.Empty;
	private bool _IsRecommend = false;
	private bool _IsHidden = false;
	private int _VisitCount = 0;
	private int _CheckState = 0;
	private DateTime _EndTime = new DateTime(1900,1,1);
	private DateTime _CreateTime = new DateTime(1900,1,1);
	private DateTime _ModifyTime = new DateTime(1900,1,1);
	private DateTime _RefreshTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public SD_SupplyDemands()
	{
	}
	
	public SD_SupplyDemands
	(
		long iD,
			long userID,
			long bidderID,
			int status,
			string title,
			string summary,
			string content,
			bool isRecommend,
			bool isHidden,
			int visitCount,
			int checkState,
			DateTime endTime,
			DateTime createTime,
			DateTime modifyTime,
			DateTime refreshTime
	)
	{
		_ID          = iD;
			_UserID      = userID;
			_BidderID    = bidderID;
			_Status      = status;
			_Title       = title;
			_Summary     = summary;
			_Content     = content;
			_IsRecommend = isRecommend;
			_IsHidden    = isHidden;
			_VisitCount  = visitCount;
			_CheckState  = checkState;
			_EndTime     = endTime;
			_CreateTime  = createTime;
			_ModifyTime  = modifyTime;
			_RefreshTime = refreshTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long UserID { set{ _UserID = value; } get{ return _UserID; }}
	public long BidderID { set{ _BidderID = value; } get{ return _BidderID; }}
	public int Status { set{ _Status = value; } get{ return _Status; }}
	public string Title { set{ _Title = value; } get{ return _Title; }}
	public string Summary { set{ _Summary = value; } get{ return _Summary; }}
	public string Content { set{ _Content = value; } get{ return _Content; }}
	public bool IsRecommend { set{ _IsRecommend = value; } get{ return _IsRecommend; }}
	public bool IsHidden { set{ _IsHidden = value; } get{ return _IsHidden; }}
	public int VisitCount { set{ _VisitCount = value; } get{ return _VisitCount; }}
	public int CheckState { set{ _CheckState = value; } get{ return _CheckState; }}
	public DateTime EndTime { set{ _EndTime = value; } get{ return _EndTime; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public DateTime ModifyTime { set{ _ModifyTime = value; } get{ return _ModifyTime; }}
	public DateTime RefreshTime { set{ _RefreshTime = value; } get{ return _RefreshTime; }}
}
}


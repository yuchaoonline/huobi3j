
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class CI_Photos{

	#region Fields
	private long _ID = 0L;
	private long _AlbumID = 0L;
	private long _CorpID = 0L;
	private string _Title = String.Empty;
	private string _Summary = String.Empty;
	private string _Content = String.Empty;
	private int _Sequence = 0;
	private bool _IsRecommend = false;
	private bool _IsHidden = false;
	private int _VisitCount = 0;
	private int _CheckState = 0;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	private DateTime _ModifyTime = new DateTime(1900,1,1);
	private string _URL = String.Empty;
	#endregion
	
	#region Contructors
	public CI_Photos()
	{
	}
	
	public CI_Photos
	(
		long iD,
			long albumID,
			long corpID,
			string title,
			string summary,
			string content,
			int sequence,
			bool isRecommend,
			bool isHidden,
			int visitCount,
			int checkState,
			DateTime createTime,
			DateTime modifyTime,
			string uRL
	)
	{
		_ID          = iD;
			_AlbumID     = albumID;
			_CorpID      = corpID;
			_Title       = title;
			_Summary     = summary;
			_Content     = content;
			_Sequence    = sequence;
			_IsRecommend = isRecommend;
			_IsHidden    = isHidden;
			_VisitCount  = visitCount;
			_CheckState  = checkState;
			_CreateTime  = createTime;
			_ModifyTime  = modifyTime;
			_URL         = uRL;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long AlbumID { set{ _AlbumID = value; } get{ return _AlbumID; }}
	public long CorpID { set{ _CorpID = value; } get{ return _CorpID; }}
	public string Title { set{ _Title = value; } get{ return _Title; }}
	public string Summary { set{ _Summary = value; } get{ return _Summary; }}
	public string Content { set{ _Content = value; } get{ return _Content; }}
	public int Sequence { set{ _Sequence = value; } get{ return _Sequence; }}
	public bool IsRecommend { set{ _IsRecommend = value; } get{ return _IsRecommend; }}
	public bool IsHidden { set{ _IsHidden = value; } get{ return _IsHidden; }}
	public int VisitCount { set{ _VisitCount = value; } get{ return _VisitCount; }}
	public int CheckState { set{ _CheckState = value; } get{ return _CheckState; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public DateTime ModifyTime { set{ _ModifyTime = value; } get{ return _ModifyTime; }}
	public string URL { set{ _URL = value; } get{ return _URL; }}
}
}


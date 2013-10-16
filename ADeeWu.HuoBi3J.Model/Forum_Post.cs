
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Forum_Post{

	#region Fields
	private long _ID = 0L;
	private long? _UserID = null;
	private string _Location = null;
	private string _Title = null;
	private string _PostContent = null;
	private int? _PostType = null;
	private int? _CurrentReplyCount = null;
	private int? _CostScore = null;
	private long? _TotalReply = null;
	private DateTime? _PostDate = null;
	private int? _Status = null;
	private int? _PageID = null;
	private decimal? _Balance = null;
	private bool? _IsCostScore = null;
	#endregion
	
	#region Contructors
	public Forum_Post()
	{
	}
	
	public Forum_Post
	(
		long iD,
			long userID,
			string location,
			string title,
			string postContent,
			int postType,
			int currentReplyCount,
			int costScore,
			long totalReply,
			DateTime postDate,
			int status,
			int pageID,
			decimal balance,
			bool isCostScore
	)
	{
		_ID                = iD;
			_UserID            = userID;
			_Location          = location;
			_Title             = title;
			_PostContent       = postContent;
			_PostType          = postType;
			_CurrentReplyCount = currentReplyCount;
			_CostScore         = costScore;
			_TotalReply        = totalReply;
			_PostDate          = postDate;
			_Status            = status;
			_PageID            = pageID;
			_Balance           = balance;
			_IsCostScore       = isCostScore;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long? UserID { set{ _UserID = value; } get{ return _UserID; }}
	public string Location { set{ _Location = value; } get{ return _Location; }}
	public string Title { set{ _Title = value; } get{ return _Title; }}
	public string PostContent { set{ _PostContent = value; } get{ return _PostContent; }}
	public int? PostType { set{ _PostType = value; } get{ return _PostType; }}
	public int? CurrentReplyCount { set{ _CurrentReplyCount = value; } get{ return _CurrentReplyCount; }}
	public int? CostScore { set{ _CostScore = value; } get{ return _CostScore; }}
	public long? TotalReply { set{ _TotalReply = value; } get{ return _TotalReply; }}
	public DateTime? PostDate { set{ _PostDate = value; } get{ return _PostDate; }}
	public int? Status { set{ _Status = value; } get{ return _Status; }}
	public int? PageID { set{ _PageID = value; } get{ return _PageID; }}
	public decimal? Balance { set{ _Balance = value; } get{ return _Balance; }}
	public bool? IsCostScore { set{ _IsCostScore = value; } get{ return _IsCostScore; }}
}
}


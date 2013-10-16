
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Forum_Reply{

	#region Fields
	private long _ID = 0L;
	private long? _PostID = null;
	private long? _UserID = null;
	private string _ReplyContent = null;
	private string _IP = null;
	private DateTime? _ReplyDate = null;
	private int? _Status = null;
	#endregion
	
	#region Contructors
	public Forum_Reply()
	{
	}
	
	public Forum_Reply
	(
		long iD,
			long postID,
			long userID,
			string replyContent,
			string iP,
			DateTime replyDate,
			int status
	)
	{
		_ID           = iD;
			_PostID       = postID;
			_UserID       = userID;
			_ReplyContent = replyContent;
			_IP           = iP;
			_ReplyDate    = replyDate;
			_Status       = status;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long? PostID { set{ _PostID = value; } get{ return _PostID; }}
	public long? UserID { set{ _UserID = value; } get{ return _UserID; }}
	public string ReplyContent { set{ _ReplyContent = value; } get{ return _ReplyContent; }}
	public string IP { set{ _IP = value; } get{ return _IP; }}
	public DateTime? ReplyDate { set{ _ReplyDate = value; } get{ return _ReplyDate; }}
	public int? Status { set{ _Status = value; } get{ return _Status; }}
}
}


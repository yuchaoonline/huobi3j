
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class CP_Keyword_Search{

	#region Fields
	private long _ID = 0L;
	private string _Keyword = null;
	private bool? _IsHidden = null;
	private DateTime? _CreateTime = null;
	private long? _UserID = null;
	#endregion
	
	#region Contructors
	public CP_Keyword_Search()
	{
	}
	
	public CP_Keyword_Search
	(
		long iD,
			string keyword,
			bool isHidden,
			DateTime createTime,
			long userID
	)
	{
		_ID         = iD;
			_Keyword    = keyword;
			_IsHidden   = isHidden;
			_CreateTime = createTime;
			_UserID     = userID;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public string Keyword { set{ _Keyword = value; } get{ return _Keyword; }}
	public bool? IsHidden { set{ _IsHidden = value; } get{ return _IsHidden; }}
	public DateTime? CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public long? UserID { set{ _UserID = value; } get{ return _UserID; }}
}
}


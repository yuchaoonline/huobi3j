
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class CP_Keyword_Result{

	#region Fields
	private long _ID = 0L;
	private long? _KeywordID = null;
	private string _Title = null;
	private string _Content = null;
	private string _Link = null;
	#endregion
	
	#region Contructors
	public CP_Keyword_Result()
	{
	}
	
	public CP_Keyword_Result
	(
		long iD,
			long keywordID,
			string title,
			string content,
			string link
	)
	{
		_ID        = iD;
			_KeywordID = keywordID;
			_Title     = title;
			_Content   = content;
			_Link      = link;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long? KeywordID { set{ _KeywordID = value; } get{ return _KeywordID; }}
	public string Title { set{ _Title = value; } get{ return _Title; }}
	public string Content { set{ _Content = value; } get{ return _Content; }}
	public string Link { set{ _Link = value; } get{ return _Link; }}
}
}



using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class CA_HireInfos{

	#region Fields
	private long _ID = 0L;
	private long _CorpID = 0L;
	private string _Title = String.Empty;
	private string _Content = String.Empty;
	private int _VisitCount = 0;
	private int _CheckState = 0;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	private DateTime _ModifyTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public CA_HireInfos()
	{
	}
	
	public CA_HireInfos
	(
		long iD,
			long corpID,
			string title,
			string content,
			int visitCount,
			int checkState,
			DateTime createTime,
			DateTime modifyTime
	)
	{
		_ID         = iD;
			_CorpID     = corpID;
			_Title      = title;
			_Content    = content;
			_VisitCount = visitCount;
			_CheckState = checkState;
			_CreateTime = createTime;
			_ModifyTime = modifyTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long CorpID { set{ _CorpID = value; } get{ return _CorpID; }}
	public string Title { set{ _Title = value; } get{ return _Title; }}
	public string Content { set{ _Content = value; } get{ return _Content; }}
	public int VisitCount { set{ _VisitCount = value; } get{ return _VisitCount; }}
	public int CheckState { set{ _CheckState = value; } get{ return _CheckState; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public DateTime ModifyTime { set{ _ModifyTime = value; } get{ return _ModifyTime; }}
}
}


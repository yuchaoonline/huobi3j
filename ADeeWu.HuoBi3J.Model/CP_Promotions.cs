
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class CP_Promotions{

	#region Fields
	private long _ID = 0L;
	private long _UserID = 0L;
	private long _CorpID = 0L;
	private string _Title = String.Empty;
	private string _Summary = String.Empty;
	private string _Url = String.Empty;
	private long _AdminUserID = 0L;
	private bool _IsHidden = false;
	private int _CheckState = 0;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	private DateTime _ModifyTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public CP_Promotions()
	{
	}
	
	public CP_Promotions
	(
		long iD,
			long userID,
			long corpID,
			string title,
			string summary,
			string url,
			long adminUserID,
			bool isHidden,
			int checkState,
			DateTime createTime,
			DateTime modifyTime
	)
	{
		_ID          = iD;
			_UserID      = userID;
			_CorpID      = corpID;
			_Title       = title;
			_Summary     = summary;
			_Url         = url;
			_AdminUserID = adminUserID;
			_IsHidden    = isHidden;
			_CheckState  = checkState;
			_CreateTime  = createTime;
			_ModifyTime  = modifyTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long UserID { set{ _UserID = value; } get{ return _UserID; }}
	public long CorpID { set{ _CorpID = value; } get{ return _CorpID; }}
	public string Title { set{ _Title = value; } get{ return _Title; }}
	public string Summary { set{ _Summary = value; } get{ return _Summary; }}
	public string Url { set{ _Url = value; } get{ return _Url; }}
	public long AdminUserID { set{ _AdminUserID = value; } get{ return _AdminUserID; }}
	public bool IsHidden { set{ _IsHidden = value; } get{ return _IsHidden; }}
	public int CheckState { set{ _CheckState = value; } get{ return _CheckState; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public DateTime ModifyTime { set{ _ModifyTime = value; } get{ return _ModifyTime; }}
}
}


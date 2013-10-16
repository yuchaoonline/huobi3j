
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class CP_Keyword_AD{

	#region Fields
	private long _ID = 0L;
	private string _Name = null;
	private string _Content = null;
	private string _Link = null;
	private long? _UserID = null;
	private bool? _IsPass = null;
	#endregion
	
	#region Contructors
	public CP_Keyword_AD()
	{
	}
	
	public CP_Keyword_AD
	(
		long iD,
			string name,
			string content,
			string link,
			long userID,
			bool isPass
	)
	{
		_ID      = iD;
			_Name    = name;
			_Content = content;
			_Link    = link;
			_UserID  = userID;
			_IsPass  = isPass;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public string Name { set{ _Name = value; } get{ return _Name; }}
	public string Content { set{ _Content = value; } get{ return _Content; }}
	public string Link { set{ _Link = value; } get{ return _Link; }}
	public long? UserID { set{ _UserID = value; } get{ return _UserID; }}
	public bool? IsPass { set{ _IsPass = value; } get{ return _IsPass; }}
}
}


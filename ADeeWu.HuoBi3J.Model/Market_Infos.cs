
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Market_Infos{

	#region Fields
	private long _ID = 0L;
	private long _UserID = 0L;
	private long _MarketCategoryID = 0L;
	private string _Title = String.Empty;
	private string _Summary = String.Empty;
	private string _Content = String.Empty;
	private bool _IsRecommend = false;
	private bool _IsHidden = false;
	private int _VisitCount = 0;
	private int _CheckState = 0;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	private DateTime _ModifyTime = new DateTime(1900,1,1);
	private DateTime _RefreshTime = new DateTime(1900,1,1);
	private int _BusinessType = 0;
	#endregion
	
	#region Contructors
	public Market_Infos()
	{
	}
	
	public Market_Infos
	(
		long iD,
			long userID,
			long marketCategoryID,
			string title,
			string summary,
			string content,
			bool isRecommend,
			bool isHidden,
			int visitCount,
			int checkState,
			DateTime createTime,
			DateTime modifyTime,
			DateTime refreshTime,
			int businessType
	)
	{
		_ID               = iD;
			_UserID           = userID;
			_MarketCategoryID = marketCategoryID;
			_Title            = title;
			_Summary          = summary;
			_Content          = content;
			_IsRecommend      = isRecommend;
			_IsHidden         = isHidden;
			_VisitCount       = visitCount;
			_CheckState       = checkState;
			_CreateTime       = createTime;
			_ModifyTime       = modifyTime;
			_RefreshTime      = refreshTime;
			_BusinessType     = businessType;
			
	}
	#endregion
		
public long ID 
{
 set{ _ID = value; }
 get{ return _ID; }
}
public long UserID 
{
 set{ _UserID = value; }
 get{ return _UserID; }
}
public long MarketCategoryID 
{
 set{ _MarketCategoryID = value; }
 get{ return _MarketCategoryID; }
}
public string Title 
{
 set{ _Title = value; }
 get{ return _Title; }
}
public string Summary 
{
 set{ _Summary = value; }
 get{ return _Summary; }
}
public string Content 
{
 set{ _Content = value; }
 get{ return _Content; }
}
public bool IsRecommend 
{
 set{ _IsRecommend = value; }
 get{ return _IsRecommend; }
}
public bool IsHidden 
{
 set{ _IsHidden = value; }
 get{ return _IsHidden; }
}
public int VisitCount 
{
 set{ _VisitCount = value; }
 get{ return _VisitCount; }
}
public int CheckState 
{
 set{ _CheckState = value; }
 get{ return _CheckState; }
}
public DateTime CreateTime 
{
 set{ _CreateTime = value; }
 get{ return _CreateTime; }
}
public DateTime ModifyTime 
{
 set{ _ModifyTime = value; }
 get{ return _ModifyTime; }
}
public DateTime RefreshTime 
{
 set{ _RefreshTime = value; }
 get{ return _RefreshTime; }
}
public int BusinessType 
{
 set{ _BusinessType = value; }
 get{ return _BusinessType; }
}
}
}


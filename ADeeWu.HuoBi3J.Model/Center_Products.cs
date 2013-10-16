
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Center_Products{

	#region Fields
	private long _ID = 0L;
	private long? _CategoryID = null;
	private string _Name = null;
	private string _Content = null;
	private string _Picture = null;
	private DateTime? _CreateTime = null;
	#endregion
	
	#region Contructors
	public Center_Products()
	{
	}
	
	public Center_Products
	(
		long iD,
			long categoryID,
			string name,
			string content,
			string picture,
			DateTime createTime
	)
	{
		_ID         = iD;
			_CategoryID = categoryID;
			_Name       = name;
			_Content    = content;
			_Picture    = picture;
			_CreateTime = createTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long? CategoryID { set{ _CategoryID = value; } get{ return _CategoryID; }}
	public string Name { set{ _Name = value; } get{ return _Name; }}
	public string Content { set{ _Content = value; } get{ return _Content; }}
	public string Picture { set{ _Picture = value; } get{ return _Picture; }}
	public DateTime? CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
}
}


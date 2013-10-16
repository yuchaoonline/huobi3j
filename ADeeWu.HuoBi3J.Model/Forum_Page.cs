
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Forum_Page{

	#region Fields
	private long _ID = 0L;
	private string _Title = null;
	private string _Description = null;
	private long? _ParentID = null;
	#endregion
	
	#region Contructors
	public Forum_Page()
	{
	}
	
	public Forum_Page
	(
		long iD,
			string title,
			string description,
			long parentID
	)
	{
		_ID          = iD;
			_Title       = title;
			_Description = description;
			_ParentID    = parentID;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public string Title { set{ _Title = value; } get{ return _Title; }}
	public string Description { set{ _Description = value; } get{ return _Description; }}
	public long? ParentID { set{ _ParentID = value; } get{ return _ParentID; }}
}
}


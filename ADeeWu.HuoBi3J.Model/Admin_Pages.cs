
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Admin_Pages{

	#region Fields
	private long _ID = 0L;
	private string _PageCode = String.Empty;
	private string _PageName = String.Empty;
	private string _URL = String.Empty;
	private string _Description = String.Empty;
	#endregion
	
	#region Contructors
	public Admin_Pages()
	{
	}
	
	public Admin_Pages
	(
		long iD,
			string pageCode,
			string pageName,
			string uRL,
			string description
	)
	{
		_ID          = iD;
			_PageCode    = pageCode;
			_PageName    = pageName;
			_URL         = uRL;
			_Description = description;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public string PageCode { set{ _PageCode = value; } get{ return _PageCode; }}
	public string PageName { set{ _PageName = value; } get{ return _PageName; }}
	public string URL { set{ _URL = value; } get{ return _URL; }}
	public string Description { set{ _Description = value; } get{ return _Description; }}
}
}


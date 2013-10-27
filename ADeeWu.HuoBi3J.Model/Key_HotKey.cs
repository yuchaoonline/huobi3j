
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Key_HotKey{

	#region Fields
	private int _ID = 0;
	private string _Name = null;
	private string _DataType = null;
	private string _DataLink = null;
	#endregion
	
	#region Contructors
	public Key_HotKey()
	{
	}
	
	public Key_HotKey
	(
		int iD,
			string name,
			string dataType,
			string dataLink
	)
	{
		_ID       = iD;
			_Name     = name;
			_DataType = dataType;
			_DataLink = dataLink;
			
	}
	#endregion
		
	public int ID { set{ _ID = value; } get{ return _ID; }}
	public string Name { set{ _Name = value; } get{ return _Name; }}
	public string DataType { set{ _DataType = value; } get{ return _DataType; }}
	public string DataLink { set{ _DataLink = value; } get{ return _DataLink; }}
}
}


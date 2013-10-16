
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class BaseData{

	#region Fields
	private long _ID = 0L;
	private string _Name = null;
	private string _Value = null;
	private long? _IDentity = null;
	#endregion
	
	#region Contructors
	public BaseData()
	{
	}
	
	public BaseData
	(
		long iD,
			string name,
			string value,
			long iDentity
	)
	{
		_ID       = iD;
			_Name     = name;
			_Value    = value;
			_IDentity = iDentity;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public string Name { set{ _Name = value; } get{ return _Name; }}
	public string Value { set{ _Value = value; } get{ return _Value; }}
	public long? IDentity { set{ _IDentity = value; } get{ return _IDentity; }}
}
}


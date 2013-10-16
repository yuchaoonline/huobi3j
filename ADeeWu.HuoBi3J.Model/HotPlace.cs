
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class HotPlace{

	#region Fields
	private int _ID = 0;
	private string _Name = null;
	#endregion
	
	#region Contructors
	public HotPlace()
	{
	}
	
	public HotPlace
	(
		int iD,
			string name
	)
	{
		_ID   = iD;
			_Name = name;
			
	}
	#endregion
		
	public int ID { set{ _ID = value; } get{ return _ID; }}
	public string Name { set{ _Name = value; } get{ return _Name; }}
}
}


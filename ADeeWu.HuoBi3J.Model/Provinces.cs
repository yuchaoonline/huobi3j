
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Provinces{

	#region Fields
	private long _ID = 0L;
	private string _Name = String.Empty;
	private int? _Sort = null;
	#endregion
	
	#region Contructors
	public Provinces()
	{
	}
	
	public Provinces
	(
		long iD,
			string name,
			int sort
	)
	{
		_ID   = iD;
			_Name = name;
			_Sort = sort;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public string Name { set{ _Name = value; } get{ return _Name; }}
	public int? Sort { set{ _Sort = value; } get{ return _Sort; }}
}
}


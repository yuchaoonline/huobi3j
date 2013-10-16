
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Citys{

	#region Fields
	private long _ID = 0L;
	private string _Name = String.Empty;
	private long _Pid = 0L;
	private int? _Sort = null;
	#endregion
	
	#region Contructors
	public Citys()
	{
	}
	
	public Citys
	(
		long iD,
			string name,
			long pid,
			int sort
	)
	{
		_ID   = iD;
			_Name = name;
			_Pid  = pid;
			_Sort = sort;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public string Name { set{ _Name = value; } get{ return _Name; }}
	public long Pid { set{ _Pid = value; } get{ return _Pid; }}
	public int? Sort { set{ _Sort = value; } get{ return _Sort; }}
}
}


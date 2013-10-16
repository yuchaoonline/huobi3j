
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Areas{

	#region Fields
	private long _ID = 0L;
	private string _Name = String.Empty;
	private long _CID = 0L;
	private int _Sort = 0;
	#endregion
	
	#region Contructors
	public Areas()
	{
	}
	
	public Areas
	(
		long iD,
			string name,
			long cID,
			int sort
	)
	{
		_ID   = iD;
			_Name = name;
			_CID  = cID;
			_Sort = sort;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public string Name { set{ _Name = value; } get{ return _Name; }}
	public long CID { set{ _CID = value; } get{ return _CID; }}
	public int Sort { set{ _Sort = value; } get{ return _Sort; }}
}
}


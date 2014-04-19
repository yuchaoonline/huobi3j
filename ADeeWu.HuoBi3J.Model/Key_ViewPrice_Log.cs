
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Key_ViewPrice_Log{

	#region Fields
	private int _ID = 0;
	private int? _CountClickID = null;
	private decimal? _Price = null;
	#endregion
	
	#region Contructors
	public Key_ViewPrice_Log()
	{
	}
	
	public Key_ViewPrice_Log
	(
		int iD,
			int countClickID,
			decimal price
	)
	{
		_ID           = iD;
			_CountClickID = countClickID;
			_Price        = price;
			
	}
	#endregion
		
	public int ID { set{ _ID = value; } get{ return _ID; }}
	public int? CountClickID { set{ _CountClickID = value; } get{ return _CountClickID; }}
	public decimal? Price { set{ _Price = value; } get{ return _Price; }}
}
}


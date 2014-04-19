
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Key_ViewPrice{

	#region Fields
	private int _ID = 0;
	private int? _KID = null;
	private decimal? _Price = null;
	private int? _Count = null;
	#endregion
	
	#region Contructors
	public Key_ViewPrice()
	{
	}
	
	public Key_ViewPrice
	(
		int iD,
			int kID,
			decimal price,
			int count
	)
	{
		_ID    = iD;
			_KID   = kID;
			_Price = price;
			_Count = count;
			
	}
	#endregion
		
	public int ID { set{ _ID = value; } get{ return _ID; }}
	public int? KID { set{ _KID = value; } get{ return _KID; }}
	public decimal? Price { set{ _Price = value; } get{ return _Price; }}
	public int? Count { set{ _Count = value; } get{ return _Count; }}
}
}


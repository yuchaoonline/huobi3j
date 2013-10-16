
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class TicketHotKey{

	#region Fields
	private int _ID = 0;
	private string _Name = null;
	private string _Link = null;
	#endregion
	
	#region Contructors
	public TicketHotKey()
	{
	}
	
	public TicketHotKey
	(
		int iD,
			string name,
			string link
	)
	{
		_ID   = iD;
			_Name = name;
			_Link = link;
			
	}
	#endregion
		
	public int ID { set{ _ID = value; } get{ return _ID; }}
	public string Name { set{ _Name = value; } get{ return _Name; }}
	public string Link { set{ _Link = value; } get{ return _Link; }}
}
}



using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Key_Product{

	#region Fields
	private long _ID = 0L;
	private long? _KID = null;
	private decimal _Price = 0M;
	private string _SimpleDesc = null;
	private string _Description = null;
	private string _SelectAttribute = null;
	private long? _CreateUserID = null;
	#endregion
	
	#region Contructors
	public Key_Product()
	{
	}
	
	public Key_Product
	(
		long iD,
			long kID,
			decimal price,
			string simpleDesc,
			string description,
			string selectAttribute,
			long createUserID
	)
	{
		_ID              = iD;
			_KID             = kID;
			_Price           = price;
			_SimpleDesc      = simpleDesc;
			_Description     = description;
			_SelectAttribute = selectAttribute;
			_CreateUserID    = createUserID;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long? KID { set{ _KID = value; } get{ return _KID; }}
	public decimal Price { set{ _Price = value; } get{ return _Price; }}
	public string SimpleDesc { set{ _SimpleDesc = value; } get{ return _SimpleDesc; }}
	public string Description { set{ _Description = value; } get{ return _Description; }}
	public string SelectAttribute { set{ _SelectAttribute = value; } get{ return _SelectAttribute; }}
	public long? CreateUserID { set{ _CreateUserID = value; } get{ return _CreateUserID; }}
}
}



using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Key_Attribute{

	#region Fields
	private long _ID = 0L;
	private long? _KID = null;
	private string _KeyType = null;
	private string _KeySize = null;
	private string _KeyPrice = null;
	#endregion
	
	#region Contructors
	public Key_Attribute()
	{
	}
	
	public Key_Attribute
	(
		long iD,
			long kID,
			string keyType,
			string keySize,
			string keyPrice
	)
	{
		_ID       = iD;
			_KID      = kID;
			_KeyType  = keyType;
			_KeySize  = keySize;
			_KeyPrice = keyPrice;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long? KID { set{ _KID = value; } get{ return _KID; }}
	public string KeyType { set{ _KeyType = value; } get{ return _KeyType; }}
	public string KeySize { set{ _KeySize = value; } get{ return _KeySize; }}
	public string KeyPrice { set{ _KeyPrice = value; } get{ return _KeyPrice; }}
}
}


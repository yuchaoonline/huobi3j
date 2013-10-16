
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class tblHistory{

	#region Fields
	private long _id = 0L;
	private string _fromUIN = String.Empty;
	private string _toUIN = String.Empty;
	private int _nTime = 0;
	private string _sMsg = String.Empty;
	private int _nType = 0;
	private long _groupChatID = 0;
    private string _sIP = string.Empty;
	#endregion
	
	#region Contructors
	public tblHistory()
	{
	}
	
	public tblHistory
	(
		long id,
			string fromUIN,
			string toUIN,
			int nTime,
			string sMsg,
			int nType,
			long groupChatID,
			string sIP
	)
	{
		_id          = id;
			_fromUIN     = fromUIN;
			_toUIN       = toUIN;
			_nTime       = nTime;
			_sMsg        = sMsg;
			_nType       = nType;
			_groupChatID = groupChatID;
			_sIP         = sIP;
			
	}
	#endregion

    public long ID { set { _id = value; } get { return _id; } }
    public string FromUIN { set { _fromUIN = value; } get { return _fromUIN; } }
    public string ToUIN { set { _toUIN = value; } get { return _toUIN; } }
    public int nTime { set { _nTime = value; } get { return _nTime; } }
    public string sMsg { set { _sMsg = value; } get { return _sMsg; } }
    public int nType { set { _nType = value; } get { return _nType; } }
    public long GroupChatID { set { _groupChatID = value; } get { return _groupChatID; } }
    public string sIP { set { _sIP = value; } get { return _sIP; } }
}
}


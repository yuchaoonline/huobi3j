
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Shops{

	#region Fields
	private long _ID = 0L;
	private long _CorpID = 0L;
	private long _CorpUserID = 0L;
	private string _Name = String.Empty;
	private string _Summary = String.Empty;
	private string _Contact = String.Empty;
	private string _AfterSaleService = String.Empty;
	private string _AgentShopAddress = String.Empty;
	private string _DeliveryTypeList = String.Empty;
	private string _Logo = String.Empty;
	private bool _IsHidden = false;
	private int _CheckState = 0;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	private DateTime _ModifyTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public Shops()
	{
	}
	
	public Shops
	(
		long iD,
			long corpID,
			long corpUserID,
			string name,
			string summary,
			string contact,
			string afterSaleService,
			string agentShopAddress,
			string deliveryTypeList,
			string logo,
			bool isHidden,
			int checkState,
			DateTime createTime,
			DateTime modifyTime
	)
	{
		_ID               = iD;
			_CorpID           = corpID;
			_CorpUserID       = corpUserID;
			_Name             = name;
			_Summary          = summary;
			_Contact          = contact;
			_AfterSaleService = afterSaleService;
			_AgentShopAddress = agentShopAddress;
			_DeliveryTypeList = deliveryTypeList;
			_Logo             = logo;
			_IsHidden         = isHidden;
			_CheckState       = checkState;
			_CreateTime       = createTime;
			_ModifyTime       = modifyTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long CorpID { set{ _CorpID = value; } get{ return _CorpID; }}
	public long CorpUserID { set{ _CorpUserID = value; } get{ return _CorpUserID; }}
	public string Name { set{ _Name = value; } get{ return _Name; }}
	public string Summary { set{ _Summary = value; } get{ return _Summary; }}
	public string Contact { set{ _Contact = value; } get{ return _Contact; }}
	public string AfterSaleService { set{ _AfterSaleService = value; } get{ return _AfterSaleService; }}
	public string AgentShopAddress { set{ _AgentShopAddress = value; } get{ return _AgentShopAddress; }}
	public string DeliveryTypeList { set{ _DeliveryTypeList = value; } get{ return _DeliveryTypeList; }}
	public string Logo { set{ _Logo = value; } get{ return _Logo; }}
	public bool IsHidden { set{ _IsHidden = value; } get{ return _IsHidden; }}
	public int CheckState { set{ _CheckState = value; } get{ return _CheckState; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public DateTime ModifyTime { set{ _ModifyTime = value; } get{ return _ModifyTime; }}
}
}


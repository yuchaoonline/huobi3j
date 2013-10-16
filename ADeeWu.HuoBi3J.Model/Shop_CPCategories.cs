
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Shop_CPCategories{

	#region Fields
	private long _ID = 0L;
	private long _ShopID = 0L;
	private string _Name = String.Empty;
	private int _ItemCount = 0;
	private long _ParentID = 0L;
	private int _Depth = 0;
	private string _ImgUrl = String.Empty;
	private bool _ShowImg = false;
	private int _Sequence = 0;
	private bool _IsHidden = false;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	private DateTime _ModifyTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public Shop_CPCategories()
	{
	}
	
	public Shop_CPCategories
	(
		long iD,
			long shopID,
			string name,
			int itemCount,
			long parentID,
			int depth,
			string imgUrl,
			bool showImg,
			int sequence,
			bool isHidden,
			DateTime createTime,
			DateTime modifyTime
	)
	{
		_ID         = iD;
			_ShopID     = shopID;
			_Name       = name;
			_ItemCount  = itemCount;
			_ParentID   = parentID;
			_Depth      = depth;
			_ImgUrl     = imgUrl;
			_ShowImg    = showImg;
			_Sequence   = sequence;
			_IsHidden   = isHidden;
			_CreateTime = createTime;
			_ModifyTime = modifyTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long ShopID { set{ _ShopID = value; } get{ return _ShopID; }}
	public string Name { set{ _Name = value; } get{ return _Name; }}
	public int ItemCount { set{ _ItemCount = value; } get{ return _ItemCount; }}
	public long ParentID { set{ _ParentID = value; } get{ return _ParentID; }}
	public int Depth { set{ _Depth = value; } get{ return _Depth; }}
	public string ImgUrl { set{ _ImgUrl = value; } get{ return _ImgUrl; }}
	public bool ShowImg { set{ _ShowImg = value; } get{ return _ShowImg; }}
	public int Sequence { set{ _Sequence = value; } get{ return _Sequence; }}
	public bool IsHidden { set{ _IsHidden = value; } get{ return _IsHidden; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public DateTime ModifyTime { set{ _ModifyTime = value; } get{ return _ModifyTime; }}
}
}


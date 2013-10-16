
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Shop_ProductCategories{

	#region Fields
	private long _ID = 0L;
	private long _AttrTplCateID = 0L;
	private string _Name = String.Empty;
	private int _ItemCount = 0;
	private long _ParentID = 0L;
	private string _ParentPath = String.Empty;
	private int _Depth = 0;
	private int _Sequence = 0;
	private bool _IsRecommend = false;
	private bool _IsHidden = false;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	private DateTime _ModifyTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public Shop_ProductCategories()
	{
	}
	
	public Shop_ProductCategories
	(
		long iD,
			long attrTplCateID,
			string name,
			int itemCount,
			long parentID,
			string parentPath,
			int depth,
			int sequence,
			bool isRecommend,
			bool isHidden,
			DateTime createTime,
			DateTime modifyTime
	)
	{
		_ID            = iD;
			_AttrTplCateID = attrTplCateID;
			_Name          = name;
			_ItemCount     = itemCount;
			_ParentID      = parentID;
			_ParentPath    = parentPath;
			_Depth         = depth;
			_Sequence      = sequence;
			_IsRecommend   = isRecommend;
			_IsHidden      = isHidden;
			_CreateTime    = createTime;
			_ModifyTime    = modifyTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long AttrTplCateID { set{ _AttrTplCateID = value; } get{ return _AttrTplCateID; }}
	public string Name { set{ _Name = value; } get{ return _Name; }}
	public int ItemCount { set{ _ItemCount = value; } get{ return _ItemCount; }}
	public long ParentID { set{ _ParentID = value; } get{ return _ParentID; }}
	public string ParentPath { set{ _ParentPath = value; } get{ return _ParentPath; }}
	public int Depth { set{ _Depth = value; } get{ return _Depth; }}
	public int Sequence { set{ _Sequence = value; } get{ return _Sequence; }}
	public bool IsRecommend { set{ _IsRecommend = value; } get{ return _IsRecommend; }}
	public bool IsHidden { set{ _IsHidden = value; } get{ return _IsHidden; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public DateTime ModifyTime { set{ _ModifyTime = value; } get{ return _ModifyTime; }}
}
}


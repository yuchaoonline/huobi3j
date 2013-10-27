
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Shop_ProductCategories{

	#region Fields
	private long? _ID = null;
	private long? _AttrTplCateID = null;
	private string _Name = null;
	private int? _ItemCount = null;
	private long? _ParentID = null;
	private string _ParentPath = null;
	private int? _Depth = null;
	private int? _Sequence = null;
	private bool? _IsRecommend = null;
	private bool? _IsHidden = null;
	private DateTime? _CreateTime = null;
	private DateTime? _ModifyTime = null;
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
		
	public long? ID { set{ _ID = value; } get{ return _ID; }}
	public long? AttrTplCateID { set{ _AttrTplCateID = value; } get{ return _AttrTplCateID; }}
	public string Name { set{ _Name = value; } get{ return _Name; }}
	public int? ItemCount { set{ _ItemCount = value; } get{ return _ItemCount; }}
	public long? ParentID { set{ _ParentID = value; } get{ return _ParentID; }}
	public string ParentPath { set{ _ParentPath = value; } get{ return _ParentPath; }}
	public int? Depth { set{ _Depth = value; } get{ return _Depth; }}
	public int? Sequence { set{ _Sequence = value; } get{ return _Sequence; }}
	public bool? IsRecommend { set{ _IsRecommend = value; } get{ return _IsRecommend; }}
	public bool? IsHidden { set{ _IsHidden = value; } get{ return _IsHidden; }}
	public DateTime? CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public DateTime? ModifyTime { set{ _ModifyTime = value; } get{ return _ModifyTime; }}
}
}


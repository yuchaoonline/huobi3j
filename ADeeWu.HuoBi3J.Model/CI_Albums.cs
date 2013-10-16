
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class CI_Albums{

	#region Fields
	private long _ID = 0L;
	private long _CorpID = 0L;
	private long _FaceID = 0L;
	private string _Title = String.Empty;
	private int _Sequence = 0;
	private bool _IsRecommend = false;
	private bool _IsHidden = false;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	private DateTime _ModifyTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public CI_Albums()
	{
	}
	
	public CI_Albums
	(
		long iD,
			long corpID,
			long faceID,
			string title,
			int sequence,
			bool isRecommend,
			bool isHidden,
			DateTime createTime,
			DateTime modifyTime
	)
	{
		_ID          = iD;
			_CorpID      = corpID;
			_FaceID      = faceID;
			_Title       = title;
			_Sequence    = sequence;
			_IsRecommend = isRecommend;
			_IsHidden    = isHidden;
			_CreateTime  = createTime;
			_ModifyTime  = modifyTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long CorpID { set{ _CorpID = value; } get{ return _CorpID; }}
	public long FaceID { set{ _FaceID = value; } get{ return _FaceID; }}
	public string Title { set{ _Title = value; } get{ return _Title; }}
	public int Sequence { set{ _Sequence = value; } get{ return _Sequence; }}
	public bool IsRecommend { set{ _IsRecommend = value; } get{ return _IsRecommend; }}
	public bool IsHidden { set{ _IsHidden = value; } get{ return _IsHidden; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
	public DateTime ModifyTime { set{ _ModifyTime = value; } get{ return _ModifyTime; }}
}
}


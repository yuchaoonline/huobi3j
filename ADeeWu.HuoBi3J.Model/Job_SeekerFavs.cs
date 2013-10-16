
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Job_SeekerFavs{

	#region Fields
	private long _ID = 0L;
	private long _UserID = 0L;
	private long _JobID = 0L;
	private string _Notes = String.Empty;
	private DateTime _CreateTime = new DateTime(1900,1,1);
	#endregion
	
	#region Contructors
	public Job_SeekerFavs()
	{
	}
	
	public Job_SeekerFavs
	(
		long iD,
			long userID,
			long jobID,
			string notes,
			DateTime createTime
	)
	{
		_ID         = iD;
			_UserID     = userID;
			_JobID      = jobID;
			_Notes      = notes;
			_CreateTime = createTime;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public long UserID { set{ _UserID = value; } get{ return _UserID; }}
	public long JobID { set{ _JobID = value; } get{ return _JobID; }}
	public string Notes { set{ _Notes = value; } get{ return _Notes; }}
	public DateTime CreateTime { set{ _CreateTime = value; } get{ return _CreateTime; }}
}
}


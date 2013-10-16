
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class Admin_Users{

	#region Fields
	private long _ID = 0L;
	private string _LoginName = String.Empty;
	private string _LoginPwd = String.Empty;
	private DateTime _RegTime = new DateTime(1900,1,1);
	private DateTime _LastLogin = new DateTime(1900,1,1);
	private int _LoginTimes = 0;
	private string _Name = String.Empty;
	private string _Notes = String.Empty;
	#endregion
	
	#region Contructors
	public Admin_Users()
	{
	}
	
	public Admin_Users
	(
		long iD,
			string loginName,
			string loginPwd,
			DateTime regTime,
			DateTime lastLogin,
			int loginTimes,
			string name,
			string notes
	)
	{
		_ID         = iD;
			_LoginName  = loginName;
			_LoginPwd   = loginPwd;
			_RegTime    = regTime;
			_LastLogin  = lastLogin;
			_LoginTimes = loginTimes;
			_Name       = name;
			_Notes      = notes;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public string LoginName { set{ _LoginName = value; } get{ return _LoginName; }}
	public string LoginPwd { set{ _LoginPwd = value; } get{ return _LoginPwd; }}
	public DateTime RegTime { set{ _RegTime = value; } get{ return _RegTime; }}
	public DateTime LastLogin { set{ _LastLogin = value; } get{ return _LastLogin; }}
	public int LoginTimes { set{ _LoginTimes = value; } get{ return _LoginTimes; }}
	public string Name { set{ _Name = value; } get{ return _Name; }}
	public string Notes { set{ _Notes = value; } get{ return _Notes; }}
}
}


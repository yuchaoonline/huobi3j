
using System;
namespace ADeeWu.HuoBi3J.Model{
	
public class System_Functions{

	#region Fields
	private long _ID = 0L;
	private string _Code = String.Empty;
	private string _Name = String.Empty;
	private string _FileName = String.Empty;
	private bool _IsCorpAgentFunc = false;
	private string _Description = String.Empty;
	#endregion
	
	#region Contructors
	public System_Functions()
	{
	}
	
	public System_Functions
	(
		long iD,
			string code,
			string name,
			string fileName,
			bool isCorpAgentFunc,
			string description
	)
	{
		_ID              = iD;
			_Code            = code;
			_Name            = name;
			_FileName        = fileName;
			_IsCorpAgentFunc = isCorpAgentFunc;
			_Description     = description;
			
	}
	#endregion
		
	public long ID { set{ _ID = value; } get{ return _ID; }}
	public string Code { set{ _Code = value; } get{ return _Code; }}
	public string Name { set{ _Name = value; } get{ return _Name; }}
	public string FileName { set{ _FileName = value; } get{ return _FileName; }}
	public bool IsCorpAgentFunc { set{ _IsCorpAgentFunc = value; } get{ return _IsCorpAgentFunc; }}
	public string Description { set{ _Description = value; } get{ return _Description; }}
}
}


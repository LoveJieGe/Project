using System;
namespace SSJT.Crm.Model
{
	/// <summary>
	/// SysLog:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SysLog
	{
		public SysLog()
		{}
		#region Model
		private int _id;
		private string _eventtype;
		private string _eventid;
		private string _eventtitle;
		private string _originaltxt;
		private string _currenttxt;
		private int? _userid;
		private string _username;
		private string _ipstreet;
		private DateTime? _eventdate;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EventType
		{
			set{ _eventtype=value;}
			get{return _eventtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EventId
		{
			set{ _eventid=value;}
			get{return _eventid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EventTitle
		{
			set{ _eventtitle=value;}
			get{return _eventtitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OriginalTxt
		{
			set{ _originaltxt=value;}
			get{return _originaltxt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CurrentTxt
		{
			set{ _currenttxt=value;}
			get{return _currenttxt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IPStreet
		{
			set{ _ipstreet=value;}
			get{return _ipstreet;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EventDate
		{
			set{ _eventdate=value;}
			get{return _eventdate;}
		}
		#endregion Model

	}
}


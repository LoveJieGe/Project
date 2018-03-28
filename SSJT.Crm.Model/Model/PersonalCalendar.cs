using System;
namespace SSJT.Crm.Model
{
	/// <summary>
	/// PersonalCalendar:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PersonalCalendar : BaseModel
    {
		public PersonalCalendar()
		{}
		#region Model
		private int _id;
		private int? _empid;
		private string _empname;
		private int? _companyid;
		private string _subject;
		private string _location;
		private string _description;
		private int? _calendartype;
		private DateTime? _starttime;
		private DateTime? _endtime;
		private bool _isalldayevent;
		private bool _hasattachment;
		private string _category;
		private int? _instancetype;
		private string _attendess;
		private string _attendeenames;
		private string _otherattendee;
		private string _upname;
		private DateTime? _updtime;
		private string _recurringrule;
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
		public int? EmpId
		{
			set{ _empid=value;}
			get{return _empid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EmpName
		{
			set{ _empname=value;}
			get{return _empname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CompanyId
		{
			set{ _companyid=value;}
			get{return _companyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Subject
		{
			set{ _subject=value;}
			get{return _subject;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Location
		{
			set{ _location=value;}
			get{return _location;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CalendarType
		{
			set{ _calendartype=value;}
			get{return _calendartype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? StartTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsAllDayEvent
		{
			set{ _isalldayevent=value;}
			get{return _isalldayevent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool HasAttachment
		{
			set{ _hasattachment=value;}
			get{return _hasattachment;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Category
		{
			set{ _category=value;}
			get{return _category;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? InstanceType
		{
			set{ _instancetype=value;}
			get{return _instancetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Attendess
		{
			set{ _attendess=value;}
			get{return _attendess;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AttendeeNames
		{
			set{ _attendeenames=value;}
			get{return _attendeenames;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OtherAttendee
		{
			set{ _otherattendee=value;}
			get{return _otherattendee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UpName
		{
			set{ _upname=value;}
			get{return _upname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdTime
		{
			set{ _updtime=value;}
			get{return _updtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RecurringRule
		{
			set{ _recurringrule=value;}
			get{return _recurringrule;}
		}
		#endregion Model

	}
}


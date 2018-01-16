using System;
namespace SSJT.Crm.Model
{
	/// <summary>
	/// CrmFollow:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CrmFollow
	{
		public CrmFollow()
		{}
		#region Model
		private int _id;
		private int? _customerid;
		private string _customername;
		private string _follow;
		private DateTime? _followdate;
		private int? _followtypeid;
		private string _followtype;
		private int? _departmentid;
		private string _departmentname;
		private int? _employeeid;
		private string _employeename;
		private int? _isdelete;
		private DateTime? _deletetime;
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
		public int? CustomerId
		{
			set{ _customerid=value;}
			get{return _customerid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CustomerName
		{
			set{ _customername=value;}
			get{return _customername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Follow
		{
			set{ _follow=value;}
			get{return _follow;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? FollowDate
		{
			set{ _followdate=value;}
			get{return _followdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? FollowTypeId
		{
			set{ _followtypeid=value;}
			get{return _followtypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FollowType
		{
			set{ _followtype=value;}
			get{return _followtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DepartmentId
		{
			set{ _departmentid=value;}
			get{return _departmentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DepartmentName
		{
			set{ _departmentname=value;}
			get{return _departmentname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? EmployeeId
		{
			set{ _employeeid=value;}
			get{return _employeeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EmployeeName
		{
			set{ _employeename=value;}
			get{return _employeename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsDelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DeleteTime
		{
			set{ _deletetime=value;}
			get{return _deletetime;}
		}
		#endregion Model

	}
}


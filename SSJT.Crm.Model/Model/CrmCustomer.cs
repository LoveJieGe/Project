using System;
namespace SSJT.Crm.Model
{
	/// <summary>
	/// CrmCustomer:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CrmCustomer:BaseModel
	{
		public CrmCustomer()
		{}
		#region Model
		private int _id;
		private string _serialnumber;
		private string _customer;
		private string _address;
		private string _tel;
		private string _fax;
		private string _site;
		private int? _industryid;
		private string _industry;
		private int? _provincesid;
		private string _provinces;
		private int? _cityid;
		private string _city;
		private int? _customertypeid;
		private string _customertype;
		private int? _customerlevelid;
		private string _customerlevel;
		private int? _customersourceid;
		private string _descripe;
		private string _remarks;
		private int? _departmentid;
		private string _department;
		private int? _employeeid;
		private string _employee;
		private string _privatecustomer;
		private DateTime? _lastfollow;
		private int? _createid;
		private string _createname;
		private DateTime? _createdate;
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
		public string SerialNumber
		{
			set{ _serialnumber=value;}
			get{return _serialnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Customer
		{
			set{ _customer=value;}
			get{return _customer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Fax
		{
			set{ _fax=value;}
			get{return _fax;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Site
		{
			set{ _site=value;}
			get{return _site;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IndustryId
		{
			set{ _industryid=value;}
			get{return _industryid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Industry
		{
			set{ _industry=value;}
			get{return _industry;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ProvincesId
		{
			set{ _provincesid=value;}
			get{return _provincesid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Provinces
		{
			set{ _provinces=value;}
			get{return _provinces;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CityId
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string City
		{
			set{ _city=value;}
			get{return _city;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CustomerTypeId
		{
			set{ _customertypeid=value;}
			get{return _customertypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CustomerType
		{
			set{ _customertype=value;}
			get{return _customertype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CustomerLevelId
		{
			set{ _customerlevelid=value;}
			get{return _customerlevelid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CustomerLevel
		{
			set{ _customerlevel=value;}
			get{return _customerlevel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CustomerSourceId
		{
			set{ _customersourceid=value;}
			get{return _customersourceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Descripe
		{
			set{ _descripe=value;}
			get{return _descripe;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remarks
		{
			set{ _remarks=value;}
			get{return _remarks;}
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
		public string Department
		{
			set{ _department=value;}
			get{return _department;}
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
		public string Employee
		{
			set{ _employee=value;}
			get{return _employee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PrivateCustomer
		{
			set{ _privatecustomer=value;}
			get{return _privatecustomer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LastFollow
		{
			set{ _lastfollow=value;}
			get{return _lastfollow;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CreateId
		{
			set{ _createid=value;}
			get{return _createid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CreateName
		{
			set{ _createname=value;}
			get{return _createname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
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


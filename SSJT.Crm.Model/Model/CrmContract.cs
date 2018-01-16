using System;
namespace SSJT.Crm.Model
{
	/// <summary>
	/// CrmContract:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CrmContract
	{
		public CrmContract()
		{}
		#region Model
		private int _id;
		private string _contractname;
		private string _serialnumber;
		private int? _customerid;
		private string _customername;
		private int? _depid;
		private string _depname;
		private int? _empid;
		private string _empname;
		private decimal? _contractamount;
		private int? _paycycle;
		private string _startdate;
		private string _enddate;
		private string _signdate;
		private byte[] _customercontractor;
		private int? _ourcontractordepid;
		private string _ourcontractordepname;
		private int? _ourcontractorid;
		private string _ourcontractorname;
		private int? _createrid;
		private string _creatername;
		private DateTime? _createtime;
		private string _maincontent;
		private string _remarks;
		private string _fileserialnumber;
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
		public string ContractName
		{
			set{ _contractname=value;}
			get{return _contractname;}
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
		public int? DepId
		{
			set{ _depid=value;}
			get{return _depid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DepName
		{
			set{ _depname=value;}
			get{return _depname;}
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
		public decimal? ContractAmount
		{
			set{ _contractamount=value;}
			get{return _contractamount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PayCycle
		{
			set{ _paycycle=value;}
			get{return _paycycle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StartDate
		{
			set{ _startdate=value;}
			get{return _startdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SignDate
		{
			set{ _signdate=value;}
			get{return _signdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public byte[] CustomerContractor
		{
			set{ _customercontractor=value;}
			get{return _customercontractor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OurContractorDepId
		{
			set{ _ourcontractordepid=value;}
			get{return _ourcontractordepid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OurContractorDepName
		{
			set{ _ourcontractordepname=value;}
			get{return _ourcontractordepname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OurContractorId
		{
			set{ _ourcontractorid=value;}
			get{return _ourcontractorid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OurContractorName
		{
			set{ _ourcontractorname=value;}
			get{return _ourcontractorname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CreaterId
		{
			set{ _createrid=value;}
			get{return _createrid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CreaterName
		{
			set{ _creatername=value;}
			get{return _creatername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MainContent
		{
			set{ _maincontent=value;}
			get{return _maincontent;}
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
		public string FileSerialNumber
		{
			set{ _fileserialnumber=value;}
			get{return _fileserialnumber;}
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


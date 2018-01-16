using System;
namespace SSJT.Crm.Model
{
	/// <summary>
	/// CrmReceive:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CrmReceive
	{
		public CrmReceive()
		{}
		#region Model
		private int _id;
		private int? _customerid;
		private string _customername;
		private string _receivenum;
		private int? _paytypeid;
		private string _paytype;
		private decimal? _receiveamount;
		private DateTime? _receivedate;
		private int? _depid;
		private string _depname;
		private int? _empid;
		private string _empname;
		private int? _createid;
		private string _createname;
		private DateTime? _createdate;
		private int? _companyid;
		private int? _orderid;
		private string _remarks;
		private int? _isdelete;
		private DateTime? _deletetime;
		private int? _receivedirectionid;
		private string _receivedirectionname;
		private int? _receivetypeid;
		private string _receivetypename;
		private decimal? _receivereal;
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
		public string ReceiveNum
		{
			set{ _receivenum=value;}
			get{return _receivenum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PayTypeId
		{
			set{ _paytypeid=value;}
			get{return _paytypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PayType
		{
			set{ _paytype=value;}
			get{return _paytype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ReceiveAmount
		{
			set{ _receiveamount=value;}
			get{return _receiveamount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ReceiveDate
		{
			set{ _receivedate=value;}
			get{return _receivedate;}
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
		public int? CompanyId
		{
			set{ _companyid=value;}
			get{return _companyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OrderId
		{
			set{ _orderid=value;}
			get{return _orderid;}
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
		/// <summary>
		/// 
		/// </summary>
		public int? ReceiveDirectionId
		{
			set{ _receivedirectionid=value;}
			get{return _receivedirectionid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReceiveDirectionName
		{
			set{ _receivedirectionname=value;}
			get{return _receivedirectionname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ReceiveTypeId
		{
			set{ _receivetypeid=value;}
			get{return _receivetypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReceiveTypeName
		{
			set{ _receivetypename=value;}
			get{return _receivetypename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ReceiveReal
		{
			set{ _receivereal=value;}
			get{return _receivereal;}
		}
		#endregion Model

	}
}


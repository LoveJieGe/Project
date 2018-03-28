using System;
namespace SSJT.Crm.Model
{
	/// <summary>
	/// CrmOrder:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CrmOrder:BaseModel
	{
		public CrmOrder()
		{}
		#region Model
		private int _id;
		private string _serialnumber;
		private int? _customerid;
		private string _customername;
		private DateTime? _orderdate;
		private int? _paytypeid;
		private string _paytype;
		private string _orderdetails;
		private string _orderstatus;
		private int? _orderstatusid;
		private decimal? _orderamount;
		private int? _createid;
		private DateTime? _createdate;
		private int? _depidc;
		private string _depnamec;
		private int? _depidf;
		private string _depnamef;
		private int? _empid;
		private string _empname;
		private decimal? _receivemoney;
		private decimal? _arrearsmoney;
		private decimal? _invoicemoney;
		private decimal? _arreasinvoice;
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
		public DateTime? OrderDate
		{
			set{ _orderdate=value;}
			get{return _orderdate;}
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
		public string OrderDetails
		{
			set{ _orderdetails=value;}
			get{return _orderdetails;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OrderStatus
		{
			set{ _orderstatus=value;}
			get{return _orderstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OrderStatusId
		{
			set{ _orderstatusid=value;}
			get{return _orderstatusid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? OrderAmount
		{
			set{ _orderamount=value;}
			get{return _orderamount;}
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
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DepIdC
		{
			set{ _depidc=value;}
			get{return _depidc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DepNameC
		{
			set{ _depnamec=value;}
			get{return _depnamec;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DepIdF
		{
			set{ _depidf=value;}
			get{return _depidf;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DepNameF
		{
			set{ _depnamef=value;}
			get{return _depnamef;}
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
		public decimal? ReceiveMoney
		{
			set{ _receivemoney=value;}
			get{return _receivemoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ArrearsMoney
		{
			set{ _arrearsmoney=value;}
			get{return _arrearsmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? InvoiceMoney
		{
			set{ _invoicemoney=value;}
			get{return _invoicemoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ArreasInvoice
		{
			set{ _arreasinvoice=value;}
			get{return _arreasinvoice;}
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


using System;
namespace SSJT.Crm.Model
{
	/// <summary>
	/// CrmInvoice:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CrmInvoice:BaseModel
	{
		public CrmInvoice()
		{}
		#region Model
		private int _id;
		private int? _customerid;
		private string _customername;
		private string _invoicenum;
		private int? _invoicetypeid;
		private string _invoicetype;
		private decimal? _invoiceamount;
		private string _invoicecontent;
		private DateTime? _invoicedate;
		private int? _depid;
		private string _depname;
		private int? _empid;
		private string _empname;
		private int? _createid;
		private string _createname;
		private DateTime? _createdate;
		private int? _orderid;
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
		public string InvoiceNum
		{
			set{ _invoicenum=value;}
			get{return _invoicenum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? InvoiceTypeId
		{
			set{ _invoicetypeid=value;}
			get{return _invoicetypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string InvoiceType
		{
			set{ _invoicetype=value;}
			get{return _invoicetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? InvoiceAmount
		{
			set{ _invoiceamount=value;}
			get{return _invoiceamount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string InvoiceContent
		{
			set{ _invoicecontent=value;}
			get{return _invoicecontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? InvoiceDate
		{
			set{ _invoicedate=value;}
			get{return _invoicedate;}
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
		public int? OrderId
		{
			set{ _orderid=value;}
			get{return _orderid;}
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


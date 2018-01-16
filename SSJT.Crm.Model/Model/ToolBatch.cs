using System;
namespace SSJT.Crm.Model
{
	/// <summary>
	/// ToolBatch:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ToolBatch
	{
		public ToolBatch()
		{}
		#region Model
		private int _id;
		private string _batchtype;
		private int? _depido;
		private string _depo;
		private int? _empido;
		private string _empo;
		private int? _depidc;
		private string _depc;
		private int? _empidc;
		private string _empc;
		private int? _count;
		private int? _createid;
		private string _createname;
		private DateTime? _createdate;
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
		public string BatchType
		{
			set{ _batchtype=value;}
			get{return _batchtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DepIdO
		{
			set{ _depido=value;}
			get{return _depido;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DepO
		{
			set{ _depo=value;}
			get{return _depo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? EmpIdO
		{
			set{ _empido=value;}
			get{return _empido;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EmpO
		{
			set{ _empo=value;}
			get{return _empo;}
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
		public string DepC
		{
			set{ _depc=value;}
			get{return _depc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? EmpIdC
		{
			set{ _empidc=value;}
			get{return _empidc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EmpC
		{
			set{ _empc=value;}
			get{return _empc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Count
		{
			set{ _count=value;}
			get{return _count;}
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
		#endregion Model

	}
}


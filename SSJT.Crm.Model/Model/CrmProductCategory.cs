using System;
namespace SSJT.Crm.Model
{
	/// <summary>
	/// CrmProductCategory:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CrmProductCategory : BaseModel
    {
		public CrmProductCategory()
		{}
		#region Model
		private int _id;
		private string _productcategory;
		private int? _parentid;
		private string _producticon;
		private int? _isdelete;
		private int? _deleteid;
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
		public string ProductCategory
		{
			set{ _productcategory=value;}
			get{return _productcategory;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ParentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductIcon
		{
			set{ _producticon=value;}
			get{return _producticon;}
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
		public int? DeleteId
		{
			set{ _deleteid=value;}
			get{return _deleteid;}
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


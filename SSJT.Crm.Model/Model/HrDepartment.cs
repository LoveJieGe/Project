using System;
namespace SSJT.Crm.Model
{
	/// <summary>
	/// HrDepartment:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class HrDepartment
	{
		public HrDepartment()
		{}
		#region Model
		private int _id;
		private string _name;
		private int? _parentid;
		private string _parentname;
		private string _type;
		private string _icon;
		private string _fuzeren;
		private string _tel;
		private string _fax;
		private string _dadd;
		private string _email;
		private string _miaoshu;
		private int? _orders;
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
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
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
		public string ParentName
		{
			set{ _parentname=value;}
			get{return _parentname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Icon
		{
			set{ _icon=value;}
			get{return _icon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Fuzeren
		{
			set{ _fuzeren=value;}
			get{return _fuzeren;}
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
		public string DAdd
		{
			set{ _dadd=value;}
			get{return _dadd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MiaoShu
		{
			set{ _miaoshu=value;}
			get{return _miaoshu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Orders
		{
			set{ _orders=value;}
			get{return _orders;}
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


using System;
namespace SSJT.Crm.Model
{
	/// <summary>
	/// HrPost:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class HrPost : BaseModel
    {
		public HrPost()
		{}
		#region Model
		private int _postid;
		private string _postname;
		private int? _positionid;
		private string _positionname;
		private int? _positionorder;
		private int? _depid;
		private string _depname;
		private int? _empid;
		private string _empname;
		private int? _defaultpost;
		private string _note;
		private string _postdescript;
		private int? _isdelete;
		private DateTime? _deletetime;
		/// <summary>
		/// 
		/// </summary>
		public int PostId
		{
			set{ _postid=value;}
			get{return _postid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PostName
		{
			set{ _postname=value;}
			get{return _postname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PositionId
		{
			set{ _positionid=value;}
			get{return _positionid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PositionName
		{
			set{ _positionname=value;}
			get{return _positionname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PositionOrder
		{
			set{ _positionorder=value;}
			get{return _positionorder;}
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
		public int? DefaultPost
		{
			set{ _defaultpost=value;}
			get{return _defaultpost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PostDescript
		{
			set{ _postdescript=value;}
			get{return _postdescript;}
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


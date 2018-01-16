using System;
namespace SSJT.Crm.Model
{
	/// <summary>
	/// PublicNews:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PublicNews
	{
		public PublicNews()
		{}
		#region Model
		private int _id;
		private string _newstitle;
		private string _newscontent;
		private int? _createid;
		private string _createname;
		private int? _depid;
		private string _depname;
		private DateTime? _newstime;
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
		public string NewsTitle
		{
			set{ _newstitle=value;}
			get{return _newstitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NewsContent
		{
			set{ _newscontent=value;}
			get{return _newscontent;}
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
		public DateTime? NewsTime
		{
			set{ _newstime=value;}
			get{return _newstime;}
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


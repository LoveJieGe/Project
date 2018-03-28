using System;
namespace SSJT.Crm.Model
{
	/// <summary>
	/// PublicNotice:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PublicNotice : BaseModel
    {
		public PublicNotice()
		{}
		#region Model
		private int _id;
		private string _noticetitle;
		private string _noticecontent;
		private int? _createid;
		private string _createname;
		private int? _depid;
		private string _depname;
		private DateTime? _noticetime;
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
		public string NoticeTitle
		{
			set{ _noticetitle=value;}
			get{return _noticetitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NoticeContent
		{
			set{ _noticecontent=value;}
			get{return _noticecontent;}
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
		public DateTime? NoticeTime
		{
			set{ _noticetime=value;}
			get{return _noticetime;}
		}
		#endregion Model

	}
}


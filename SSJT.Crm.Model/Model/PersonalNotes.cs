using System;
namespace SSJT.Crm.Model
{
	/// <summary>
	/// PersonalNotes:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PersonalNotes
	{
		public PersonalNotes()
		{}
		#region Model
		private int _id;
		private int? _empid;
		private string _empname;
		private string _notecontent;
		private string _notecolor;
		private string _xyz;
		private DateTime? _notetime;
		private int? _createid;
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
		public string NoteContent
		{
			set{ _notecontent=value;}
			get{return _notecontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NoteColor
		{
			set{ _notecolor=value;}
			get{return _notecolor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Xyz
		{
			set{ _xyz=value;}
			get{return _xyz;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? NoteTime
		{
			set{ _notetime=value;}
			get{return _notetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CreateId
		{
			set{ _createid=value;}
			get{return _createid;}
		}
		#endregion Model

	}
}


using System;
namespace SSJT.Crm.Model
{
	/// <summary>
	/// HrEmployee:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class HrEmployee
	{
		public HrEmployee()
		{}
		#region Model
		private int _id;
		private string _uid;
		private string _pwd;
		private string _uname;
		private string _cardid;
		private string _birthday;
		private int? _did;
		private string _dname;
		private int? _postid;
		private string _post;
		private string _email;
		private string _sex;
		private string _tel;
		private string _status;
		private int? _zhiwuid;
		private string _zhiwu;
		private int? _sort;
		private string _entrydate;
		private string _address;
		private string _remarks;
		private string _education;
		private string _levels;
		private string _professional;
		private string _isdelete;
		private DateTime? _deletetime;
		private byte[] _portal;
		private string _theme;
		private string _canlogin;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Uid
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Pwd
		{
			set{ _pwd=value;}
			get{return _pwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UName
		{
			set{ _uname = value;}
			get{return _uname; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string CardId
		{
			set{ _cardid=value;}
			get{return _cardid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Birthday
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Did
		{
			set{ _did=value;}
			get{return _did;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Dname
		{
			set{ _dname=value;}
			get{return _dname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PostId
		{
			set{ _postid=value;}
			get{return _postid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Post
		{
			set{ _post=value;}
			get{return _post;}
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
		public string Sex
		{
			set{ _sex=value;}
			get{return _sex;}
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
		public string Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ZhiWuId
		{
			set{ _zhiwuid=value;}
			get{return _zhiwuid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ZhiWu
		{
			set{ _zhiwu=value;}
			get{return _zhiwu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EntryDate
		{
			set{ _entrydate=value;}
			get{return _entrydate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
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
		public string Education
		{
			set{ _education=value;}
			get{return _education;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Levels
		{
			set{ _levels=value;}
			get{return _levels;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Professional
		{
			set{ _professional=value;}
			get{return _professional;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IsDelete
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
		public byte[] Portal
		{
			set{ _portal=value;}
			get{return _portal;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Theme
		{
			set{ _theme=value;}
			get{return _theme;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CanLogin
		{
			set{ _canlogin=value;}
			get{return _canlogin;}
		}
		#endregion Model

	}
}


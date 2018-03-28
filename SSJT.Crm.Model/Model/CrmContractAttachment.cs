using System;
namespace SSJT.Crm.Model
{
	/// <summary>
	/// CrmContractAttachment:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CrmContractAttachment:BaseModel
	{
		public CrmContractAttachment()
		{}
		#region Model
		private int? _contractid;
		private string _pageid;
		private string _fileid;
		private string _filename;
		private string _realname;
		private int? _filesize;
		private int? _createid;
		private string _createname;
		private DateTime? _createdate;
		/// <summary>
		/// 
		/// </summary>
		public int? ContractId
		{
			set{ _contractid=value;}
			get{return _contractid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PageId
		{
			set{ _pageid=value;}
			get{return _pageid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FileId
		{
			set{ _fileid=value;}
			get{return _fileid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FileName
		{
			set{ _filename=value;}
			get{return _filename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RealName
		{
			set{ _realname=value;}
			get{return _realname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? FileSize
		{
			set{ _filesize=value;}
			get{return _filesize;}
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


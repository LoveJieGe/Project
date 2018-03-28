using System;
namespace SSJT.Crm.Model
{
	/// <summary>
	/// SysLogErr:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SysLogErr : BaseModel
    {
		public SysLogErr()
		{}
		#region Model
		private int _id;
		private int? _errtypeid;
		private string _errtype;
		private DateTime? _errtime;
		private string _errurl;
		private string _errmessage;
		private string _errsource;
		private string _errtrace;
		private int? _errempid;
		private string _errempname;
		private string _errip;
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
		public int? ErrTypeId
		{
			set{ _errtypeid=value;}
			get{return _errtypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ErrType
		{
			set{ _errtype=value;}
			get{return _errtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ErrTime
		{
			set{ _errtime=value;}
			get{return _errtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ErrUrl
		{
			set{ _errurl=value;}
			get{return _errurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ErrMessage
		{
			set{ _errmessage=value;}
			get{return _errmessage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ErrSource
		{
			set{ _errsource=value;}
			get{return _errsource;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ErrTrace
		{
			set{ _errtrace=value;}
			get{return _errtrace;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ErrEmpId
		{
			set{ _errempid=value;}
			get{return _errempid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ErrEmpName
		{
			set{ _errempname=value;}
			get{return _errempname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ErrIp
		{
			set{ _errip=value;}
			get{return _errip;}
		}
		#endregion Model

	}
}


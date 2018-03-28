using System;
namespace SSJT.Crm.Model
{
	/// <summary>
	/// SysApp:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SysApp : BaseModel
    {
		public SysApp()
		{}
		#region Model
		private int _id;
		private string _appname;
		private int? _apporder;
		private string _appurl;
		private string _apphandler;
		private string _apptype;
		private string _appicon;
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
		public string AppName
		{
			set{ _appname=value;}
			get{return _appname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AppOrder
		{
			set{ _apporder=value;}
			get{return _apporder;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AppUrl
		{
			set{ _appurl=value;}
			get{return _appurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AppHandler
		{
			set{ _apphandler=value;}
			get{return _apphandler;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AppType
		{
			set{ _apptype=value;}
			get{return _apptype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AppIcon
		{
			set{ _appicon=value;}
			get{return _appicon;}
		}
		#endregion Model

	}
}


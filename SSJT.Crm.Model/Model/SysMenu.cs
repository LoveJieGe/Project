using System;
namespace SSJT.Crm.Model
{
	/// <summary>
	/// SysMenu:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SysMenu
	{
		public SysMenu()
		{}
		#region Model
		private int _menuid;
		private string _menuname;
		private int? _parentid;
		private string _parnetname;
		private int? _appid;
		private string _menuurl;
		private string _menuicon;
		private string _menuhandler;
		private int? _menuorder;
		private string _menutype;
		/// <summary>
		/// 
		/// </summary>
		public int MenuId
		{
			set{ _menuid=value;}
			get{return _menuid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MenuName
		{
			set{ _menuname=value;}
			get{return _menuname;}
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
		public string ParnetName
		{
			set{ _parnetname=value;}
			get{return _parnetname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AppId
		{
			set{ _appid=value;}
			get{return _appid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MenuUrl
		{
			set{ _menuurl=value;}
			get{return _menuurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MenuIcon
		{
			set{ _menuicon=value;}
			get{return _menuicon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MenuHandler
		{
			set{ _menuhandler=value;}
			get{return _menuhandler;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MenuOrder
		{
			set{ _menuorder=value;}
			get{return _menuorder;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MenuType
		{
			set{ _menutype=value;}
			get{return _menutype;}
		}
		#endregion Model

	}
}


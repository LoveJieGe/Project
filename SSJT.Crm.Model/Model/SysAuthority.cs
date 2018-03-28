using System;
namespace SSJT.Crm.Model
{
	/// <summary>
	/// SysAuthority:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SysAuthority : BaseModel
    {
		public SysAuthority()
		{}
		#region Model
		private int _roleid;
		private string _appids;
		private string _menuids;
		private string _buttonids;
		private int? _createid;
		private DateTime? _createdate;
		/// <summary>
		/// 
		/// </summary>
		public int RoleId
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AppIds
		{
			set{ _appids=value;}
			get{return _appids;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MenuIds
		{
			set{ _menuids=value;}
			get{return _menuids;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ButtonIds
		{
			set{ _buttonids=value;}
			get{return _buttonids;}
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
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}


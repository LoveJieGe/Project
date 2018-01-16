using System;
namespace SSJT.Crm.Model
{
	/// <summary>
	/// SysDataAuthority:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SysDataAuthority
	{
		public SysDataAuthority()
		{}
		#region Model
		private int _roleid;
		private int? _optionid;
		private string _sysoption;
		private int? _sysview;
		private int? _sysadd;
		private int? _sysedit;
		private int? _sysdel;
		private int? _createid;
		private DateTime? _createtime;
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
		public int? OptionId
		{
			set{ _optionid=value;}
			get{return _optionid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SysOption
		{
			set{ _sysoption=value;}
			get{return _sysoption;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SysView
		{
			set{ _sysview=value;}
			get{return _sysview;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SysAdd
		{
			set{ _sysadd=value;}
			get{return _sysadd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SysEdit
		{
			set{ _sysedit=value;}
			get{return _sysedit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SysDel
		{
			set{ _sysdel=value;}
			get{return _sysdel;}
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
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		#endregion Model

	}
}


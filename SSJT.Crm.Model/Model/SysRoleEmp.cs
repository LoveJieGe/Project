using System;
namespace SSJT.Crm.Model
{
	/// <summary>
	/// SysRoleEmp:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SysRoleEmp : BaseModel
    {
		public SysRoleEmp()
		{}
		#region Model
		private int _roleid;
		private int _empid;
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
		public int EmpId
		{
			set{ _empid=value;}
			get{return _empid;}
		}
		#endregion Model

	}
}


using System;
namespace SSJT.Crm.Model
{
	/// <summary>
	/// SysInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SysInfo : BaseModel
    {
		public SysInfo()
		{}
		#region Model
		private int _id;
		private string _syskey;
		private string _sysvalue;
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
		public string SysKey
		{
			set{ _syskey=value;}
			get{return _syskey;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SysValue
		{
			set{ _sysvalue=value;}
			get{return _sysvalue;}
		}
		#endregion Model

	}
}


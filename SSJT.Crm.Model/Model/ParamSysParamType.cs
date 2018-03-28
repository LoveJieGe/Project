using System;
namespace SSJT.Crm.Model
{
	/// <summary>
	/// ParamSysParamType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ParamSysParamType : BaseModel
    {
		public ParamSysParamType()
		{}
		#region Model
		private int? _id;
		private string _paramsname;
		private int? _paramsorder;
		private int? _isdelete;
		private DateTime? _deletetime;
		/// <summary>
		/// 
		/// </summary>
		public int? id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ParamsName
		{
			set{ _paramsname=value;}
			get{return _paramsname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ParamsOrder
		{
			set{ _paramsorder=value;}
			get{return _paramsorder;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsDelete
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
		#endregion Model

	}
}


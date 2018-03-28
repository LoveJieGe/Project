using System;
namespace SSJT.Crm.Model
{
	/// <summary>
	/// HrPosition:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class HrPosition : BaseModel
    {
		public HrPosition()
		{}
		#region Model
		private int _id;
		private string _positionname;
		private int? _positionorder;
		private string _positionlevel;
		private int? _createid;
		private DateTime? _createdate;
		private int? _isdelete;
		private DateTime? _deletetime;
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
		public string PositionName
		{
			set{ _positionname=value;}
			get{return _positionname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PositionOrder
		{
			set{ _positionorder=value;}
			get{return _positionorder;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PositionLevel
		{
			set{ _positionlevel=value;}
			get{return _positionlevel;}
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


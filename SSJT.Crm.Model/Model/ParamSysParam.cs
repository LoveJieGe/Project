﻿using System;
namespace SSJT.Crm.Model
{
	/// <summary>
	/// ParamSysParam:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ParamSysParam
	{
		public ParamSysParam()
		{}
		#region Model
		private int _id;
		private int? _parentid;
		private string _paramsname;
		private int? _paramsorder;
		private int? _createid;
		private DateTime? _createdate;
		private int? _updateid;
		private DateTime? _updatedate;
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
		public int? ParentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
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
		public int? UpdateId
		{
			set{ _updateid=value;}
			get{return _updateid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdateDate
		{
			set{ _updatedate=value;}
			get{return _updatedate;}
		}
		#endregion Model

	}
}


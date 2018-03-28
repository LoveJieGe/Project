using System;
namespace SSJT.Crm.Model
{
	/// <summary>
	/// SysButton:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SysButton : BaseModel
    {
		public SysButton()
		{}
		#region Model
		private int _btnid;
		private string _btnname;
		private string _btnicon;
		private string _btnhanlder;
		private int? _menuid;
		private string _menuname;
		private int? _btnorder;
		/// <summary>
		/// 
		/// </summary>
		public int BtnId
		{
			set{ _btnid=value;}
			get{return _btnid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BtnName
		{
			set{ _btnname=value;}
			get{return _btnname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BtnIcon
		{
			set{ _btnicon=value;}
			get{return _btnicon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BtnHanlder
		{
			set{ _btnhanlder=value;}
			get{return _btnhanlder;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MenuId
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
		public int? BtnOrder
		{
			set{ _btnorder=value;}
			get{return _btnorder;}
		}
		#endregion Model

	}
}


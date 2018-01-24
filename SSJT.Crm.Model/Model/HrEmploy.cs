using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSJT.Crm.Model
{
	/// <summary>
	/// HrEmployee:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class HrEmploy
	{
		public int Id
		{
            set;
            get;
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserID
		{
            set;
            get;
		}
		/// <summary>
		/// 
		/// </summary>
		public string PassWord
		{
            set;
            get;
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
            set; get;
		}
		/// <summary>
		/// 
		/// </summary>
		public string CardId
		{
            set; get;
		}
		/// <summary>
		/// 
		/// </summary>
		public string Birthday
		{
            set; get;
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Did
		{
            set; get;
		}
		/// <summary>
		/// 
		/// </summary>
		public string Dname
		{
            set; get;
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PostId
		{
            set; get;
		}
		/// <summary>
		/// 
		/// </summary>
		public string Post
		{
            set; get;
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
            set; get;
		}
		/// <summary>
		/// 
		/// </summary>
		public string Sex
		{
            set; get;
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tel
		{
            set; get;
		}
		/// <summary>
		/// 
		/// </summary>
		public string Status
		{
            set; get;
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ZhiWuId
		{
            set; get;
		}
		/// <summary>
		/// 
		/// </summary>
		public string ZhiWu
		{
            set; get;
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Sort
		{
            set; get;
		}
		/// <summary>
		/// 
		/// </summary>
		public string EntryDate
		{
            set; get;
		}
		/// <summary>
		/// 
		/// </summary>
		public string Address
		{
            set; get;
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remarks
		{
            set; get;
		}
		/// <summary>
		/// 
		/// </summary>
		public string Education
		{
            set; get;
		}
		/// <summary>
		/// 
		/// </summary>
		public string Levels
		{
            set; get;
		}
		/// <summary>
		/// 
		/// </summary>
		public string Professional
		{
            set; get;
		}
		/// <summary>
		/// 
		/// </summary>
		public string IsDelete
		{
            set; get;
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DeleteTime
		{
            set; get;
		}
		/// <summary>
		/// 
		/// </summary>
		public byte[] Portal
		{
            set; get;
		}
		/// <summary>
		/// 
		/// </summary>
		public string Theme
		{
            set; get;
		}
		/// <summary>
		/// 
		/// </summary>
		public string CanLogin
		{
            set; get;
		}
	}
}


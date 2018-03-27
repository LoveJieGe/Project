using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSJT.Crm.Model
{
	/// <summary>
	/// HrEmploy:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class HrEmploy:BaseModel
	{
        [Key]
		public int Id
		{
            set;
            get;
		}
		/// <summary>
		/// 
		/// </summary>
		[AjaxProperty]
        [Required]
        [StringLength(20)]
		public string UserID
		{
            set;
            get;
		}
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [StringLength(40)]
        public string PassWord
		{
            set;
            get;
		}
        /// <summary>
        /// 
        /// </summary>
        [AjaxProperty]
        [StringLength(50)]
        public string UserName
		{
            set; get;
		}
        /// <summary>
        /// 
        /// </summary>
        [StringLength(20)]
        public string CardId
		{
            set; get;
		}
        /// <summary>
        /// 
        /// </summary>
        [AjaxProperty]
        [DataType(DataType.DateTime)]
        public DateTime? Birthday
		{
            set; get;
		}
        /// <summary>
        /// 
        /// </summary>
        public int? DepId
        {
            set; get;
		}
        /// <summary>
        /// 
        /// </summary>
        [StringLength(50)]
        public string DepName
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
        [StringLength(50)]
        public string Post
		{
            set; get;
		}
        /// <summary>
        /// 
        /// </summary>
        [AjaxProperty]
        [StringLength(80)]
        public string Email
		{
            set; get;
		}
        /// <summary>
        /// 
        /// </summary>
        [AjaxProperty]
        [StringLength(8)]
        public string Gender
		{
            set; get;
		}
        /// <summary>
        /// 
        /// </summary>
        [AjaxProperty]
        [StringLength(20)]
        public string Tel
		{
            set; get;
		}
        /// <summary>
        /// 
        /// </summary>
        [StringLength(20)]
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
        [StringLength(50)]
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
		/// 入学日期
		/// </summary>
        [DataType(DataType.DateTime)]
		public DateTime? EntryDate
		{
            set; get;
		}
        /// <summary>
        /// 
        /// </summary>
        [AjaxProperty]
        [StringLength(255)]
        public string Address
		{
            set; get;
		}
        /// <summary>
        /// 
        /// </summary>
        [AjaxProperty]
        [Column(TypeName ="text")]
        public string Remarks
		{
            set; get;
		}
        /// <summary>
        /// 
        /// </summary>
        [AjaxProperty]
        [StringLength(40)]
        public string Education
		{
            set; get;
		}
        /// <summary>
        /// 
        /// </summary>
        [AjaxProperty]
        [StringLength(40)]
        public string Levels
		{
            set; get;
		}
        /// <summary>
        /// 
        /// </summary>
        [AjaxProperty]
        [StringLength(40)]
        public string Professional
		{
            set; get;
		}
        /// <summary>
        /// 
        /// </summary>
        [StringLength(1)]
        [Column(TypeName ="char")]
        public string IsDelete
		{
            set; get;
		}
		/// <summary>
		/// 
		/// </summary>
        [DataType(DataType.DateTime)]
		public DateTime? DeleteTime
		{
            set; get;
		}
		/// <summary>
		/// 
		/// </summary>
        
		//public byte[] Portal
		//{
  //          set; get;
		//}
        /// <summary>
        /// 
        /// </summary>
        [StringLength(40)]
        public string Theme
		{
            set; get;
		}
		/// <summary>
		/// 
		/// </summary>
        [StringLength(1)]
        [Column(TypeName = "char")]
        public string CanLogin
		{
            set; get;
		}
        /// <summary>
        /// 头像文件名字
        /// </summary>
        [AjaxProperty]
        [StringLength(100)]
	    public string AvatarName
	    {
            get;set;
	    }
        /// <summary>
        /// 手机号码
        /// </summary>
        [AjaxProperty]
        [StringLength(20)]
        public string Mobile
        {
            get;set;
        }
        [AjaxProperty]
        [StringLength(1)]
        [Column(TypeName ="char")]
        public string IsRoot
        {
            get;set;
        }
	}
}


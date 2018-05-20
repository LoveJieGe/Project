using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSJT.Crm.Model
{
	/// <summary>
	/// PublicNews:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    [Table("News")]
	public partial class News : BaseModel
    {
		/// <summary>
        /// 新闻ID
        /// </summary>
        [Key]
        [AjaxProperty]
        public int NewsId
        {
            set;get;
		}
		/// <summary>
		/// 新闻标题
		/// </summary>
        [StringLength(255)]
        [AjaxProperty]
		public string NewsTitle
		{
            set;get;
		}
		/// <summary>
		/// x新闻内容
		/// </summary>
        [Column(TypeName ="ntext")]
        [AjaxProperty]
        public string NewsContent
		{
            set; get;
		}
        /// <summary>
        /// 
        /// </summary>
        public int CreatorId
        {
            set; get;
		}
        /// <summary>
        /// 
        /// </summary>
        [AjaxProperty]
        [StringLength(40)]
        public string CreatorName
        {
            set; get;
		}
        /// <summary>
        /// 
        /// </summary>
        [AjaxProperty]
        public int? DepId
		{
            set; get;
		}
        /// <summary>
        /// 
        /// </summary>
        [AjaxProperty]
        [StringLength(40)]
        public string DepName
		{
            set; get;
		}
        /// <summary>
        /// 
        /// </summary>
        [AjaxProperty]
        [DataType(DataType.DateTime)]
        public DateTime? NewsTime
		{
            set; get;
		}
        /// <summary>
        /// 
        /// </summary>
        [AjaxProperty]
        [StringLength(1)]
        [Column(TypeName ="char")]
        public string IsDelete
		{
            set; get;
		}
        /// <summary>
        /// 
        /// </summary>
        [AjaxProperty]
        [DataType(DataType.DateTime)]
		public DateTime? DeleteTime
		{
            set; get;
		}
	}
}


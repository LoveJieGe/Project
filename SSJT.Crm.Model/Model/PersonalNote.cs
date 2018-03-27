using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSJT.Crm.Model
{
	/// <summary>
	/// PersonalNote:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class PersonalNote:BaseModel
	{
        #region Model
        [AjaxProperty]
        [Key]
        [StringLength(20)]
        public string NoteID
		{
            get;set;
		}
		/// <summary>
		/// 便签内容
		/// </summary>
        [AjaxProperty]
        [Column(TypeName = "text")]
        public string NoteContent
		{
            get;set;
		}
        /// <summary>
        /// 优先级（L:低,M:中,H:高）
        /// </summary>
        [AjaxProperty]
        [StringLength(1)]
        [Column(TypeName="char")]
        public string Priority
        {
            get;set;
        }
        /// <summary>
        /// 便签颜色
        /// </summary>
        [AjaxProperty]
        [StringLength(20)]
        public string NoteColor
		{
            get;set;
		}
        /// <summary>
        /// 便签的X坐标
        /// </summary>
        [AjaxProperty]
        public int? LocationX
        {
            get;set;
        }
        /// <summary>
        /// 便签Y坐标
        /// </summary>
        [AjaxProperty]
        public int? LocationY
        {
            get; set;
        }
        /// <summary>
        /// 便签的宽度
        /// </summary>
        [AjaxProperty]
        public int? Width
        {
            get;set;
        }
        /// <summary>
        /// 便签的高度
        /// </summary>
        [AjaxProperty]
        public int? Height
        {
            get;set;
        }
        /// <summary>
        /// 便签是否显示(Y/N)
        /// </summary>
        [AjaxProperty]
        [StringLength(1)]
        [Column(TypeName = "char")]
        public string IsShow
        {
            get;set;
        }

        /// <summary>
        /// 创建者的ID
        /// </summary>
        [AjaxProperty]
        [StringLength(10)]
        public string CreatorId
        {
            get;set;
		}
        /// <summary>
        /// 创建者的名字
        /// </summary>
        [AjaxProperty]
        [StringLength(40)]
        public string CreatorName
        {
            get;set;
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        [AjaxProperty]
        [DataType(DataType.DateTime)]
        public DateTime? CreateDate
        {
            get;set;
        }
        /// <summary>
        /// 更新者名字
        /// </summary>
        [AjaxProperty]
        [StringLength(10)]
        public string UpdaterID
        {
            get; set;
        }
        /// <summary>
        /// 更新者名字
        /// </summary>
        [AjaxProperty]
        [StringLength(40)]
        public string UpdaterName
        {
            get; set;
        }
        /// <summary>
        /// 更新时间
        /// </summary>
        [AjaxProperty]
        [DataType(DataType.DateTime)]
        public DateTime? UpdateDate
        {
            get; set;
        }
        /// <summary>
        /// 是否(完成Y/N)
        /// </summary>
        [AjaxProperty]
        [StringLength(1)]
        [Column(TypeName = "char")]
        public string IsFinish
        {
            get;set;
        }
        /// <summary>
        /// 完成时间
        /// </summary>
        [AjaxProperty]
        [DataType(DataType.DateTime)]
        public DateTime? FinishDate
        {
            get;set;
        }
        #endregion Model
    }
}


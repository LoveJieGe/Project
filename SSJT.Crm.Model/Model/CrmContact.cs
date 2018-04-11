using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSJT.Crm.Model
{
	/// <summary>
	/// CrmContact:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CrmContact:BaseModel
	{
        /// <summary>
        /// 联系人ID
        /// </summary>
        [Key]
        [AjaxProperty]
		public int CntID
		{
            get;set;
		}
		/// <summary>
		/// 联系人名字
		/// </summary>
        [StringLength(50)]
        [AjaxProperty]
        public string CntName
		{
            get;set;
		}
        /// <summary>
        /// 性别
        /// </summary>
        [AjaxProperty]
        public int Gender
        {
            get;set;
		}
        /// <summary>
        /// 部门ID
        /// </summary>
        [StringLength(20)]
        [AjaxProperty]
        public string DepID
        {
            get;set;
        }
        /// <summary>
        /// 部门名字
        /// </summary>
        [StringLength(40)]
        [AjaxProperty]
        public string DepName
		{
            get;set;
		}
        /// <summary>
        /// 职位
        /// </summary>
        [StringLength(80)]
        [AjaxProperty]
        public string Position
		{
            get;set;
		}
        /// <summary>
        /// 
        /// </summary>
        [AjaxProperty]
        [DataType(DataType.DateTime)]
		public DateTime? Birthday
		{
            get;set;
		}
        /// <summary>
        /// 移动电话
        /// </summary>
        [AjaxProperty]
        [StringLength(20)]
        public string Mobile
        {
            get;set;
		}
        /// <summary>
        /// 单位电话
        /// </summary>
        [AjaxProperty]
        [StringLength(20)]
        public string WorkPhone
        {
            get; set;
        }
        /// <summary>
        /// 家庭电话
        /// </summary>
        [AjaxProperty]
        [StringLength(40)]
        public string HomePhone
        {
            get; set;
        }
        /// <summary>
        /// 传真
        /// </summary>
        [AjaxProperty]
        [StringLength(20)]
        public string Fax
		{
            get;set;
		}
        /// <summary>
        /// 邮箱
        /// </summary>
        [AjaxProperty]
        [StringLength(100)]
        public string Email
		{
            get;set;
		}

        /// <summary>
        /// QQ号码
        /// </summary>
        [AjaxProperty]
        [StringLength(40)]
        public string QQ
        {
            get; set;
        }
        /// <summary>
        /// 微信号码
        /// </summary>
        [AjaxProperty]
        [StringLength(40)]
        public string WeChat
        {
            get;set;
        }
        /// <summary>
        /// 身份证
        /// </summary>
        [AjaxProperty]
        [StringLength(80)]
        public string IDCard
		{
            get;set;
		}
        /// <summary>
        /// 爱好
        /// </summary>
        [AjaxProperty]
        [StringLength(255)]
        public string Hobby
		{
            get;set;
		}
        /// <summary>
        /// 备注说明
        /// </summary>
        [AjaxProperty]
        [Column(TypeName = "text")]
        public string Remarks
		{
            get;set;
		}
        /// <summary>
        /// 联系人地址
        /// </summary>
        [AjaxProperty]
        [StringLength(255)]
        public string Address
        {
            get;set;
        }
        /// <summary>
        /// 创建者ID
        /// </summary>
        [AjaxProperty]
        [StringLength(20)]
        public string CreatorId
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
            get; set;
        }
        /// <summary>
        /// 更新者名字
        /// </summary>
        [AjaxProperty]
        [StringLength(20)]
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
        /// 是否删除
        /// </summary>
        [AjaxProperty]
        [StringLength(1)]
        [Column(TypeName = "char")]
        public int? IsDelete
		{
            get;set;
		}
        /// <summary>
        /// 删除日期
        /// </summary>
        [AjaxProperty]
        [DataType(DataType.DateTime)]
        public DateTime? DeleteTime
		{
            get;set;
		}

	}
}


using SSJT.Crm.Core;
using SSJT.Crm.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.IBLL
{
    [AjaxClass("SSJT.Crm.BLL.PersonalService,SSJT.Crm.BLL")]
    public interface IPersonalService
    {
        /// <summary>
        /// 添加便签
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AjaxMethod]
        [Description("添加便签")]
        PersonalNote InsertData(Model.PersonalNote model);

        [AjaxMethod]
        [Description("删除便签")]
        void DeleteNote(string noteId);

        /// <summary>
        /// 完成便签
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        [AjaxMethod]
        [Description("完成便签")]
        PersonalNote FinishNote(string noteId);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AjaxMethod]
        [Description("更新数据")]
        PersonalNote UpdateData(PersonalNote model);
    }
}

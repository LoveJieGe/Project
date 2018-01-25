using SSJT.Crm.Core.AjaxResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSJT.Crm.WebApp
{
    /// <summary>
    /// 用来获取一些实例的类
    /// </summary>
    public class ContextFactory
    {
        private IAjaxProcess _ajaxProcess;
        /// <summary>
        /// Ajax操作
        /// </summary>
        public static IAjaxProcess AjaxProcess { get; private set; }
        public void Init()
        {
            ContextFactory.AjaxProcess = this._ajaxProcess;
        }
    }
}
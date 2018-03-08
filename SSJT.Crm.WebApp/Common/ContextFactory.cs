using SSJT.Crm.Core.Server;
using SSJT.Crm.IBLL;

namespace SSJT.Crm.WebApp
{
    /// <summary>
    /// 用来获取一些实例的类
    /// </summary>
    public class ContextFactory
    {
        private IAjaxProcess _ajaxProcess;
        private IHrEmployService _hrEmployService;
        /// <summary>
        /// Ajax操作
        /// </summary>
        public static IAjaxProcess AjaxProcess { get; private set; }
        public static IHrEmployService HrEmployService { get; private set; }
        public void Init()
        {
            ContextFactory.AjaxProcess = this._ajaxProcess;
            ContextFactory.HrEmployService = this._hrEmployService;
        }
    }
}
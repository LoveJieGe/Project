using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.Core.Exceptions
{
    public enum ErrorCode
    {
        /// <summary>
        /// 数据丢失
        /// </summary>
        DataLostCode = -32090,
        /// <summary>
        /// 用户名或密码、验证码错误代码
        /// </summary>
        VErrorCode = -32091,
        /// <summary>
        /// 其他错误代码
        /// </summary>
        OErrorCode = -32090,
        /// <summary>
        /// 用户登录失败错误
        /// </summary>
        SErrorCode = -32092,
        /// <summary>
        /// 参数错误
        /// </summary>
        PErrorCode = -32093,
        /// <summary>
        /// 默认的错误代码
        /// </summary>
        Default  = 400
    }
}

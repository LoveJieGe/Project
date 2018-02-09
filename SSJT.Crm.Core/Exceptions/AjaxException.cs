using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSJT.Crm.Core.AjaxRequest;

namespace SSJT.Crm.Core.Exceptions
{
    public class AjaxException:Exception
    {
        private ErrorCode _errorCode;
        public ErrorCode ErrorCode
        {
            get { return this._errorCode; }
            private set { this._errorCode = value; }
        }
        public AjaxException(string message) : base(message)
        {
            this.ErrorCode = ErrorCode.Default;
        }
        public AjaxException(ErrorCode errcode,string message) : base(message)
        {
            this.ErrorCode = errcode;
        }
        public static AjaxException ToException(string message, params object[] values)
        {
            if (values != null && values.Length > 0)
                return new AjaxException(string.Format(message, values));
            return new AjaxException(message);
        }
        public static AjaxException ToException(ErrorCode errcode,string message, params object[] values)
        {
            if (values != null && values.Length > 0)
                return new AjaxException(errcode,string.Format(message, values));
            return new AjaxException(errcode,message);
        }
    }
}

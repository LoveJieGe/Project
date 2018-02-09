using SSJT.Crm.Core.Exceptions;

namespace SSJT.Crm.Core.AjaxRequest
{
    public class AjaxResult
    {
        public string ResponseText { get; set; }
        public string Result { get; set; }
        public object Data { get; set; }
        public AjaxMethod Method { get; set; }
        public string ErrorMsg { get; set; }
        public ErrorCode ErrorCode { get; set; }
        public bool IsSuccess { get; set; }
        public void FillResponseText()
        {
            if(this.IsSuccess)
            {
                this.ResponseText = string.Format("{{\"Result\":{0}}}", this.Result);
            }
            else
            {
                this.ResponseText = string.Format("{{\"ErrorCode\":{0},\"ErrMsg\":{1},\"Success\":{2}}}", this.ErrorCode, Ajaxhelper.ToJson(this.ErrorMsg), IsSuccess);
            }
        }
    }
}

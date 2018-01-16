using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace SSJT.Crm.Common
{
    public class BasePage:Page
    {
        protected override void OnInit(EventArgs e)
        {
            //验证输入内容
            for(int i = 0,len = this.Page.Request.Params.Count; i<len;i++)
            {
                string temp = string.Format("{0}", this.Page.Request.Params[i].ToLower());
                if (temp.Contains("<script>") || temp.Contains("</script>"))
                    throw new  Exception("从客户端检测到有潜在的危险的javascript字符3");
            }
            base.OnInit(e);
            if(!IsPostBack)
            {
                int nextIndex = GetNetIndex();
                this.AddMetaToHead(nextIndex, "meta");
                //添加图标
                HtmlLink link = new HtmlLink();
                link.Attributes.Add("rel", "shortcut icon");
            }
        }
        /// <summary>
        /// 返回<title>的下一个位置
        /// </summary>
        /// <returns></returns>
        protected int GetNetIndex()
        {
            int nextIndex = 0;
            for(int index = 0,len = this.Page.Header.Controls.Count;index<len;index++)
            {
                Control control = this.Page.Header.Controls[index];
                if (control is HtmlTitle) nextIndex = index;
            }
            return nextIndex++;
        }
        protected void AddMetaToHead(int ctrlIndex,string crdId)
        {
            LiteralControl control = new LiteralControl();
            control.ID = crdId;
            control.Text = "<meta http-equiv=\"Content-Type\" content=\"text/html;charset=utf-8\">\r\n";
            this.Page.Header.Controls.AddAt(ctrlIndex, control);
        }
    }
}

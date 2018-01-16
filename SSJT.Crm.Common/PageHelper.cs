﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.Common
{
    public class PageHelper
    {
        public static string ValidateInputText(string inputText, int maxLength)
        {
            StringBuilder sb = new StringBuilder();
            inputText = inputText.Trim();
            if (maxLength > 0 && inputText.Length > maxLength)
                throw new Exception(string.Format("超过了该输入域的最大长度[{0}]", maxLength));
            //判断是否为空
            if (!string.IsNullOrEmpty(inputText))
            {
                //替换危险字符
                for (int i = 0, len = inputText.Length; i < len; i++)
                {
                    switch (inputText[i])
                    {
                        case '"':
                            sb.Append("&quot;");
                            break;
                        case '<':
                            sb.Append("&lt;");
                            break;
                        case '>':
                            sb.Append("&gt;");
                            break;
                        default:
                            sb.Append(inputText[i]);
                            break;
                    }
                }
                sb.Replace("'", " ");
            }
            return sb.ToString();
        }
        /// <summary>
        /// 验证字符串，转换危险字符
        /// </summary>
        /// <param name="inputText"></param>
        /// <returns></returns>
        public static string ValidateInputText(string inputText)
        {
            return ValidateInputText(inputText, -1);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FrontEndRequestHandle
{
    public static class XmlHandle
    {
        /// <summary>
        /// 返回最终xml字符串给局平台
        /// </summary>
        /// <param name="rtnValue">返回状态码</param>
        /// <param name="bzxx">标志（状态）信息</param>
        /// <param name="data">附带数据</param>
        /// <returns></returns>
        public static string ReturnXml(int rtnValue, string bzxx, string data)
        {
            XElement xmlElement =
                new XElement("YyghInterface",
                    new XElement("RtnValue", rtnValue),
                    new XElement("bzxx", bzxx)
                );
            if (data != null)
            {
                xmlElement.Add(new XElement("interface", data));
            }
            return xmlElement.ToString().Trim();
        }
    }
}

using System.IO;
using System.Net;
using System.Web.Services;

namespace FrontEndWebService
{
    /// <summary>
    /// GetWado 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class GetWado : WebService
    {
        /// <summary>
        /// 替换原有前置机服务
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        [WebMethod(Description = "前置机服务--查询各医院影像前置机接口", EnableSession = false)]
        public byte[] DownloadDataFromWado(string inStr)
        {
            using (WebClient client = new WebClient())
            {
                //client.Proxy = null;
                return client.DownloadData(inStr);
            }
        }
    }
}

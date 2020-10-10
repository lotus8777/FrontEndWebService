using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FE.Context;
using FE.Model.Local;

namespace FE.Handle.Request
{
    public class WsjDqJzDlHandle : BasicHandle<WsjDqJzDlIn>, IHandle
    {
        public WsjDqJzDlHandle(FrontEndContext context, string xmlString) : base(context, xmlString)
        {

        }
        /// <summary>
        ///     获取当前排班记录序号
        /// </summary>
        /// <returns></returns>
        public string GetResultXml()
        {
            try
            {
                var gzrq = Convert.ToDateTime(InPara.gzrq);
                var yspb = Ctx.MsYspbSet.FirstOrDefault(p => p.Ksdm == InPara.ksdm
                                                             && p.Ysdm == InPara.ysdm
                                                             && p.Zblb == InPara.zblb
                                                             && p.Gzrq == gzrq
                                                             && p.MsGhks.Ghlb == InPara.ghlb);
                if (yspb == null)
                {
                    throw new Exception("获取排班信息失败！");
                }

                var wsjDqJzDlOut = new WsjDqJzDlOut
                {
                    RtnValue = 1,
                    bzxx = "获取当前就诊序号成功",
                    Jzcx = new DqJzCx
                    {
                        dqcx = yspb.Jzxh
                    }
                };
                return ConvertToObject<WsjDqJzDlOut>.SerializeXmlToString(wsjDqJzDlOut).Replace("Jzcx", "interface");
            }
            catch (Exception e)
            {
                throw new Exception("取就诊序号时发生错误 /r/n" + e.Message);
            }
        }
    }
}

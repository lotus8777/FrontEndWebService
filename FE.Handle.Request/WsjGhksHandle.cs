using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FE.Context;
using FE.Model.Local;

namespace FE.Handle.Request
{
    public class WsjGhksHandle : BasicHandle<WsjGhksIn>, IHandle
    {
        public WsjGhksHandle(FrontEndContext context, string xmlString) : base(context, xmlString)
        {

        }

        /// <summary>
        /// 获取医院挂号科室列表
        /// </summary>
        /// <returns></returns>
        public string GetResultXml()
        {
            try
            {
                var ghksRows = GetghksRows();
                if (!ghksRows.Any())
                {
                    throw new Exception("挂号科室为空！");
                }
                var wsjGhksOut = new WsjGhksOut
                {
                    RtnValue = 1,
                    bzxx = "获取挂号科室成功",
                    GhksRows = ghksRows
                };
                return ConvertToObject<WsjGhksOut>.SerializeXmlToString(wsjGhksOut).Replace("GhksRows", "interface");
            }
            catch (Exception e)
            {

                throw new Exception("获取挂号科室失败 /r/n" + e.Message);
            }
        }

        private List<GhksRow> GetghksRows()
        {
            var list = new List<GhksRow>();
            var ghksList = Ctx.MsGhksSet.Where(p => p.Kfyypb == InPara.mode && p.Zfpb == 0).ToList();
            var ksdmSet = ghksList.Select(p => p.Ksdm).Distinct();
            var payDmzds = Ctx.PayDmzdSet.Where(p => p.Dmlb == "GHKS_DZ" && ksdmSet.Contains(p.Dmsb)).ToList();
            foreach (var item in ghksList)
            {
                var row = new GhksRow()
                {
                    bzdm = payDmzds.FirstOrDefault(p => p.Dmsb == item.Ksdm)?.Dmbz ?? "",
                    ksdm = item.Ksdm,
                    ksmc = item.Ksmc,
                    zjpb = item.Ghlb == 3 ? 1 : 0,
                    ghje = item.Ghf + item.Zlf,
                    zswz = "门诊1楼",
                    bzxx = item.Zjsjap??""
                };
                list.Add(row);
            }
            return list;
        }
    }
}

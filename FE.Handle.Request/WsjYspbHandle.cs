using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FE.Context;
using FE.Model.Hrp275;
using FE.Model.Local;

namespace FE.Handle.Request
{
    public class WsjYspbHandle : BasicHandle<WsjYspbIn>, IHandle
    {
        public WsjYspbHandle(FrontEndContext context, string xmlString) : base(context, xmlString)
        {

        }

        /// <summary>
        ///     获取某个科室所有医生排班状态
        /// </summary>
        /// <returns></returns>
        public string GetResultXml()
        {
            try
            {
                var list = GetKsYspb();
                if (!list.Any())
                {
                    throw new Exception("科室排班为空");
                }
                var wsjYspbOut = new WsjYspbOut()
                {
                    RtnValue = 1,
                    bzxx = "获取排班信息成功！",
                    YspbRows = list
                };

                return ConvertToObject<WsjYspbOut>.SerializeXmlToString(wsjYspbOut).Replace("YspbRows", "interface");
            }
            catch (Exception e)
            {
                throw new Exception("获取科室排班失败--" + e.Message);
            }
        }

        private List<YspbRow> GetKsYspb()
        {

            try
            {
                var list = new List<YspbRow>();
                var kssj = Convert.ToDateTime(InPara.ksrq);
                var jssj = Convert.ToDateTime(InPara.zzrq);
                var msYspbList = Ctx.MsYspbSet.Where(p => p.Ksdm == InPara.ksdm && p.Gzrq >= kssj && p.Gzrq <= jssj)
                    .Include(p => p.GyYgdm)
                    .Include(p => p.MsGhks)
                    .ToList();

                if (msYspbList.Any())
                {
                    var ysdmSet = msYspbList.Select(p => p.Ysdm).Distinct();
                    var gzrqSet = msYspbList.Select(p => p.Gzrq).Distinct();
                    var payDmzdSet = Ctx.PayDmzdSet.Where(p => ysdmSet.Contains(p.Dmsb) && p.Dmlb == "YSDM_DZ")
                        .ToList();
                    var msFsdYyList = Ctx.MsFsdYySet.Where(p => p.Ksdm == InPara.ksdm
                                                                && ysdmSet.Contains(p.Ysdm)
                                                                && gzrqSet.Contains(p.Gzrq))
                        .ToList();

                    foreach (var item in msYspbList)
                    {
                        var sfzh = payDmzdSet.FirstOrDefault(p => p.Dmsb == item.Ysdm)?.Dmbz ?? "";

                        var pbzt = 1;
                        if (item.Tgbz == 1)
                        {
                            pbzt = 3;
                        }
                        else
                        {
                            var itemFsdYy = msFsdYyList.Where(p => p.Gzrq == item.Gzrq
                                                               && p.Zblb == item.Zblb
                                                               && p.Ksdm == item.Ksdm
                                                               && p.Ysdm == item.Ysdm)
                                .ToList();

                            var count = itemFsdYy.Count(p => p.Yylb == 1);
                            var count1 = itemFsdYy.Count(p => p.Yylb == 1 && p.Ghpb == 1);
                            if (count == 0)
                            {
                                pbzt = 0;
                            }
                            else if (count == count1)
                            {
                                pbzt = 2;
                            }
                        }
                        var yspbRow = new YspbRow
                        {
                            gzrq = item.Gzrq,
                            zblb = item.Zblb,
                            ysdm = item.Ysdm,
                            ysxm = item.GyYgdm.Ygxm,
                            djyssfzh = sfzh,
                            ghxe = item.Ghxe,
                            zjpb = item.MsGhks.Ghlb == 3 ? 1 : 0,
                            ghlb = item.MsGhks.Ghlb == 3 ? 6 : 1,
                            ghje = item.MsGhks.Ghf + item.MsGhks.Zlf,
                            pbzt = pbzt

                        };
                        list.Add(yspbRow);
                    }
                }
                return list;
            }
            catch (Exception e)
            {
                throw new Exception("获取科室所有医生排班信息失败--" + e.Message);
            }
        }
    }
}

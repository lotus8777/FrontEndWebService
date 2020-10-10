using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FE.Context;
using FE.Model.Local;

namespace FE.Handle.Request
{
    public class WsjFyqdHandle:BasicHandle<WsjFyqdIn>, IHandle
    {
        public WsjFyqdHandle(FrontEndContext context,string xmlString):base(context,xmlString)
        {
            
        }
        /// <summary>
        ///     获取住院费用清单
        /// </summary>
        /// <returns></returns>
        public string GetResultXml()
        {
            try
            {
                if (InPara?.jssj == null || InPara?.kssj == null)
                {
                    throw new Exception("查询时间不能为空!");
                }

                var patient = Ctx.ZyBrrySet.Where(p => p.Actnumber == InPara.actnumber)
                    .Include(p => p.KsBrks)
                    .Include(p => p.ZyTbkks)
                    .Include(p => p.GyBrxz)
                    .Include(p => p.ZyFymxs)
                    .FirstOrDefault();
                if (patient == null)
                {
                    throw new Exception("不存在该序号的病人住院信息!");
                }

                var validList = patient.ZyFymxs.Where(p => p.Jfrq >= InPara.start && p.Jfrq < InPara.stop).ToList();
                var jbxx = new YyghInterfaceInterfaceJbxx
                {
                    brxm = patient.Brxm,
                    fyxz = patient.GyBrxz.Xzmc,
                    ryrq = patient.Ryrq,
                    cyrq = patient.Cyrq ?? DateTime.Now,
                    zyts = (int)((patient.Cyrq ?? DateTime.Now) - patient.Ryrq).TotalDays,
                    brch = patient.Brch,
                    zyhm = patient.Zyhm,
                    ksmc = patient.KsBrks.Ksmc,
                    fyze = patient.ZyFymxs.Where(p => p.Jfrq <= InPara.stop).Sum(p => p.Zjje),
                    fyxj = validList.Sum(p => p.Zjje),
                    yjk = patient.ZyTbkks.Where(p => p.Zfpb == 0).Sum(p => p.Jkje)
                };
                var fyqd = validList.GroupBy(p => p.Fyxm)
                    .Select(t => new YyghInterfaceInterfaceItem
                    {
                        fylxdm = t.Key,
                        xmxj = t.Sum(a => a.Zjje),
                        zfxj = t.Sum(a => a.Zjje)
                    }).ToArray();

                var sfxmList = Ctx.GySfxmSet.ToList();

                foreach (var item in fyqd)
                {
                    item.fylxmc = sfxmList.FirstOrDefault(p => p.Sfxm == item.fylxdm)?.Sfmc;
                    item.fyitem = validList.Where(p => p.Fyxm == item.fylxdm)
                        .GroupBy(p => new { fyxh = p.Fyxh, fymc = p.Fymc, ypcd = p.Ypcd, fydj = p.Fydj, YPLX = p.Yplx })
                        .Select(p => new YyghInterfaceInterfaceItemFyitem
                        {
                            fydj = p.Key.fydj,
                            fymc = p.Key.fymc,
                            fysl = p.Sum(t => t.Fysl),
                            zfje = p.Sum(t => t.Zjje),
                            yblb = p.Key.YPLX,
                            fydm = p.Key.fyxh,
                            fyje = p.Sum(t => t.Zjje)
                        }).ToArray();
                }

                var outPara = new WsjFyqdOut
                {
                    RtnValue = 1,
                    bzxx = "获取住院费用清单成功",
                    FyqdGetInterface = new WsjFyqdGetInterface
                    {
                        jbxx = jbxx,
                        fyqd = fyqd
                    }
                };

                return ConvertToObject<WsjFyqdOut>.SerializeXmlToString(outPara);
            }
            catch (Exception e)
            {
                throw new Exception("获取住院清单失败" + e.Message);
            }
        }

    }
}

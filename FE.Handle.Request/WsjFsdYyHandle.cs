using System;
using System.Collections.Generic;
using System.Linq;
using FE.Context;
using FE.Model.Local;

namespace FE.Handle.Request
{
    public class WsjFsdYyHandle : BasicHandle<WsjFsdYyIn>, IHandle
    {
        public WsjFsdYyHandle(FrontEndContext context, string xmlString) : base(context, xmlString)
        {
        }

        /// <summary>
        ///     门诊分时段预约号源
        /// </summary>
        /// <returns></returns>
        public  string GetResultXml()
        {
            try
            {
                //医院排班

                DateTime gzrq = Convert.ToDateTime(InPara.gzrq);
                var yypb = Ctx.MsFsdYySet.Where(p =>
                        p.Gzrq == gzrq &&
                        p.Ksdm == InPara.ksdm &&
                        p.Ysdm == InPara.ysdm &&
                        p.Zblb == InPara.zblb &&
                        p.Yylb == 1 &&
                        p.Ghpb == 0)
                    .ToList();
                if (yypb.Any())
                {
                    var fsdYyOutRows = new List<FsdYyRow>();
                    foreach (var item in yypb)
                    {
                        var row = new FsdYyRow
                        {
                            jzxh = item.Jzxh,
                            jzsj = item.Jzsj,
                            jzsj2 = item.Jzsj.AddMinutes(30)
                        };
                        fsdYyOutRows.Add(row);
                    }

                    var wsjFsdYyOut = new WsjFsdYyOut
                    {
                        RtnValue = 1,
                        bzxx = "获取医院分时段预约明细成功",
                        FsdYyRows = fsdYyOutRows
                    };
                    return ConvertToObject<WsjFsdYyOut>.SerializeXmlToString(wsjFsdYyOut).Replace("FsdYyRows", "interface");
                }

                throw new Exception("号源为空！");
            }
            catch (Exception e)
            {
                throw new Exception("没有获取得时段号源->" + e.Message);
            }
        }
    }
}
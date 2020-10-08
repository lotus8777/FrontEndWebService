using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FE.Context;
using FE.Model.Local;

namespace FE.Handle.Request
{
    public class HosOrderHandle : BasicHandle
    {
        private HosOrderIn InPara;
        public HosOrderHandle(FrontEndContext context, string xmlString) : base(context)
        {
            InPara = ConvertToObject<HosOrderIn>.XmlDeserialize(xmlString);
        }

        public string GetHosOrders()
        {
            try
            {
                var zyBrry = Ctx.ZyBrrySet.FirstOrDefault(p => p.Actnumber == InPara.actnumber);
                if (zyBrry?.Csny == null)
                {
                    throw new Exception("检索病人信息失败！");
                }
                //var orders = Ctx.Database.SqlQuery<HosOrderItem>($"exec proc_hos_orders {zyBrry.Zyh} ").ToList();
                //if (!orders.Any())
                //{
                //    throw new Exception("检索病人医嘱信息失败！");
                //}
                var hosOrderOut = new HosOrderOut
                {
                    head = new HosOrderHead
                    {
                        jzlsh = zyBrry.Zyh,
                        mzzyhm = zyBrry.Zyhm,
                        brxm = zyBrry.Brxm,
                        brxb = zyBrry.Brxb,
                        brnl = (int)(DateTime.Now - zyBrry.Csny.Value).TotalDays / 365 + 1,
                        lxdh = zyBrry.Dwdh,
                        jtdz = zyBrry.Gzdw,
                        nldw = "岁"
                    },
                    list = GetHosOrdersItems(zyBrry.Zyh)
                };
                return ConvertToObject<HosOrderOut>.SerializeXmlToString(hosOrderOut);
            }
            catch (Exception e)
            {
                throw new Exception("获取病人医嘱信息失败->" + e.Message);
            }
        }

        public List<HosOrderItem> GetHosOrdersItems(int zyh)
        {
            try
            {
                var zyBqyzSet = Ctx.ZyBqyzSet.Where(p => p.Zyh == zyh)
                    .Include(p => p.GyKsdm)
                    .Include(p => p.GyYgdm)
                    .Include(p => p.ZyYpyf)
                    .Include(p => p.GySypc)
                    .OrderByDescending(p => p.Kssj)
                    .ThenBy(p => new { p.Yzzh, p.Jlxh })
                    .ToList();
                if (!zyBqyzSet.Any())
                {
                    throw new Exception("获取医嘱列表失败");
                }
                var drugList = zyBqyzSet.Where(p => p.Yplx != 0)
                    .Select(p => p.Ypxh)
                    .Distinct();
                var treatList = zyBqyzSet.Where(p => p.Yplx == 0)
                    .Select(p => p.Ypxh)
                    .Distinct();

                var ykTypkList = Ctx.YkTypkSet.Where(p => drugList.Contains(p.Ypxh));
                var gyYlsfList = Ctx.GyYlsfSet.Where(p => treatList.Contains(p.Fyxh))
                    .Include(p => p.GySfxm);

                var list = new List<HosOrderItem>();
                foreach (var item in zyBqyzSet)
                {
                    string orderClass;
                    var dosage = "";
                    var duration = 0;
                    var tzsj = item.Tzsj ?? DateTime.Now;
                    if (item.Kssj.HasValue)
                    {
                        duration = (int)(tzsj - item.Kssj.Value).TotalDays + 1;
                    }

                    if (item.Yplx == 0)
                    {
                        dosage = "";
                    }
                    else
                    {
                        var ykTypk = ykTypkList.FirstOrDefault(p => p.Ypxh == item.Ypxh);
                        if (ykTypk != null)
                        {
                            dosage = $"{item.Ycjl}{ykTypk.Jldw}";
                        }
                    }
                    if (item.Yplx == 1)
                    {
                        orderClass = "西药";
                    }
                    else if (item.Yplx == 2)
                    {
                        orderClass = "中成药";
                    }
                    else if (item.Yplx == 3)
                    {
                        orderClass = "中草药";
                    }
                    else
                    {
                        orderClass = gyYlsfList.FirstOrDefault(p => p.Fyxh == item.Ypxh)?.GySfxm.Sfmc ?? "";
                    }
                    var hosOrderItem = new HosOrderItem
                    {
                        ORDER_NO = item.Yzzh,
                        ORDER_SUB_NO = item.Jlxh,
                        REPEAT_INDICATOR = item.Lsyz == 0 ? 1 : 0,
                        ORDER_CLASS = orderClass,
                        ORDER_TEXT = item.Yzmc,
                        DOSAGE = dosage,
                        ADMINISTRATION = item.ZyYpyf.Xmmc ?? "",
                        START_DATE_TIME = item.Kssj.HasValue ? item.Kssj.Value.ToString("yyyy-MM-ddTHH:mm:ss") : "",
                        STOP_DATE_TIME = item.Tzsj.HasValue ? item.Tzsj.Value.ToString("yyyy-MM-ddTHH:mm:ss") : "",
                        DURATION = $"{duration}天",
                        FREQUENCY = item.GySypc.Pcmc ?? "",
                        FREQ_DETAIL = item.GySypc.Pcmc ?? "",
                        PERFORM_SCHEDULE = item.Qrsj.HasValue ? item.Qrsj.Value.ToString("yyyy-MM-ddTHH:mm:ss") : "",
                        PERFORM_RESULT = "",
                        ORDERING_DEPT = item.GyKsdm.Ksmc ?? "",
                        DOCTOR = item.GyYgdm.Ygxm ?? "",
                        STOP_DOCTOR = item.GyYgdm.Ygxm ?? "",
                        NURSE = "",
                        STOP_NURSE = "",
                        ORDER_STATUS = item.Qrsj.HasValue ? (item.Lsbz == 0 ? 2 : 3) : 1,
                        DRUG_BILLING_ATTR = item.Fysx == 2 ? 1 : 0,
                        BILLING_ATTR = item.Fysx == 2 ? 1 : 0,
                        LAST_PERFORM_DATE_TIME = item.Qrsj.HasValue ? item.Qrsj.Value.ToString("yyyy-MM-ddTHH:mm:ss") : ""
                    };
                    list.Add(hosOrderItem);
                }
                return list;
            }
            catch (Exception e)
            {

                throw new Exception("获取医嘱信息过程出现错误->" + e.Message);
            }
        }
    }
}

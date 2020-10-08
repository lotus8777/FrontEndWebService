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
    public class HosInvoiceFactory : BasicFactory
    {
        private readonly HosInvoiceIn _inPara;
        public HosInvoiceFactory(FrontEndContext context, string inXmlStr) : base(context)
        {
            _inPara = ConvertToObject<HosInvoiceIn>.XmlDeserialize(inXmlStr);
        }
        /// <summary>
        ///     获取发票费用明细
        /// </summary>
        /// <returns></returns>
        public string GetHosInvoice()
        {
            try
            {
                var invoiceItems = new List<InvoiceItem>();
                invoiceItems.AddRange(GetExaminationItems());
                invoiceItems.AddRange(GetRecipeItems());
                var hosInvoiceOut = new HosInvoiceOut()
                {
                    sfxmmx = invoiceItems
                };
                return ConvertToObject<HosInvoiceOut>.SerializeXmlToString(hosInvoiceOut);
            }
            catch (Exception e)
            {

                throw new Exception("发票信息获取失败" + e.Message);
            }
        }

        /// <summary>
        /// 获取检查项目信息
        /// </summary>
        /// <returns></returns>
        private IList<InvoiceItem> GetExaminationItems()
        {
            try
            {
                var invoiceItems = new List<InvoiceItem>();
                var msYj01 = _ctx.MsYj01Set.Where(p => p.Fphm == _inPara.fphm)
                    .Include(p => p.MsYj02.Select(y => y.GyYlsf))
                    .Include(p => p.GyKsdm)
                    .FirstOrDefault();
                if (msYj01?.MsYj02 != null)
                {
                    var fyxh = msYj01.MsYj02.Select(p => p.Ylxh).Distinct();
                    var ybFydz = _ctx.YbFydzSet.Where(p => fyxh.Contains(p.Fyxh)
                                                           && p.Kssj <= msYj01.Kdrq
                                                           && (p.Zzsj == null || p.Zzsj >= msYj01.Kdrq))
                        .ToList();

                    foreach (var item in msYj01.MsYj02)
                    {

                        var fydj = ybFydz.FirstOrDefault(p => p.Fyxh == item.Ylxh)?.Fydj;
                        var itemClass = "";
                        if (fydj == "1")
                        {
                            itemClass = "甲";
                        }
                        else if (fydj == "2")
                        {
                            itemClass = "乙";
                        }
                        else
                        {
                            itemClass = "丙";
                        }
                        var invoiceItem = new InvoiceItem()
                        {
                            item_no = item.Sbxh,
                            item_code = item.Ylxh,
                            item_class = itemClass,
                            item_name = item.GyYlsf.Fymc,
                            item_spec = "",
                            units = item.GyYlsf.Fydw,
                            ammount = item.Ylsl,
                            unitprice = item.Yldj,
                            price = item.Ylsl * item.Yldj,
                            zxksbm = msYj01.Zxks.HasValue ? msYj01.Zxks.ToString() : "",
                            zxksmc = msYj01.GyKsdm.Ksmc,
                            zfbl = item.Zfbl*100

                        };
                        invoiceItems.Add(invoiceItem);
                    }
                }
                return invoiceItems;
            }
            catch (Exception e)
            {
                throw new Exception("获取检查项目信息失败->"+e.Message);
            }
           
        }

        /// <summary>
        /// 获取处方项目信息
        /// </summary>
        /// <returns></returns>
        private IList<InvoiceItem> GetRecipeItems()
        {

            var invoiceItems = new List<InvoiceItem>();
            var msCf01 = _ctx.MsCf01Set.Where(p => p.Fphm == _inPara.fphm)
                   .Include(p => p.MsCf02.Select(t => t.YkTypk))
                   .Include(p => p.GyKsdm)
                   .FirstOrDefault();
            if (msCf01?.MsCf02 != null)
            {
                var ypxh = msCf01.MsCf02.Select(p => p.Ypxh).Distinct();
                var ypYpdz = _ctx.YbYpdzNewSet.Where(p => ypxh.Contains(p.Ypxh)
                    && p.Kssj <= msCf01.Kfrq
                    && (p.Zzsj >= msCf01.Kfrq || p.Zzsj == null))
                    .ToList();
                foreach (var item in msCf01.MsCf02)
                {

                    var ypdj = ypYpdz.FirstOrDefault(p => p.Ypxh == item.Ypxh)?.Ypdj;
                    string itemClass;
                    if (ypdj == "1")
                    {
                        itemClass = "甲";
                    }
                    else if (ypdj == "2")
                    {
                        itemClass = "乙";
                    }
                    else
                    {
                        itemClass = "丙";
                    }
                    var invoiceItem = new InvoiceItem()
                    {
                        item_no = item.Sbxh,
                        item_code = item.Ypxh,
                        item_class = itemClass,
                        item_name = item.YkTypk.Ypmc,
                        item_spec = item.YkTypk.Ypgg,
                        units = item.Yfdw,
                        ammount = item.Ypsl * item.Cfts,
                        unitprice = item.Ypdj,
                        price = item.Ypdj * item.Ypsl * item.Cfts,
                        zxksbm = msCf01.Ksdm.HasValue ? msCf01.Ksdm.ToString() : "",
                        zxksmc = msCf01.GyKsdm.Ksmc,
                        zfbl = item.Zfbl*100

                    };
                    invoiceItems.Add(invoiceItem);
                }
            }

            return invoiceItems;
        }
    }
}

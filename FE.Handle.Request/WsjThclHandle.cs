using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using FE.Context;
using FE.Model.Hrp275;
using FE.Model.Local;
namespace FE.Handle.Request
{
    public class WsjThclHandle : BasicHandle<WsjThclIn>
    {
        //private readonly WsjThclIn InPara;
        public WsjThclHandle(FrontEndContext context, string inXmlStr) : base(context,inXmlStr)
        {
            //InPara = ConvertToObject<WsjThclIn>.XmlDeserialize(inXmlStr);
        }
        /// <summary>
        ///     退号处理
        /// </summary>
        /// <returns></returns>
        public string GetWsjThcl()
        {
            using (var transaction = Ctx.Database.BeginTransaction())
            {
                try
                {
                    var msYygh = Ctx.MzYyghSet.Where(p => p.Yyxh == InPara.ghxh)
                        .Include(p => p.MsGhmx)
                        .Include(p => p.MsYj01.MsYj02)
                        .FirstOrDefault();
                    if (msYygh?.Yyrq == null)
                    {
                        throw new Exception("获取ms_yygh数据有错误!");
                    }
                    msYygh.Ghbz = 2;
                    msYygh.MsGhmx.Thbz = 1;
                    Ctx.MsYj02Set.RemoveRange(msYygh.MsYj01.MsYj02);
                    Ctx.MsYj01Set.Remove(msYygh.MsYj01);
                    //获取工作日期
                    var gzrq = msYygh.Yyrq.Value.Date;
                    //修改ms_yspb信息，释放排班
                    var msYspb = Ctx.MzYspbSet.FirstOrDefault(p => p.Gzrq == gzrq
                                                                    && p.Ksdm == msYygh.Ksdm
                                                                    && p.Ysdm == msYygh.Ysdm
                                                                    && p.Zblb == msYygh.Zblb);
                    if (msYspb == null)
                    {
                        throw new Exception("获取ms_yspb数据有错误!");
                    }
                    --msYspb.Yyrs;
                    --msYspb.Ygrs;
                    --msYspb.Jzxh;
                    //释放号源
                    var fsdyy = Ctx.MzFsdYySet.FirstOrDefault(p => p.Gzrq == gzrq
                                                                    && p.Ksdm == msYygh.Ksdm
                                                                    && p.Ysdm == msYygh.Ysdm
                                                                    && p.Zblb == msYygh.Zblb
                                                                    && p.Jzxh == msYygh.Jzxh);
                    if (fsdyy == null)
                    {
                        throw new Exception("获取ms_fsdyyb数据有错误!");
                    }
                    fsdyy.Ghpb = 0;
                    fsdyy.Brxm = string.Empty;
                    fsdyy.Brid = null;
                    Ctx.SaveChanges();
                    transaction.Commit();
                    var a = new YyghInterface
                    {
                        RtnValue = 1,
                        bzxx = "门诊退号成功！"
                    };
                    return ConvertToObject<YyghInterface>.SerializeXmlToString(a);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception("门诊退号失败" + e.Message);
                }
            }
        }
    }
}

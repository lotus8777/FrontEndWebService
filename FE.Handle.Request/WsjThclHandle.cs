using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using FE.Context;
using FE.Model.Hrp275;
using FE.Model.Local;
namespace FE.Handle.Request
{
    public class WsjThclHandle : BasicHandle
    {
        private readonly WsjThclIn _inPara;
        public WsjThclHandle(FrontEndContext context, string inXmlStr) : base(context)
        {
            _inPara = ConvertToObject<WsjThclIn>.XmlDeserialize(inXmlStr);
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
                    var msYygh = Ctx.MzYyghSet.Find(_inPara.ghxh);
                    if (msYygh?.Yyrq == null)
                    {
                        throw new Exception("获取ms_yygh数据有错误!");
                    }
                    msYygh.Ghbz = 2;
                    var msGhmx = Ctx.MzGhmxSet.Find(msYygh.Ghsbxh);
                    if (msGhmx == null)
                    {
                        throw new Exception("获取ms_ghmx数据有错误!");
                    }
                    msGhmx.Thbz = 1;
                    //删除MS_yj02
                    var yj02 = Ctx.MsYj02Set.Where(p => p.Yjxh == msYygh.Yjsbxh);
                    if (yj02.Any())
                    {
                        Ctx.MsYj02Set.RemoveRange(yj02);
                    }
                    //删除MS_YJ01
                    if (msYygh.Yjsbxh != null)
                    {
                        var yj01 = new MsYj01
                        {
                            Yjxh = msYygh.Yjsbxh.Value
                        };
                        Ctx.MsYj01Set.Attach(yj01);
                        Ctx.MsYj01Set.Remove(yj01);
                    }
                    //获取工作日期
                    var gzrq = msYygh.Yyrq.Value.Date;
                    //修改ms_yspb信息，释放号源
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

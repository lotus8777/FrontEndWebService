﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Xml;
using System.Xml.Linq;
using FE.Context;
using FE.Model.Hrp275;
using FE.Model.Local;
using Newtonsoft.Json;
namespace FE.Handle.Request
{
    public class ExecuteProcedureFactory
    {
        private readonly FrontEndContext _ctx;
        private readonly GenericConfig _config;
        public ExecuteProcedureFactory(FrontEndContext context)
        {
            _ctx = context;
            _config = GetGenericConfig();
        }



        /// <summary>
        /// 退号处理
        /// </summary>
        /// <param name="inXmlStr"></param>
        /// <returns></returns>
        public string GetThcl(string inXmlStr)
        {
            XElement root = null;
            using (var transaction = _ctx.Database.BeginTransaction())
            {
                try
                {
                    var xml = XElement.Parse(inXmlStr);
                    var ghxh = xml.Descendants().FirstOrDefault(p => p.Name == "ghxh")?.Value;
                    var yyxh = Convert.ToInt32(ghxh);
                    var msYygh = _ctx.MzYyghSet.Find(yyxh);
                    if (msYygh?.Yyrq == null) throw new Exception("获取ms_yygh数据有错误!");
                    msYygh.Ghbz = 2;
                    var msGhmx = _ctx.MzGhmxSet.Find(msYygh.Ghsbxh);
                    if (msGhmx == null) throw new Exception("获取ms_ghmx数据有错误!");
                    msGhmx.Thbz = 1;
                    var yj02 = _ctx.MsYj02Set.Where(p => p.Yjxh == msYygh.Yjsbxh);
                    if (yj02.Any())
                    {
                        _ctx.MsYj02Set.RemoveRange(yj02);
                    }

                    if (msYygh.Yjsbxh != null)
                    {
                        var yj01 = new MsYj01()
                        {
                            Yjxh = msYygh.Yjsbxh.Value
                        };
                        _ctx.MsYj01Set.Attach(yj01);
                        _ctx.MsYj01Set.Remove(yj01);

                    }
                    //获取工作日期
                    var gzrq = msYygh.Yyrq.Value.Date;
                    //修改ms_yspb信息，释放号源
                    var msYspb = _ctx.MzYspbSet.FirstOrDefault(p => p.Gzrq == gzrq
                                                                && p.Ksdm == msYygh.Ksdm
                                                                && p.Ysdm == msYygh.Ysdm
                                                                && p.Zblb == msYygh.Zblb);
                    if (msYspb == null) throw new Exception("获取ms_yspb数据有错误!");
                    --msYspb.Yyrs;
                    --msYspb.Ygrs;
                    --msYspb.Jzxh;

                    var fsdyy = _ctx.MzFsdYySet.FirstOrDefault(p => p.Gzrq == gzrq
                                                                        && p.Ksdm == msYygh.Ksdm
                                                                        && p.Ysdm == msYygh.Ysdm
                                                                        && p.Zblb == msYygh.Zblb
                                                                        && p.Jzxh == msYygh.Jzxh);
                    if (fsdyy == null) throw new Exception("获取ms_fsdyyb数据有错误!");
                    fsdyy.Ghpb = 0;
                    fsdyy.Brxm = string.Empty;
                    fsdyy.Brid = null;

                    _ctx.SaveChanges();
                    transaction.Commit();
                    root = new XElement("YyghInterface",
                            new XElement("RtnValue", 1),
                            new XElement("bzxx", "门诊退号成功")
                            );
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return ReturnXml(-1, "wsj_Thcl" + e.Message, null);
                }
            }
            return root.ToString();
        }

        /// <summary>
        /// 获取住院费用清单
        /// </summary>
        /// <param name="inXmlStr"></param>
        /// <returns></returns>
        public string GetWsjFyqd(string inXmlStr)
        {

            try
            {

                var inPara = ConvertToObject<WsjFyqdGetIn>.XmlDeserialize(inXmlStr);
                if (inPara?.jssj == null || inPara?.kssj == null)
                {
                    throw new Exception("查询时间不能为空!");
                }

                var patient = _ctx.ZyBrrySet.Where(p => p.Actnumber == inPara.actnumber)
                    .Include(p => p.KsBrks)
                    .Include(p => p.Jkmx)
                    .Include(p => p.GyBrxz)
                    .Include(p => p.Fymx)
                    .FirstOrDefault();
                if (patient == null)
                {
                    throw new Exception("不存在该序号的病人住院信息!");
                }

                var validList = patient.Fymx.Where(p => p.Jfrq >= inPara.start && p.Jfrq < inPara.stop).ToList();
                var jbxx = new YyghInterfaceInterfaceJbxx()
                {
                    brxm = patient.Brxm,
                    fyxz = patient.GyBrxz.Xzmc,
                    ryrq = patient.Ryrq,
                    cyrq = patient.Cyrq ?? DateTime.Now,
                    zyts = (int)((DateTime)(patient.Cyrq ?? DateTime.Now) - patient.Ryrq).TotalDays,
                    brch = patient.Brch,
                    zyhm = patient.Zyhm,
                    ksmc = patient.KsBrks.Ksmc,
                    fyze = patient.Fymx.Where(p => p.Jfrq <= inPara.stop).Sum(p => p.Zjje),
                    fyxj = validList.Sum(p => p.Zjje),
                    yjk = patient.Jkmx.Where(p => p.Zfpb == 0).Sum(p => p.Jkje)
                };
                var fyqd = validList.GroupBy(p => p.Fyxm)
                    .Select(t => new YyghInterfaceInterfaceItem()
                    {
                        fylxdm = t.Key,
                        xmxj = t.Sum(a => a.Zjje),
                        zfxj = t.Sum(a => a.Zjje)

                    }).ToArray();

                var sfxmList = _ctx.GySfxmSet.ToList();

                foreach (var item in fyqd)
                {
                    item.fylxmc = sfxmList.FirstOrDefault(p => p.Sfxm == item.fylxdm)?.Sfmc;
                    item.fyitem = validList.Where(p => p.Fyxm == item.fylxdm)
                        .GroupBy(p => new { fyxh = p.Fyxh, fymc = p.Fymc, ypcd = p.Ypcd, fydj = p.Fydj, YPLX = p.Yplx })
                        .Select(p => new YyghInterfaceInterfaceItemFyitem()
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
                var outPara = new WsjFyqdGetOut()
                {
                    RtnValue = 1,
                    bzxx = "获取住院费用清单成功",
                    FyqdGetInterface = new WsjFyqdGetInterface()
                    {
                        jbxx = jbxx,
                        fyqd = fyqd
                    }
                };

                return ConvertToObject<WsjFyqdGetOut>.XmlSerialize(outPara);

            }
            catch (Exception e)
            {
                return ReturnXml(-1, "获取住院费用清单失败" + e.InnerException?.Message, null);
            }
        }

        public string GetHosOrders(string inXmlStr)
        {
            try
            {
                var xmlNodes = GetXmlNodes(inXmlStr);
                var actNumber = xmlNodes.FirstOrDefault(p => p.Name == "actnumber")?.Value;
                var zyBrry = _ctx.ZyBrrySet.FirstOrDefault(p => p.Actnumber == actNumber);
                if (zyBrry?.Csny == null)
                {
                    throw new Exception("检索病人信息失败！");
                }
                var head = new HosOrderHead()
                {
                    jzlsh = zyBrry.Zyh,
                    mzzyhm = zyBrry.Zyhm,
                    brxm = zyBrry.Brxm,
                    brxb = zyBrry.Brxb,
                    brnl = (int)(DateTime.Now - zyBrry.Csny.Value).TotalDays / 365 + 1,
                    lxdh = zyBrry.Dwdh,
                    jtdz = zyBrry.Gzdw
                };
                var orders = _ctx.Database.SqlQuery<HosOrderItem>($"exec proc_hos_orders {zyBrry.Zyh} ").ToList();
                if (!orders.Any())
                {
                    throw new Exception("检索病人医嘱信息失败！");
                }
                var listNode = new XElement("list");
                foreach (var order in orders)
                {
                    listNode.Add(order.ToXml("item"));
                }

                var root = new XElement("interface",
                    new XElement("RtnValue", 1),
                    new XElement("bzxx", "获取病人医嘱信息成功"),
                    head.ToXml("head"),
                    listNode
                );
                return root.ToString();
            }
            catch (Exception e)
            {
                return ReturnXml(-1, "获取医嘱信息失败" + e.Message, null);
            }

        }

        /// <summary>
        /// 挂号处理
        /// </summary>
        /// <param name="inXml"></param>
        /// <returns></returns>
        public string GetGhcl(string inXml)
        {
            XElement root = null;
            using (var transaction = _ctx.Database.BeginTransaction())
            {

                try
                {
                    var para = ConvertToObject<GhclParameter>.GetObjectFromXml(inXml);
                    //获取当前预约挂号涉及的门诊侦查费
                    GetMedicalFee(para);
                    GetTableKey(para);
                    ProcessMzBrda(para, _config.HZYB_BRXZ);
                    //判断是否满足挂号条件
                    CanYyGh(para);
                    //开始预约挂号操作
                    //获取jzhm
                    para.jzhm = GetJzhm(_config.CZGH);
                    //获取各表的key值
                    if (string.IsNullOrEmpty(para.pzhm))
                    {
                        //插入MsYYGH
                        InsertMsYygh(para);
                    }
                    else
                    {
                        //更新msyy_ghxx
                        UpdateMsyyGhxx(para.pzhm);
                        //更新ms_yygh
                        UpdateMsyyGh(para);
                    }

                    //插入ms_ghmx
                    InsertMzGhmx(para, _config.CZGH);
                    var yj2Count = para.yj02xh.Length;
                    if (yj2Count > 0)
                    {
                        //插入ms_yj01
                        InsertMzYj01(para);
                        //插入ms_yj02
                        InsertMzYj02(para);
                    }
                    //更新挂号人数
                    UpdateMzYspb(para);
                    //锁定号源
                    LockMzFsdyy(para);

                    transaction.Commit();
                    root = new XElement("YyghInterface",
                        new XElement("RtnValue", 1),
                        new XElement("bzxx", "预约挂号成功"),
                        new XElement("interface",
                                new XElement("row",
                                    new XElement("ghxh", para.yyxh)))
                    );
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return ReturnXml(-1, "wsj_ghcl" + e.Message, null);
                }
            }
            return root.ToString();
        }

        /// <summary>
        /// 获取就诊号码
        /// </summary>
        /// <param name="czgh"></param>
        /// <returns></returns>
        private string GetJzhm(string czgh)
        {
            try
            {
                var ygpj = _ctx.MzYgpjSet.FirstOrDefault(p => p.Ygdm == czgh && p.Pjlx == 1 && p.Sypb == 0);
                if (ygpj == null) throw new Exception("取就诊号码(挂号发票号码)失败！");
                var syhm = Convert.ToInt32(ygpj.Syhm);
                var zzhm = Convert.ToInt32(ygpj.Zzhm);
                if (syhm > zzhm) throw new Exception("票据号码用完了，无法挂号！");
                ygpj.Syhm = (++syhm).ToString();
                _ctx.SaveChanges();
                return syhm.ToString();
            }
            catch (Exception e)
            {
                throw new Exception("获取就诊号码失败" + e.Message);
            }

        }

        private void UpdateMsyyGhxx(string pzhm)
        {
            try
            {
                var yyghxx = _ctx.MzyyGhxxSet.FirstOrDefault(p => p.Pzhm == pzhm);
                if (yyghxx == null) throw new Exception("取MSYY_GhXX失败！");
                yyghxx.Yyzt = 1;
                _ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("更新MSYY_GhXX失败" + e.Message);
            }
        }
        private void UpdateMsyyGh(GhclParameter para)
        {
            try
            {
                var yygh = _ctx.MzYyghSet.FirstOrDefault(p => p.Pzhm == para.pzhm);
                if (yygh == null) throw new Exception("取MS_YYGH失败！");
                yygh.Ghbz = 1;
                yygh.Sbxh = para.ghxh;
                yygh.Ghsbxh = para.ghxh;
                yygh.Yjsbxh = para.yj01xh;
                _ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("更新Ms_yygh失败" + e.Message);
            }
        }
        /// <summary>
        /// 插入Ms_YYGH
        /// </summary>
        private void InsertMsYygh(GhclParameter para)
        {
            try
            {
                var yygh = new MsYygh()
                {
                    Yyxh = para.yyxh,
                    Yymm = "123",
                    Ghrq = DateTime.Now,
                    Brid = para.brid,
                    Ksdm = para.ksdm,
                    Ysdm = para.ysdm,
                    Jzxh = para.jzxh,
                    Brxm = para.brxm,
                    Zcid = 0,
                    Ghbz = 1,
                    Zblb = para.zblb,
                    Yylb = para.yylb,
                    Yyrq = para.jzsj,
                    Ghsbxh = para.ghxh,
                    Yjsbxh = para.yj01xh
                };
                _ctx.MzYyghSet.Add(yygh);
                _ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("插入Ms_yygh失败" + e.Message);
            }
        }
        /// <summary>
        /// 插入ms_ghmx
        /// </summary>
        /// <param name="para"></param>
        /// <param name="czgh"></param>
        private void InsertMzGhmx(GhclParameter para, string czgh)
        {
            try
            {
                DateTime ghsj;
                if (para.zblb == 1)
                {
                    //上午挂号时间+8小时
                    ghsj = para.gzrq.AddHours(8);
                }
                else
                {
                    //下午挂号时间+13小时
                    ghsj = para.gzrq.AddHours(13);
                }
                //插入ms_ghmx
                var ghmx = new MsGhmx()
                {
                    Sbxh = para.ghxh,
                    Brid = para.brid,
                    Brxz = para.brxz,
                    Ghsj = ghsj,
                    Ghlb = para.ghlb,
                    Ksdm = para.ksdm,
                    Ysdm = para.ysdm,
                    Jzxh = para.jzxh,
                    Czgh = czgh,
                    Jzhm = para.jzhm,
                    Yybz = 1,
                    Mzlb = 1,
                    Qybr = para.qybr,
                    Jzsj = para.jzsj,
                    Zblb = para.zblb
                };
                _ctx.MzGhmxSet.Add(ghmx);
                _ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("插入Ms_ghmx失败" + e.Message);
            }
        }
        /// <summary>
        /// 插入Ms_yj01数据
        /// </summary>
        /// <param name="para"></param>
        private void InsertMzYj01(GhclParameter para)
        {
            try
            {
                var mzYj01 = new MsYj01()
                {
                    Yjxh = para.yj01xh,
                    Brid = para.brid,
                    Brxm = para.brxm,
                    Kdrq = para.gzrq,
                    Ksdm = Convert.ToDecimal(para.ksdm),
                    Ysdm = para.ysdm,
                    Zxks = para.mzks,
                    Zysx = "签约挂号",
                    Hymx = para.jzhm,
                    Qybr = para.qybr,
                    Cfbz = 0
                };
                _ctx.MsYj01Set.Add(mzYj01);
                _ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("插入Ms_YJ01失败" + e.Message);
            }
        }
        /// <summary>
        /// 插入Ms_yj02数据
        /// </summary>
        /// <param name="para"></param>
        private void InsertMzYj02(GhclParameter para)
        {
            try
            {
                var count = para.yj02xh.Length;
                for (int i = 0; i < count; i++)
                {
                    var ylxh = para.ZlfList[i].Item1;
                    var yldj = para.ZlfList[i].Item2;
                    var yj02 = new MsYj02()
                    {
                        Sbxh = para.yj02xh[i],
                        Yjxh = para.yj01xh,
                        Ylxh = ylxh,
                        Xmlx = 0,
                        Yjzx = 1,
                        Yldj = yldj,
                        Ylsl = 1,
                        Hjje = yldj,
                        Fygb = _config.ZCFGB,
                        Zfbl = 1,
                        Zfpb = 0
                    };
                    _ctx.MsYj02Set.Add(yj02);
                }
                _ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("插入Ms_YJ02失败" + e.Message);
            }
        }
        /// <summary>
        /// 更新医生排班可挂号数量
        /// </summary>
        /// <param name="para"></param>
        private void UpdateMzYspb(GhclParameter para)
        {
            try
            {
                var yspb = _ctx.MzYspbSet.FirstOrDefault(p => p.Gzrq == para.gzrq
                                                              && p.Ksdm == para.ksdm
                                                              && p.Ysdm == para.ysdm
                                                              && p.Zblb == para.zblb);
                if (yspb == null) throw new Exception("获取医生排班信息失败！");
                var ygrs = yspb.Ygrs;
                var jzxhOld = yspb.Jzxh;
                yspb.Ygrs = ygrs + 1;
                yspb.Jzxh = jzxhOld + 1;
                _ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("更新已挂人数失败" + e.Message);
            }
        }
        /// <summary>
        /// 锁定号源
        /// </summary>
        /// <param name="para"></param>
        private void LockMzFsdyy(GhclParameter para)
        {
            try
            {
                var fsdyy = _ctx.MzFsdYySet.FirstOrDefault(p => p.Gzrq == para.gzrq
                                                                && p.Ksdm == para.ksdm
                                                                && p.Ysdm == para.ysdm
                                                                && p.Zblb == para.zblb
                                                                && p.Jzxh == para.jzxh
                                                                && p.Ghpb == 0);
                if (fsdyy == null) throw new Exception("获取号源ms_fsdyyb失败！");
                fsdyy.Ghpb = 1;
                fsdyy.Brxm = para.brxm;
                fsdyy.Brid = para.brid;
                _ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("锁定号源失败" + e.Message);
            }
        }
        /// <summary>
        /// 获取各个表的Key值
        /// </summary>
        /// <param name="para"></param>
        private void GetTableKey(GhclParameter para)
        {
            try
            {
                //
                var keyTable = _ctx.MzIdentitySet.ToList();
                var keyBrda = keyTable.FirstOrDefault(p => p.Bmc == "MS_BRDA");
                if (keyBrda == null) throw new Exception("取MS_BRDA序号失败！");
                var brid = keyBrda.Dqz + 1;
                keyBrda.Dqz = brid;
                para.brid = brid;
                var keyYygh = keyTable.FirstOrDefault(p => p.Bmc == "MS_YYGH");
                if (keyYygh == null) throw new Exception("取MS_YYGH序号失败！");
                para.yyxh = keyYygh.Dqz + 1;
                keyYygh.Dqz = para.yyxh;
                var keyGhMx = keyTable.FirstOrDefault(p => p.Bmc == "MS_GHMX");
                if (keyGhMx == null) throw new Exception("取MS_GHMX序号失败！");
                para.ghxh = keyGhMx.Dqz + 1;
                keyGhMx.Dqz = para.ghxh;
                var yj01 = keyTable.FirstOrDefault(p => p.Bmc == "MS_YJ01");
                if (yj01 == null) throw new Exception("取MS_YJ01序号失败！");
                para.yj01xh = yj01.Dqz + 1;
                yj01.Dqz = para.yj01xh;
                var yj02 = keyTable.FirstOrDefault(p => p.Bmc == "MS_YJ02");
                if (yj02 == null) throw new Exception("取MS_YJ02序号失败！");
                var count = para.ZlfList.Count;
                int[] arr = new int[count];
                for (int i = 0; i < count; i++)
                {
                    arr[i] = yj02.Dqz + i + 1;
                }
                yj02.Dqz = arr[count - 1];
                para.yj02xh = arr;
                _ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void ProcessMzBrda(GhclParameter para, string ybxz)
        {
            try
            {
                //判断病人性质
                if (para.cardtype == 1)
                {
                    //市民卡处理
                    if (string.IsNullOrEmpty(para.ybkh)) throw new Exception("传入医保卡号长度不对");
                    var left4 = para.ybkh.Substring(0, 4);
                    if (left4 == "3301")
                    {
                        para.brxz = Convert.ToInt32(ybxz);
                        para.qybr = 1;
                    }
                    else
                    {
                        para.brxz = 1000;
                        para.qybr = 5;
                    }
                }
                else
                {
                    para.brxz = 1000;
                    para.qybr = 5;
                }
                //判断档案是否存在
                var record = _ctx.MzBrdaSet.Where(p => p.Brxm == para.brxm && p.Sfzh == para.sfzh && p.Brxz == para.brxz).OrderByDescending(p => p.Brid).FirstOrDefault();
                if (record != null)
                {
                    UpdateMzBrda(record, para);
                    para.brid = (int)record.Brid;
                }
                else
                {
                    //新建档案
                    record = CreateMzBrda(para);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 是否能预约挂号
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        private bool CanYyGh(GhclParameter para)
        {
            try
            {
                if (string.IsNullOrEmpty(para.pzhm))
                {
                    var notHas = _ctx.MzYyghSet.Any(p =>
                        p.Yyrq == para.gzrq && p.Zblb == para.zblb && p.Ksdm == para.ksdm && p.Ysdm == para.ysdm &&
                        p.Jzxh == para.jzxh && p.Ghbz == 0);
                    if (notHas) throw new Exception("该挂号序号已有人预约");
                }
                else
                {
                    var hasRegistered = _ctx.MzYyghSet.Any(p => p.Pzhm == para.pzhm && (p.Ghbz == 0 || p.Ghbz == 1));
                    if (!hasRegistered) throw new Exception("获取预约信息失败");
                }
                var source = _ctx.MzFsdYySet.Where(p =>
                    p.Gzrq == para.gzrq && p.Zblb == para.zblb && p.Ksdm == para.ksdm && p.Ysdm == para.ysdm).ToList();
                if (source.Any(p => p.Brid == para.brid)) throw new Exception("存在同时段同科室同医生预约挂号");
                var hy = source.FirstOrDefault(p => p.Jzxh == para.jzxh);
                if (hy == null) throw new Exception("取就诊时间失败");
                para.jzsj = hy.Jzsj;
                var lsbrxm = hy.Brxm;
                if (!string.IsNullOrEmpty(lsbrxm) && string.IsNullOrEmpty(para.pzhm))
                    throw new Exception("该号已经被占用，请重新选择");
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("判断是否可以预约挂号出错" + e.Message);
            }
        }
        /// <summary>
        /// 获取挂号费用
        /// </summary>
        /// <param name="para"></param>
        private void GetMedicalFee(GhclParameter para)
        {
            var ks = _ctx.MzGhksSet.Find(para.ksdm);
            //ghje=zlf ghje1=ghf
            if (ks == null) throw new Exception("无法获取挂号科室及诊疗费用信息");
            para.ghlb = (int)ks.Ghlb;
            para.mzks = (int)(ks.Mzks ?? 101);
            para.ZlfList = new List<Tuple<int, decimal>>();
            if (ks.Zlf > 0)
            {
                para.ZlfList.Add(new Tuple<int, decimal>(_config.PTZCF, ks.Zlf));
            }
            if (ks.Ghf > 0)
            {
                if (ks.Ghlb == 4)
                {
                    //急诊
                    para.ZlfList.Add(new Tuple<int, decimal>(_config.JZZCF, ks.Ghf));
                }
                else if (ks.Ghlb == 3 && ks.Ksdm == "3001")
                {
                    //特需
                    para.ZlfList.Add(new Tuple<int, decimal>(_config.TXZCF, ks.Ghf));
                    //@ghxh = 1579
                }
                else if (ks.Ghlb == 3 && ks.Ghf > 10)
                {
                    //正高
                    para.ZlfList.Add(new Tuple<int, decimal>(_config.ZJZCFZG, ks.Ghf));
                }
                else if (ks.Ghlb == 3 && ks.Ghf <= 10)
                {
                    //副高
                    para.ZlfList.Add(new Tuple<int, decimal>(_config.ZJZCFFG, ks.Ghf));
                }
            }
        }
        private MsBrda CreateMzBrda(GhclParameter para)
        {
            try
            {
                var brda = new MsBrda()
                {
                    Brid = para.brid,
                    Mzhm = DateTime.Now.ToString("yyMMddHHmmss"),
                    Brxz = para.brxz,
                    Brxm = para.brxm,
                    Brxb = para.brxb,
                    Csny = para.csny,
                    Hkdz = para.jtdz,
                    Jtdh = para.gddh,
                    Phone = para.tel,
                    Ybkh = para.ybkh,
                    Qybr = para.qybr,
                    Sfzh = para.sfzh,
                    Ickh = para.ybkh,
                    Jdrq = DateTime.Now
                };
                _ctx.MzBrdaSet.Add(brda);
                _ctx.SaveChanges();
                return brda;
            }
            catch (Exception e)
            {
                throw new Exception("创建MS_BRDA记录失败" + e.Message);
            }
        }
        private MsBrda UpdateMzBrda(MsBrda record, GhclParameter para)
        {
            try
            {
                if (para.cardtype == 1)
                {
                    if (record.Ybkh != para.ybkh) record.Ybkh = para.ybkh;
                }
                if (record.Qybr != para.qybr) record.Qybr = para.qybr;
                if (record.Phone != para.tel) record.Phone = para.tel;
                if (record.Jtdh != para.tel) record.Jtdh = para.tel;
                _ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("档案更新失败" + e.Message);
            }
            return record;
        }
        private string GetBrdaMzhm(GhclParameter para)
        {
            string mzhm = string.Empty;
            var list = _ctx.MzBrdaSet.Where(p => p.Mzhm == para.cardnum || p.Mzhm == para.smkNo).ToList();
            if (!string.IsNullOrEmpty(para.cardnum))
            {
                if (!list?.Any(p => p.Mzhm == para.cardnum) ?? false)
                {
                    mzhm = para.cardnum;
                }
            }
            else if (string.IsNullOrEmpty(para.smkNo))
            {
                if (!list?.Any(p => p.Mzhm == para.smkNo) ?? false)
                {
                    mzhm = para.smkNo;
                }
            }
            else
            {
                mzhm = DateTime.Now.ToString("yyMMddHHmmss");
            }
            return mzhm;
        }
        /// <summary>
        /// 获取某个科室所有医生排班状态
        /// </summary>
        /// <param name="inXml"></param>
        /// <returns></returns>
        public string GetKsYsPb(string inXml)
        {
            XElement root = null;
            try
            {
                var xml = XElement.Parse(inXml);
                var ksdm = xml.Element("ksdm")?.Value;
                var ksrq = Convert.ToDateTime(xml.Element("ksrq")?.Value);
                var zzrq = Convert.ToDateTime(xml.Element("zzrq")?.Value);
                var list = getKsyspb(ksdm, ksrq, zzrq);
                var interfaceXml = new XElement("interface");
                foreach (var item in list)
                {
                    interfaceXml.Add(item.ToXml("row"));
                }
                root = new XElement("YyghInterface",
                    new XElement("RtnValue", 1),
                    new XElement("bzxx"),
                    interfaceXml
                );
            }
            catch (Exception e)
            {
                throw e;
            }
            return root.ToString();
        }
        private IList<ksyspb> getKsyspb(string ksdm, DateTime kssj, DateTime jssj)
        {
            try
            {
                return _ctx.Database.SqlQuery<ksyspb>($"exec proc_wjj_yspb '{ksdm}','{kssj}','{jssj}'").ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("获取科室所有医生排班信息失败0" + e.Message); ;
            }
        }
        /// <summary>
        ///     门诊分时段预约号源
        /// </summary>
        /// <param name="inXml"></param>
        /// <returns></returns>
        public string GetMzFsdYy(string inXml)
        {
            string rtnXml;
            try
            {
                var xml = XElement.Parse(inXml);
                var ksdm = xml.Element("ksdm")?.Value;
                var ysdm = xml.Element("ysdm")?.Value;
                var gzrq = Convert.ToDateTime(xml.Element("gzrq")?.Value);
                var zblb = Convert.ToInt32(xml.Element("zblb")?.Value);
                var yypb = _ctx.MzFsdYySet.Where(p =>
                        p.Gzrq == gzrq &&
                        p.Ksdm == ksdm &&
                        p.Ysdm == ysdm &&
                        p.Zblb == zblb &&
                        p.Yylb == 1 &&
                        p.Ghpb == 0)
                    .ToList();
                if (yypb.Any())
                {
                    var document = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                        new XElement("YyghInterface",
                            new XElement("RtnValue", 1),
                            new XElement("bzxx", ""),
                            new XElement("interface")
                        ));
                    //var interfaceNode = xmlElement.Element("interface");
                    foreach (var item in yypb)
                    {
                        document.Root?.Element("interface")
                            ?.Add(new XElement("row",
                                new XElement("jzxh", item.Jzxh),
                                new XElement("jzsj", item.Jzsj),
                                new XElement("jzsj2", item.Jzsj.AddMinutes(30))
                            ));
                    }
                    rtnXml = document.ToString();
                }
                else
                {
                    rtnXml = GeneralTools.ReturnXml(-1, "没有查询到数据！~r~n", null);
                }
            }
            catch (Exception e)
            {
                rtnXml = GeneralTools.ReturnXml(-1, "数据查询出现错误！~r~n" + e, null);
            }
            return rtnXml.Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "");
        }
        /// <summary>
        ///     使用Linq方式获取科室排班信息
        /// </summary>
        /// <returns></returns>
        private IList<WsjGhks> GetGhkses2() =>
            (from a in _ctx.MzGhksSet
             where a.Kfyypb == 1 && a.Zfpb == 0
             join b in from e in _ctx.PayDmzdSet where e.Dmlb == "GHKS_DZ" select e
                 on a.Ksdm equals b.Dmsb into aJoin
             from t in aJoin.DefaultIfEmpty()
             join c in from x in _ctx.GyDmzdSet where x.Dmlb == 1165 select x
                 on a.Kswz equals c.Dmsb into cJoin
             from d in cJoin.DefaultIfEmpty()
             select new WsjGhks
             {
                 bzdm = t.Dmbz,
                 ksdm = a.Ksdm,
                 ksmc = a.Ksmc,
                 zjpb = a.Ghlb == 3 ? 1 : 0,
                 ghje = a.Ghf + a.Zlf,
                 zswz = d.Dmmc,
                 bzxx = a.Zjsjap
             }).ToList();
        public string GetMzGhksXml2(string inXml)
        {
            var xml = XElement.Parse(inXml);
            var mode = Convert.ToInt32(xml.Element("mode")?.Value ?? "1");
            string rtnXml;
            var query = GetGhkses2();
            if (query.Any())
            {
                var document = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("YyghInterface",
                        new XElement("RtnValue", 1),
                        new XElement("bzxx", ""),
                        new XElement("interface")
                    ));
                foreach (var item in query)
                {
                    document.Root?.Element("interface")?.Add(item.ToXml());
                }
                rtnXml = document.ToString();
            }
            else
            {
                rtnXml = GeneralTools.ReturnXml(-1, "没有查询到数据！~r~n", null);
            }
            return rtnXml;
        }
        public string GetMzGhksXml(string inXml)
        {
            var xml = XElement.Parse(inXml);
            var mode = Convert.ToInt32(xml.Element("mode")?.Value ?? "1");
            string rtnXml;
            var query = _ctx.Database.SqlQuery<WsjGhks>("exec proc_get_ghks").Where(p => p.kfyypb == mode).ToList();
            if (query.Any())
            {
                var document = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("YyghInterface",
                        new XElement("RtnValue", 1),
                        new XElement("bzxx", ""),
                        new XElement("interface")
                    ));
                query.ForEach(p => { document.Root?.Element("interface")?.Add(p.ToXml()); });
                rtnXml = document.ToString();
            }
            else
            {
                rtnXml = GeneralTools.ReturnXml(-1, "没有查询到数据！~r~n", null);
            }
            return rtnXml;
        }
        public string GetPatientInvoice(string inXml)
        {
            try
            {
                var xml = XElement.Parse(inXml);
                var actType = xml.Element("acttype")?.Value;
                var actNumber = xml.Element("actnumber")?.Value;
                if (string.IsNullOrEmpty(actNumber)) throw new Exception("获取actnumber参数失败!");
                //var jzlsh = xml.Descendants("list").Elements().FirstOrDefault(p => p.Name == "jzlsh")?.Value;
                //var mzzyhm = xml.Descendants("list").Elements().FirstOrDefault(p => p.Name == "mzzyhm")?.Value;
                if (string.IsNullOrEmpty(_config.YYBH)) throw new Exception("获取医院编码失败");
                if (string.IsNullOrEmpty(_config.CZGH)) throw new Exception("获取操作工号失败");
                if (actType == "4")
                {
                    return GetInpatientInvoices(actNumber);
                }
                return GetOutpatientInvoices(actNumber);
            }
            catch (Exception exception)
            {
                return new XElement("YyghInterface",
                    new XElement("RtnValue", -1),
                    new XElement("bzxx", exception.Message)
                ).ToString();
            }
        }
        /// <summary>
        ///     住院病人费用清单
        /// </summary>
        /// <returns></returns>
        public string GetInpatientInvoices(string actNumber)
        {
            var xml = new XElement("YyghInterface");
            try
            {
                var patient = VerifyInpatient(actNumber);
                var cvxCardType = GetCvxCardType(_config.HZYB_BRXZ, _config.WXYB_BRXZ, patient.Brxz.ToString(CultureInfo.InvariantCulture));
                if (cvxCardType != "08")
                {
                    var noUpload = _ctx.ZyFymxSet.Any(p => p.Zyh == patient.Zyh && p.Scbz == 0 && p.Jscs == 0);
                    if (noUpload) throw new Exception("本次住院结算有未上传的明细记录");
                }
                var fee = GetInpatientFee(patient.Zyh, (int)(patient.Yepb ?? 0));
                //预交款
                var yjk = _ctx.ZyTbkkSet.Where(p => p.Zyh == patient.Zyh && p.Zfpb == 0 && p.Jscs == 0)
                    ?.Select(p => p.Jkje).DefaultIfEmpty(0).Sum();
                var clinic = GetInpatientClinicInfo(patient.Zyh, fee.cnt1);
                var feeSummary = GetInpatientFeeSummary(patient.Zyh);
                xml.Add(
                    new XElement("RtnValue", 1),
                    new XElement("bzxx", "获取出院费用清单成功"),
                    new XElement("interface",
                        new XElement("HospitalCode", _config.YYBH),
                        new XElement("Operator", _config.CZGH),
                        new XElement("CVX_CardType", cvxCardType),
                        new XElement("ICInfo", patient.Cardno),
                        new XElement("ChargeType", 4),
                        new XElement("YLLB", patient.Yllb), //门诊的医疗类别为11，固定值
                        new XElement("DisAudNo"),
                        new XElement("FeeTotal", fee.zjje2 + fee.zjje1),
                        new XElement("ZFFY", fee.zjje2),
                        new XElement("yjje", yjk),
                        new XElement("DisMark", 0),
                        new XElement("OperatorName"),
                        clinic.ToXml(),
                        new XElement("zyfymx")
                    )
                );
                var listNode = xml.Descendants("interface").Elements("zyfymx").FirstOrDefault();
                foreach (var item in feeSummary)
                {
                    var arr = item.Split('-');
                    listNode?.Add(new XElement($"I{arr[0]}", arr[1]));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return xml.ToString();
        }
        /// <summary>
        ///     验证住院病人是否可以结算
        /// </summary>
        /// <param name="actNumber">唯一代码</param>
        /// <returns></returns>
        private ZyBrry VerifyInpatient(string actNumber)
        {
            var patient = _ctx.ZyBrrySet.FirstOrDefault(p => p.Actnumber == actNumber);
            if (patient == null) throw new Exception("获取住院病人档案失败");
            if (patient.Cypb == 0) throw new Exception("未完成出院证明操作");
            if (patient.Cypb == 8) throw new Exception("已完成出院结算");
            if (patient.Cypb == 99) throw new Exception("本次住院已注销");
            if (patient.Xgpb == 2) throw new Exception("正在进行费别转换2");
            if (patient.Xgpb == 9) throw new Exception("正在进行出院结算9");
            if (patient.Ydjsbz == 0) throw new Exception("该就诊信息移动结算检测未通过");
            return patient;
        }
        private (int cnt1, int cnt2, decimal zjje1, decimal zjje2) GetInpatientFee(int zyh, int yepb)
        {
            int cnt1;
            var cnt2 = 0;
            decimal zjje1;
            decimal zjje2 = 0;
            var mx = _ctx.ZyFymxSet
                .Where(p => p.Jscs == 0 && p.Zyh == zyh)
                .GroupBy(p => p.Yefbz).Select(t => new
                {
                    yefbz = t.Key,
                    zjje = t.Sum(p => p.Zjje),
                    count = t.Count()
                });
            if (yepb == 1)
            {
                cnt1 = mx.Where(p => p.yefbz == 0).Sum(p => p.count);
                cnt2 = mx.Where(p => p.yefbz == 1).Sum(p => p.count);
                zjje1 = mx.Where(p => p.yefbz == 0).Sum(p => p.zjje);
                zjje2 = mx.Where(p => p.yefbz == 1).Sum(p => p.zjje);
            }
            else
            {
                cnt1 = mx.Sum(p => p.count);
                zjje1 = mx.Sum(p => p.zjje);
            }
            if (cnt2 + cnt1 == 0) throw new Exception("本次住院结算无费用明细数据");
            return (cnt1, cnt2, zjje1, zjje2);
        }
        private Clinic GetInpatientClinicInfo(int zyh, int count)
        {
            var clinic = _ctx.Database.SqlQuery<Clinic>($"exec proc_wjj_inclinic {zyh}").FirstOrDefault();
            if (clinic == null) throw new Exception("获取住院相关信息失败");
            //获取诊断
            clinic.CYZD = GetInpatientClinicDiagnose(zyh);
            clinic.FeeDetail = count;
            return clinic;
        }
        /// <summary>
        ///     获取住院病人临床诊断
        /// </summary>
        /// <param name="zyh"></param>
        /// <returns></returns>
        private IList<string> GetInpatientClinicDiagnose(int zyh)
        {
            var sql = $@"SELECT
                              gj.ICD9 AS ICD9
                            FROM zy_ryzd zr
                                ,gy_jbbm gj
                            WHERE zr.ZDXH = gj.jbxh
                            AND zr.ZYH = {zyh}
                            AND zr.zdlb IN (3, 4)";
            var query = _ctx.Database.SqlQuery<string>(sql).ToList();
            if (!query.Any()) throw new Exception("出入院诊断获取失败！");
            return query;
        }
        /// <summary>
        /// 获取住院费用分类信息
        /// </summary>
        /// <param name="zyh">住院号</param>
        /// <returns></returns>
        private IList<string> GetInpatientFeeSummary(int zyh)
        {
            var sql = $@"select (ISNULL(gs.zxgb, '99'))+'-'+ CAST(SUM(zf.zjje) AS VARCHAR)
                            FROM zy_fymx zf,gy_sfxm gs
                            WHERE zf.fyxm = gs.sfxm
                            AND zf.zyh = {zyh}
                            AND zf.jscs =0
                            GROUP BY gs.zxgb";
            var query = _ctx.Database.SqlQuery<string>(sql).ToList();
            if (!query.Any()) throw new Exception("费用分类数据获取失败！");
            return query;
        }
        /// <summary>
        /// 拼接门诊病人费用字符串
        /// </summary>
        /// <returns></returns>
        public string GetOutpatientInvoices(string actNumber)
        {
            var xml = new XElement("YyghInterface");
            try
            {
                //获取病人信息
                var jzls = _ctx.YsMzJzlsSet.FirstOrDefault(p => p.Actnumber == actNumber);
                if (jzls == null) throw new Exception("获取门诊就诊记录失败");
                if (jzls.Brbh <= 0) throw new Exception("获取门诊病人档案失败");
                var patient = _ctx.MzBrdaSet.Find(jzls.Brbh);
                if (patient == null || patient.Brxz <= 0) throw new Exception("获取病人基本信息失败");
                var clinic = _ctx.Database.SqlQuery<Clinic>($"exec proc_wjj_outclinic {jzls.Jzxh}").FirstOrDefault();
                if (clinic == null) throw new Exception("获取门诊clinic信息失败");
                //获取费用清单
                var details = GetOutpatientFeeDetails((int)patient.Brid, (int)(patient.Qybr ?? 0));
                clinic.FeeDetail = details.Select(p => p.Items.Count).DefaultIfEmpty(0).Sum();
                //组装xml语句
                xml.Add(
                    new XElement("RtnValue", 1),
                    new XElement("bzxx", "获取门诊费用清单成功"),
                    new XElement("interface",
                        new XElement("HospitalCode", _config.YYBH),
                        new XElement("Operator", _config.CZGH),
                        new XElement("CVX_CardType",
                            GetCvxCardType(_config.HZYB_BRXZ, _config.WXYB_BRXZ, patient.Brxz.ToString())),
                        new XElement("ICInfo", GetIcInfor(patient.Ickh, patient.Ybkh, patient.Icxx)),
                        new XElement("ChargeType", 1),
                        new XElement("YLLB", 11), //门诊的医疗类别为11，固定值
                        new XElement("DisAudNo"),
                        new XElement("FeeTotal", details.Sum(p => p.itemCost)),
                        new XElement("ZFFY", 0),
                        new XElement("yjje", 0),
                        new XElement("DisMark", 0),
                        new XElement("OperatorName"),
                        clinic.ToXml(),
                        GetOutpatientFeeXml(details)
                    )
                );
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return xml.ToString();
        }
        /// <summary>
        /// 获取门诊费用明细XML
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        private XElement GetOutpatientFeeXml(IList<Detail> details)
        {
            var xml = new XElement("list");
            foreach (var detail in details)
            {
                xml.Add(detail.ToXml());
            }
            return xml;
        }
        /// <summary>
        ///     获取门诊费用详单
        /// </summary>
        /// <param name="brid"></param>
        /// <param name="qybr"></param>
        /// <returns></returns>
        private IList<Detail> GetOutpatientFeeDetails(int brid, int qybr)
        {
            var cfsj = DateTime.Now.AddDays(0 - _config.CFXQ);
            var webCfsj = DateTime.Now.AddDays(0 - _config.WebCFXQ);
            DateTime djsj1;
            if (qybr == 1 || qybr == 5)
            {
                djsj1 = cfsj;
            }
            else
            {
                djsj1 = webCfsj;
            }
            //获取费用清单
            var sql = $"exec proc_wjj_cfyj {brid},'{cfsj}','{webCfsj}','{djsj1}'";
            var list = _ctx.Database.SqlQuery<Detail>(sql).ToList();
            if (list.Any())
            {
                try
                {
                    foreach (var item in list)
                    {
                        if (item.Type == 1)
                        {
                            item.Items = _ctx.Database.SqlQuery<item>($"exec proc_wjj_cfmx {item.itemNo}").ToList();
                        }
                        else
                        {
                            item.Items = _ctx.Database.SqlQuery<item>($"exec proc_wjj_yjmx {item.itemNo}").ToList();
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("获取处方或检查明细失败" + e.Message);
                }
            }
            else
            {
                throw new Exception("没有获取到费用清单");
            }
            return list;
        }
        /// <summary>
        ///     返回医保类型代码
        /// </summary>
        /// <param name="hzBrxz">杭州医保病人性质</param>
        /// <param name="wxBrxz">原网新医保病人性质</param>
        /// <param name="brxz">病人性质</param>
        /// <returns></returns>
        public string GetCvxCardType(string hzBrxz, string wxBrxz, string brxz)
        {
            if (hzBrxz == brxz || wxBrxz == brxz)
            {
                return "02";
            }
            return "08";
        }
        /// <summary>
        ///     返回医保ic卡信息
        /// </summary>
        /// <param name="ickh"></param>
        /// <param name="ybkh"></param>
        /// <param name="icxx"></param>
        /// <returns></returns>
        public string GetIcInfor(string ickh, string ybkh, string icxx)
        {
            if (string.IsNullOrEmpty(ickh)) ickh = "";
            if (string.IsNullOrEmpty(ybkh)) ybkh = "";
            if (string.IsNullOrEmpty(icxx)) icxx = "";
            if (ickh.Length <= 30)
            {
                if (ybkh.Length >= 30)
                {
                    return ybkh;
                }
                if (icxx.Length > 100) return icxx.Trim().Substring(0, 50).Trim();
            }
            return ickh;
        }
        public string GetCodePayXml(string inXmlStr)
        {
            string yyjsls = string.Empty;
            try
            {
                var xml = XElement.Parse(inXmlStr);
                yyjsls = xml.Element("yyjsls")?.Value;
                var pay = Convert.ToDecimal(xml.Element("pay")?.Value);
                var zffs = xml.Element("zffs")?.Value;
                try
                {
                    var fkrz = new PayFkrz
                    {
                        Jydm = "hos_codepay",
                        Jylx = "1",
                        Yyjsls = yyjsls,
                        Xrrq = DateTime.Now,
                        Instr = inXmlStr
                    };
                    _ctx.PayFkrzSet.Add(fkrz);
                    _ctx.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception("业务日志保存失败/r/n" + e.Message);
                }
                var record = _ctx.PayFkjlSet.Find(yyjsls);
                if (record == null)
                {
                    throw new Exception("PAY_FKJL查询失败");
                }
                if (record.Zfpb != 0)
                {
                    throw new Exception("该记录已作废");
                }
                if (record.State == 1)
                {
                    var outXml = ReturnXml(1, "已经成功", null);
                    var fkrz = new PayFkrz
                    {
                        Jydm = "hos_codepay",
                        Jylx = "2",
                        Yyjsls = yyjsls,
                        Xrrq = DateTime.Now,
                        Instr = outXml
                    };
                    _ctx.PayFkrzSet.Add(fkrz);
                    _ctx.SaveChanges();
                    return outXml;
                }
                if (record.State == -1)
                {
                    throw new Exception("该记录已冲正");
                }
                //更新PAY_FKJL表状态失败
                try
                {
                    record.Pay2 = pay;
                    record.Zffs = zffs;
                    record.State = 1;
                    _ctx.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception("更新PAY_FKJL表状态失败/r/n" + e.Message);
                }
                return ReturnXml(1, "成功", null);
            }
            catch (Exception e)
            {
                var outXml = ReturnXml(-1, "hos_codepay" + e.Message, null);
                var fkrz = new PayFkrz
                {
                    Jydm = "hos_codepay",
                    Jylx = "2",
                    Yyjsls = yyjsls,
                    Xrrq = DateTime.Now,
                    Instr = outXml
                };
                _ctx.PayFkrzSet.Add(fkrz);
                _ctx.SaveChanges();
                return outXml;
            }
        }
        private string ReturnXml(int rtnValue, string bzxx, string data)
        {
            var xmlElement =
                new XElement("YyghInterface",
                    new XElement("RtnValue", rtnValue),
                    new XElement("bzxx", bzxx)
                );
            if (data != null)
            {
                xmlElement.Add(new XElement("interface", data));
            }
            return xmlElement.ToString();
        }

        private GenericConfig GetGenericConfig()
        {
            var path = $@"{AppContext.BaseDirectory}\appconfig.json";
            return JsonConvert.DeserializeObject<GenericConfig>(File.ReadAllText(path));
        }

        private IList<XElement> GetXmlNodes(string xmlString)
        {
            var xml = XElement.Parse(xmlString);
            return xml.Descendants().ToList();
        }


        /// <summary>
        /// 获取当前排班记录序号
        /// </summary>
        /// <param name="inXmlStr"></param>
        /// <returns></returns>
        public string GetQdJzxh(string inXmlStr)
        {
            try
            {


                var nodeList = GetXmlNodes(inXmlStr);
                var ghlb = Convert.ToInt32(nodeList.FirstOrDefault(p => p.Name == "ghlb")?.Value);
                var ksdm = nodeList.FirstOrDefault(p => p.Name == "ksdm")?.Value;
                var gzrq = Convert.ToDateTime(nodeList.FirstOrDefault(p => p.Name == "gzrq")?.Value);
                var ysdm = nodeList.FirstOrDefault(p => p.Name == "ysdm")?.Value;
                var zblb = Convert.ToInt32(nodeList.FirstOrDefault(p => p.Name == "zblb")?.Value);
                var yspb = _ctx.MzYspbSet.FirstOrDefault(p => p.Ksdm == ksdm
                                                              && p.Ysdm == ysdm
                                                              && p.Zblb == zblb
                                                              && p.Gzrq == gzrq
                                                              && p.MzGhks.Ghlb == ghlb);
                if (yspb == null)
                {
                    throw new Exception("获取排班信息失败！");
                }
                var root = new XElement("YyghInterface",
                    new XElement("RtnValue", 1),
                    new XElement("bzxx"),
                    new XElement("interface",
                        new XElement("dqcx", yspb.Jzxh))
                    );
                return root.ToString(SaveOptions.DisableFormatting);
            }
            catch (Exception e)
            {
                return ReturnXml(-1, "取就诊序号时发生错误，" + e.Message, null);
            }
        }

        /// <summary>
        /// 获取发票费用明细
        /// </summary>
        /// <param name="inXmlStr"></param>
        /// <returns></returns>
        public string GetHosInvoice(string inXmlStr)
        {
            try
            {
                var nodeList = GetXmlNodes(inXmlStr);
                var actNumber = nodeList.FirstOrDefault(p => p.Name == "actnumber")?.Value;
                var fphm = nodeList.FirstOrDefault(p => p.Name == "fphm")?.Value;
                var yjfy = _ctx.MsYj02Set
                    .Include(p => p.GyYlsf)
                    .Include(p => p.MsYj01)
                    .FirstOrDefault();
                return null;
            }
            catch (Exception e)
            {
                return ReturnXml(-1, e.InnerException.Message, null);
                throw;
            }
        }
    }
}
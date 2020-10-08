using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FE.Context;
using FE.Model.Hrp275;
using FE.Model.Local;

namespace FE.Handle.Request
{
    public class WsjGhclHandle : BasicHandle
    {
        private readonly WsjGhclIn InPara;

        public WsjGhclHandle(FrontEndContext context, string xmlString) : base(context)
        {
            InPara = ConvertToObject<WsjGhclIn>.XmlDeserialize(xmlString);
        }

        /// <summary>
        ///     挂号处理
        /// </summary>
        /// <returns></returns>
        public string GetWsjGhcl()
        {
            using (var transaction = Ctx.Database.BeginTransaction())
            {
                try
                {
                    //获取当前预约挂号涉及的门诊侦查费
                    GetMedicalFee();
                    GetTableKey();
                    ProcessMzBrda();
                    //判断是否满足挂号条件
                    CanYyGh();
                    //开始预约挂号操作
                    //获取jzhm
                    InPara.ghxx.jzhm = GetJzhm(Config.CZGH);
                    //获取各表的key值
                    if (string.IsNullOrEmpty(InPara.ghxx.pzhm))
                    {
                        //插入MsYYGH
                        InsertMsYygh();
                    }
                    else
                    {
                        //更新msyy_ghxx
                        UpdateMsyyGhxx();
                        //更新ms_yygh
                        UpdateMsyyGh();
                    }

                    //插入ms_ghmx
                    InsertMzGhmx();
                    var yj2Count = InPara.ghxx.yj02xh.Length;
                    if (yj2Count > 0)
                    {
                        //插入ms_yj01
                        InsertMzYj01();
                        //插入ms_yj02
                        InsertMzYj02();
                    }

                    //更新挂号人数
                    UpdateMzYspb();
                    //锁定号源
                    LockMzFsdyy();
                    transaction.Commit();

                    var wsjGhclOut = new WsjGhclOut
                    {
                        GhclOutInterface = new GhclOutInterface
                        {
                            row = new GhclOutInterfaceRow
                            {
                                ghxh = InPara.ghxx.yyxh
                            }
                        }
                    };

                    return ConvertToObject<WsjGhclOut>.SerializeXmlToString(wsjGhclOut);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception("预约挂号失败->" + e.Message);
                }
            }
        }


        /// <summary>
        ///     获取就诊号码
        /// </summary>
        /// <param name="czgh"></param>
        /// <returns></returns>
        private string GetJzhm(string czgh)
        {
            try
            {
                var ygpj = Ctx.MzYgpjSet.FirstOrDefault(p => p.Ygdm == czgh && p.Pjlx == 1 && p.Sypb == 0);
                if (ygpj == null)
                {
                    throw new Exception("取就诊号码(挂号发票号码)失败！");
                }

                var syhm = Convert.ToInt32(ygpj.Syhm);
                var zzhm = Convert.ToInt32(ygpj.Zzhm);
                if (syhm > zzhm)
                {
                    throw new Exception("票据号码用完了，无法挂号！");
                }

                ygpj.Syhm = (++syhm).ToString();
                Ctx.SaveChanges();
                return syhm.ToString();
            }
            catch (Exception e)
            {
                throw new Exception("获取就诊号码失败->" + e.Message);
            }
        }

        private void UpdateMsyyGhxx()
        {
            try
            {
                var yyghXx = Ctx.MzyyGhxxSet.FirstOrDefault(p => p.Pzhm == InPara.ghxx.pzhm);
                if (yyghXx == null)
                {
                    throw new Exception("取MSYY_GhXX失败！");
                }

                yyghXx.Yyzt = 1;
                Ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("更新MSYY_GhXX失败->" + e.Message);
            }
        }

        private void UpdateMsyyGh()
        {
            try
            {
                var yygh = Ctx.MzYyghSet.FirstOrDefault(p => p.Pzhm == InPara.ghxx.pzhm);
                if (yygh == null)
                {
                    throw new Exception("取MS_YYGH失败！");
                }

                yygh.Ghbz = 1;
                yygh.Sbxh = InPara.ghxx.ghxh;
                yygh.Ghsbxh = InPara.ghxx.ghxh;
                yygh.Yjsbxh = InPara.ghxx.yj01xh;
                Ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("更新Ms_yygh失败->" + e.Message);
            }
        }

        /// <summary>
        ///     插入Ms_YYGH
        /// </summary>
        private void InsertMsYygh()
        {
            try
            {
                var yygh = new MsYygh
                {
                    Yyxh = InPara.ghxx.yyxh,
                    Yymm = "123",
                    Ghrq = DateTime.Now,
                    Brid = InPara.brxx.brid,
                    Ksdm = InPara.ghxx.ksdm,
                    Ysdm = InPara.ghxx.ysdm,
                    Jzxh = InPara.ghxx.jzxh,
                    Brxm = InPara.brxx.brxm,
                    Zcid = 0,
                    Ghbz = 1,
                    Zblb = InPara.ghxx.zblb,
                    Yylb = InPara.ghxx.yylb,
                    Yyrq = Convert.ToDateTime(InPara.ghxx.jzsj),
                    Ghsbxh = InPara.ghxx.ghxh,
                    Yjsbxh = InPara.ghxx.yj01xh
                };
                Ctx.MzYyghSet.Add(yygh);
                Ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("插入Ms_yygh失败->" + e.Message);
            }
        }

        /// <summary>
        ///     插入ms_ghmx
        /// </summary>
        private void InsertMzGhmx()
        {
            try
            {
                DateTime ghsj;
                if (InPara.ghxx.zblb == 1)
                {
                    //上午挂号时间+8小时
                    ghsj = InPara.ghxx.gzrq.AddHours(8);
                }
                else
                {
                    //下午挂号时间+13小时
                    ghsj = InPara.ghxx.gzrq.AddHours(13);
                }

                //插入ms_ghmx
                var ghmx = new MsGhmx
                {
                    Sbxh = InPara.ghxx.ghxh,
                    Brid = InPara.brxx.brid,
                    Brxz = InPara.brxx.brxz,
                    Ghsj = ghsj,
                    Ghlb = InPara.ghxx.ghlb,
                    Ksdm = InPara.ghxx.ksdm,
                    Ysdm = InPara.ghxx.ysdm,
                    Jzxh = InPara.ghxx.jzxh,
                    Czgh = Config.CZGH,
                    Jzhm = InPara.ghxx.jzhm,
                    Yybz = 1,
                    Mzlb = 1,
                    Qybr = InPara.brxx.qybr,
                    Jzsj = Convert.ToDateTime(InPara.ghxx.jzsj),
                    Zblb = InPara.ghxx.zblb
                };
                Ctx.MzGhmxSet.Add(ghmx);
                Ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("插入Ms_ghmx失败" + e.Message);
            }
        }

        /// <summary>
        ///     插入Ms_yj01数据
        /// </summary>
        private void InsertMzYj01()
        {
            try
            {
                var mzYj01 = new MsYj01
                {
                    Yjxh = InPara.ghxx.yj01xh,
                    Brid = InPara.brxx.brid,
                    Brxm = InPara.brxx.brxm,
                    Kdrq = InPara.ghxx.gzrq,
                    Ksdm = decimal.TryParse(InPara.ghxx.ksdm, out _) ? Convert.ToDecimal(InPara.ghxx.ksdm) : 101,
                    Ysdm = InPara.ghxx.ysdm,
                    Zxks = InPara.ghxx.mzks,
                    Zysx = "签约挂号",
                    Hymx = InPara.ghxx.jzhm,
                    Qybr = InPara.brxx.qybr,
                    Cfbz = 0
                };
                Ctx.MsYj01Set.Add(mzYj01);
                Ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("插入Ms_YJ01失败" + e.Message);
            }
        }

        /// <summary>
        ///     插入Ms_yj02数据
        /// </summary>
        private void InsertMzYj02()
        {
            try
            {
                var count = InPara.ghxx.yj02xh.Length;
                for (var i = 0; i < count; i++)
                {
                    var ylxh = InPara.ghxx.ZlfList[i].Item1;
                    var yldj = InPara.ghxx.ZlfList[i].Item2;
                    var yj02 = new MsYj02
                    {
                        Sbxh = InPara.ghxx.yj02xh[i],
                        Yjxh = InPara.ghxx.yj01xh,
                        Ylxh = ylxh,
                        Xmlx = 0,
                        Yjzx = 1,
                        Yldj = yldj,
                        Ylsl = 1,
                        Hjje = yldj,
                        Fygb = Config.ZCFGB,
                        Zfbl = 1,
                        Zfpb = 0
                    };
                    Ctx.MsYj02Set.Add(yj02);
                }

                Ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("插入Ms_YJ02失败" + e.Message);
            }
        }

        /// <summary>
        ///更新医生排班可挂号数量
        /// </summary>
        private void UpdateMzYspb()
        {
            try
            {
                var yspb = Ctx.MzYspbSet.FirstOrDefault(p => p.Gzrq == InPara.ghxx.gzrq
                                                             && p.Ksdm == InPara.ghxx.ksdm
                                                             && p.Ysdm == InPara.ghxx.ysdm
                                                             && p.Zblb == InPara.ghxx.zblb);
                if (yspb == null)
                {
                    throw new Exception("获取医生排班信息失败！");
                }

                var ygrs = yspb.Ygrs;
                var jzxhOld = yspb.Jzxh;
                yspb.Ygrs = ygrs + 1;
                yspb.Jzxh = jzxhOld + 1;
                Ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("更新已挂人数失败" + e.Message);
            }
        }

        /// <summary>
        ///     锁定号源
        /// </summary>
        private void LockMzFsdyy()
        {
            try
            {
                var fsdyy = Ctx.MzFsdYySet.FirstOrDefault(p => p.Gzrq == InPara.ghxx.gzrq
                                                               && p.Ksdm == InPara.ghxx.ksdm
                                                               && p.Ysdm == InPara.ghxx.ysdm
                                                               && p.Zblb == InPara.ghxx.zblb
                                                               && p.Jzxh == InPara.ghxx.jzxh
                                                               && p.Ghpb == 0);
                if (fsdyy == null)
                {
                    throw new Exception("获取号源ms_fsdyyb失败！");
                }

                fsdyy.Ghpb = 1;
                fsdyy.Brxm = InPara.brxx.brxm;
                fsdyy.Brid = InPara.brxx.brid;
                Ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("锁定号源失败" + e.Message);
            }
        }

        /// <summary>
        ///     获取各个表的Key值
        /// </summary>
        private void GetTableKey()
        {
            //
            var keyTable = Ctx.MzIdentitySet.ToList();
            var keyBrda = keyTable.FirstOrDefault(p => p.Bmc == "MS_BRDA");
            if (keyBrda == null)
            {
                throw new Exception("取MS_BRDA序号失败！");
            }

            var brid = keyBrda.Dqz + 1;
            keyBrda.Dqz = brid;
            InPara.brxx.brid = brid;
            var keyYygh = keyTable.FirstOrDefault(p => p.Bmc == "MS_YYGH");
            if (keyYygh == null)
            {
                throw new Exception("取MS_YYGH序号失败！");
            }

            InPara.ghxx.yyxh = keyYygh.Dqz + 1;
            keyYygh.Dqz = InPara.ghxx.yyxh;
            var keyGhMx = keyTable.FirstOrDefault(p => p.Bmc == "MS_GHMX");
            if (keyGhMx == null)
            {
                throw new Exception("取MS_GHMX序号失败！");
            }

            InPara.ghxx.ghxh = keyGhMx.Dqz + 1;
            keyGhMx.Dqz = InPara.ghxx.ghxh;
            var yj01 = keyTable.FirstOrDefault(p => p.Bmc == "MS_YJ01");
            if (yj01 == null)
            {
                throw new Exception("取MS_YJ01序号失败！");
            }

            InPara.ghxx.yj01xh = yj01.Dqz + 1;
            yj01.Dqz = InPara.ghxx.yj01xh;
            var yj02 = keyTable.FirstOrDefault(p => p.Bmc == "MS_YJ02");
            if (yj02 == null)
            {
                throw new Exception("取MS_YJ02序号失败！");
            }

            var count = InPara.ghxx.ZlfList.Count;
            var arr = new int[count];
            for (var i = 0; i < count; i++)
            {
                arr[i] = yj02.Dqz + i + 1;
            }

            yj02.Dqz = arr[count - 1];
            InPara.ghxx.yj02xh = arr;
            Ctx.SaveChanges();
        }

        public void ProcessMzBrda()
        {
            //判断病人性质
            if (InPara.brxx.cardtype == 1)
            {
                //市民卡处理
                if (string.IsNullOrEmpty(InPara.brxx.ybkh))
                {
                    throw new Exception("传入医保卡号长度不对");
                }

                var left4 = InPara.brxx.ybkh.Substring(0, 4);
                if (left4 == "3301")
                {
                    InPara.brxx.brxz = Convert.ToInt32(Config.HZYB_BRXZ);
                    InPara.brxx.qybr = 1;
                }
                else
                {
                    InPara.brxx.brxz = 1000;
                    InPara.brxx.qybr = 5;
                }
            }
            else
            {
                InPara.brxx.brxz = 1000;
                InPara.brxx.qybr = 5;
            }

            //判断档案是否存在
            var record = Ctx.MzBrdaSet
                .Where(p => p.Brxm == InPara.brxx.brxm && p.Sfzh == InPara.brxx.sfzh &&
                            p.Brxz == InPara.brxx.brxz).OrderByDescending(p => p.Brid).FirstOrDefault();
            if (record != null)
            {
                UpdateMzBrda(record);
                InPara.brxx.brid = (int)record.Brid;
            }
            else
            {
                //新建档案
                CreateMzBrda();
            }
        }

        /// <summary>
        ///     是否能预约挂号
        /// </summary>
        /// <returns></returns>
        private void CanYyGh()
        {
            try
            {
                if (string.IsNullOrEmpty(InPara.ghxx.pzhm))
                {
                    var notHas = Ctx.MzYyghSet.Any(p =>
                        p.Yyrq == InPara.ghxx.gzrq && p.Zblb == InPara.ghxx.zblb && p.Ksdm == InPara.ghxx.ksdm &&
                        p.Ysdm == InPara.ghxx.ysdm &&
                        p.Jzxh == InPara.ghxx.jzxh && p.Ghbz == 0);
                    if (notHas)
                    {
                        throw new Exception("该挂号序号已有人预约");
                    }
                }
                else
                {
                    var hasRegistered =
                        Ctx.MzYyghSet.Any(p => p.Pzhm == InPara.ghxx.pzhm && (p.Ghbz == 0 || p.Ghbz == 1));
                    if (!hasRegistered)
                    {
                        throw new Exception("获取预约信息失败");
                    }
                }

                var source = Ctx.MzFsdYySet.Where(p =>
                    p.Gzrq == InPara.ghxx.gzrq && p.Zblb == InPara.ghxx.zblb && p.Ksdm == InPara.ghxx.ksdm &&
                    p.Ysdm == InPara.ghxx.ysdm).ToList();
                if (source.Any(p => p.Brid == InPara.brxx.brid))
                {
                    throw new Exception("存在同时段同科室同医生预约挂号");
                }

                var hy = source.FirstOrDefault(p => p.Jzxh == InPara.ghxx.jzxh);
                if (hy == null)
                {
                    throw new Exception("取就诊时间失败");
                }

                InPara.ghxx.jzsj = hy.Jzsj.ToString(CultureInfo.InvariantCulture);
                var lsbrxm = hy.Brxm;
                if (!string.IsNullOrEmpty(lsbrxm) && string.IsNullOrEmpty(InPara.ghxx.pzhm))
                {
                    throw new Exception("该号已经被占用，请重新选择");
                }
            }
            catch (Exception e)
            {
                throw new Exception("判断是否可以预约挂号出错" + e.Message);
            }
        }

        /// <summary>
        ///     获取挂号费用
        /// </summary>
        private void GetMedicalFee()
        {
            var ks = Ctx.MzGhksSet.Find(InPara.ghxx.ksdm);
            //ghje=zlf ghje1=ghf
            if (ks == null)
            {
                throw new Exception("无法获取挂号科室及诊疗费用信息");
            }

            InPara.ghxx.ghlb = (int)ks.Ghlb;
            InPara.ghxx.mzks = (int)(ks.Mzks ?? 101);
            InPara.ghxx.ZlfList = new List<Tuple<int, decimal>>();
            if (ks.Zlf > 0)
            {
                InPara.ghxx.ZlfList.Add(new Tuple<int, decimal>(Config.PTZCF, ks.Zlf));
            }

            if (ks.Ghf > 0)
            {
                if (ks.Ghlb == 4)
                {
                    //急诊
                    InPara.ghxx.ZlfList.Add(new Tuple<int, decimal>(Config.JZZCF, ks.Ghf));
                }
                else if (ks.Ghlb == 3 && ks.Ksdm == "3001")
                {
                    //特需
                    InPara.ghxx.ZlfList.Add(new Tuple<int, decimal>(Config.TXZCF, ks.Ghf));
                }
                //@ghxh = 1579
                else if (ks.Ghlb == 3 && ks.Ghf > 10)
                {
                    //正高
                    InPara.ghxx.ZlfList.Add(new Tuple<int, decimal>(Config.ZJZCFZG, ks.Ghf));
                }
                else if (ks.Ghlb == 3 && ks.Ghf <= 10)
                {
                    //副高
                    InPara.ghxx.ZlfList.Add(new Tuple<int, decimal>(Config.ZJZCFFG, ks.Ghf));
                }
            }
        }

        private void CreateMzBrda()
        {
            try
            {
                var brda = new MsBrda
                {
                    Brid = InPara.brxx.brid,
                    Mzhm = DateTime.Now.ToString("yyMMddHHmmss"),
                    Brxz = InPara.brxx.brxz,
                    Brxm = InPara.brxx.brxm,
                    Brxb = InPara.brxx.brxb,
                    Csny = InPara.brxx.csny,
                    Hkdz = InPara.brxx.jtdz,
                    Jtdh = InPara.brxx.gddh,
                    Phone = InPara.brxx.tel,
                    Ybkh = InPara.brxx.ybkh,
                    Qybr = InPara.brxx.qybr,
                    Sfzh = InPara.brxx.sfzh,
                    Ickh = InPara.brxx.ybkh,
                    Jdrq = DateTime.Now
                };
                Ctx.MzBrdaSet.Add(brda);
                Ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("创建MS_BRDA记录失败" + e.Message);
            }
        }

        private void UpdateMzBrda(MsBrda record)
        {
            try
            {
                if (InPara.brxx.cardtype == 1)
                {
                    if (record.Ybkh != InPara.brxx.ybkh)
                    {
                        record.Ybkh = InPara.brxx.ybkh;
                    }
                }

                if (record.Qybr != InPara.brxx.qybr)
                {
                    record.Qybr = InPara.brxx.qybr;
                }

                if (record.Phone != InPara.brxx.tel)
                {
                    record.Phone = InPara.brxx.tel;
                }

                if (record.Jtdh != InPara.brxx.tel)
                {
                    record.Jtdh = InPara.brxx.tel;
                }

                Ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("档案更新失败" + e.Message);
            }
        }
    }
}
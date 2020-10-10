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
    public class WsjCodePayHandle : BasicHandle<WsjCodePayIn>, IHandle
    {
        private readonly string xmlIn;
        public WsjCodePayHandle(FrontEndContext context, string xmlString) : base(context, xmlString)
        {
            xmlIn = xmlString;
        }
        public string GetResultXml()
        {
            try
            {
                InsertPayFkrz("1", xmlIn);
                var record = Ctx.PayFkjlSet.Find(InPara.yyjsls);
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

                    var outXml = ReturnXml(1, "已经成功");
                    InsertPayFkrz("2", outXml);
                    return outXml;
                }

                if (record.State == -1)
                {
                    throw new Exception("该记录已冲正");
                }

                //更新PAY_FKJL表状态失败
                try
                {
                    record.Pay2 = InPara.pay;
                    record.Zffs = InPara.zffs;
                    record.State = 1;
                    Ctx.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception("更新PAY_FKJL表状态失败/r/n" + e.Message);
                }

                return ReturnXml(1, "成功");
            }
            catch (Exception e)
            {
                var outXml = ReturnXml(-1, e.Message);
                InsertPayFkrz("2", outXml);
                return outXml;
            }

        }

        /// <summary>
        /// 插入PayFkrz
        /// </summary>
        /// <param name="jylx"></param>
        /// <param name="inXml"></param>
        private void InsertPayFkrz(string jylx, string inXml)
        {
            var fkrz = new PayFkrz
            {
                Jydm = "hos_codepay",
                Jylx = jylx,
                Yyjsls = InPara.yyjsls,
                Xrrq = DateTime.Now,
                Instr = inXml
            };
            Ctx.PayFkrzSet.Add(fkrz);
            Ctx.SaveChanges();
        }
    }
}

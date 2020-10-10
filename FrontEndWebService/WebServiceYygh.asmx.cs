using FE.Context;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Xml.Linq;
using FE.Handle.Request;
using FE.Model.Hrp275;

namespace FrontEndWebService
{
    /// <summary>
    /// WebServiceYygh 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceYygh : WebService
    {
        public FrontEndContext _ctx;

        public WebServiceYygh()
        {
            _ctx = new FrontEndContext();
        }

        /// <summary>
        ///     替换原有前置机服务
        /// </summary>
        /// <param name="ProcName"></param>
        /// <param name="inXmlStr"></param>
        /// <returns></returns>
        [WebMethod(Description = "前置机服务--调用各医院存储过程", EnableSession = false)]
        public string ExecProcedure(string ProcName, string inXmlStr)
        {
            DateTime requestTime = DateTime.Now;
            string rtnXml;
            var isSuccess = 1;
            try
            {
                if (string.IsNullOrEmpty(ProcName))
                {
                    return ReturnXml(-1, "存储过程名称为空!", null);
                }

                if (string.IsNullOrEmpty(inXmlStr))
                {
                    return ReturnXml(-1, "传入参数为空!", null);
                }
                string procedureName = ProcName.ToLower().Trim();
                
                if (procedureName == "wsj_get_fsdyyb")
                {
                    var wsjFsdYy=new WsjFsdYyHandle(_ctx,inXmlStr);
                    rtnXml = wsjFsdYy.GetResultXml();
                }
                else if (procedureName == "wsj_get_ghks")
                {
                    var handle=new WsjGhksHandle(_ctx,inXmlStr);
                    rtnXml = handle.GetResultXml();
                }
                else if (procedureName == "hos_expense_invoices")
                {
                    var epf = new ExpenseInvoicesHandle(_ctx,inXmlStr);
                    rtnXml = epf.GetResultXml();
                }
                else if (procedureName == "hos_codepay")
                {
                    var wsjCodePay=new WsjCodePayHandle(_ctx,inXmlStr);
                    rtnXml = wsjCodePay.GetResultXml();
                }
                else if (procedureName == "wsj_get_yspb")
                {
                    var wsjYspb=new WsjYspbHandle(_ctx,inXmlStr);
                    rtnXml = wsjYspb.GetResultXml();
                }
                else if (procedureName == "wsj_ghcl")
                {
                    var wsjGhcl=new WsjGhclHandle(_ctx,inXmlStr);
                    rtnXml = wsjGhcl.GetResultXml();
                }
                else if (procedureName == "wsj_thcl")
                {
                    var wsjThcl=new WsjThclHandle(_ctx,inXmlStr);
                    rtnXml = wsjThcl.GetResultXml();
                }
                else if (procedureName == "hos_orders")
                {
                    var hosOrder=new HosOrderHandle(_ctx,inXmlStr);
                    rtnXml = hosOrder.GetResultXml();
                }
                else if (procedureName == "wsj_get_dqjzdl")
                {
                    var handle = new WsjDqJzDlHandle(_ctx, inXmlStr);
                    rtnXml = handle.GetResultXml();
                }
                else if (procedureName == "wsj_fyqd_get")
                {
                    var wsjFyqd=new WsjFyqdHandle(_ctx,inXmlStr);
                    rtnXml = wsjFyqd.GetResultXml();
                }
                else if (procedureName == "hos_invoice")
                {
                    var hosInvoice=new HosInvoiceHandle(_ctx,inXmlStr);
                    rtnXml = hosInvoice.GetResultXml();
                }
                else if (procedureName == "hos_pay_confirm1")
                {
                    var pcf = new PayConfirmHandle(_ctx, inXmlStr);
                    rtnXml = pcf.GetResultXml();
                }
                else
                {
                    rtnXml = ExecDbProcedure(ProcName, inXmlStr);
                }
            }
            catch (Exception e)
            {
                isSuccess = 0;
                rtnXml = ReturnXml(-1, e.Message, null);
            }
            SaveWjjRequest(ProcName,inXmlStr,isSuccess,rtnXml,requestTime);
            return rtnXml;
        }

        private void SaveWjjRequest(string procName,string inXml,int isSuccess,string outXml,DateTime requestTime)
        {
            try
            {
                var record = new WjjRequest
                {
                    ProcedureName = procName,
                    InXml = inXml,
                    IsSuccess = isSuccess,
                    OutXml = outXml,
                    ResponseTime = DateTime.Now,
                    RequestTime = requestTime
                };
                _ctx.RequestRecords.Add(record);
                _ctx.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// 执行数据库存储过程
        /// </summary>
        /// <param name="procedureName">存储过程名称</param>
        /// <param name="inXml">xml参数</param>
        /// <returns></returns>
        private string ExecDbProcedure(string procedureName, string inXml)
        {
            string rtnXml;
            try
            {
                var connStrOra = ConfigurationManager.AppSettings["conn_ora_his"]?.Trim();
                var connStrSql = ConfigurationManager.AppSettings["conn_sql_his"]?.Trim();
                if (!string.IsNullOrEmpty(connStrOra))
                {
                    rtnXml = ExecuteOracleProcedure(procedureName, inXml, connStrOra);
                }
                else
                {
                    rtnXml = !string.IsNullOrEmpty(connStrSql)
                        ? ExecuteSqlServerProcedure(procedureName, inXml, connStrSql)
                        : ReturnXml(-1, "调用HIS存储过程发生错误！~r~n数据库连接配置错误", null);
                }
            }
            catch (Exception ex)
            {
                rtnXml = ReturnXml(-1, "调用HIS存储过程发生错误！~r~n" + ex, null);
            }
            return rtnXml;
        }

        private string ExecuteOracleProcedure(string procedureName, string inXml, string connectionString)
        {
            string rtnXml;
            using (var connection = new OracleConnection(connectionString))
            {
                connection.Open();
                using (var command = new OracleCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = procedureName;
                    //所有调用该WebService的超时时间(默认是100s)必须设置比command.CommandTimeout要小
                    //调用存储过程超时，该接口返回-1（实际上结算可能是成功的，只不过比较耗时）
                    //如果调用该WebService的超时时间比command.CommandTimeout要大，就会出现接收到-1而去撤销结算
                    command.CommandTimeout = 110;
                    command.Parameters.Add(new OracleParameter("inXml", OracleDbType.Clob, 60000)).Value = inXml;
                    command.Parameters.Add(new OracleParameter("outXml", OracleDbType.Clob, 60000)).Direction =
                        ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    if (command.Parameters[1]?.Value == null)
                    {
                        rtnXml = ReturnXml(-1, "调用HIS存储过程发生错误！~r~n返回NULL", null);
                    }
                    else
                    {
                        var responseContent = command.Parameters[1].Value as OracleClob;
                        rtnXml = responseContent?.Value;
                    }
                }
            }
            return rtnXml;
        }

        private string ExecuteSqlServerProcedure(string procedureName, string inXml, string connectionString)
        {
            string rtnXml;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = procedureName;
                    //所有调用该WebService的超时时间(默认是100s)必须设置比command.CommandTimeout要小
                    //调用存储过程超时，该接口返回-1（实际上结算可能是成功的，只不过比较耗时）
                    //如果调用该WebService的超时时间比command.CommandTimeout要大，就会出现接收到-1而去撤销结算
                    command.CommandTimeout = 110;
                    var para1 = new SqlParameter("inXml", SqlDbType.VarChar, 60000)
                    {
                        Value = inXml,
                        Direction = ParameterDirection.Input
                    };
                    command.Parameters.Add(para1);
                    var para2 = new SqlParameter("outxml", SqlDbType.VarChar, 60000)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(para2);
                    command.ExecuteNonQuery();
                    if (command.Parameters[1]?.Value == null)
                    {
                        rtnXml = ReturnXml(-1, "调用HIS存储过程发生错误！~r~n返回NULL", null);
                    }
                    else
                    {
                        var responseContent = command.Parameters[1].Value;
                        rtnXml = responseContent.ToString();
                    }
                }
            }
            return rtnXml;
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
    }
}
using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Xml;

namespace FrontEndWebService
{
    /// <summary>
    /// WebServiceYygh 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceYygh : WebService
    {
        /// <summary>
        /// 替换原有前置机服务
        /// </summary>
        /// <param name="ProcName"></param>
        /// <param name="inXmlStr"></param>
        /// <returns></returns>
        [WebMethod(Description = "前置机服务--调用各医院存储过程", EnableSession = false)]
        public string ExecProcedure(string ProcName, string inXmlStr)
        {
            try
            {
                string connStr_ora = ConfigurationManager.AppSettings["conn_ora_his"]?.Trim();
                string connStr_sql = ConfigurationManager.AppSettings["conn_sql_his"]?.Trim();
                if (!string.IsNullOrEmpty(connStr_ora))
                {
                    using (var conncetion = new OracleConnection(connStr_ora))
                    {
                        conncetion.Open();
                        using (var command = new OracleCommand(ProcName, conncetion))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = ProcName;
                            //所有调用该WebService的超时时间(默认是100s)必须设置比command.CommandTimeout要小
                            //调用存储过程超时，该接口返回-1（实际上结算可能是成功的，只不过比较耗时）
                            //如果调用该WebService的超时时间比command.CommandTimeout要大，就会出现接收到-1而去撤销结算
                            command.CommandTimeout = 110;

                            command.Parameters.Add(new OracleParameter("inxml", OracleDbType.Clob, 60000)).Value = inXmlStr;
                            command.Parameters.Add(new OracleParameter("outxml", OracleDbType.Clob, 60000)).Direction = ParameterDirection.Output;

                            command.ExecuteNonQuery();
                            if (command.Parameters[1]?.Value == null)
                            {
                                return returnXml(-1, "调用HIS存储过程发生错误！~r~n返回NULL", null);
                            }
                            else
                            {
                                var responseContent = command.Parameters[1].Value as Oracle.ManagedDataAccess.Types.OracleClob;
                                return responseContent?.Value;
                            }
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(connStr_sql))
                {
                    using (var conncetion = new SqlConnection(connStr_sql))
                    {
                        conncetion.Open();
                        using (var command = new SqlCommand(ProcName, conncetion))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = ProcName;
                            //所有调用该WebService的超时时间(默认是100s)必须设置比command.CommandTimeout要小
                            //调用存储过程超时，该接口返回-1（实际上结算可能是成功的，只不过比较耗时）
                            //如果调用该WebService的超时时间比command.CommandTimeout要大，就会出现接收到-1而去撤销结算
                            command.CommandTimeout = 110;

                            SqlParameter para1 = new SqlParameter("inxml", SqlDbType.VarChar, 60000);
                            para1.Value = inXmlStr;
                            para1.Direction = ParameterDirection.Input;
                            command.Parameters.Add(para1);

                            SqlParameter para2 = new SqlParameter("outxml", SqlDbType.VarChar, 60000);
                            para2.Direction = ParameterDirection.Output;
                            command.Parameters.Add(para2);

                            command.ExecuteNonQuery();
                            if (command.Parameters[1]?.Value == null)
                            {
                                return returnXml(-1, "调用HIS存储过程发生错误！~r~n返回NULL", null);
                            }
                            else
                            {
                                var responseContent = command.Parameters[1].Value;
                                return responseContent.ToString();
                            }
                        }
                    }
                }
                else
                    return returnXml(-1, "调用HIS存储过程发生错误！~r~n数据库连接配置错误", null);
            }
            catch (Exception ex)
            {
                return returnXml(-1, "调用HIS存储过程发生错误！~r~n" + ex.ToString(), null);
            }
        }

        private string returnXml(int RtnValue, string bzxx, string data)
        {
            XmlDocument outDoc = new XmlDocument();
            XmlElement root = outDoc.CreateElement("YyghInterface");
            outDoc.AppendChild(root);
            XmlElement xmlelement_rtnvalue = outDoc.CreateElement("RtnValue");
            xmlelement_rtnvalue.InnerText = RtnValue.ToString();
            root.AppendChild(xmlelement_rtnvalue);
            XmlElement xmlelement_bzxx = outDoc.CreateElement("bzxx");
            xmlelement_bzxx.InnerText = bzxx;
            root.AppendChild(xmlelement_bzxx);
            if (data != null)
            {
                XmlElement xmlelement_data = outDoc.CreateElement("interface");
                xmlelement_data.InnerXml = data;
                root.AppendChild(xmlelement_data);
            }

            return outDoc.InnerXml;
        }
    }
}

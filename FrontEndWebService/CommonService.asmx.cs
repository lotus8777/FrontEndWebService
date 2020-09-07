using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using System.Web.Services;
using System.Text;
using System.Security.Cryptography;

namespace FrontEndWebService
{
    /// <summary>
    /// CommonService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class CommonService : WebService
    {
        /// <summary>
        /// 前置机服务调用视图
        /// </summary>
        /// <param name="orgCode">组织机构代码</param>
        /// <param name="viewParam">查询参数</param>
        /// <param name="verifyParam">校验参数</param>
        /// <param name="searchType">类型 1:his 2:lis 3:pacs 4:pe 5:yyh 默认his</param>
        /// <param name="databaseType">数据库类型 1:sqlserver 2:oracle</param>
        /// <returns></returns>
        [WebMethod(Description = "前置机服务--调用各医院视图", EnableSession = false)]
        public string GetView(string orgCode, string viewParam, string verifyParam, string searchType = null, string databaseType = null)
        {
            orgCode = orgCode?.Trim();
            viewParam = viewParam?.Trim();
            verifyParam = verifyParam?.Trim();
            searchType = searchType?.Trim();
            databaseType = databaseType?.Trim();
            if (string.IsNullOrEmpty(orgCode) || orgCode.Length != 9)
                return returnJson(-1, "组织机构代码错误");
            if (string.IsNullOrEmpty(viewParam) || !viewParam.ToLower().StartsWith("select ") || viewParam.ToLower().IndexOf(" v_", StringComparison.Ordinal) == -1)
                return returnJson(-1, "查询参数错误");
            string curVerify = GetMd5(orgCode + ":" + viewParam);
            if (curVerify != verifyParam)
                return returnJson(-1, "校验参数错误");
            try
            {
                if (string.IsNullOrEmpty(searchType))
                    searchType = "his";
                if (string.IsNullOrEmpty(databaseType))
                {
                    //富阳区妇幼保健院/富阳区第二人民医院/富阳区第三人民医院/富阳中医骨伤医院--杭州创业SQLServer，其他Oracle
                    if (orgCode == "470331285" || orgCode == "470331293" || orgCode == "470332499" || orgCode == "470332560")
                        databaseType = "sqlserver";
                    else
                        databaseType = "oracle";
                }
                if (databaseType == "sqlserver")
                {
                    string connStr;
                    if (searchType == "his" || searchType == "lis" || searchType == "pacs" || searchType == "pe" || searchType == "yyh")
                        connStr = ConfigurationManager.AppSettings["conn_sql_" + searchType];
                    else
                        return returnJson(-1, "类型错误");

                    using (SqlConnection conn = new SqlConnection { ConnectionString = connStr })
                    {
                        conn.Open();
                        using (SqlCommand com = new SqlCommand { Connection = conn, CommandType = CommandType.Text, CommandText = viewParam })
                        {
                            com.CommandTimeout = 120;
                            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
                            {
                                DataSet dataTemp = new DataSet();
                                dataAdapter.SelectCommand = com;//检索command设置
                                dataAdapter.Fill(dataTemp);//将检索结果保存到data_temp数据集

                                if (dataTemp.Tables.Count > 0 && dataTemp.Tables[0].Rows?.Count > 0)
                                    return returnJson(1, "成功", ToJson(dataTemp.Tables[0]));
                                else
                                    return returnJson(1, "成功");
                            }
                        }
                    }
                }
                else if (databaseType == "oracle")
                {
                    string connStr;
                    if (searchType == "his" || searchType == "lis" || searchType == "pacs" || searchType == "pe" || searchType == "yyh")
                        connStr = ConfigurationManager.AppSettings["conn_ora_" + searchType];
                    else
                        return returnJson(-1, "类型错误");

                    using (OracleConnection conn = new OracleConnection { ConnectionString = connStr })
                    {
                        conn.Open();
                        using (OracleCommand com = new OracleCommand { Connection = conn, CommandType = CommandType.Text, CommandText = viewParam })
                        {
                            com.CommandTimeout = 120;
                            using (OracleDataAdapter dataAdapter = new OracleDataAdapter())
                            {
                                DataSet dataTemp = new DataSet();
                                dataAdapter.SelectCommand = com;//检索command设置
                                dataAdapter.Fill(dataTemp);//将检索结果保存到data_temp数据集

                                if (dataTemp.Tables.Count > 0 && dataTemp.Tables[0].Rows?.Count > 0)
                                    return returnJson(1, "成功", ToJson(dataTemp.Tables[0]));
                                else
                                    return returnJson(1, "成功");
                            }
                        }
                    }
                }
                else
                    return returnJson(-1, "数据库类型错误");
            }
            catch (Exception ex)
            {
                return returnJson(-1, "异常：" + ex.Message);
            }
        }

        /// <summary>
        /// 以json格式返回结果
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private string returnJson(int code, string msg, string data = null)
        {
            StringBuilder jsonString = new StringBuilder();
            jsonString.Append("{\"code\":\"" + code + "\",\"message\":\"" + msg + "\"");
            data = data?.Trim();
            if (!string.IsNullOrEmpty(data))
                jsonString.Append(",\"data\":" + data);
            jsonString.Append("}");
            return jsonString.ToString();
        }

        /// <summary>
        /// 将字符串生成md5
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string GetMd5(string data)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            var bytValue = Encoding.UTF8.GetBytes(data);
            var bytHash = md5.ComputeHash(bytValue);
            md5.Clear();
            string sTemp = "";
            foreach (var t in bytHash)
            {
                sTemp += t.ToString("X").PadLeft(2, '0');
            }
            return sTemp.ToLower();
        }

        #region DateTable转json
        /// <summary>  
        /// DataTable转换为Json  
        /// </summary> 
        /// <param name="dt">DataTable对象</param>  
        /// <returns>Json字符串</returns>  
        private string ToJson(DataTable dt)
        {
            StringBuilder jsonString = new StringBuilder();
            jsonString.Append("[");
            DataRowCollection drc = dt.Rows;
            for (int i = 0; i < drc.Count; i++)
            {
                jsonString.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string strKey = dt.Columns[j].ColumnName;
                    string strValue = drc[i][j].ToString();
                    Type type = dt.Columns[j].DataType;
                    jsonString.Append("\"" + strKey + "\":");
                    if (j < dt.Columns.Count - 1)
                        jsonString.Append("\"" + StringFormat(strValue, type) + "\",");
                    else
                        jsonString.Append("\"" + StringFormat(strValue, type) + "\"");
                }
                jsonString.Append("},");
            }
            jsonString.Remove(jsonString.Length - 1, 1);
            jsonString.Append("]");
            return jsonString.ToString();
        }

        /// <summary>
        /// 格式化字符型、日期型、布尔型
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private string StringFormat(string strValue, Type type)
        {
            if (type == typeof(string))
                strValue = String2Json(strValue);
            else if (type == typeof(bool))
                strValue = strValue.ToLower();
            else
                strValue = string.Format(strValue, type);

            return strValue;
        }

        /// <summary>
        /// 过滤特殊字符
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string String2Json(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            StringBuilder sb = new StringBuilder();
            char[] charArray = s.ToCharArray();
            if (charArray.Length > 0)
            {
                foreach (char charItem in charArray)
                {
                    switch (charItem)
                    {
                        case '\"':
                            sb.Append("\\\""); break;
                        case '\\':
                            sb.Append("\\\\"); break;
                        case '/':
                            sb.Append("\\/"); break;
                        case '\b':
                            sb.Append("\\b"); break;
                        case '\f':
                            sb.Append("\\f"); break;
                        case '\n':
                            sb.Append("\\n"); break;
                        case '\r':
                            sb.Append("\\r"); break;
                        case '\t':
                            sb.Append("\\t"); break;
                        default:
                            sb.Append(charItem); break;
                    }
                }
            }
            return sb.ToString();
        }
        #endregion
    }
}
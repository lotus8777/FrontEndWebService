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
        /// <param name="org_code">组织机构代码</param>
        /// <param name="view_param">查询参数</param>
        /// <param name="verify_param">校验参数</param>
        /// <param name="search_type">类型 1:his 2:lis 3:pacs 4:pe 5:yyh 默认his</param>
        /// <param name="database_type">数据库类型 1:sqlserver 2:oracle</param>
        /// <returns></returns>
        [WebMethod(Description = "前置机服务--调用各医院视图", EnableSession = false)]
        public string GetView(string org_code, string view_param, string verify_param, string search_type = null, string database_type = null)
        {
            org_code = org_code?.Trim();
            view_param = view_param?.Trim();
            verify_param = verify_param?.Trim();
            search_type = search_type?.Trim();
            database_type = database_type?.Trim();
            if (string.IsNullOrEmpty(org_code) || org_code.Length != 9)
                return returnJson(-1, "组织机构代码错误");
            if (string.IsNullOrEmpty(view_param) || !view_param.ToLower().StartsWith("select ") || view_param.ToLower().IndexOf(" v_") == -1)
                return returnJson(-1, "查询参数错误");
            string cur_verify = GetMd5(org_code + ":" + view_param);
            if (cur_verify != verify_param)
                return returnJson(-1, "校验参数错误");
            try
            {
                if (string.IsNullOrEmpty(search_type))
                    search_type = "his";
                if (string.IsNullOrEmpty(database_type))
                {
                    //富阳区妇幼保健院/富阳区第二人民医院/富阳区第三人民医院/富阳中医骨伤医院--杭州创业SQLServer，其他Oracle
                    if (org_code == "470331285" || org_code == "470331293" || org_code == "470332499" || org_code == "470332560")
                        database_type = "sqlserver";
                    else
                        database_type = "oracle";
                }
                if (database_type == "sqlserver")
                {
                    string conn_str = string.Empty;
                    if (search_type == "his" || search_type == "lis" || search_type == "pacs" || search_type == "pe" || search_type == "yyh")
                        conn_str = ConfigurationManager.AppSettings["conn_sql_" + search_type];
                    else
                        return returnJson(-1, "类型错误");

                    using (SqlConnection conn = new SqlConnection { ConnectionString = conn_str })
                    {
                        conn.Open();
                        using (SqlCommand com = new SqlCommand { Connection = conn, CommandType = CommandType.Text, CommandText = view_param })
                        {
                            com.CommandTimeout = 120;
                            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
                            {
                                DataSet data_temp = new DataSet();
                                dataAdapter.SelectCommand = com;//检索command设置
                                dataAdapter.Fill(data_temp);//将检索结果保存到data_temp数据集

                                if (data_temp != null && data_temp.Tables != null && data_temp.Tables.Count > 0 && data_temp.Tables[0].Rows?.Count > 0)
                                    return returnJson(1, "成功", ToJson(data_temp.Tables[0]));
                                else
                                    return returnJson(1, "成功");
                            }
                        }
                    }
                }
                else if (database_type == "oracle")
                {
                    string conn_str = string.Empty;
                    if (search_type == "his" || search_type == "lis" || search_type == "pacs" || search_type == "pe" || search_type == "yyh")
                        conn_str = ConfigurationManager.AppSettings["conn_ora_" + search_type];
                    else
                        return returnJson(-1, "类型错误");

                    using (OracleConnection conn = new OracleConnection { ConnectionString = conn_str })
                    {
                        conn.Open();
                        using (OracleCommand com = new OracleCommand { Connection = conn, CommandType = CommandType.Text, CommandText = view_param })
                        {
                            com.CommandTimeout = 120;
                            using (OracleDataAdapter dataAdapter = new OracleDataAdapter())
                            {
                                DataSet data_temp = new DataSet();
                                dataAdapter.SelectCommand = com;//检索command设置
                                dataAdapter.Fill(data_temp);//将检索结果保存到data_temp数据集

                                if (data_temp != null && data_temp.Tables != null && data_temp.Tables.Count > 0 && data_temp.Tables[0].Rows?.Count > 0)
                                    return returnJson(1, "成功", ToJson(data_temp.Tables[0]));
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
            byte[] bytValue, bytHash;
            bytValue = Encoding.UTF8.GetBytes(data);
            bytHash = md5.ComputeHash(bytValue);
            md5.Clear();
            string sTemp = "";
            for (int i = 0; i < bytHash.Length; i++)
            {
                sTemp += bytHash[i].ToString("X").PadLeft(2, '0');
            }
            return sTemp.ToLower();
        }

        #region DateTable转json
        /// <summary>  
        /// Datatable转换为Json  
        /// </summary> 
        /// <param name="dt">Datatable对象</param>  
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
        /// <param name="str"></param>
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
            if (string.IsNullOrEmpty(s))
                return s;
            StringBuilder sb = new StringBuilder();
            char[] c_arr = s.ToCharArray();
            if (c_arr != null && c_arr.Length > 0)
            {
                foreach (char c_item in c_arr)
                {
                    switch (c_item)
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
                            sb.Append(c_item); break;
                    }
                }
            }
            return sb.ToString();
        }
        #endregion
    }
}
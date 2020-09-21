using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace FrontEndRequestHandle
{
    public static  class ConvertToObject<T> where T:new()
    {
        public static T GetObjectFromXml(string inXml)
        {
            try
            {
                var xml = XElement.Parse(inXml);
                var t = new T();
                var type = t.GetType();
                var properties = type.GetProperties();
                foreach (var p in properties)
                {
                    var value = xml.Descendants().FirstOrDefault(x => x.Name == p.Name)?.Value;
                    if (value != null)
                    {
                        if (!p.PropertyType.IsGenericType)
                        {
                            p.SetValue(t, Convert.ChangeType(value, p.PropertyType));
                        }
                        else
                        {
                            var genericType = p.PropertyType.GetGenericTypeDefinition();
                            if (genericType == typeof(Nullable<>))
                            {
                                p.SetValue(t,
                                    Convert.ChangeType(xml.Element(p.Name)?.Value,
                                        Nullable.GetUnderlyingType(p.PropertyType)), null);
                            }
                        }
                    }
                }
                return t;
            }
            catch (Exception e)
            {
                
                throw new Exception("xml转换为对象时出错"+e.Message);
            }
        }
    }
}

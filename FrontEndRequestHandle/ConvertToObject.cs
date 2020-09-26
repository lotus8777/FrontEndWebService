using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace FE.Handle.Request
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

        public static T XmlDeserialize(string inXml)
        {
            using (StringReader reader=new StringReader(inXml))
            {
                var type = typeof(T);
                XmlSerializer serializer = new XmlSerializer(type);
                return (T)serializer.Deserialize(reader);
            }
        }
        public static string XmlSerialize(T t)
        {
            string outStr;
            using (MemoryStream stream = new MemoryStream())
            {
                var type = typeof(T);
                XmlSerializer serializer = new XmlSerializer(type);
                serializer.Serialize(stream,t);
                stream.Position = 0;
                StreamReader reader=new StreamReader(stream);
                outStr = reader.ReadToEnd();
                reader.Dispose();
            }
            return outStr;
        }
    }
}

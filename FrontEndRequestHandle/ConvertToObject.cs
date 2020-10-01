﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace FE.Handle.Request
{
    public static class ConvertToObject<T> where T : new()
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

                throw new Exception("xml转换为对象时出错" + e.Message);
            }
        }

        public static T XmlDeserialize(string inXml)
        {
            using (StringReader reader = new StringReader(inXml))
            {
                var type = typeof(T);
                XmlSerializer serializer = new XmlSerializer(type);
                return (T)serializer.Deserialize(reader);
            }
        }
        /// <summary>
        /// 将对象序列化为xml字符串
        /// </summary>
        /// <param name="t">对象</param>
        /// <returns></returns>
        public static string XmlSerializeToString(T t)
        {
            string outStr;
            var setting = new XmlWriterSettings()
            {
                //去除xml声明
                OmitXmlDeclaration = true,
                Encoding = Encoding.UTF8,
                //Xml缩进
                Indent = true
            };
            //去除去除默认命名空间xmlns:xsd和xmlns:xsi
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            using (MemoryStream stream = new MemoryStream())
            {
                var xmlWriter = XmlWriter.Create(stream, setting);
                var type = typeof(T);
                XmlSerializer serializer = new XmlSerializer(type);
                serializer.Serialize(xmlWriter, t, ns);
                stream.Flush();
                stream.Seek(0, SeekOrigin.Begin);
                outStr = Encoding.UTF8.GetString(stream.ToArray());
                xmlWriter.Dispose();
            }
            return outStr;
        }

        /// <summary>
        /// 序列化对象返回XElement
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static XElement SerializeToXElement(T t)
        {
            XElement xmlElement;
            var setting = new XmlWriterSettings()
            {
                //去除xml声明
                OmitXmlDeclaration = true,
                Encoding = Encoding.UTF8,
                //Xml缩进
                Indent = true
            };
            //去除去除默认命名空间xmlns:xsd和xmlns:xsi
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            using (MemoryStream stream = new MemoryStream())
            {
                var type = typeof(T);
                var xmlWriter = XmlWriter.Create(stream, setting);
                XmlSerializer serializer = new XmlSerializer(type);
                serializer.Serialize(xmlWriter, t, ns);
                stream.Flush();
                stream.Seek(0, SeekOrigin.Begin);
                var reader = XmlReader.Create(stream);
                xmlElement = XElement.Load(reader);
                reader.Dispose();
                xmlWriter.Dispose();
            }
            return xmlElement;
        }
    }
}

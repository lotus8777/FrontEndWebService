using System;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using FE.Context;
using FE.Model.Hrp275;
using FE.Model.Local;
using Newtonsoft.Json;

namespace FE.Handle.Request
{
    public class BasicHandle<T> where T : new()
    {
        protected readonly T InPara;
        protected readonly JsonConfig Config;
        protected readonly FrontEndContext Ctx;

        public BasicHandle(FrontEndContext context, string xmlString)
        {
            Ctx = context;
            Config = GetGenericConfig();
            InPara = ConvertToObject<T>.XmlDeserialize(xmlString);
        }

        private JsonConfig GetGenericConfig()
        {
            var path = $@"{AppContext.BaseDirectory}\appConfig.json";
            return JsonConvert.DeserializeObject<JsonConfig>(File.ReadAllText(path));
        }

        protected string ReturnXml(int rtnValue, string bzxx, string data)
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
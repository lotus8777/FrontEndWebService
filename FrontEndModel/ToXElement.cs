using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FrontEndModel
{
    public abstract class ToXElement
    {
        public virtual XElement ToXml(string nodeName = null)
        {
            var className = this.GetType().Name;
            var info = this.GetType();
            var properties = info.GetProperties();
            var xml = string.IsNullOrEmpty(nodeName) ? new XElement(className) : new XElement(nodeName);
            
            foreach (var property in properties)
            {
                var list = property.PropertyType.GetInterface("IEnumerable",false);
                //如果有IsVirtual跳过
                if (property.GetAccessors().Any(p => p.IsVirtual)) continue;
                xml.Add(new XElement(property.Name, property.GetValue(this)));
            }
            return xml;
        }
    }
}

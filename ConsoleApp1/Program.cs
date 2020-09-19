using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using ConsoleApp1.old;
using ConsoleApp1.newService;
using FrontEndRequestHandle;
using ExecProcedureRequest = ConsoleApp1.old.ExecProcedureRequest;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //string inXml = "<interface><zzjgdm>470332499</zzjgdm><ksdm>1</ksdm><ysdm>140</ysdm><gzrq>2020.08.19</gzrq><zblb>1</zblb><ghlb>1</ghlb><zjpb>0</zjpb></interface>";
            string procName = "hos_expense_invoices";
            //old.WebServiceYyghSoapClient client = new old.WebServiceYyghSoapClient();
            //var result = client.ExecProcedure(procName, inXml);
            ExecuteProcedureFactory epf =new ExecuteProcedureFactory();
            string inXml = @"<interface><acttype>1</acttype><actnumber>33011100047033249912020091410195900000000000000006</actnumber><list><actnumber>33011100047033249912020091410195900000000000000006</actnumber><jzlsh>518974</jzlsh><mzzyhm>2720422805</mzzyhm></list></interface>";
            var result = new ExecuteProcedureFactory().GetPatientInvoice( inXml);
            //DateTime begin = DateTime.Now;
            //for (int i = 0; i < 100; i++)
            //{
            //epf.GetMzGhksXml(inXml);
            //}
            //DateTime end=DateTime.Now;
            //TimeSpan ts = end.Subtract(begin);
            //Console.WriteLine($"100次总耗时{ts.TotalMilliseconds}-平均时间{ts.TotalMilliseconds/100}");

            //DateTime begin1 = DateTime.Now;
            //for (int i = 0; i < 100; i++)
            //{
            //    epf.GetMzGhksXml2(inXml);
            //}
            //DateTime end1 = DateTime.Now;
            //TimeSpan ts1 = end1.Subtract(begin1);
            //Console.WriteLine($"100次总耗时{ts1.TotalMilliseconds}-平均时间{ts1.TotalMilliseconds / 100}");

            //var result = epf.GetMzGhksXml("<interface><zzjgdm>470332499</zzjgdm><mode>1</mode></interface>");
            Console.WriteLine(result);
            //newService.WebServiceYyghSoapClient newClient = new newService.WebServiceYyghSoapClient();
            //var newResult = newClient.ExecProcedure(procName, inXml);
            //Console.WriteLine(newResult);
            //Console.WriteLine(returnXml(1, "成功", "11"));
            //Console.WriteLine(RtnXml(1, "成功", "11"));
            Console.ReadLine();
        }

        private static string returnXml(int RtnValue, string bzxx, string data)
        {
            XmlDocument outDoc = new XmlDocument();
            XmlElement root = outDoc.CreateElement("YyghInterface");
            outDoc.AppendChild(root);
            XmlElement xmlelementRtnvalue = outDoc.CreateElement("RtnValue");
            xmlelementRtnvalue.InnerText = RtnValue.ToString();
            root.AppendChild(xmlelementRtnvalue);
            XmlElement xmlelementBzxx = outDoc.CreateElement("bzxx");
            xmlelementBzxx.InnerText = bzxx;
            root.AppendChild(xmlelementBzxx);
            if (data != null)
            {
                XmlElement xmlelementData = outDoc.CreateElement("interface");
                xmlelementData.InnerXml = data;
                root.AppendChild(xmlelementData);
            }

            return outDoc.InnerXml;
        }

        private static string RtnXml(int rtnValue, string bzxx, string data)
        {
            XElement xmlElement =
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

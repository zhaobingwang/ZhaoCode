using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CSharp.XML
{
    class Program
    {
        static void Main(string[] args)
        {
            XElement root = XElement.Load("xml/PurchaseOrder.xml"); //XML文档中读取
            //XElement root = XElement.Parse(XMLHandler.InitXML()); //XML字符串中读取
            IEnumerable<XElement> address =
                from e1 in root.Elements("Address")
                where (string)e1.Attribute("Type") == "Billing"
                select e1;
            foreach (var item in address)
            {
                Console.WriteLine(item);
            }
        }
    }
    class XMLHandler
    {
        public static string InitXML()
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load("xml/PurchaseOrder.xml");
            return ConvertXmlToString(xmldoc);
        }
        public static string InitXML2()
        {
            string xmlstr = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
            xmlstr += "<root>";
            xmlstr += "<Users>";

            xmlstr += "<User>";
            xmlstr += "<Id>10001</Id>";
            xmlstr += "<Name>曹操</Name>";
            xmlstr += "<Gender>男</Gender>";
            xmlstr += "<Age>55</Age>";
            xmlstr += "</User>";

            xmlstr += "<User>";
            xmlstr += "<Id>10002</Id>";
            xmlstr += "<Name>刘备</Name>";
            xmlstr += "<Gender>男</Gender>";
            xmlstr += "<Age>5</Age>";
            xmlstr += "</User>";

            xmlstr += "<User>";
            xmlstr += "<Id>10002</Id>";
            xmlstr += "<Name>孙尚香</Name>";
            xmlstr += "<Gender>女</Gender>";
            xmlstr += "<Age>20</Age>";
            xmlstr += "</User>";

            xmlstr += "</Users>";
            xmlstr += "</root>";
            return xmlstr;
        }

        public static string ConvertXmlToString(XmlDocument xmlDoc)
        {
            MemoryStream stream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(stream, null);
            writer.Formatting = Formatting.Indented; xmlDoc.Save(writer);
            StreamReader sr = new StreamReader(stream, System.Text.Encoding.UTF8);
            stream.Position = 0;
            string xmlString = sr.ReadToEnd();
            sr.Close();
            stream.Close();
            return xmlString;
        }
    }
}

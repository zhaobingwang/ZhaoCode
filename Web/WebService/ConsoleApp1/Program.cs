using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
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

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(xmlstr);
            //获取根节点
            XmlElement root = xmldoc.DocumentElement;
            //获取指定单个节点
            XmlNode node = xmldoc.SelectSingleNode("//Users//User");
            //获取指定节点的集合
            XmlNodeList nodeList = xmldoc.SelectNodes("//Users/User");
            //获取所有的xml节点
            XmlNodeList allNodeList = xmldoc.SelectNodes("*");

            

            Console.WriteLine(node.OuterXml);
        }
    }
}

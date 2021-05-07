using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LocateMe
{
    public class LocationData
    {
        public string Ip { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string TimeZone { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string MetroCode { get; set; }


        public LocationData Parse(string xmlToParse)
        {

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlToParse);

            XmlNodeList nodes =  xmlDocument.DocumentElement.SelectNodes("//Response");

            foreach (XmlNode node in nodes)
            {
                Ip = node.SelectSingleNode("IP").InnerText;
                CountryCode = node.SelectSingleNode("CountryCode").InnerText;
                CountryName = node.SelectSingleNode("CountryName").InnerText;
                RegionCode = node.SelectSingleNode("RegionCode").InnerText;
                RegionName = node.SelectSingleNode("RegionName").InnerText;
                City = node.SelectSingleNode("City").InnerText;
                ZipCode = node.SelectSingleNode("ZipCode").InnerText;
                TimeZone = node.SelectSingleNode("TimeZone").InnerText;
                Latitude = node.SelectSingleNode("Latitude").InnerText;
                Longitude = node.SelectSingleNode("Longitude").InnerText;
                MetroCode = node.SelectSingleNode("MetroCode").InnerText;
                    
            }

          

            return this;

        }

    }

}

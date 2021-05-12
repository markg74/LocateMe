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
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string MetroCode { get; set; }

        public LocationData Parse(string xmlToParse)
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xmlToParse);

                XmlNodeList nodes = xmlDocument.DocumentElement.SelectNodes("//Response");

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

                    if (Decimal.TryParse(node.SelectSingleNode("Latitude").Value, out decimal _latitude))
                        Latitude = _latitude;
                    if (Decimal.TryParse(node.SelectSingleNode("Longitude").Value, out decimal _longitude))
                        Longitude = _longitude;

                    //Latitude = Convert.ToDecimal(node.SelectSingleNode("Latitude").Value);
                    //Longitude = Convert.ToDecimal(node.SelectSingleNode("Longitude").Value);
                    MetroCode = node.SelectSingleNode("MetroCode").InnerText;
                }

                return this;
            }
            catch (Exception)
            {
                this.Ip = "N/A";
                return this;
            }
            
            
        }
    }
}

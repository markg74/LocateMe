using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace LocateMe
{
    class ExternalApi
    {
        public static string Call(string host)    
        {
            string endPoint = "https://freegeoip.app/xml/";

            if (!String.IsNullOrWhiteSpace(host))
                endPoint += host;
            try
            {
                HttpWebRequest webRequest = System.Net.WebRequest.CreateHttp(endPoint);
                webRequest.Method = "GET";

                using (WebResponse webResponse = webRequest.GetResponse())
                using (StreamReader responseReader = new StreamReader(webResponse.GetResponseStream()))
                {
                    return Convert.ToString(responseReader.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                return "ERROR : " + e.Message ;
            }
        }
    }
}

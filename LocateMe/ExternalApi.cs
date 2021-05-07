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
        public string Call()
        {
            HttpWebRequest webRequest = System.Net.WebRequest.CreateHttp("https://freegeoip.app/xml/");
            webRequest.Method = "GET";

            using (WebResponse webResponse = webRequest.GetResponse())
            using (StreamReader responseReader = new StreamReader(webResponse.GetResponseStream()))
            {
                return  Convert.ToString(responseReader.ReadToEnd());
            }
       
        }
    }
}

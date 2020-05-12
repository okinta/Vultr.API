using System.Collections.Generic;
using System.Net;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Vultr.API.Extensions
{
    public class ApiClient
    {
        public static readonly string VultrApiUrl = "https://api.vultr.com/v1/";

        public static HttpWebResponse ApiExecute(string AccessPoint, string ApiKey, List<KeyValuePair<string, object>> Parameters = null, string Method = "GET")
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)Conversions.ToInteger(3072);
            ServicePointManager.DefaultConnectionLimit = 9999;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(VultrApiUrl + AccessPoint);
            httpWebRequest.UserAgent = "VultrAPI.Net";
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = Method;
            if (string.IsNullOrWhiteSpace(ApiKey) == false)
            {
                httpWebRequest.Headers.Add("API-Key", ApiKey);
            }

            if ((Method ?? "") == "GET")
            {
                if (Information.IsNothing(Parameters) == false)
                {
                    foreach (KeyValuePair<string, object> pair in Parameters)
                        httpWebRequest.Headers.Add(pair.Key, Conversions.ToString(pair.Value));
                }
            }
            else if (Information.IsNothing(Parameters) == false)
            {
                string postData = "";
                foreach (KeyValuePair<string, object> pair in Parameters)
                    postData += (string.IsNullOrEmpty(postData) ? "" : "&") + pair.Key + "=" + pair.Value;
                var encoding = new UTF8Encoding();
                var byteData = encoding.GetBytes(postData);
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                httpWebRequest.ContentLength = byteData.Length;
                var postreqstream = httpWebRequest.GetRequestStream();
                postreqstream.Write(byteData, 0, byteData.Length);
                postreqstream.Close();
            }

            HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            return httpResponse;
        }
    }
}
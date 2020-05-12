using System.Collections.Generic;
using System.Net;

namespace Vultr.API.Models.Responses
{
    public class ISOImage
    {
        public int ISOID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string date_created { get; set; }
        public string filename { get; set; }
        public int size { get; set; }
        public string md5sum { get; set; }
        public string status { get; set; }
    }

    public struct ISOImageCreateResult
    {
        public ISOImage ISOImage { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }

    public struct ISOImageResult
    {
        public Dictionary<string, ISOImage> ISOImages { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }
}
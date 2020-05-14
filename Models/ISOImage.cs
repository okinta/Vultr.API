using System.Collections.Generic;
using System.Net.Http;
using System.Numerics;

namespace Vultr.API.Models
{
    public class ISOImage
    {
        public int ISOID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string date_created { get; set; }
        public string filename { get; set; }
        public BigInteger size { get; set; }
        public string md5sum { get; set; }
        public string status { get; set; }
    }

    public struct ISOImageCreateResult
    {
        public ISOImage ISOImage { get; set; }
        public HttpResponseMessage ApiResponse { get; set; }
    }

    public struct ISOImageResult
    {
        public Dictionary<string, ISOImage> ISOImages { get; set; }
        public HttpResponseMessage ApiResponse { get; set; }
    }
}

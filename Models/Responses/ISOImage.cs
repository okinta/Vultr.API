using System.Collections.Generic;
using System.Net;

namespace Vultr.API.Models.Responses
{
    public class ISOImage
    {
        public int ISOID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DateCreated { get; set; }
        public string Filename { get; set; }
        public int Size { get; set; }
        public string MD5Sum { get; set; }
        public string Status { get; set; }
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
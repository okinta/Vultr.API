using System.Net;

namespace Vultr.API.Models.Responses
{
    public class Auth
    {
        public string[] acls { get; set; }
        public string email { get; set; }
        public string name { get; set; }
    }

    public struct AuthResult
    {
        public Auth Auth { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }
}
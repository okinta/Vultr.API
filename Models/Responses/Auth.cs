using System.Net;

namespace Vultr.API.Models.Responses
{
    public class Auth
    {
        public string[] ACLS { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }

    public struct AuthResult
    {
        public Auth Auth { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }
}
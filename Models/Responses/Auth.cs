using System.Net.Http;

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
        public HttpResponseMessage ApiResponse { get; set; }
    }
}

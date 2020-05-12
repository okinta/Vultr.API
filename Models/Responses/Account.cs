using System.Net;

namespace Vultr.API.Models.Responses
{
    public class Account
    {
        public string balance { get; set; }
        public string pending_charges { get; set; }
        public string last_payment_date { get; set; }
        public string last_payment_amount { get; set; }
    }

    public struct AccountResult
    {
        public Account Account { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }
}
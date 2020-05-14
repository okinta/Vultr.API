using System.Net.Http;

namespace Vultr.API.Models
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
        public HttpResponseMessage ApiResponse { get; set; }
    }
}
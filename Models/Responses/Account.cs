using System.Net;

namespace Vultr.API.Models.Responses
{
    public class Account
    {
        public string Balance { get; set; }
        public string PendingCharges { get; set; }
        public string LastPaymentDate { get; set; }
        public string LastPaymentAmount { get; set; }
    }

    public struct AccountResult
    {
        public Account Account { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }
}
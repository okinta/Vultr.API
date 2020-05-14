using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;

namespace Vultr.API.Models.Responses
{
    public class User
    {
        public string USERID { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        [DefaultValue("yes")]
        public string api_enabled { get; set; }
        public acls[] acls { get; set; }
    }

    public struct UserResult
    {
        public List<User> Users { get; set; }
        public HttpResponseMessage ApiResponse { get; set; }
    }

    public struct UserCreateResult
    {
        public User User { get; set; }
        public HttpResponseMessage ApiResponse { get; set; }
    }

    public struct UserDeleteResult
    {
        public HttpResponseMessage ApiResponse { get; set; }
    }

    public struct UserUpdateResult
    {
        public HttpResponseMessage ApiResponse { get; set; }
    }

    public class acls
    {
        private string Key;
        public static readonly acls ManageUsers = new acls("manage_users");
        public static readonly acls Subscriptions = new acls("subscriptions");
        public static readonly acls Provisioning = new acls("provisioning");
        public static readonly acls Billing = new acls("billing");
        public static readonly acls Support = new acls("support");
        public static readonly acls Abuse = new acls("abuse");
        public static readonly acls Dns = new acls("dns");
        public static readonly acls Upgrade = new acls("upgrade");

        private acls(string key)
        {
            Key = key;
        }

        public override string ToString()
        {
            return Key;
        }
    }
}

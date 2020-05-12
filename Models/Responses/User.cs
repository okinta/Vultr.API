using System.Collections.Generic;
using System.Net;

namespace Vultr.API.Models.Responses
{
    public class User
    {
        public string USERID { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string ApiEnabled { get; set; } = "yes";

        public Acls[] Acls { get; set; }
    }

    public struct UserResult
    {
        public List<User> Users { get; set; }

        public HttpWebResponse ApiResponse { get; set; }
    }

    public struct UserCreateResult
    {
        public User User { get; set; }

        public HttpWebResponse ApiResponse { get; set; }
    }

    public struct UserDeleteResult
    {
        public HttpWebResponse ApiResponse { get; set; }
    }

    public struct UserUpdateResult
    {
        public HttpWebResponse ApiResponse { get; set; }
    }

    public class Acls
    {
        private readonly string Key;
        public static readonly Acls ManageUsers = new Acls("manage_users");
        public static readonly Acls Subscriptions = new Acls("subscriptions");
        public static readonly Acls Provisioning = new Acls("provisioning");
        public static readonly Acls Billing = new Acls("billing");
        public static readonly Acls Support = new Acls("support");
        public static readonly Acls Abuse = new Acls("abuse");
        public static readonly Acls Dns = new Acls("dns");
        public static readonly Acls Upgrade = new Acls("upgrade");

        private Acls(string key)
        {
            Key = key;
        }

        public override string ToString()
        {
            return Key;
        }
    }
}
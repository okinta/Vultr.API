using System.Collections.Generic;
using System.Linq;
using Vultr.API.Models;
using Vultr.Clients;

namespace Vultr.API.Clients
{
    public class UserClient : BaseClient
    {
        public UserClient(string apiKey, string apiURL) : base(apiKey, apiURL) { }

        /// <summary>
        /// Retrieve a list of any users associated with this account.
        /// </summary>
        /// <returns>List of active Users.</returns>
        public UserResult GetUsers()
        {
            var response = ApiExecute<List<User>>(
                "user/list", ApiKey);
            return new UserResult()
            {
                ApiResponse = response.Item1,
                Users = response.Item2
            };
        }

        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <param name="User">New User class with email, name, password.</param>
        /// <returns>Returns backup list and HTTP API Respopnse.</returns>
        public UserCreateResult CreateUser(User User)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("email", User.email),
                new KeyValuePair<string, object>("name", User.name),
                new KeyValuePair<string, object>("api_enabled", User.api_enabled),
                new KeyValuePair<string, object>("password", User.password)
            };

            for (int i = 0, loopTo = User.acls.Count() - 1; i <= loopTo; i++)
                args.Add(new KeyValuePair<string, object>("acls[]", User.acls[i]));

            var response = ApiExecute<User>(
                "user/create", ApiKey, args, ApiMethod.POST);
            return new UserCreateResult()
            {
                ApiResponse = response.Item1,
                User = response.Item2
            };
        }

        /// <summary>
        /// Delete a user.
        /// </summary>
        /// <param name="User">Updated usesr class with parameters.</param>
        /// <returns>No response, check HTTP result code.</returns>
        public UserUpdateResult DeleteUser(User User)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("USERID", User.USERID),
                new KeyValuePair<string, object>("email", User.email),
                new KeyValuePair<string, object>("name", User.name),
                new KeyValuePair<string, object>("api_enabled", User.api_enabled),
                new KeyValuePair<string, object>("password", User.password)
            };

            for (int i = 0, loopTo = User.acls.Count() - 1; i <= loopTo; i++)
                args.Add(new KeyValuePair<string, object>("acls[]", User.acls[i]));

            var response = ApiExecute<User>(
                "user/update", ApiKey, args, ApiMethod.POST);
            return new UserUpdateResult()
            {
                ApiResponse = response.Item1
            };
        }


        /// <summary>
        /// Update the details for a user.
        /// </summary>
        /// <param name="USERID">ID of the user to delete</param>
        /// <returns>No response, check HTTP result code.</returns>
        public UserDeleteResult UpdateUser(string USERID)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("USERID", USERID)
            };

            var response = ApiExecute<User>(
                "user/delete", ApiKey, args, ApiMethod.POST);
            return new UserDeleteResult()
            {
                ApiResponse = response.Item1
            };
        }
    }
}

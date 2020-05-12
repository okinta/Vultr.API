using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Vultr.API.Models.Responses;

namespace Vultr.API.Clients
{
    public class UserClient
    {
        private readonly string _ApiKey;

        public UserClient(string ApiKey)
        {
            _ApiKey = ApiKey;
        }

        /// <summary>
        /// Retrieve a list of any users associated with this account.
        /// </summary>
        /// <returns>List of active Users.</returns>
        public UserResult GetUsers()
        {
            var answer = new List<User>();
            var httpResponse = Extensions.ApiClient.ApiExecute("user/list", _ApiKey);
            if ((int)httpResponse.StatusCode == 200)
            {
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());
                string st = streamReader.ReadToEnd();
                answer = JsonConvert.DeserializeObject<List<User>>((st ?? "") == "[]" ? "{}" : st);
            }

            return new UserResult() { ApiResponse = httpResponse, Users = answer };
        }

        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <param name="User">New User class with email, name, password.</param>
        /// <returns>Returns backup list and HTTP API Respopnse.</returns>
        public UserCreateResult CreateUser(User User)
        {
            var dict = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("email", User.Email),
                new KeyValuePair<string, object>("name", User.Name),
                new KeyValuePair<string, object>("api_enabled", User.ApiEnabled),
                new KeyValuePair<string, object>("password", User.Password)
            };
            for (int i = 0, loopTo = User.Acls.Count() - 1; i <= loopTo; i++)
                dict.Add(new KeyValuePair<string, object>("acls[]", User.Acls[i]));
            var answer = new UserCreateResult();
            var httpResponse = Extensions.ApiClient.ApiExecute("user/create", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());
                string st = streamReader.ReadToEnd();
                answer.User = JsonConvert.DeserializeObject<User>((st ?? "") == "[]" ? "{}" : st);
            }

            return new UserCreateResult() { ApiResponse = httpResponse, User = answer.User };
        }

        /// <summary>
        /// Delete a user.
        /// </summary>
        /// <param name="User">Updated usesr class with parameters.</param>
        /// <returns>No response, check HTTP result code.</returns>
        public UserUpdateResult DeleteUser(User User)
        {
            var dict = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("USERID", User.USERID)
            };
            for (int i = 0, loopTo = User.Acls.Count() - 1; i <= loopTo; i++)
                dict.Add(new KeyValuePair<string, object>("acls[]", User.Acls[i]));
            if (string.IsNullOrWhiteSpace(User.Email) == false)
            {
                dict.Add(new KeyValuePair<string, object>("email", User.Email));
            }

            if (string.IsNullOrWhiteSpace(User.Name) == false)
            {
                dict.Add(new KeyValuePair<string, object>("name", User.Name));
            }

            if (string.IsNullOrWhiteSpace(User.ApiEnabled) == false)
            {
                dict.Add(new KeyValuePair<string, object>("api_enabled", User.ApiEnabled));
            }

            if (string.IsNullOrWhiteSpace(User.Password) == false)
            {
                dict.Add(new KeyValuePair<string, object>("password", User.Password));
            }

            var httpResponse = Extensions.ApiClient.ApiExecute("user/update", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());
                string st = streamReader.ReadToEnd();
            }

            return new UserUpdateResult() { ApiResponse = httpResponse };
        }


        /// <summary>
        /// Update the details for a user.
        /// </summary>
        /// <param name="USERID">ID of the user to delete</param>
        /// <returns>No response, check HTTP result code.</returns>
        public UserDeleteResult UpdateUser(string USERID)
        {
            var dict = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("USERID", USERID)
            };
            var httpResponse = Extensions.ApiClient.ApiExecute("user/delete", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());
                string st = streamReader.ReadToEnd();
            }

            return new UserDeleteResult() { ApiResponse = httpResponse };
        }
    }
}
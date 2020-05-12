using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Vultr.API.Models.Responses;

namespace Vultr.API.Clients
{
    public class ISOImageClient
    {
        private readonly string _ApiKey;

        public ISOImageClient(string ApiKey)
        {
            _ApiKey = ApiKey;
        }

        /// <summary>
        /// List all ISOs currently available on this account.
        /// </summary>
        /// <returns>List of all ISOs currently available on this account.</returns>
        public ISOImageResult GetISOImages()
        {
            var answer = new Dictionary<string, ISOImage>();
            var httpResponse = Extensions.ApiClient.ApiExecute("iso/list", _ApiKey);
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                    answer = JsonConvert.DeserializeObject<Dictionary<string, ISOImage>>((st ?? "") == "[]" ? "{}" : st);
                }
            }

            return new ISOImageResult() { ApiResponse = httpResponse, ISOImages = answer };
        }
        /// <summary>
        /// List public ISOs offered in the Vultr ISO library.
        /// </summary>
        /// <returns>List of all public ISOs offered in the Vultr ISO library.</returns>
        public ISOImageResult GetPublicISOImages()
        {
            var answer = new Dictionary<string, ISOImage>();
            var httpResponse = Extensions.ApiClient.ApiExecute("iso/list_public", _ApiKey);
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                    answer = JsonConvert.DeserializeObject<Dictionary<string, ISOImage>>((st ?? "") == "[]" ? "{}" : st);
                }
            }

            return new ISOImageResult() { ApiResponse = httpResponse, ISOImages = answer };
        }

        /// <summary>
        /// Create a new ISO image on the current account. The ISO image will be downloaded from a given URL. Download status can be checked with the GetISOImages call.
        /// </summary>
        /// <param name="URL">Remote URL from where the ISO will be downloaded.</param>
        /// <returns>Returns backup list and HTTP API Respopnse.</returns>
        public ISOImageCreateResult CreateISOImage(Uri URL)
        {
            var dict = new List<KeyValuePair<string, object>>();
            dict.Add(new KeyValuePair<string, object>("url", URL.AbsoluteUri));
            var answer = new ISOImageCreateResult();
            var httpResponse = Extensions.ApiClient.ApiExecute("iso/create_from_url", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                    answer.ISOImage = JsonConvert.DeserializeObject<ISOImage>((st ?? "") == "[]" ? "{}" : st);
                }
            }

            return new ISOImageCreateResult() { ApiResponse = httpResponse, ISOImage = answer.ISOImage };
        }
    }
}
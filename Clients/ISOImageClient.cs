using System.Collections.Generic;
using System;
using Vultr.API.Extensions;
using Vultr.API.Models.Responses;

namespace Vultr.API.Clients
{
    public class ISOImageClient
    {
        private string ApiKey { get; }

        public ISOImageClient(string apiKey)
        {
            ApiKey = apiKey;
        }

        /// <summary>
        /// List all ISOs currently available on this account.
        /// </summary>
        /// <returns>List of all ISOs currently available on this account.</returns>
        public ISOImageResult GetISOImages()
        {
            var response = ApiClient.ApiExecute<Dictionary<string, ISOImage>>(
                "iso/list", ApiKey);
            return new ISOImageResult() {
                ApiResponse = response.Item1, ISOImages = response.Item2
            };
        }
        /// <summary>
        /// List public ISOs offered in the Vultr ISO library.
        /// </summary>
        /// <returns>List of all public ISOs offered in the Vultr ISO library.</returns>
        public ISOImageResult GetPublicISOImages()
        {
            var response = ApiClient.ApiExecute<Dictionary<string, ISOImage>>(
                "iso/list_public", ApiKey);
            return new ISOImageResult()
            {
                ApiResponse = response.Item1,
                ISOImages = response.Item2
            };
        }

        /// <summary>
        /// Create a new ISO image on the current account. The ISO image will be downloaded from a given URL. Download status can be checked with the GetISOImages call.
        /// </summary>
        /// <param name="URL">Remote URL from where the ISO will be downloaded.</param>
        /// <returns>Returns backup list and HTTP API Respopnse.</returns>
        public ISOImageCreateResult CreateISOImage(Uri URL)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("url", URL.AbsoluteUri)
            };

            var response = ApiClient.ApiExecute<ISOImage>(
                "iso/create_from_url", ApiKey, args, ApiMethod.POST);
            return new ISOImageCreateResult()
            {
                ApiResponse = response.Item1,
                ISOImage = response.Item2
            };
        }
    }
}

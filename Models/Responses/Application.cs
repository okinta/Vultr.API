using System.Collections.Generic;
using System.Net.Http;

namespace Vultr.API.Models.Responses
{

    /// <summary>
    /// Application APPID, name, short_name, deploy_name and surcharge.
    /// </summary>
    public class Application
    {
        /// <summary>
        /// Application ID
        /// </summary>
        /// <returns>Integer</returns>
        /// <example>1</example>
        public string APPID { get; set; }

        /// <summary>
        /// Application name as string
        /// </summary>
        /// <returns>String</returns>
        /// <example>LEMP</example>
        public string name { get; set; }

        /// <summary>
        /// Application short name
        /// </summary>
        /// <returns>lemp</returns>
        public string short_name { get; set; }

        /// <summary>
        /// Application deploy name
        /// </summary>
        /// <returns>String</returns>
        /// <example>LEMP on CentOS 6 x64</example>
        public string deploy_name { get; set; }

        /// <summary>
        /// Application's surcharge
        /// </summary>
        /// <returns>Double</returns>
        /// <example>0</example>
        public string surcharge { get; set; }
    }

    /// <summary>
    /// Applications and HTTP API Response
    /// </summary>
    public struct ApplicationResult
    {
        /// <summary>
        /// Returns API Result with Applications Dictionary (Of String, Application)
        /// </summary>
        /// <returns>Applications Dictionary</returns>
        public Dictionary<string, Application> Applications { get; set; }

        /// <summary>
        /// Returns API Result with HttpWebResponse
        /// </summary>
        /// <returns>HttpWebResponse</returns>
        public HttpResponseMessage ApiResponse { get; set; }
    }
}
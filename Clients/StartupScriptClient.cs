using System.Collections.Generic;
using System.Net.Http;
using Vultr.API.Extensions;
using Vultr.API.Models;

namespace Vultr.API.Clients
{
    public class StartupScriptClient
    {
        private string ApiKey { get; }

        public StartupScriptClient(string apiKey)
        {
            ApiKey = apiKey;
        }

        /// <summary>
        /// List all startup scripts on the current account. Scripts of type "boot" are
        /// executed by the server's operating system on the first boot. Scripts of type
        /// "pxe" are executed by iPXE when the server itself starts up.
        /// </summary>
        /// <returns>List of all startup scripts on the current account.</returns>
        public StartupScriptResult GetStartupScripts()
        {
            var response = ApiClient.ApiExecute<
                Dictionary<string, StartupScript>>("startupscript/list", ApiKey);
            return new StartupScriptResult()
            {
                ApiResponse = response.Item1,
                StartupScripts = response.Item2
            };
        }

        /// <summary>
        /// Create a startup script.
        /// </summary>
        /// <param name="name">Name of the newly created startup script.</param>
        /// <param name="script">Startup script contents.</param>
        /// <param name="type">Type of startup script. Default is 'boot'.</param>
        /// <returns>StartupScript element with only SCRIPTID.</returns>
        public StartupScriptCreateResult CreateStartupScript(
            string name, string script, ScriptType type = ScriptType.boot)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("name", name),
                new KeyValuePair<string, object>("script", script),
                new KeyValuePair<string, object>("type", type.ToString())
            };

            var response = ApiClient.ApiExecute<StartupScript>(
                "startupscript/create", ApiKey, args, ApiMethod.POST);
            return new StartupScriptCreateResult()
            {
                ApiResponse = response.Item1,
                StartupScript = response.Item2
            };
        }

        /// <summary>
        /// Remove a startup script.
        /// </summary>
        /// <param name="SCRIPTID">Unique identifier for this startup script. These can
        /// be found using the v1/startupscript/list call.</param>
        /// <returns>The HttpResponseMessage resulted from the API call.</returns>
        public HttpResponseMessage DeleteStartupScript(string SCRIPTID)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("SCRIPTID", SCRIPTID)
            };

            var response = ApiClient.ApiExecute<StartupScript>(
                "startupscript/destroy", ApiKey, args, ApiMethod.POST);
            return response.Item1;
        }

        /// <summary>
        /// Update an existing startup script.
        /// </summary>
        /// <param name="SCRIPTID">SCRIPTID of script to update (see
        /// /v1/startupscript/list).</param>
        /// <param name="name">New name for the startup script.</param>
        /// <param name="script">New startup script contents.</param>
        /// <returns>The HttpResponseMessage resulted from the API call.</returns>
        public HttpResponseMessage UpdateStartupScript(
            string SCRIPTID, string name = null, string script = null)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("SCRIPTID", SCRIPTID),
                new KeyValuePair<string, object>("name", name),
                new KeyValuePair<string, object>("script", script)
            };

            var response = ApiClient.ApiExecute<StartupScript>(
                "startupscript/update", ApiKey, args, ApiMethod.POST);
            return response.Item1;
        }
    }
}

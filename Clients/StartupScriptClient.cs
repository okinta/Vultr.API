using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Vultr.API.Models.Responses;

namespace Vultr.API.Clients
{
    public class StartupScriptClient
    {
        private readonly string _ApiKey;

        public StartupScriptClient(string ApiKey)
        {
            _ApiKey = ApiKey;
        }

        /// <summary>
        /// List all startup scripts on the current account. Scripts of type "boot" are executed by the server's operating system on the first boot. Scripts of type "pxe" are executed by iPXE when the server itself starts up.
        /// </summary>
        /// <returns>List of all startup scripts on the current account.</returns>
        public StartupScriptResult GetStartupScripts()
        {
            var answer = new Dictionary<string, StartupScript>();
            var httpResponse = Extensions.ApiClient.ApiExecute("startupscript/list", _ApiKey);
            if ((int)httpResponse.StatusCode == 200)
            {
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());
                string st = streamReader.ReadToEnd();
                answer = JsonConvert.DeserializeObject<Dictionary<string, StartupScript>>((st ?? "") == "[]" ? "{}" : st);
            }

            return new StartupScriptResult() { ApiResponse = httpResponse, StartupScripts = answer };
        }

        /// <summary>
        /// Create a startup script..
        /// </summary>
        /// <param name="name">Name of the newly created startup script.</param>
        /// <param name="script">Startup script contents.</param>
        /// <param name="ScriptType">Type of startup script. Default is 'boot'.</param>
        /// <returns>StartupScript element with only SCRIPTID.</returns>
        public StartupScriptCreateResult CreateStartupScript(string name, string script, ScriptType ScriptType)
        {
            var dict = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("name", name),
                new KeyValuePair<string, object>("script", script),
                new KeyValuePair<string, object>("type", ScriptType.ToString())
            };
            var answer = new StartupScript();
            var httpResponse = Extensions.ApiClient.ApiExecute("startupscript/create", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());
                string st = streamReader.ReadToEnd();
                answer = JsonConvert.DeserializeObject<StartupScript>((st ?? "") == "[]" ? "{}" : st);
            }

            return new StartupScriptCreateResult() { ApiResponse = httpResponse, StartupScript = answer };
        }

        /// <summary>
        /// Remove a SSH key. Note that this will not remove the key from any machines that already have it.
        /// </summary>
        /// <param name="SCRIPTID">Unique identifier for this startup script. These can be found using the GetStartupScripts()</param>
        /// <returns>No response, check HTTP result code.</returns>
        public StartupScriptDeleteResult DeleteStartupScript(string SCRIPTID)
        {
            var dict = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("SCRIPTID", SCRIPTID)
            };
            var httpResponse = Extensions.ApiClient.ApiExecute("startupscript/destroy", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());
                string st = streamReader.ReadToEnd();
            }

            return new StartupScriptDeleteResult() { ApiResponse = httpResponse };
        }

        /// <summary>
        /// Update an existing startup script.
        /// </summary>
        /// <param name="SCRIPTID">SCRIPTID of script to update. These can be found using the GetStartupScripts()</param>
        /// <param name="name">Name of the newly created startup script.</param>
        /// <param name="script">Startup script contents.</param>
        /// <param name="ScriptType">Type of startup script. Default is 'boot'.</param>
        /// <returns>No response, check HTTP result code.</returns>
        public StartupScriptUpdateResult UpdateSSHKey(string SCRIPTID, string name, string script, ScriptType ScriptType)
        {
            var dict = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("SCRIPTID", SCRIPTID),
                new KeyValuePair<string, object>("name", name),
                new KeyValuePair<string, object>("script", script),
                new KeyValuePair<string, object>("type", ScriptType.ToString())
            };
            var httpResponse = Extensions.ApiClient.ApiExecute("startupscript/update", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());
                string st = streamReader.ReadToEnd();
            }

            return new StartupScriptUpdateResult() { ApiResponse = httpResponse };
        }
    }
}
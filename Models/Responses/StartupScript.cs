using System.Collections.Generic;
using System.Net;

namespace Vultr.API.Models.Responses
{
    public class StartupScript
    {
        public string SCRIPTID { get; set; }

        public string DateCreated { get; set; }

        public string DateModified { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Script { get; set; }
    }

    public struct StartupScriptCreateResult
    {
        public StartupScript StartupScript { get; set; }

        public HttpWebResponse ApiResponse { get; set; }
    }

    public struct StartupScriptDeleteResult
    {
        public HttpWebResponse ApiResponse { get; set; }
    }

    public struct StartupScriptUpdateResult
    {
        public HttpWebResponse ApiResponse { get; set; }
    }

    public struct StartupScriptResult
    {
        public Dictionary<string, StartupScript> StartupScripts { get; set; }

        public HttpWebResponse ApiResponse { get; set; }
    }

    public class ScriptType
    {
        private readonly string Key;
        public static readonly ScriptType BOOT = new ScriptType("boot");
        public static readonly ScriptType PXE = new ScriptType("pxe");

        private ScriptType(string key)
        {
            Key = key;
        }

        public override string ToString()
        {
            return Key;
        }
    }
}
﻿using System.Collections.Generic;
using System.Net.Http;

namespace Vultr.API.Models
{
    public class StartupScript
    {
        public string SCRIPTID { get; set; }
        public string date_created { get; set; }
        public string date_modified { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string script { get; set; }
    }

    public struct StartupScriptCreateResult
    {
        public StartupScript StartupScript { get; set; }
        public HttpResponseMessage ApiResponse { get; set; }
    }

    public struct StartupScriptResult
    {
        public Dictionary<string, StartupScript> StartupScripts { get; set; }
        public HttpResponseMessage ApiResponse { get; set; }
    }

    public enum ScriptType
    {
        boot,
        pxe
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.WebUI.Configuration
{
    public class AppSettingsOptions
    {
        public string ManifestJsonPath { get; set; }

        public string VersionedScriptPartialView { get; set; }

        public string VersionedStylesPartialView { get; set; }
    }
}

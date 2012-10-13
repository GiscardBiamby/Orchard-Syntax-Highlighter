using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orchard;
using Orchard.UI.Resources;

namespace TheMonarch.SyntaxHighlighter {

    public class ResourceManifest : IResourceManifestProvider {

        #region helpers

        private static string ThemeFolder = @"~/Themes/TheMonarch.SyntaxHighlighter/";
        private static string ModuleFolder = @"~/Modules/TheMonarch.SyntaxHighlighter/";
        private enum ResourceType { Scripts, Styles }
        private enum ResourceLocation { Module, Theme }
        
        private static string ModuleStyle(string path) {
            return GetResourcePath(path, ResourceType.Styles, ResourceLocation.Module);
        }

        private static string ModuleScript(string path) {
            return GetResourcePath(path, ResourceType.Scripts, ResourceLocation.Module);
        }

        private static string GetResourcePath(string path, ResourceType type, ResourceLocation loc) {
            if (path.StartsWith("/")) {
                path = path.Substring(1);
            }
            return string.Format("{0}{1}/{2}"
                , loc == ResourceLocation.Module ? ModuleFolder : ThemeFolder
                , type.ToString()
                , path
            );
        }

        #endregion helpers

        private readonly IOrchardServices _services;

        public ResourceManifest(IOrchardServices services) {
            _services = services;
        }

        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();

            //Styles
            manifest.DefineStyle("TheMonarch.prettify").SetUrl(ModuleStyle("pretty/prettify.css"));
            manifest.DefineStyle("TheMonarch.prettify-tubster").SetUrl(ModuleStyle("pretty/prettify-tomorrow-night.css"));


            // Scripts
            manifest.DefineScript("TheMonarch.prettify").SetUrl(ModuleScript("pretty/prettify.js")).SetDependencies("jQuery");
        }
    }
}

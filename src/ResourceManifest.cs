using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orchard;
using Orchard.UI.Resources;

namespace TheMonarch.bootstrap {

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
            manifest.DefineStyle("TheMonarch.shCore").SetUrl(ModuleStyle("shCore.css"));
            
            manifest.DefineStyle("TheMonarch.shCoreDefault").SetUrl(ModuleStyle("shCoreDefault.css"));
            manifest.DefineStyle("TheMonarch.shCoreDjango").SetUrl(ModuleStyle("shCoreDjango.css"));
            manifest.DefineStyle("TheMonarch.shCoreEclipse").SetUrl(ModuleStyle("shCoreEclipse.css"));
            manifest.DefineStyle("TheMonarch.shCoreEmacs").SetUrl(ModuleStyle("shCoreEmacs.css"));
            manifest.DefineStyle("TheMonarch.shCoreFadeToGrey").SetUrl(ModuleStyle("shCoreFadeToGrey.css"));
            manifest.DefineStyle("TheMonarch.shCoreMDUltra").SetUrl(ModuleStyle("shCoreMDUltra.css"));
            manifest.DefineStyle("TheMonarch.shCoreMidnight").SetUrl(ModuleStyle("shCoreMidnight.css"));
            manifest.DefineStyle("TheMonarch.shCoreRDark").SetUrl(ModuleStyle("shCoreRDark.css"));
            
            manifest.DefineStyle("TheMonarch.shThemeDefault").SetUrl(ModuleStyle("shThemeDefault.css")).SetDependencies("TheMonarch.shCoreDefault");
            manifest.DefineStyle("TheMonarch.shThemeDjango").SetUrl(ModuleStyle("shThemeDjango.css")).SetDependencies("TheMonarch.shCoreDjango");
            manifest.DefineStyle("TheMonarch.shThemeEclipse").SetUrl(ModuleStyle("shThemeEclipse.css")).SetDependencies("TheMonarch.shCoreEclipse");
            manifest.DefineStyle("TheMonarch.shThemeEmacs").SetUrl(ModuleStyle("shThemeEmacs.css")).SetDependencies("TheMonarch.shCoreEmacs");
            manifest.DefineStyle("TheMonarch.shThemeFadeToGrey").SetUrl(ModuleStyle("shThemeFadeToGrey.css")).SetDependencies("TheMonarch.shCoreFadeToGrey");
            manifest.DefineStyle("TheMonarch.shThemeMDUltra").SetUrl(ModuleStyle("shThemeMDUltra.css")).SetDependencies("TheMonarch.shCoreMDUltra");
            manifest.DefineStyle("TheMonarch.shThemeMidnight").SetUrl(ModuleStyle("shThemeMidnight.css")).SetDependencies("TheMonarch.shCoreMidnight");
            manifest.DefineStyle("TheMonarch.shThemeRDark").SetUrl(ModuleStyle("shThemeRDark.css")).SetDependencies("TheMonarch.shCoreRDark");


            // Scripts
            manifest.DefineScript("TheMonarch.shCore").SetUrl(ModuleScript("shCore.js")).SetVersion("3.0.83");
            manifest.DefineScript("TheMonarch.shAutoloader").SetUrl(ModuleScript("shAutoloader.js")).SetVersion("3.0.83").SetDependencies("TheMonarch.shCore");
            manifest.DefineScript("TheMonarch.shBrushAppleScript").SetUrl(ModuleScript("shBrushAppleScript.js")).SetVersion("3.0.83").SetDependencies("TheMonarch.shAutoloader");
            manifest.DefineScript("TheMonarch.shBrushAS3").SetUrl(ModuleScript("shBrushAS3.js")).SetVersion("3.0.83").SetDependencies("TheMonarch.shAutoloader");
            manifest.DefineScript("TheMonarch.shBrushBash").SetUrl(ModuleScript("shBrushBash.js")).SetVersion("3.0.83").SetDependencies("TheMonarch.shAutoloader");
            manifest.DefineScript("TheMonarch.shBrushColdFusion").SetUrl(ModuleScript("shBrushColdFusion.js")).SetVersion("3.0.83").SetDependencies("TheMonarch.shAutoloader");
            manifest.DefineScript("TheMonarch.shBrushCpp").SetUrl(ModuleScript("shBrushCpp.js")).SetVersion("3.0.83").SetDependencies("TheMonarch.shAutoloader");
            manifest.DefineScript("TheMonarch.shBrushCSharp").SetUrl(ModuleScript("shBrushCSharp.js")).SetVersion("3.0.83").SetDependencies("TheMonarch.shAutoloader");
            manifest.DefineScript("TheMonarch.shBrushCss").SetUrl(ModuleScript("shBrushCss.js")).SetVersion("3.0.83").SetDependencies("TheMonarch.shAutoloader");
            manifest.DefineScript("TheMonarch.shBrushDelphi").SetUrl(ModuleScript("shBrushDelphi.js")).SetVersion("3.0.83").SetDependencies("TheMonarch.shAutoloader");
            manifest.DefineScript("TheMonarch.shBrushDiff").SetUrl(ModuleScript("shBrushDiff.js")).SetVersion("3.0.83").SetDependencies("TheMonarch.shAutoloader");
            manifest.DefineScript("TheMonarch.shBrushErlang").SetUrl(ModuleScript("shBrushErlang.js")).SetVersion("3.0.83").SetDependencies("TheMonarch.shAutoloader");
            manifest.DefineScript("TheMonarch.shBrushGroovy").SetUrl(ModuleScript("shBrushGroovy.js")).SetVersion("3.0.83").SetDependencies("TheMonarch.shAutoloader");
            manifest.DefineScript("TheMonarch.shBrushJava").SetUrl(ModuleScript("shBrushJava.js")).SetVersion("3.0.83").SetDependencies("TheMonarch.shAutoloader");
            manifest.DefineScript("TheMonarch.shBrushJavaFX").SetUrl(ModuleScript("shBrushJavaFX.js")).SetVersion("3.0.83").SetDependencies("TheMonarch.shAutoloader");
            manifest.DefineScript("TheMonarch.shBrushJScript").SetUrl(ModuleScript("shBrushJScript.js")).SetVersion("3.0.83").SetDependencies("TheMonarch.shAutoloader");
            manifest.DefineScript("TheMonarch.shBrushPerl").SetUrl(ModuleScript("shBrushPerl.js")).SetVersion("3.0.83").SetDependencies("TheMonarch.shAutoloader");
            manifest.DefineScript("TheMonarch.shBrushPhp").SetUrl(ModuleScript("shBrushPhp.js")).SetVersion("3.0.83").SetDependencies("TheMonarch.shAutoloader");
            manifest.DefineScript("TheMonarch.shBrushPlain").SetUrl(ModuleScript("shBrushPlain.js")).SetVersion("3.0.83").SetDependencies("TheMonarch.shAutoloader");
            manifest.DefineScript("TheMonarch.shBrushPowerShell").SetUrl(ModuleScript("shBrushPowerShell.js")).SetVersion("3.0.83").SetDependencies("TheMonarch.shAutoloader");
            manifest.DefineScript("TheMonarch.shBrushPython").SetUrl(ModuleScript("shBrushPython.js")).SetVersion("3.0.83").SetDependencies("TheMonarch.shAutoloader");
            manifest.DefineScript("TheMonarch.shBrushRuby").SetUrl(ModuleScript("shBrushRuby.js")).SetVersion("3.0.83").SetDependencies("TheMonarch.shAutoloader");
            manifest.DefineScript("TheMonarch.shBrushSass").SetUrl(ModuleScript("shBrushSass.js")).SetVersion("3.0.83").SetDependencies("TheMonarch.shAutoloader");
            manifest.DefineScript("TheMonarch.shBrushScala").SetUrl(ModuleScript("shBrushScala.js")).SetVersion("3.0.83").SetDependencies("TheMonarch.shAutoloader");
            manifest.DefineScript("TheMonarch.shBrushSql").SetUrl(ModuleScript("shBrushSql.js")).SetVersion("3.0.83").SetDependencies("TheMonarch.shAutoloader");
            manifest.DefineScript("TheMonarch.shBrushVb").SetUrl(ModuleScript("shBrushVb.js")).SetVersion("3.0.83").SetDependencies("TheMonarch.shAutoloader");
            manifest.DefineScript("TheMonarch.shBrushXml").SetUrl(ModuleScript("shBrushXml.js")).SetVersion("3.0.83").SetDependencies("TheMonarch.shAutoloader");
            manifest.DefineScript("TheMonarch.shLegacy").SetUrl(ModuleScript("shLegacy.js")).SetVersion("3.0.83").SetDependencies("TheMonarch.shAutoloader");

        }
    }
}

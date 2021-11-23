using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace ERDMaker
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "ERD Schema Generator"),
        ExportMetadata("Description", "Building dbdiagram.io diagrams from dataserve data stracture"),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "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"),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "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"),
        ExportMetadata("BackgroundColor", "Lavender"),
        ExportMetadata("PrimaryFontColor", "Black"),
        ExportMetadata("SecondaryFontColor", "Gray")]
    public class MyPlugin : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new MainControl();
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public MyPlugin()
        {
            // If you have external assemblies that you need to load, uncomment the following to 
            // hook into the event that will fire when an Assembly fails to resolve
            // AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}
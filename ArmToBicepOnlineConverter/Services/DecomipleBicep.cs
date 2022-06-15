using ArmToBicepOnlineConverter.Utility;
using Bicep.Core.FileSystem;
using Bicep.Core.Registry;
using Bicep.Decompiler;
using System.Text.RegularExpressions;

namespace ArmToBicepOnlineConverter.Services
{
    public static class DecomipleArm
    {
      

        public static string Decompile(string template)
        {
            try
            {
                // replace newlines with the style passed in
                template = string.Join(" ", Regex.Split(template, "\r?\n"));

                var fileUri = new Uri("file:///path/to/main.json");
                var fileResolver = new InMemoryFileResolver(new Dictionary<Uri, string>
                {
                    [fileUri] = template,
                }); ;

                var decompiler = new TemplateDecompiler(BicepTestConstants.Features, TestTypeHelper.CreateEmptyProvider(), fileResolver, new DefaultModuleRegistryProvider(fileResolver, BicepTestConstants.ClientFactory, BicepTestConstants.TemplateSpecRepositoryFactory, BicepTestConstants.Features), BicepTestConstants.ConfigurationManager);
                var (entryPointUri, filesToSave) = decompiler.DecompileFileWithModules(fileUri, PathHelper.ChangeToBicepExtension(fileUri));

                return filesToSave[entryPointUri];
            }
            catch
            {
                return "No valid input";
            }

            

        } 
    }
}

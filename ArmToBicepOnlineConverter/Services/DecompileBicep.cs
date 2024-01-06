using Bicep.Decompiler;

namespace ArmToBicepOnlineConverter.Services
{
    public class DecompileArm(BicepDecompiler bicepDecompiler)
    {

        public async Task<string> Decompile(string template)
        { 
            if(String.IsNullOrWhiteSpace(template))
            {
                return "";
            }

            try
            {
                var decompilation = await bicepDecompiler.Decompile(new Uri("file:///main.bicep"), template);
             
                return decompilation.FilesToSave.First().Value;
            }
            catch(Exception ex)
            {
                return "No valid input, " + ex.Message + ex.StackTrace + ex.Source + (ex?.InnerException?.ToString());
            }

            

        } 
    }
}

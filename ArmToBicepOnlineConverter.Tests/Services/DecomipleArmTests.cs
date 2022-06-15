using ArmToBicepOnlineConverter.Services;

namespace ArmToBicepOnlineConverter.Tests
{
    [TestClass]
    public class DecomipleBicepTests
    {
        [TestMethod]
        public void Empty()
        {
            Assert.AreEqual("No valid input", DecomipleArm.Decompile(""));

        }

        [TestMethod]
        public void Trash()
        {
            Assert.AreEqual("No valid input", DecomipleArm.Decompile("#$%^&*"));

        }

        [TestMethod]
        public void Default()
        {
            var result = DecomipleArm.Decompile(Constants.ExampleInput);
            Assert.IsTrue(result.Contains("resource storageAccountName_resource 'Microsoft.Storage/storageAccounts@2021-06-01' = {"));
        }
    }
}
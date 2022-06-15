using ArmToBicepOnlineConverter.Services;

namespace ArmToBicepOnlineConverter.Tests
{
    [TestClass]
    public class DecomipleBicepTests
    {
        [TestMethod]
        public void Empty()
        {
            Assert.AreEqual("", DecomipleArm.Decompile(""));

        }

        [TestMethod]
        public void Trash()
        {
            Assert.IsTrue(DecomipleArm.Decompile("#$%^&*").Contains("No valid input"));

        }

        [TestMethod]
        public void Default()
        {
            var result = DecomipleArm.Decompile(Constants.ExampleInput);
            Assert.IsTrue(result.Contains("resource storageAccountName_resource 'Microsoft.Storage/storageAccounts@2021-06-01' = {"));
        }
    }
}
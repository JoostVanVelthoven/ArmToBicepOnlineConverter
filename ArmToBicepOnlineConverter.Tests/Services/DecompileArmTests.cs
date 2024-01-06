using ArmToBicepOnlineConverter.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ArmToBicepOnlineConverter.Tests
{
    [TestClass]
    public class DecomipleBicepTests
    {
        [TestMethod]
        public async Task Empty()
        {
            var service = CreateService();

            Assert.AreEqual("", await service.Decompile(""));

        }

        [TestMethod]
        public async Task Trash()
        {
            var service = CreateService();

            var result = await service.Decompile("#$%^&*");

            Assert.IsTrue(result.Contains("No valid input"));

        }

        [TestMethod]
        public async Task Default()
        {
            var service = CreateService();

            var result = await service.Decompile(Constants.ExampleInput);
            Assert.IsTrue(
                result.Contains(
                    "resource storageAccountName_default_container 'Microsoft.Storage"
                )
            );
        }

        private static DecompileArm CreateService()
        {
            var serviceProvider = new ServiceCollection().AddBicepCore().BuildServiceProvider();

            var service = serviceProvider.GetRequiredService<DecompileArm>();
            return service;
        }
    }
}

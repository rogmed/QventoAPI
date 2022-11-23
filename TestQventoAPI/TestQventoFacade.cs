using QventoAPI;

namespace TestQventoAPI
{

    [TestClass]
    public class TestQventoFacade
    {
        QventoFacade facade = new QventoFacade();

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            var task = Vault.GetConnectionString();
            task.Wait();
        }

        [TestMethod]
        public void Get()
        {
            var qvento = facade.Get(100);

            Assert.IsNotNull(qvento);

            Assert.AreEqual(100, qvento.QventoId);
        }
    }
}

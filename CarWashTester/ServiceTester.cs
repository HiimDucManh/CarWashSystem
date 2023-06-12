using CarWashManagementSystem.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarWashTester
{
    [TestClass]
    public class ServiceTester
    {
        private ServiceRepository repository { get; set; }

        [TestInitialize]
        public void Init()
        {
            repository = new ServiceRepository();
        }
        [TestMethod]
        public void AddSuccess()
        {
            var res = repository.AddService("Spray", "100000000");
            Assert.AreEqual(res, "Success");
        }
        [TestMethod]
        public void AddFailureByEmptyName()
        {
            var res = repository.AddService("", "100000000");
            Assert.AreEqual(res, "Success");
        }
        [TestMethod]
        public void AddFailureByInvalidInput()
        {
            var res = repository.AddService("Spray", "-1");
            Assert.AreEqual(res, "invalidprice");
        }
        [TestMethod]
        public void AddFailureByInvalidAndEmptyInput()
        {
            var res = repository.AddService("", "-1");
            Assert.AreEqual(res, "invalidprice");
        }
        [TestMethod]
        public void AddFailureByEmptyNameAndEmptyPrice()
        {
            var res = repository.AddService("", "");
            Assert.AreEqual(res, "emptyfield");
        }
        [TestMethod]
        public void AddException()
        {
            var res = repository.AddService("Spray", "anvisekd");
            Assert.AreEqual(res, "exception");
        }
    }
}

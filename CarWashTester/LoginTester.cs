using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarWashTester
{
    [TestClass]
    public class LoginTester
    {
        private dbConnect dn;

        [TestInitialize]
        public void Init()
        {
            dn = new dbConnect();
        }

        [TestMethod]
        public void Fail()
        {
            Assert.AreEqual(dn.Query("SELECT name FROM tbEmployer WHERE name ='hahaha' AND password ='hihihi'"), 1);
        }

        [TestMethod]
        public void ManagerSucess()
        {
            Assert.AreEqual(dn.Query("SELECT * FROM tbEmployer WHERE name ='mdemy' AND password ='mdemy' AND role = 'Manager'"), 1);
        }

        [TestMethod]
        public void CashierSuccess()
        {
            Assert.AreEqual(dn.Query("SELECT * FROM tbEmployer WHERE name ='nayoo' AND password ='nayoo' AND role ='Cashier' "), 1);
        }
    }
}

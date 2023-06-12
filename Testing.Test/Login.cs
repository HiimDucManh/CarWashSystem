using NUnit.Framework;
using CarWashManagementSystem;
using System.Data.SqlClient;
using CarWashTester.Test;

namespace Testing.Test
{
    [TestFixture]
    public class Login
    {

        private DBConnection db;

        [SetUp]
        public void Setup()
        {
            db = new DBConnection();
        }
        [Test]
        public void Fail()
        {
            Assert.AreEqual(db.Query("SELECT name FROM tbEmployer WHERE name ='hahaha' AND password ='hihihi'"),1);
        }
        [Test]
        public void ManagerSucess()
        {
            Assert.AreEqual(db.Query("SELECT name FROM tbEmployer WHERE name ='mdemy' AND password ='mdemy' AND role = 'Manager'"), 0);
        }
        [Test]
        public void CashierSuccess()
        {
            Assert.AreEqual(db.Query("SELECT name FROM tbEmployer WHERE name ='nayoo' AND password ='nayoo' AND role ='Cashier' "), 0);
        }
    }
}
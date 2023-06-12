using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CarWashManagementSystem;
using System.Data.SqlClient;
using CarWashManagementSystem.Repositories;
namespace Testing.Test
{
    [TestFixture]
    public class Customer
    {
        CustomerRepository repository = new CustomerRepository();
        
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void AddSuccess()
        {
            var result = repository.AddCustomer("2", "An", "0797043481", "88", "hihi", "adefsdfs", "10");
            Assert.AreEqual(result, "Success");
        }
        [Test]
        public void AddFail()
        {
            var result = repository.AddCustomer("", "", "", "", "", "", "");
            Assert.AreEqual(result, "emptyfield");
        }

    }
}

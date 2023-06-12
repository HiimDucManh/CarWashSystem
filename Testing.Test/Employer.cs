using CarWashManagementSystem;
using CarWashManagementSystem.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Testing.Test
{
    public class Employer
    {
        EmployerRepository repository = new EmployerRepository();

        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void AddSuccess()
        {
            var result = repository.AddEmployer("vdmanh", "012321421", "HCM", DateTime.Parse("01/03/2002"), "Male", "Manager", "10000000", "123456");
            Assert.AreEqual(result, "Success");
        }
        [Test]
        public void AddFail()
        {
            var result = repository.AddEmployer("", "012321421", "HCM", new DateTime(01 / 03 / 2002), "", "", "", "123456"); 
            Assert.AreEqual(result, "emptyfield");
        }
        [Test]
        public void AddNotEnoughOld()
        {
            var result = repository.AddEmployer("vdmanh", "012321421", "HCM", DateTime.Parse("01/03/2012"), "Male", "Manager", "10000000", "123456"); 
            Assert.AreEqual(result, "notenoughage");
        }

    }
}

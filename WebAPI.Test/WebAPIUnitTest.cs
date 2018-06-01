using System;
using NUnit.Framework;
using System.Net.Http;
using LearningAPI.DataLogic;
using LearningAPI.Models;
using Microsoft.EntityFrameworkCore;
using WebAPIEFCore.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using static WebAPIEFCore.Models.IOCContainer;

namespace WebAPI.Test
{

    public static class InitialTest
        {
        public static InMemoryContext SeedDatabaseFourEmployees()
        {
            InMemoryContext Context = (InMemoryContext)IOCContainer.GetReqDBContext("memory");
            Context.Employees.AddRange(CreateFourBooks());
            Context.SaveChanges();
            return Context;
        }
        public static List<Employees> CreateFourBooks()
        {
            var employees = new List<Employees>();

            var employee1 = new Employees{ Id = 1, FirstName="Testa",LastName="TestaLName",ManagerID=1,
                    LeaveDate=DateTime.Now,Salary=200};
            employees.Add(employee1);
            var employee2 = new Employees{ Id = 1, FirstName="Testa",LastName="TestaLName",ManagerID=1,
                    LeaveDate=DateTime.Now,Salary=200};
            employees.Add(employee2);
            var employee3 = new Employees{ Id = 1, FirstName="Testa",LastName="TestaLName",ManagerID=1,
                    LeaveDate=DateTime.Now,Salary=200};
            employees.Add(employee3);
            var employee4 = new Employees{ Id = 1, FirstName="Testa",LastName="TestaLName",ManagerID=1,
                    LeaveDate=DateTime.Now,Salary=200};
            employees.Add(employee4);

            return employees;
        }
    }
    [TestFixture]
    public class WebAPIUnitTest
    {
        private IDAWebAPIEFCore<Employees, int> _iRepo;
        [SetUp]
        public void CreateContext()
        {
            IEmployeeContext context=InitialTest.SeedDatabaseFourEmployees();
            
            _iRepo = repo;

        }


       
        [Test]
        public void CanReturnAllEmployees()
        {

            var context = objWebAPIUnitTest.CreateInMemoryDB("EmployeesDB");
            var service = new EmployeeService(context);
            var result = service.Get(2);
            Assert.AreEqual("Testb", result.FirstName);
        }


        [Test]
        public void CanReturnEmployeebyId()
        {


            var context = objWebAPIUnitTest.CreateInMemoryDB("EmployeesDB");
            var service = new EmployeeService(context);
            var result = service.Get(2);
            Assert.AreEqual("Testb", result.FirstName);

        }

        [Test]
        public void CanInsertEmployee()
        {
            int Result;
            Employees newEmployee = new Employees
            {
                Id = 4,
                FirstName = "Testd",
                LastName = "TestdLName",
                ManagerID = 1,
                LeaveDate = DateTime.Now,
                Salary = 900
            };
            WebAPIUnitTest objWebAPIUnitTest = new WebAPIUnitTest();

            var context = objWebAPIUnitTest.CreateInMemoryDB("EmployeesDB");
            var service = new EmployeeService(context);
            Result = service.Add(newEmployee);
            Assert.IsNotNull(newEmployee);
            var result = service.GetAll();
            Assert.AreEqual(4, result.Count());
        }

        [Test]
        public void CanUpdateEmployee()
        {
            int intResult;
            Employees newEmployee = new Employees
            {
                Id = 2,
                FirstName = "NewTestFName",
                LastName = "NewTestLName",
                ManagerID = 1,
                LeaveDate = DateTime.Now.AddDays(-1),
                Salary = 450
            };
            WebAPIUnitTest objWebAPIUnitTest = new WebAPIUnitTest();

            var context = objWebAPIUnitTest.CreateInMemoryDB("EmployeesDB");
            var service = new EmployeeService(context);
            intResult = service.Update(2, newEmployee);
            var empresult = service.Get(2);
            Assert.AreEqual(empresult.FirstName, newEmployee.FirstName);
            Assert.AreEqual(empresult.LastName, newEmployee.LastName);
            Assert.AreEqual(empresult.ManagerID, newEmployee.ManagerID);
            Assert.AreEqual(empresult.LeaveDate, newEmployee.LeaveDate);
            Assert.AreEqual(empresult.Salary, newEmployee.Salary);
            Assert.AreNotEqual(intResult, 0);
        }

        [Test]
        public void CandeleteEmployee()
        {
            WebAPIUnitTest objWebAPIUnitTest = new WebAPIUnitTest();

            var context = objWebAPIUnitTest.CreateInMemoryDB("EmployeesDB");
            var service = new EmployeeService(context);
            var id = service.Delete(2);
            var result = service.GetAll();
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public void CanUpdateLeaveDate()
        {
            int rowupdated;
            WebAPIUnitTest objWebAPIUnitTest = new WebAPIUnitTest();

            var context = objWebAPIUnitTest.CreateInMemoryDB("EmployeesDB");
            var service = new EmployeeService(context);
            rowupdated = service.UpdateLeaveDate(3, DateTime.Now.AddDays(-3));
            var result = service.Get(3);
            Assert.AreEqual(DateTime.Now.AddDays(-3).Date, result.LeaveDate.Date);
        }

        [Test]
        public void CanUpdateSalary()
        {
            int rowupdated;
            WebAPIUnitTest objWebAPIUnitTest = new WebAPIUnitTest();

            var context = objWebAPIUnitTest.CreateInMemoryDB("EmployeesDB");
            var service = new EmployeeService(context);
            rowupdated = service.UpdateSalary(3, 600);
            var result = service.Get(3);
            Assert.AreEqual(600, result.Salary);
        }

        [Test]
        public void CanReturnEmployeebyName()
        {
            WebAPIUnitTest objWebAPIUnitTest = new WebAPIUnitTest();

            var context = objWebAPIUnitTest.CreateInMemoryDB("EmployeesDB");
            var service = new EmployeeService(context);
            var result = service.GetEmployeesbyName("Testc");
            Assert.AreEqual("Testc", result.FirstName);

        }
    }
}






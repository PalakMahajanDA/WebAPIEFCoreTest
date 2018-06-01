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


namespace WebAPI.Test
{



    [TestFixture]
    public class WebAPIUnitTest
    {
        EmployeeContext context;
        EmployeeService service;
        //EmployeeContext context;
        public EmployeeContext CreateInMemoryDB()
        {
            var options = new DbContextOptionsBuilder<EmployeeContext>()
                .UseInMemoryDatabase(databaseName: "EmployeesDB")
                .Options;

            var context = new EmployeeContext(options);
            context.Employees.AddRange(CreateFourEmployees());
                

            context.SaveChanges();
            return context;
        }

        public IEnumerable<Employees> CreateFourEmployees()
        {
            IEnumerable<Employees> employees = new List<Employees>();

            var employee1 = new Employees
            {
                Id = 1,
                FirstName = "Testa",
                LastName = "TestaLName",
                ManagerID = 1,
                LeaveDate = DateTime.Now,
                Salary = 200
            };
            employees = employees.Append(employee1);
            var employee2 = new Employees
            {
                Id = 2,
                FirstName = "Testb",
                LastName = "TestbLName",
                ManagerID = 2,
                LeaveDate = DateTime.Now,
                Salary = 200
            };
            employees = employees.Append(employee2);
            var employee3 = new Employees
            {
                Id = 3,
                FirstName = "Tesc",
                LastName = "TestcLName",
                ManagerID = 2,
                LeaveDate = DateTime.Now,
                Salary = 200
            };
            employees = employees.Append(employee3);
            var employee4 = new Employees
            {
                Id = 4,
                FirstName = "Testd",
                LastName = "TestdLName",
                ManagerID = 1,
                LeaveDate = DateTime.Now,
                Salary = 200
            };
            employees = employees.Append(employee4);

            return employees;
        }

        
     [SetUp]
        public void CreateContext()
        {
            context = CreateInMemoryDB();
            service = new EmployeeService(context);
        }


       
        [Test]
        public void CanReturnAllEmployees()
        {
   
            var result = service.GetAll();
            Assert.AreEqual(context.Employees.Count(), result.Count());
        }


        [Test]
        public void CanReturnEmployeebyId()
        {
            
            var result = service.Get(2);
            Assert.AreEqual("Testb", result.FirstName);

        }

        [Test]
        public void CanInsertEmployee()
        {
            int? Result;
            EmployeeContext context = CreateInMemoryDB();
            Employees newEmployee = new Employees
            {
                Id = 5,
                FirstName = "Teste",
                LastName = "TesteLName",
                ManagerID = 1,
                LeaveDate = DateTime.Now,
                Salary = 900
            };
            WebAPIUnitTest objWebAPIUnitTest = new WebAPIUnitTest();

            var service = new EmployeeService(context);
            Result = service.Add(newEmployee);
            Assert.IsNotNull(newEmployee);
            var result = service.GetAll();
            Assert.AreEqual(5, result.Count());
        }

        [Test]
        public void CanUpdateEmployee()
        {
            EmployeeContext context = CreateInMemoryDB();
            int? intResult;
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
            EmployeeContext context = CreateInMemoryDB();


            var service = new EmployeeService(context);
            var id = service.Delete(2);
            var result = service.GetAll();
            Assert.AreEqual(3, result.Count());
        }

        [Test]
        public void CanUpdateLeaveDate()
        {
            int? rowupdated;
            EmployeeContext context = CreateInMemoryDB();


            var service = new EmployeeService(context);
            rowupdated = service.UpdateLeaveDate(3, DateTime.Now.AddDays(-3));
            var result = service.Get(3);
            Assert.AreEqual(DateTime.Now.AddDays(-3).Date, result.LeaveDate.Date);
        }

        [Test]
        public void CanUpdateSalary()
        {
            int? rowupdated;
            EmployeeContext context = CreateInMemoryDB();


            var service = new EmployeeService(context);
            rowupdated = service.UpdateSalary(3, 600);
            var result = service.Get(3);
            Assert.AreEqual(600, result.Salary);
        }

        [Test]
        public void CanReturnEmployeebyName()
        {
            EmployeeContext context = CreateInMemoryDB();


            var service = new EmployeeService(context);
            var result = service.GetEmployeesbyName("Testb");
            Assert.AreEqual("Testb", result.FirstName);

        }
    }
}






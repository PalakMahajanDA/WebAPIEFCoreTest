using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIEFCore.Models;
using LearningAPI.DataLogic;
using LearningAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace WebAPIEFCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Employees/[Action]")]
    public class EmployeesController : Controller
    {

        private IDAWebAPIEFCore<Employees, int> _iRepo;

        public EmployeesController(IDAWebAPIEFCore<Employees, int> repo)
        {
            _iRepo = repo;
        }

        /// <summary>
        /// This will get All Employees
        /// </summary>
        /// <returns></returns>
        // GET: api/Employees
        [HttpGet]
        public IEnumerable<Employees> GetEmployees()
        {
            return _iRepo.GetAll();
        }

        /// <summary>
        /// This will get Employee of specific id
        /// </summary>
        /// <param name="id">Please provide Employee ID</param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet("{id}")]
        public Employees Get([Required]int id)
        {
            return _iRepo.Get(id);
        }

        // POST api/values
        /// <summary>
        /// This will add new Employee
        /// </summary>
        /// <param name="employees"> Spouse Name is mandatory if Married</param>
        [HttpPost]
        public void Post([FromBody]Employees employees)
        {
            _iRepo.Add(employees);
        }
        /// <summary>
        /// update employee
        /// </summary>
        /// <param name="employees"></param>
        // POST api/values
        [HttpPut]
        public void Put([FromBody]Employees employees)
        {
            _iRepo.Update(employees.Id, employees);
        }
        /// <summary>
        /// delete employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _iRepo.Delete(id);
        }
        /// <summary>
        /// update Leave Date
        /// </summary>
        /// <param name="id"></param>
        /// <param name="leaveDate"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public int UpdateLeaveDate([FromBody]int id, DateTime leaveDate)
        {
            return _iRepo.UpdateLeaveDate(id, leaveDate);
        }

        /// <summary>
        /// Update Salary
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="Salary">Salary</param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public int UpdateSalary([FromBody]int id, decimal Salary)
        {
            return _iRepo.UpdateSalary(id, Salary);
        }


        // GET api/values/5
        [HttpGet("{Name}")]
        public Employees GetEmployeesbyName(string name)
        {
            return _iRepo.GetEmployeesbyName(name);
        }
    }
}


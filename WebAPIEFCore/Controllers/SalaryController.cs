using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIEFCore.Models;

namespace WebAPIEFCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Employees/[Action]")]
    public class SalaryController : Controller
    {
        private readonly WebAPIEFCoreContext _context;

        public SalaryController(WebAPIEFCoreContext context)
        {
            _context = context;
        }
             
        private Employees Getdetails (int id)
        {
        

            var employees =  _context.Employees.FirstOrDefault(m => m.Id == id);

           

            return employees;
        }

        // GET: api/SearchEmployees/test
        [HttpPatch("{id}")]
        [ActionName("UpdateSalary")]
        public async Task<IActionResult> UpdateSalary([FromRoute] int id, [FromBody] Decimal Salary)
        {
            Employees objemployees = new Employees();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
               
            //if (id != employees.Id)
            //{hfdskjhfk
            //    return BadRequest();
            //}
            objemployees = Getdetails(id);
            objemployees.Salary = Salary;
            _context.Entry(objemployees).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool EmployeesExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }

    }
}
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
    [Route("api/Employees")]
    public class SalaryController : Controller
    {
        private readonly WebAPIEFCoreContext _context;

        public SalaryController(WebAPIEFCoreContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public IEnumerable<Employees> GetEmployees()
        {
            return _context.Employees;
        }

        // PUT: api/Employees/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PutEmployees([FromRoute] int id, [FromBody] Employees employees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employees.Id)
            {
                return BadRequest();
            }

            _context.Entry(employees.).State = EntityState.Modified;

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
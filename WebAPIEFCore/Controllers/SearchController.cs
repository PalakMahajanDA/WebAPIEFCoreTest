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
    public class SearchController : Controller
    {
        private readonly WebAPIEFCoreContext _context;

        //public EmployeesController(WebAPIEFCoreContext context)
        //{
        //    //_context = context;
        //}

     
        // GET: api/SearchEmployees/test
        [HttpGet("{Name}")]
        [ActionName("SearchEmployees")]
        public async Task<IActionResult>SearchEmployees([FromRoute] string Name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employees = await _context.Employees.SingleOrDefaultAsync(m => (Name.Contains(m.FirstName)|| Name.Contains(m.LastName)));

            if (employees == null)
            {
                return NotFound();
            }

            return Ok(employees);
        }  

     }  
}
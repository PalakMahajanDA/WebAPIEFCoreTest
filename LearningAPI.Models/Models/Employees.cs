using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIEFCore.Models
{
    public class Employees
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ManagerID { get; set; }

        public Decimal Salary { get; set; }

        public DateTime LeaveDate { get; set; }
    }
}

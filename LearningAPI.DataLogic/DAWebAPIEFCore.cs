using System;
using System.Collections.Generic;
using System.Text;
using LearningAPI.Models;
using WebAPIEFCore.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LearningAPI.DataLogic
{
    public class EmployeeService : IDAWebAPIEFCore<Employees, int>
    {
        private EmployeeContext ctx;
        public EmployeeService(EmployeeContext c)
        {
            ctx = c;
            
        }

        public Employees Get(int id)
        {
            var employees = ctx.Employees.FirstOrDefault(b => b.Id == id);
            return employees;
        }

        public IEnumerable<Employees> GetAll()
        {
            var employees = ctx.Employees.ToList();
            return employees;
        }

        public int Add(Employees employees)
        {
            ctx.Employees.Add(employees);
            int employeeid = ctx.SaveChanges();
            return employeeid;
        }

        public int Delete(int id)
        {
            int employeeId = 0;
            var employees = ctx.Employees.FirstOrDefault(b => b.Id == id);
            if (employees != null)
            {
                ctx.Employees.Remove(employees);
                employeeId = ctx.SaveChanges();
            }
            return employeeId;
        }

        public int Update(int id, Employees item)
        {
            int employeeId = 0;
            var employees = ctx.Employees.Find(id);
            if (employees != null)
            {
                employees.FirstName = item.FirstName;
                employees.LastName = item.LastName;
                employees.LeaveDate = item.LeaveDate;
                employees.ManagerID = item.ManagerID;
                employees.Salary = item.Salary;


               employeeId = ctx.SaveChanges();
            }
            return employeeId;
        }

        public int UpdateLeaveDate(int id, DateTime LeaveDate)
        {
            int employeeId = 0;
            var employees = ctx.Employees.Find(id);
            if (employees != null)
            {
                employees.LeaveDate = LeaveDate;
                employeeId = ctx.SaveChanges();
            }
            return employeeId;
        }

        public int UpdateSalary(int id, decimal Salary)
        {
            int employeeId = 0;
            var employees = ctx.Employees.Find(id);
            if (employees != null)
            {
                employees.Salary = Salary;
                employeeId = ctx.SaveChanges();
            }
            return employeeId;
        }

        public Employees GetEmployeesbyName(string Name)
        {
            var employees = ctx.Employees.FirstOrDefault(m => (Name.Contains(m.FirstName) || Name.Contains(m.LastName)));
            return employees;
        }
    }

}

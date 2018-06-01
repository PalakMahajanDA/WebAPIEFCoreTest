//using Queries.Core.Domain;
//using Queries.Persistence.EntityConfigurations;
using LearningAPI.Models;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;

namespace WebAPIEFCore.Models
{
    public class EmployeeContext : DbContext
    {

        public EmployeeContext(DbContextOptions opts) : base(opts)
        {
        }
        public DbSet<Employees> Employees { get; set; }
    }
}

using LearningAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPIEFCore.Models
{
    public interface IEmployeeContext
    {
        DbSet<Employees> Employees { get; set; }
    }
}
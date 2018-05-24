using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAPIEFCore.Models
{
    public class WebAPIEFCoreContext : DbContext
    {
        public WebAPIEFCoreContext (DbContextOptions<WebAPIEFCoreContext> options)
            : base(options)
        {
        }

        public DbSet<WebAPIEFCore.Models.Employees> Employees { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using LearningAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAPIEFCore;
using WebAPIEFCore.Models;

namespace WebAPI.Test
{
    public class TestStartup : Startup
    {
        public IConfiguration Configuration { get; set; }
        public void ConfigureTestServices(IServiceCollection services)
        {
            //base.ConfigureServices(services);
            //var options = new DbContextOptionsBuilder<EmployeeContext>()
            // .UseInMemoryDatabase(databaseName: Databasename)
            // .Options;

            services.AddDbContext<EmployeeContext>(opt => opt.UseInMemoryDatabase("TestAPIDB", null));
        }

        public new void  Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var context = app.ApplicationServices.GetService<EmployeeContext>();
            //AddTestData(context);
        }
     
    }
}

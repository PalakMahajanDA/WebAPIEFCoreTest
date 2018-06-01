using System;
using System.Collections.Generic;
using System.Text;

namespace LearningAPI.Models
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            HttpConfiguration configuration1 = new HttpConfiguration();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EmployeeContext>(options => options.UseSqlServer(Configuration.GetConnectionString("WebAPIEFCoreContext"), b => b.MigrationsAssembly("WebAPIEFCore")));
            services.AddScoped(typeof(IDAWebAPIEFCore<Employees, int>), typeof(EmployeeService));
            //services.AddMvc(o =>
            //{  o.AllowEmptyInputInBodyModelBinding = true;
            //});
            services.AddMvc();
            services.AddMvcCore();

            services.AddMvcCore().AddApiExplorer();
            //services.AddSingleton(typeof(MvcHtmlHelpers));
            services.AddScoped(typeof(Employees));
            //services.<WebAPIEFCoreContext zxas>();



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Learning WebApi", Version = "v1" });
                //var xmlpath = System.AppDomain.CurrentDomain.BaseDirectory + @"WebAPIEFCore.xml";
                //c.IncludeXmlComments(xmlpath);
                c.IncludeXmlComments(string.Format("{0}\\WebAPIEFCore.XML",
                System.AppDomain.CurrentDomain.BaseDirectory));
                c.DescribeAllEnumsAsStrings();
                c.DescribeAllParametersInCamelCase();

            });
            //services.AddSingleton(typeof(MvcHtmlHelpers));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            };


            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Learning WebApi");
            });
            app.UseMvc();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TestCore.Model;

namespace TestCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //var connection = "data source=MyData;initial catalog=ContosoUniversity1;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            //var connection = "Data Source=.;Integrated Security=True";
            var connection = @"Data Source=(LocalDb)\MSSQLLocalDb;initial catalog=SchoolDatabase;Integrated Security=True";
            //var connection = "Server=(localdb)\\mssqllocaldb;Database=TestToli2;Trusted_Connection=True;MultipleActiveResultSets=true";
            services.AddDbContext<SchoolContext>(op => op.UseSqlServer(connection));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}

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
using Swashbuckle.AspNetCore.Swagger;
using TestCore.Dto;

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
            services.AddSwaggerGen(x => x.SwaggerDoc("v1", new Info { Title = "Core Api", Description = "Swagger Core API" }));
            var perosnalConfig =Configuration["PersonalSql"];
            //Configuration.Configure<TTemplate>(perosnalConfig);

            var connection = @"Data Source=(LocalDb)\MSSQLLocalDb;initial catalog=SchoolDatabase;Integrated Security=True";
            services.AddDbContext<SchoolContext>(op => op.UseSqlServer(connection));
            services.AddMvc();

            services.AddSingleton<IDtoMapper, DtoMapper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json","Core API");
                //c.SwaggerEndpoint("/swagger/vi/swagger.json", "Core API");
            });
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DACKSearch.Domain.Entities;
using DACKSearch.Domain.Mappers;
using DACKSearch.Domain.Repositories;
using DACKSearch.Domain.Services;
using DACKSearch.Infrastructure;
using Microsoft.EntityFrameworkCore;
using DACKSearch.Infrastructure.Repositories;

namespace DACKSearch.API
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
            services.AddDbContext<DackDbContext>(contextOptions=> { 
                // Best to put it in the config file but this is just a demo so I put it in here.
                contextOptions.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=DACK;Trusted_Connection=True;");
            });

            services.AddScoped<IRepository<EmployeeSearch>, EmployeeRepository>();
            services.AddSingleton<IEmployeeMapper, EmployeeMapper>();
            services.AddScoped<IEmployeeSearchService, EmployeeSearchService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

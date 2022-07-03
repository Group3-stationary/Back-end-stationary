using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using StationaryServer2.Models.Stationary;
using StationaryServer2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StationaryServer2
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
            services.AddDbContext<StationeryContext>(options => options.UseSqlServer(Configuration.GetConnectionString("StationeryCon")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StationaryServer2", Version = "v1" });
            });
            //services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
            //            services.AddScoped(typeof(IEmployeeRepository), typeof(EmployeeRepository));
            //            services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));
            //            services.AddScoped(typeof(IPermissionRepository), typeof(PermissionRepository));
            //            services.AddScoped(typeof(IRoleRepository), typeof(RoleRepository));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StationaryServer2 v1"));
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
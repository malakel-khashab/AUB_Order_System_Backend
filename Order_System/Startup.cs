using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Order_System.DAL;
using Order_System.Generic_repository;
using Order_System.Interfaces;
using Order_System.Repository;
using OrderSystem_BLL.Services;
using OrderSystem_DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_System
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string allowSpecificOrigins = "_allowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddCors(options =>

            { options.AddPolicy(allowSpecificOrigins,
                builder =>
                {builder.WithOrigins("https://localhost:44325/api", "http://localhost:4200").AllowAnyHeader().AllowAnyMethod();

                });

            });

            services.AddDbContext<Order_System_Context>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository_Class<>));
            services.AddTransient<ICustomerRepo, Customer_RepoClass>();
            services.AddTransient<IProductRepo, ProductService>();
            services.AddTransient<IOrderRepo, Order_RepoClass>();
            services.AddTransient<IOrderProductRepo, OrderProduct_RepoClass>();
            services.AddTransient<ICartRepo, Cart_RepoClass>();
            services.AddTransient<IUnitOfWork, UnitOfWork_Class>();

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

            app.UseCors(allowSpecificOrigins);


            app.UseHttpsRedirection();
            //add it here
            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }
    }
}

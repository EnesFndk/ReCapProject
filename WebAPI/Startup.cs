using Business.Abstract;
using Business.Contrete;
using DataAccess.Abstract;
using DataAccess.Contrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
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
            services.AddControllers();

            services.AddSingleton<ICarManager, CarManager>();
            services.AddSingleton<ICarDal, EfCarDal>();
            services.AddSingleton<IBrandManager, BrandManager>();
            services.AddSingleton<IBrandDal, EfBrandDal>();
            services.AddSingleton<IColorManager, ColorManager>();
            services.AddSingleton<IColorDal, EfColorDal>();
            services.AddSingleton<IUserManager, UserManager>();
            services.AddSingleton<IUserDal, EfUserDal>();
            services.AddSingleton<ICustomerManager, CustomerManager>();
            services.AddSingleton<ICustomerDal, EfCustomerDal>();
            services.AddSingleton<IRentalManager, RentalManager>();
            services.AddSingleton<IRentalDal, EfRentalDal>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

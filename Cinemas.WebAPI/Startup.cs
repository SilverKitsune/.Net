using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cinemas.BLL.Contracts;
using Cinemas.BLL.Implementation;
using Cinemas.DataAccess.Context;
using Cinemas.DataAccess.Contracts;
using Cinemas.DataAccess.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cinemas.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            //BLL
            services.Add(new ServiceDescriptor(typeof(ICinemaCreateService),typeof(CinemaCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ICinemaGetService),typeof(CinemaGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ICinemaUpdateService),typeof(CinemaUpdateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IMovieCreateService),typeof(MovieCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IMovieGetService),typeof(MovieGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IMovieUpdateService),typeof(MovieUpdateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IScreeningCreateService),typeof(ScreeningCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IScreeningGetService),typeof(ScreeningGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IScreeningUpdateService),typeof(ScreeningUpdateService), ServiceLifetime.Scoped));
            
            //DataAccess
            services.Add(new ServiceDescriptor(typeof(ICinemaDataAccess), typeof(CinemaDataAccess), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IMovieDataAccess), typeof(MovieDataAccess), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IScreeningDataAccess), typeof(ScreeningDataAccess), ServiceLifetime.Transient));
            
            //DB Contexts
            services.AddDbContext<CinemaContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("Cinemas")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<CinemaContext>();
                context.Database.EnsureCreated(); 
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
using LeagueSimulator.Core.IRepositories;
using LeagueSimulator.Core.IRepository;
using LeagueSimulator.Core.IServices;
using LeagueSimulator.Core.IUnitOfWorks;
using LeagueSimulator.Data;
using LeagueSimulator.Data.Repositories;
using LeagueSimulator.Data.Repository;
using LeagueSimulator.Data.UnitOfWorksBase;
using LeagueSimulator.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using LeagueSimulator.Data.DTOs.Validator;
using LeagueSimulator.MS.Filters;

namespace LeagueSimulator.MS
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
            services.AddControllersWithViews(o => o.Filters.Add(new ValidationFilter())).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<AddTeamValidator>());
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddDbContext<LeagueDbContext>(p => p.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(typeof(Startup));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IPuanTableRepository, PuanTableRepository>();
            services.AddScoped<IWeeklyResultRepository, WeeklyResultRepository>();
            services.AddScoped<IPredictionCampRepository, PredictionCampRepository>();

            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped<IPuanTableService, PuanTableService>();
            services.AddScoped<IWeeklyResultService, WeeklyResultService>();
            services.AddScoped<IPredictionCampService,PredictionCampService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStatusCodePagesWithReExecute("/Home/NotFound", "?code={0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

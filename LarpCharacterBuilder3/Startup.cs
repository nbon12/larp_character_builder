
using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using AutoMapper;
using Core.IoC;
using LarpCharacterBuilder3.Core.Core.Dapper;
using LarpCharacterBuilder3.Core.IoC;
using LarpCharacterBuilder3.Data;
using LarpCharacterBuilder3.Logic;
using LarpCharacterBuilder3.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LarpCharacterBuilder3
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        public IConfigurationRoot Configuration { get; }

        public Startup(IWebHostEnvironment env)
        {
            _env = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
                builder.AddUserSecrets<Startup>(false);

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddDbContext<LarpBuilderContext>(options =>
                options.UseMySql("server=localhost;port=3306;database=larpbuilder;uid=root;pwd=legolas indigo;"));
            services.AddScoped<ICharacterRepository, CharacterRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //services.AddTransient<IDapperDataSession, DapperDataSession>();

        }
        
        public void ConfigureContainer(ContainerBuilder builder)
        {
            var modules = new List<IModule> {new DataAccessRegistry(Configuration)};

            modules.ForEach(x=>builder.RegisterModule(x));

            IContainer container = null;
            builder.Register(c => container).AsSelf();
            builder.RegisterBuildCallback(c =>
            {
                container = (IContainer) c;
                DependencyResolver.SetContainer(c);
            });
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Infra.Data.Context;
using Domain.Entities;
using System;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Presentation.AutoMapper;
using Presentation.StartupExtensions;
using Sakura.AspNetCore.Mvc;
using Aplication.Services.Email.Clients;
using Aplication.Services.Email.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Presentation
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddDbContext<DataBaseContext>();
            services.AddIdentity<User, Role>().AddEntityFrameworkStores<DataBaseContext>().AddDefaultTokenProviders();
            services.AddLogging();
            services.AddAutoMapper(p => AutoMapperConfig.RegisterMapping());
            services.AddSession();

            //Custom DI
            services.AplicationDi();
            services.DomainDi();
            services.InfraDi();

            //Depois Adicionar os Serviços de SMS e Email -> SendGrid
            services.AddTransient<IEmailSender, SendGrid>();
            //services.AddTransient<ISmsSender, AuthMessageSender>();

            services.AddBootstrapPagerGenerator(options =>
            {
                // Use default pager options.
                options.ConfigureDefault();
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = new PathString("/Users/Login/");
                options.AccessDeniedPath = new PathString("/Users/Login/");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var seed = new SeedDevDatabase();
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //Verificar Uso dessa congfiguração
            app.UseDeveloperExceptionPage();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                seed.Seed(app);
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

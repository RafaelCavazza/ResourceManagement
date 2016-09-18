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
using Aplication.Interfaces;
using Aplication;
using Domain.Interfaces.Services;
using Domain.Services;
using Infra.Data.Repositories;
using Domain.Interfaces.Repositories;

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
            
            using(var dbContext = new DataBaseContext())
            {
                dbContext.Database.EnsureCreated();
                try
                {
                    dbContext.Seed();
                }
                catch {  }
            }
        }
   
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddDbContext<DataBaseContext>();
            services.AddIdentity<User,Role>().AddEntityFrameworkStores<DataBaseContext, Guid>().AddDefaultTokenProviders();
            services.AddLogging();
            services.AddAutoMapper(p => AutoMapperConfig.RegisterMapping() );

            services.AddScoped(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
            services.AddScoped(typeof(IEmployeeAppService), typeof(EmployeeAppService));

            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped(typeof(IEmployeeService), typeof(EmployeeService));

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped(typeof(IEmployeeRepository), typeof(EmployeeRepository));
            
            //Depois Adicionar os Serviços de SMS e Email -> SendGrid
            //services.AddTransient<IEmailSender, AuthMessageSender>();
            //services.AddTransient<ISmsSender, AuthMessageSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //Verificar Uso dessa congfiguração
            app.UseDeveloperExceptionPage();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            
            app.UseIdentity();

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationScheme = "CookieMiddlewareInstance",
                LoginPath = new PathString("/Users/Login/"),
                AccessDeniedPath = new PathString("/Users/Login/"),
                AutomaticAuthenticate = true,
                AutomaticChallenge = true
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute( name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

using System;
using System.IO;
using System.Reflection;
using AuditLog.Application.AutoMapper;
using AuditLog.Infra.CrossCutting.IoC;
using AuditLog.Infra.Data.Context;
using AuditLog.Services.API.Config;
using AuditLog.Services.API.Filters;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace AuditLog.Services.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AuditLogContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AuditLogConnection")));

            services.AddOptions();
            services.AddMvc(config =>
            {
                config.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
                //config.UseCentralRoutePrefix(new RouteAttribute("api/v{version}"));
            })
            .AddJsonOptions(o =>
            {
                o.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                o.SerializerSettings.Converters.Add(new StringEnumConverter());
                o.SerializerSettings.Formatting = Formatting.Indented;
                o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                o.SerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
                o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Error;
                o.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
                o.SerializerSettings.DateFormatString = "dd/MM/yyyy HH:mm:ss";
            });

            services.AddAutoMapper(Assembly.GetAssembly(typeof(AutoMapperConfiguration)));
            services.AddScoped<ApiActionFilters>();
            services.AddScoped<ApiExceptionFilter>();

            // .NET Native DI Abstraction
            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseMvc();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}

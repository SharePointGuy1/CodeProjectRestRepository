using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CodeProject.RESTRepository.Data.Repository;
using CodeProject.RESTRepository.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using System.Diagnostics;
using Newtonsoft.Json;
using System;

namespace CodeProject.RESTRepository.WebAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables()
                //.AddEntityFrameworkConfig(options=>options.UseSqlServer(connectionStringConfig.GetConnectionString("Sample")))
                ;
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })
                ;

            var connection = Configuration.GetSection("ConnectionStrings").GetValue<string>("Sample");
            services.AddDbContext<WWIDataContext>(options => options.UseSqlServer(connection));

            services.AddCors(options=>
            {
                options.AddPolicy("AllowSpecificOrigin", 
                    builder => builder.WithOrigins("http://localhost:3000"));
                options.AddPolicy("AllowAllOrigins", 
                    builder => { builder.AllowAnyOrigin(); });
                options.AddPolicy("AllowAllMethods",
                    builder => { builder.AllowAnyMethod(); });
                options.AddPolicy("AllowAllHeaders",
                    builder => { builder.AllowAnyHeader(); });
                options.AddPolicy("AllowCredentials",
                    builder =>  {builder.AllowCredentials(); });

            });



            Debug.WriteLine("\n\nStartup.cs Debug.WriteLine\n\n");
            //Output.WriteLine("Startup.cs Output.WriteLine");
            Console.WriteLine(string.Format(
                "\n\nStartup.cs {0}\n\n",
                DateTime.Now.ToLocalTime()
                ));




            var enumerator = services.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Debug.WriteLine(enumerator.Current.ServiceType.FullName);
            }




            services.AddSingleton<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<IDeliveryMethodRepository, DeliveryMethodRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();


            //app.Use(async (context, next) =>
            //{
            //    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            //    context.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
            //    context.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "Content-Type, x-xsrf-token" });

            //    if (context.Request.Method == "OPTIONS")
            //    {
            //        context.Response.StatusCode = 200;
            //    }
            //    else
            //    {
            //        await next();
            //    }
            //});

            app.UseMvc();

        }
    }
}

using AutoMapper;
using AutoMapper.EquivalencyExpression;
using NServiceBusPoC.BussinesLogic;
using NServiceBusPoC.BussinesLogic.ClubDomain;
using NServiceBusPoC.BussinesLogic.UserDomain;
using NServiceBusPoC.Core.Persistance;
using NServiceBusPoC.Core.Persistance.Context;
using NServiceBusPoC.Core.Persistance.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace NServiceBusPoC.UI.Api
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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Version = "v1",
                    Title = "Api NServiceBusPoC",
                    Description = "This is the AspNetCore provided by Dev of NServiceBusPoC",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Francisco Javier Ruiz de la Torre",
                        Email = string.Empty,
                        Url = "https://twitter.com/spboyer"
                    },
                    License = new License
                    {
                        Name = "ToDo lincense",
                        Url = "https://example.com/license"
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddDbContext<NServiceBusPoCContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection"))
                );

            services.AddAutoMapper(cfg =>
            {
                cfg.AddCollectionMappers();

            });

            services.AddMvc();

            ConfigureRepositoryServices(services);

            ConfigureBussinesLogicServices(services);

        }

        private void ConfigureRepositoryServices(IServiceCollection services)
        {
            // Add application services.
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IClubRepository, ClubRepository>();
            services.AddTransient<IEmailConfirmationRepository, EmailConfirmationRepository>();
            services.AddTransient<IAppConfigurationRepository, AppConfigurationRepository>();


            //GenericUoW
            services.AddTransient<IGenericUoW, GenericUoW>();
        }

        private void ConfigureBussinesLogicServices(IServiceCollection services)
        {
            // Add application services.
            services.AddTransient<IUserBussinesLogic, UserBussinesLogic>();
            services.AddTransient<IClubBussinesLogic, ClubBussinesLogic>();

        }





        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();



            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {

                c.SwaggerEndpoint("/swagger/v1/swagger.json", "NServiceBusPoC Api V1");
            });

            app.UseMvc();
        }
    }
}

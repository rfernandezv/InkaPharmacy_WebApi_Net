using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using InkaPharmacy.Api.Common.Infrastructure.Persistence.NHibernate;
using InkaPharmacy.Api.Accounts.Infrastructure.Persistence.NHibernate.Repository;
using InkaPharmacy.Api.Customers.Domain.Repository;
using InkaPharmacy.Api.Customers.Infrastructure.Persistence.NHibernate.Repository;
using AutoMapper;
using InkaPharmacy.Api.Common.Application;
using InkaPharmacy.Api.Security.Application.Assembler;
using InkaPharmacy.Api.Security.Domain.Repository;
using InkaPharmacy.Api.Customers.Application.Assembler;
using InkaPharmacy.Api.Products.Application.Assembler;
using InkaPharmacy.Api.Product.Domain.Repository;
using InkaPharmacy.Api.Employee.Domain.Repository;
using InkaPharmacy.Api.Employee.Infrastructure.Persistence.NHibernate.Repository;
using InkaPharmacy.Api.Providers.Application.Assembler;
using InkaPharmacy.Api.Providers.Domain.Repository;
using InkaPharmacy.Api.Providers.Infrastructure.Persistence.NHibernate.Repository;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace InkaPharmacy.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton(new SessionFactory(Environment.GetEnvironmentVariable("InkaPharmacyBD")));
            var serviceProvider = services.BuildServiceProvider();
            var mapper = serviceProvider.GetService<IMapper>();

            services.AddSingleton(new ProductAssembler(mapper));
            services.AddSingleton(new CustomerAssembler(mapper));
            services.AddSingleton(new EmployeeAssembler(mapper));
            services.AddSingleton(new ProviderAssembler(mapper));

            services.AddScoped<IUnitOfWork, UnitOfWorkNHibernate>();

            services.AddTransient<IProductRepository, ProductNHibernateRepository>((ctx) =>
            {
                IUnitOfWork unitOfWork = ctx.GetService<IUnitOfWork>();
                return new ProductNHibernateRepository((UnitOfWorkNHibernate)unitOfWork);
            });

            services.AddTransient<IEmployeeRepository, EmployeeNHibernateRepository>((ctx) =>
            {
                IUnitOfWork unitOfWork = ctx.GetService<IUnitOfWork>();
                return new EmployeeNHibernateRepository((UnitOfWorkNHibernate)unitOfWork);
            });

            services.AddTransient<ISecurityRepository, SecurityNHibernateRepository>((ctx) =>
            {
                IUnitOfWork unitOfWork = ctx.GetService<IUnitOfWork>();
                return new SecurityNHibernateRepository((UnitOfWorkNHibernate)unitOfWork);
            });


            services.AddTransient<IProviderRepository, ProviderNHibernateRepository>((ctx) =>
            {
                IUnitOfWork unitOfWork = ctx.GetService<IUnitOfWork>();
                return new ProviderNHibernateRepository((UnitOfWorkNHibernate)unitOfWork);
            });

            services.AddTransient<ICustomerRepository, CustomerCustomerNHibernateRepository>((ctx) =>
            {
                IUnitOfWork unitOfWork = ctx.GetService<IUnitOfWork>();
                return new CustomerCustomerNHibernateRepository((UnitOfWorkNHibernate)unitOfWork);
            });

            var TokenSecret = Environment.GetEnvironmentVariable("InkaPharmacyTokenSecret");
            Console.WriteLine(TokenSecret);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Jwt";
                options.DefaultChallengeScheme = "Jwt";
            }).AddJwtBearer("Jwt", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenSecret)),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(5)
                };
            });

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}

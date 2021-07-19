using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Mappings;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Account;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infra.Data.Context;
using CleanArchitecture.Infra.Data.Identity;
using CleanArchitecture.Infra.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CleanArchitecture.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<ApplicationDbContext>(
                    options => options.UseSqlServer(configuration.GetConnectionString("CleanArchitectureDB"),
                    m => m.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))); //Where the migrations will be

            services
                .AddScoped<ICategoryRepository, CategoryRepository>() //The interface and the concrete class who implements it
                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<ICategoryService, CategoryService>()
                .AddScoped<IProductService, ProductService>()
                .AddScoped<IAuthentication, AuthenticationService>()
                .AddScoped<ISeedUserRole, SeedUserRole>();

            services
                .AddAutoMapper(typeof(ProductToDTOMappingProfile))
                .AddMediatR(AppDomain.CurrentDomain.Load("CleanArchitecture.Application"));

            services
                .AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}

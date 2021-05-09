using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infra.Data.Context;
using CleanArchitecture.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<ApplicationDbContext>(
                    options => options.UseSqlServer(configuration.GetConnectionString("ProductCleanArchitectureDB"),
                    m => m.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))); //Where the migrations will be

            services
                .AddScoped<ICategoryRepository, CategoryRepository>() //The interface and the concrete class who implements it
                .AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}

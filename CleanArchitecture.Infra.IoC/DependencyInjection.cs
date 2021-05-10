using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Mappings;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infra.Data.Context;
using CleanArchitecture.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
                .AddScoped<IProductService, ProductService>();

            services
                .AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}

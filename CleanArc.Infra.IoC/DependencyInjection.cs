using CleanArc.Application.Interfaces;
using CleanArc.Application.Mappings;
using CleanArc.Application.Services;
using CleanArc.Domain.Interfaces;
using CleanArc.Infra.Data.Context;
using CleanArc.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArc.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // 1. Banco de Dados
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase("CleanArcDb"));

        // 2. Repositórios
        services.AddScoped<IProductRepository, ProductRepository>();

        // 3. Serviços (ESSA É A LINHA QUE ESTÁ FALTANDO)
        services.AddScoped<IProductService, ProductService>();

        // 4. AutoMapper
        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        return services;
    }
}
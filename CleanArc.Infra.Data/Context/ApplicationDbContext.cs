using CleanArc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArc.Infra.Data.Context;

public class ApplicationDbContext : DbContext
{
    // Construtor: Passa as opções (como string de conexão) para a classe base
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    // Mapeamento: Transforma a classe Product na tabela Products
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Isso diz ao EF Core: "Procure neste projeto qualquer classe de configuração
        // e aplique aqui". Isso deixa o Contexto limpo.
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
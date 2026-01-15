using CleanArc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArc.Infra.Data.EntitiesConfiguration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // Define a chave primária
        builder.HasKey(t => t.Id);

        // Define propriedades
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Description).HasMaxLength(200).IsRequired();
        
        // Define precisão decimal para o preço (10 dígitos, 2 decimais)
        builder.Property(p => p.Price).HasPrecision(10, 2);

        // Popula o banco com um dado inicial (Seed) - Opcional, mas útil para testes
        builder.HasData(
            new Product(1, "Caderno", "Caderno espiral 100 folhas", 7.45m, 50, "caderno1.jpg"),
            new Product(2, "Borracha", "Borracha branca pequena", 2.45m, 80, "borracha1.jpg"),
            new Product(3, "Estojo", "Estojo de plástico", 5.25m, 10, "estojo1.jpg")
        );
    }
}
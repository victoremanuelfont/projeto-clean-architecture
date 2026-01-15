using System.ComponentModel.DataAnnotations; // Para validações básicas

namespace CleanArc.Application.DTOs;

public class ProductDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Name { get; set; }

    [Required(ErrorMessage = "A descrição é obrigatória")]
    [MinLength(5)]
    [MaxLength(200)]
    public string? Description { get; set; }

    [Required(ErrorMessage = "O preço é obrigatório")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "O estoque é obrigatório")]
    [Range(1, 9999)]
    public int Stock { get; set; }

    [MaxLength(250)]
    public string? Image { get; set; }
    
    public int CategoryId { get; set; } // Caso tenhamos categorias no futuro
}
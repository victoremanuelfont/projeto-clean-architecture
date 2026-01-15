using CleanArc.Application.DTOs;

namespace CleanArc.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetProdutos();
    Task<ProductDTO> GetById(int? id);
    Task Add(ProductDTO productDto);
    Task Update(ProductDTO productDto);
    Task Remove(int? id);
}
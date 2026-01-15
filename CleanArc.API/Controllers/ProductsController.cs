using CleanArc.Application.DTOs;
using CleanArc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArc.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    // Injeção de Dependência: Pedimos o SERVIÇO, não o Repositório
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
    {
        var produtos = await _productService.GetProdutos();
        if (produtos == null)
        {
            return NotFound("Nenhum produto encontrado");
        }
        return Ok(produtos);
    }

    [HttpGet("{id:int}", Name = "GetProduct")]
    public async Task<ActionResult<ProductDTO>> Get(int id)
    {
        var produto = await _productService.GetById(id);
        if (produto == null)
        {
            return NotFound("Produto não encontrado");
        }
        return Ok(produto);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ProductDTO produtoDto)
    {
        if (produtoDto == null)
            return BadRequest("Dados inválidos");

        await _productService.Add(produtoDto);

        // Retorna código 201 (Created) e o caminho para consultar o item criado
        return new CreatedAtRouteResult("GetProduct", new { id = produtoDto.Id }, produtoDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody] ProductDTO produtoDto)
    {
        if (id != produtoDto.Id)
            return BadRequest();

        if (produtoDto == null)
            return BadRequest();

        await _productService.Update(produtoDto);
        return Ok(produtoDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ProductDTO>> Delete(int id)
    {
        var produto = await _productService.GetById(id);
        if (produto == null)
        {
            return NotFound("Produto não encontrado");
        }

        await _productService.Remove(id);
        return Ok(produto);
    }
}
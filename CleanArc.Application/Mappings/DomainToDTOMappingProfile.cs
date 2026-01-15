using AutoMapper;
using CleanArc.Application.DTOs;
using CleanArc.Domain.Entities;

namespace CleanArc.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        // Configura o AutoMapper para converter Produto em DTO e vice-versa
        CreateMap<Product, ProductDTO>().ReverseMap();
    }
}
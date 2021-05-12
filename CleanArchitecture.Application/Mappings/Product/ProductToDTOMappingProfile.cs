using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Mappings
{
    public class ProductToDTOMappingProfile : Profile
    {
        public ProductToDTOMappingProfile()
        {
            CreateMap<CategoryDTO, Category>().ReverseMap();
            CreateMap<ProductDTO, Product>().ReverseMap();
        }
    }
}

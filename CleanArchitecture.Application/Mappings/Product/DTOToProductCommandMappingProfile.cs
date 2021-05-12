using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Products.Commands;

namespace CleanArchitecture.Application.Mappings
{
    class DTOToProductCommandMappingProfile : Profile
    {
        public DTOToProductCommandMappingProfile()
        {
            CreateMap<ProductDTO, ProductInsertCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();
        }

    }
}

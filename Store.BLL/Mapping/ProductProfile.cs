using AutoMapper;
using Store.BLL.DataTransferObjects;
using Store.BLL.DataTransferObjects.Products.Responses;
using Store.DAL.Entities;

namespace Store.BLL.Mapping;

public sealed class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductDtoCommand, Product>()
            .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color));

        CreateMap<Product, GetAllProductsItemDto>();
    }
}
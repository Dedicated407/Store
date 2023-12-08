using AutoMapper;
using Store.BLL.DataTransferObjects;
using Store.DAL.Entities;

namespace Store.BLL.Mapping;

public sealed class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductDto, Product>();
    }
}
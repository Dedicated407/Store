using AutoMapper;
using Store.BLL.DomainModels;
using Store.DAL.Entities;

namespace Store.BLL.Mapping;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductDto, Product>();
    }
}
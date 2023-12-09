using AutoMapper;
using Store.BLL.DataTransferObjects;
using Store.BLL.DataTransferObjects.StoresProducts;
using Store.DAL.Entities;

namespace Store.BLL.Mapping;

public sealed class StoreProductProfile : Profile
{
    public StoreProductProfile()
    {
        CreateMap<CreateStoreProductDto, StoreProduct>();
    }
}
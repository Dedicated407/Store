using AutoMapper;
using Store.BLL.DataTransferObjects.StoresProducts;
using Store.BLL.DataTransferObjects.StoresProducts.Responses;
using Store.DAL.Entities;

namespace Store.BLL.Mapping;

public sealed class StoreProductProfile : Profile
{
    public StoreProductProfile()
    {
        CreateMap<CreateStoreProductDto, StoreProduct>();

        CreateMap<StoreProduct, GetAllStoresProductsItemDto>();
    }
}
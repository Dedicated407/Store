using AutoMapper;
using Store.BLL.DataTransferObjects.Stores;
using Store.BLL.DataTransferObjects.Stores.Responses;
using Store.BLL.DataTransferObjects.StoresProducts;
using StoreEntity = Store.DAL.Entities.Store;

namespace Store.BLL.Mapping;

public sealed class StoreProfile : Profile
{
    public StoreProfile()
    {
        CreateMap<CreateStoreDto, StoreEntity>();

        CreateMap<StoreEntity, GetAllStoresItemDto>();

        CreateMap<StoreEntity, ReadStoreDto>();
    }
}
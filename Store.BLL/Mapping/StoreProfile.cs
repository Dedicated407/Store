using AutoMapper;
using Store.BLL.DataTransferObjects;
using Store.BLL.DataTransferObjects.Stores;
using StoreEntity = Store.DAL.Entities.Store;

namespace Store.BLL.Mapping;

public sealed class StoreProfile : Profile
{
    public StoreProfile()
    {
        CreateMap<CreateStoreDto, StoreEntity>();
    }
}
using AutoMapper;
using Store.BLL.DataTransferObjects.Stores.Command;
using StoreEntity = Store.DAL.Entities.Store;

namespace Store.BLL.Mapping;

public sealed class StoreProfile : Profile
{
    public StoreProfile()
    {
        CreateMap<CreateStoreCommand, StoreEntity>();
    }
}
using Store.BLL.DataTransferObjects.Stores;
using Store.BLL.DataTransferObjects.Stores.Responses;

namespace Store.BLL.Services.Stores;

public class StoresFileService : IStoresService
{
    public Task CreateAsync(CreateStoreDto command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GetAllStoresItemDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
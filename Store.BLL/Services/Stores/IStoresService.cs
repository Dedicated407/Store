using Store.BLL.DataTransferObjects.Stores;
using Store.BLL.DataTransferObjects.Stores.Responses;

namespace Store.BLL.Services.Stores;

public interface IStoresService
{
    Task CreateAsync(CreateStoreDto command, CancellationToken cancellationToken);

    Task<IEnumerable<GetAllStoresItemDto>> GetAllAsync(CancellationToken cancellationToken);
}
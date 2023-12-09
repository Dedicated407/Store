using Store.BLL.DataTransferObjects;
using Store.BLL.DataTransferObjects.Stores;

namespace Store.BLL.Services.Stores;

public interface IStoresService
{
    Task CreateAsync(CreateStoreDto command, CancellationToken cancellationToken);
}
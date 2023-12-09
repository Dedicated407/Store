using Store.BLL.DataTransferObjects;

namespace Store.BLL.Services.Stores;

public interface IStoresService
{
    Task CreateAsync(StoreDto command, CancellationToken cancellationToken);
}
using Store.BLL.DataTransferObjects.Stores.Command;

namespace Store.BLL.Services.Stores;

public interface IStoresService
{
    Task CreateAsync(CreateStoreCommand command, CancellationToken cancellationToken);
}
using Store.BLL.DataTransferObjects;

namespace Store.BLL.Services.StoresProducts;

public interface IStoresProductsService
{
    Task AddProductAsync(StoreProductDto command, CancellationToken cancellationToken);
}
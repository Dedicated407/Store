using Store.BLL.DataTransferObjects.Stores;
using Store.BLL.DataTransferObjects.StoresProducts;

namespace Store.BLL.Services.StoresProducts;

public interface IStoresProductsService
{
    Task AddProductAsync(CreateStoreProductDto dto, CancellationToken cancellationToken);
    Task ChangeProductPriceAsync(ChangeProductPriceDto dto, CancellationToken cancellationToken);
    Task<ReadStoreDto> FindStoreWithChipperProductAsync(Guid productId, CancellationToken cancellationToken);
}
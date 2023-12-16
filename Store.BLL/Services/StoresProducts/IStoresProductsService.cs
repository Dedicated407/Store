using Store.BLL.DataTransferObjects.Products.Responses;
using Store.BLL.DataTransferObjects.StoresProducts;
using Store.BLL.DataTransferObjects.StoresProducts.Responses;

namespace Store.BLL.Services.StoresProducts;

public interface IStoresProductsService
{
    Task AddProductAsync(CreateStoreProductDto dto, CancellationToken cancellationToken);
    Task ChangeProductPriceAsync(ChangeProductPriceDto dto, CancellationToken cancellationToken);
    Task<ReadStoreDto> FindStoreWithChipperProductAsync(Guid productId, CancellationToken cancellationToken);
    Task<ReadStoreDto> FindStoreWithCheapestBatchesAsync(FindCheapestBatchesDto dto, CancellationToken cancellationToken);

    Task<IEnumerable<GetAllProductsWithQuantityItemDto>> BuyAsync(BuyProductsDto dto, CancellationToken cancellationToken);
    Task<IEnumerable<GetAllStoresProductsItemDto>> GetAllAsync(CancellationToken cancellationToken);
}
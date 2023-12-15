using Store.BLL.DataTransferObjects.StoresProducts;
using Store.BLL.DataTransferObjects.StoresProducts.Responses;

namespace Store.BLL.Services.StoresProducts;

public class StoresProductsFileService : IStoresProductsService
{
    public Task AddProductAsync(CreateStoreProductDto dto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task ChangeProductPriceAsync(ChangeProductPriceDto dto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ReadStoreDto> FindStoreWithChipperProductAsync(Guid productId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ReadStoreDto> FindStoreWithCheapestBatchesAsync(FindCheapestBatchesDto dto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GetAllStoresProductsItemDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
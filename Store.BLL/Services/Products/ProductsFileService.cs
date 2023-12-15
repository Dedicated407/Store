using Store.BLL.DataTransferObjects;
using Store.BLL.DataTransferObjects.Products.Responses;

namespace Store.BLL.Services.Products;

public class ProductsFileService : IProductsService
{
    public Task CreateAsync(ProductDtoCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GetAllProductsItemDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
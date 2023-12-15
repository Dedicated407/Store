using Store.BLL.DataTransferObjects;
using Store.BLL.DataTransferObjects.Products.Responses;

namespace Store.BLL.Services.Products;

public interface IProductsService
{
    Task CreateAsync(ProductDtoCommand command, CancellationToken cancellationToken);

    Task<IEnumerable<GetAllProductsItemDto>> GetAllAsync(CancellationToken cancellationToken);
}
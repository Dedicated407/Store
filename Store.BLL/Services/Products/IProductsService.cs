using Store.BLL.DataTransferObjects;

namespace Store.BLL.Services.Products;

public interface IProductsService
{
    Task CreateAsync(ProductDto command, CancellationToken cancellationToken);
}
using Store.BLL.DomainModels;

namespace Store.BLL.Services.Products;

public interface IProductService
{
    Task Add(ProductDto productDto);
}
using Microsoft.AspNetCore.Mvc;
using Store.BLL.DataTransferObjects;
using Store.BLL.DataTransferObjects.Products.Responses;
using Store.BLL.Services.Products;

namespace Store.API.Controllers;

public class ProductsController : BaseApiController
{
    private readonly IProductsService _productsService;

    public ProductsController(ILogger<ProductsController> logger, IProductsService productsService) : base(logger)
    {
        _productsService = productsService;
    }

    [HttpGet]
    public async Task<IEnumerable<GetAllProductsItemDto>> GetAllAsync(
        CancellationToken cancellationToken) =>
        await _productsService.GetAllAsync(cancellationToken);

    [HttpPost]
    public async Task<IActionResult> CreateAsync(ProductDtoCommand command, CancellationToken cancellationToken)
    {
        await _productsService.CreateAsync(command, cancellationToken);
        return Ok();
    }
}
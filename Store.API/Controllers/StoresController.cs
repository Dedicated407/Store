using Microsoft.AspNetCore.Mvc;
using Store.BLL.DataTransferObjects;
using Store.BLL.Services.Stores;
using Store.BLL.Services.StoresProducts;

namespace Store.API.Controllers;

public class StoresController : BaseApiController
{
    private readonly IStoresService _storesService;
    private readonly IStoresProductsService _storesProductsService;

    public StoresController(
        ILogger<StoresController> logger, 
        IStoresService storesService, 
        IStoresProductsService storesProductsService) 
        : base(logger)
    {
        _storesService = storesService;
        _storesProductsService = storesProductsService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        StoreDto command, 
        CancellationToken cancellationToken)
    {
        await _storesService.CreateAsync(command, cancellationToken);
        return Ok();
    }

    [HttpPost("{storeId:guid}/add-product")]
    public async Task<IActionResult> AddProductToStoreAsync(
        Guid storeId,
        StoreProductDto command,
        CancellationToken cancellationToken)
    {
        command.StoreId = storeId;
        await _storesProductsService.AddProductAsync(command, cancellationToken);
        return Ok();
    }
}
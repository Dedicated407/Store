using Microsoft.AspNetCore.Mvc;
using Store.BLL.DataTransferObjects.Stores;
using Store.BLL.DataTransferObjects.Stores.Responses;
using Store.BLL.DataTransferObjects.StoresProducts;
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

    #region GET

    [HttpGet]
    public async Task<IEnumerable<GetAllStoresItemDto>> GetAllAsync(
        CancellationToken cancellationToken) =>
        await _storesService.GetAllAsync(cancellationToken);

    [HttpGet("find/product/{productId:guid}")]
    public async Task<ReadStoreDto> FindStoreWithChipperProductAsync(
        Guid productId,
        CancellationToken cancellationToken) =>
        await _storesProductsService.FindStoreWithChipperProductAsync(productId, cancellationToken);

    #endregion

    #region POST

    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        CreateStoreDto command, 
        CancellationToken cancellationToken)
    {
        await _storesService.CreateAsync(command, cancellationToken);
        return Ok();
    }

    [HttpPost("{storeId:guid}/product/add")]
    public async Task<IActionResult> AddProductToStoreAsync(
        Guid storeId,
        CreateStoreProductDto dto,
        CancellationToken cancellationToken)
    {
        dto.StoreId = storeId;
        await _storesProductsService.AddProductAsync(dto, cancellationToken);
        return Ok();
    }

    #endregion

    #region PATCH

    [HttpPatch("{storeId:guid}/product/{productId:guid}/change-price")]
    public async Task<IActionResult> ChangeProductPriceAsync(
        Guid storeId,
        Guid productId,
        ChangeProductPriceDto dto,
        CancellationToken cancellationToken)
    {
        dto.StoreId = storeId;
        dto.ProductId = productId;

        await _storesProductsService.ChangeProductPriceAsync(dto, cancellationToken);
        return Ok();
    }

    #endregion
}
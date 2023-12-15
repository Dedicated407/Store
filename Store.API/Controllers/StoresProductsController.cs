using Microsoft.AspNetCore.Mvc;
using Store.BLL.DataTransferObjects.StoresProducts.Responses;
using Store.BLL.Services.StoresProducts;

namespace Store.API.Controllers;

public class StoresProductsController : BaseApiController
{
    private readonly IStoresProductsService _storesProductsService;

    public StoresProductsController(
        ILogger<StoresProductsController> logger, 
        IStoresProductsService storesProductsService) 
        : base(logger)
    {
        _storesProductsService = storesProductsService;
    }

    #region GET

    [HttpGet]
    public async Task<IEnumerable<GetAllStoresProductsItemDto>> GetAllAsync(
        CancellationToken cancellationToken) =>
        await _storesProductsService.GetAllAsync(cancellationToken);

    #endregion
}
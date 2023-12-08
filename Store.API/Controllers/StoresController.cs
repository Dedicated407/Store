using Microsoft.AspNetCore.Mvc;
using Store.BLL.DataTransferObjects.Stores.Command;
using Store.BLL.Services.Stores;

namespace Store.API.Controllers;

public class StoresController : BaseApiController
{
    private readonly IStoresService _storesService;

    public StoresController(ILogger<StoresController> logger, IStoresService storesService) : base(logger)
    {
        _storesService = storesService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateStoreCommand command, CancellationToken cancellationToken)
    {
        await _storesService.CreateAsync(command, cancellationToken);
        return Ok();
    }
}
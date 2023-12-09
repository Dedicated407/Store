using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store.BLL.DataTransferObjects;
using Store.DAL.Entities;
using Store.DAL.Storages.DatabaseStorage;

namespace Store.BLL.Services.StoresProducts;

internal class StoresProductsService : IStoresProductsService
{
    private readonly IMapper _mapper;
    private readonly StoreDbContext _dbContext;
    private readonly DbSet<StoreProduct> _entitySet;

    public StoresProductsService(IMapper mapper, StoreDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
        _entitySet = _dbContext.Set<StoreProduct>();
    }

    public async Task AddProductAsync(StoreProductDto command, CancellationToken cancellationToken)
    {
        var storeProduct = _mapper.Map<StoreProduct>(command);

        var storeDataExists = await _dbContext.Stores.AnyAsync(x => 
                x.Id == storeProduct.StoreId,
            cancellationToken);
        if (!storeDataExists)
        {
            throw new ArgumentException($"{nameof(command.StoreId)} is not found!", nameof(command.StoreId));
        }

        var productDataExists = await _dbContext.Products.AnyAsync(x =>
                x.Id == storeProduct.ProductId,
            cancellationToken);
        if (!productDataExists)
        {
            throw new ArgumentException($"{nameof(command.ProductId)} is not found!", nameof(command.ProductId));
        }

        _entitySet.Add(storeProduct);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
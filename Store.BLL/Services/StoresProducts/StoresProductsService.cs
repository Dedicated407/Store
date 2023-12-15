using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store.BLL.DataTransferObjects.Stores;
using Store.BLL.DataTransferObjects.StoresProducts;
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

    public async Task AddProductAsync(CreateStoreProductDto dto, CancellationToken cancellationToken)
    {
        var storeProduct = _mapper.Map<StoreProduct>(dto);

        var storeDataExists = await _dbContext.Stores.AnyAsync(x => 
                x.Id == storeProduct.StoreId,
            cancellationToken);
        if (!storeDataExists)
        {
            throw new ArgumentException($"{nameof(dto.StoreId)} is not found!", nameof(dto.StoreId));
        }

        var productDataExists = await _dbContext.Products.AnyAsync(x =>
                x.Id == storeProduct.ProductId,
            cancellationToken);
        if (!productDataExists)
        {
            throw new ArgumentException($"{nameof(dto.ProductId)} is not found!", nameof(dto.ProductId));
        }

        _entitySet.Add(storeProduct);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task ChangeProductPriceAsync(ChangeProductPriceDto dto, CancellationToken cancellationToken)
    {
        var storeProductData = await _dbContext.StoresProducts.FirstOrDefaultAsync(x =>
                x.StoreId == dto.StoreId &&
                x.ProductId == dto.ProductId,
            cancellationToken);
        if (storeProductData == null)
        {
            throw new ArgumentException("StoreProduct is not found!");
        }

        storeProductData.Price = dto.Price;

        _entitySet.Update(storeProductData);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<ReadStoreDto> FindStoreWithChipperProductAsync(Guid productId, CancellationToken cancellationToken)
    {
        var cheapestStore = await _dbContext.StoresProducts
            .Where(sp => sp.ProductId == productId)
            .OrderBy(sp => sp.Price)
            .Select(sp => sp.Store)
            .FirstOrDefaultAsync(cancellationToken);
        if (cheapestStore == null)
        {
            throw new ArgumentException("Product is not found!", nameof(productId));
        }

        return _mapper.Map<ReadStoreDto>(cheapestStore);
    }
}
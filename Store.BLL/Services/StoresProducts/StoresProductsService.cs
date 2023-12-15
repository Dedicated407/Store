using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store.BLL.DataTransferObjects.StoresProducts;
using Store.BLL.DataTransferObjects.StoresProducts.Responses;
using Store.DAL.Entities;
using Store.DAL.Storages.DatabaseStorage;

namespace Store.BLL.Services.StoresProducts;

public class StoresProductsService : IStoresProductsService
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

    public async Task AddProductAsync(CreateStoreProductDto dto,
        CancellationToken cancellationToken)
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

    public async Task ChangeProductPriceAsync(ChangeProductPriceDto dto, 
        CancellationToken cancellationToken)
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

    public async Task<ReadStoreDto> FindStoreWithChipperProductAsync(Guid productId, 
        CancellationToken cancellationToken)
    {
        var cheapestStore = await _entitySet
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

    public async Task<ReadStoreDto> FindStoreWithCheapestBatchesAsync(FindCheapestBatchesDto dto, 
        CancellationToken cancellationToken)
    {
        var items = dto.Items.Distinct().ToList();
        var array = new List<Guid>();

        for (var i = 0; i < items.Count; i++)
        {
            var storeIds = await _entitySet
                .Where(x => 
                    x.ProductId == items[i].ProductId && 
                    x.Quantity >= items[i].Quantity)
                .Select(x => x.StoreId)
                .ToListAsync(cancellationToken);

            array = i == 0 ? storeIds : array.Intersect(storeIds).ToList();
        }

        var minTotalPrice = decimal.MaxValue;
        var cheapestStoreId = Guid.Empty;

        foreach (var guid in array)
        {
            var allStoreProducts = _dbContext.StoresProducts
                .Where(x => x.StoreId == guid)
                .ToList();

            decimal totalBatchPrice = 0;

            foreach (var item in items)
            {
                var product = allStoreProducts
                    .FirstOrDefault(x => x.ProductId == item.ProductId);
                
                totalBatchPrice += product!.Price * item.Quantity;
            }

            if (totalBatchPrice < minTotalPrice)
            {
                minTotalPrice = totalBatchPrice;
                cheapestStoreId = guid;
            }
        }

        if (cheapestStoreId == Guid.Empty)
        {
            throw new ArgumentException("Error!");
        }

        var cheapestStore = await _dbContext.Stores
            .FirstOrDefaultAsync(x => x.Id == cheapestStoreId, cancellationToken: cancellationToken);
        return _mapper.Map<ReadStoreDto>(cheapestStore);
    }

    public async Task<IEnumerable<GetAllStoresProductsItemDto>> GetAllAsync(CancellationToken cancellationToken) => 
        _mapper.Map<IEnumerable<GetAllStoresProductsItemDto>>(await _entitySet
            .ToListAsync(cancellationToken));
}
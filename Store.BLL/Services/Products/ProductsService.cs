using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store.BLL.DataTransferObjects;
using Store.BLL.DataTransferObjects.Products.Responses;
using Store.DAL.Entities;
using Store.DAL.Storages.DatabaseStorage;

namespace Store.BLL.Services.Products;

internal class ProductsService : IProductsService
{
    private readonly IMapper _mapper;
    private readonly StoreDbContext _dbContext;
    private readonly DbSet<Product> _entitySet;

    public ProductsService(IMapper mapper, StoreDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
        _entitySet = _dbContext.Set<Product>();
    }

    public async Task CreateAsync(ProductDtoCommand command, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(command);

        _entitySet.Add(product);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<GetAllProductsItemDto>> GetAllAsync(CancellationToken cancellationToken) => 
        _mapper.Map<IEnumerable<GetAllProductsItemDto>>(await _entitySet.ToListAsync(cancellationToken));
}
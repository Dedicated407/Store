using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store.BLL.DataTransferObjects.Stores;
using Store.BLL.DataTransferObjects.Stores.Responses;
using Store.DAL.Storages.DatabaseStorage;
using StoreEntity = Store.DAL.Entities.Store;

namespace Store.BLL.Services.Stores;

public class StoresService : IStoresService
{
    private readonly IMapper _mapper;
    private readonly StoreDbContext _dbContext;
    private readonly DbSet<StoreEntity> _entitySet;

    public StoresService(IMapper mapper, StoreDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
        _entitySet = _dbContext.Set<StoreEntity>();
    }

    public async Task CreateAsync(CreateStoreDto command, CancellationToken cancellationToken)
    {
        var store = _mapper.Map<StoreEntity>(command);

        _entitySet.Add(store);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<GetAllStoresItemDto>> GetAllAsync(CancellationToken cancellationToken) => 
        _mapper.Map<IEnumerable<GetAllStoresItemDto>>(await _entitySet.ToListAsync(cancellationToken));
}
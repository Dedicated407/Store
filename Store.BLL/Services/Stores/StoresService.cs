using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store.BLL.DataTransferObjects;
using Store.DAL.Storages.DatabaseStorage;
using StoreEntity = Store.DAL.Entities.Store;

namespace Store.BLL.Services.Stores;

internal class StoresService : IStoresService
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

    public async Task CreateAsync(StoreDto command, CancellationToken cancellationToken)
    {
        var store = _mapper.Map<StoreEntity>(command);

        _entitySet.Add(store);
        await _dbContext.SaveChangesAsync(cancellationToken);

        // TODO: стоит ли в try catch оборачивать?
    }
}
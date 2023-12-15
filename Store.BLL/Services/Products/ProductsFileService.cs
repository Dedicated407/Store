using AutoMapper;
using Store.BLL.DataTransferObjects;
using Store.BLL.DataTransferObjects.Products.Responses;
using Store.DAL.Entities;
using Store.DAL.Storages.FileStorage;

namespace Store.BLL.Services.Products;

public class ProductsFileService : IProductsService
{
    private readonly IMapper _mapper;
    private const string Path = "products.json";

    public ProductsFileService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task CreateAsync(ProductDtoCommand command, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(command);
        await FileManager.WriteToFileAsync(Path, product);
    }

    public async Task<IEnumerable<GetAllProductsItemDto>> GetAllAsync(CancellationToken cancellationToken) 
        => _mapper.Map<IEnumerable<GetAllProductsItemDto>>(await FileManager.ReadAllFromFileAsync<Product>(Path));
}
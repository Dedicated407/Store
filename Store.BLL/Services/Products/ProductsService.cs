using AutoMapper;
using Store.BLL.DataTransferObjects;
using Store.DAL.Entities;

namespace Store.BLL.Services.Products;

internal class ProductsService : IProductsService
{
    private readonly IMapper _mapper;

    public ProductsService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task Add(ProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        // TODO: подумать над тем, стоит ли добавлять UnitOfWork, Repositories
    }
}
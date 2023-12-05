using AutoMapper;
using Store.BLL.DomainModels;
using Store.DAL.Entities;

namespace Store.BLL.Services.Products;

internal class ProductService : IProductService
{
    private readonly IMapper _mapper;

    public ProductService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task Add(ProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        // TODO: подумать над тем, стоит ли добавлять UnitOfWork, Repositories
    }
}
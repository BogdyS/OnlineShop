using System.Linq.Expressions;
using BusinessLogic.Repositories.Interfaces;
using BusinessLogic.Services.Interfaces;
using Common.DTO;
using DataConnection.Entity;

namespace BusinessLogic.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<IEnumerable<ProductDTO>> GetAllAsync()
    {
        return await _productRepository.GetAllAsync();
    }

    public async Task<ProductDTO> GetByIdAsync(int id)
    {
        return await _productRepository.GetAsync(id);
    }

    public async Task<IEnumerable<ProductDTO>> FindByNameAsync(string name)
    {
        return await _productRepository.GetAllAsync(product => product.Name.ToLower().Contains(name.ToLower()));
    }

    public async Task<IEnumerable<ProductDTO>> GetCustomAsync(Expression<Func<Product, bool>>? filter, IOrderedQueryable<Product>? orderBy = null)
    {
        return await _productRepository.GetAllAsync(filter, orderBy);
    }

    public async Task<IEnumerable<ProductDTO>> GetCustomAsync(IOrderedQueryable<Product>? orderBy)
    {
        return await _productRepository.GetAllAsync(orderBy);
    }
}
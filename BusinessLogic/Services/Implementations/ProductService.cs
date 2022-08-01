using System.Linq.Expressions;
using BusinessLogic.Repositories.Interfaces;
using BusinessLogic.Services.Interfaces;
using Common.DTO;
using Common.Exceptions;
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
        var products = await _productRepository.GetAllAsync();
        if (products == null)
        {
            throw new NotFoundException("No products exists");
        }

        return products;
    }

    public async Task<ProductDTO> GetByIdAsync(int id)
    {
        var product = await _productRepository.GetAsync(id);
        if (product == null)
        {
            throw new NotFoundException("Product not found");
        }

        return product;
    }

    public async Task<IEnumerable<ProductDTO>> FindByNameAsync(string name) //TODO: ElasticSearch 
    {
        var products = await _productRepository.GetAllAsync(product => product.Name.ToLower().Contains(name.ToLower()));
        if (products == null)
        {
            throw new NotFoundException($"Products with name \"{name}\" not exists");
        }
        return products;
    }

    public async Task<IEnumerable<ProductDTO>> GetCustomAsync(Expression<Func<Product, bool>>? filter,
                                    Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null)
    {
        if (filter == null && orderBy == null)
        {
            return await _productRepository.GetAllAsync() ?? new List<ProductDTO>();
        }
        if (orderBy == null)
        {
            return await _productRepository.GetAllAsync(filter) ?? new List<ProductDTO>();
        }
        return await _productRepository.GetAllAsync(filter, orderBy) ?? new List<ProductDTO>();
    }

    public async Task<IEnumerable<ProductDTO>> GetCustomAsync(Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy)
    {
        return await _productRepository.GetAllAsync(orderBy) ?? new List<ProductDTO>();
    }
}
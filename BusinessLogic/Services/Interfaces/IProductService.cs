using System.Linq.Expressions;
using Common.DTO.Product;
using DataConnection.Entity;

namespace BusinessLogic.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetAllAsync();
    Task<ProductDTO> GetByIdAsync(int id);
    Task<IEnumerable<ProductDTO>> FindByNameAsync(string name);
    Task<IEnumerable<ProductDTO>> GetCustomAsync(Expression<Func<Product, bool>> filter,
        Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null);
    Task<IEnumerable<ProductDTO>> GetCustomAsync(Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy);
}
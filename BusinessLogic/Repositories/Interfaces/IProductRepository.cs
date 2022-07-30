using System.Linq.Expressions;
using Common.DTO;
using DataConnection.Entity;

namespace BusinessLogic.Repositories.Interfaces;

public interface IProductRepository : IDisposable
{
    Task<IEnumerable<ProductDTO>> GetAllAsync();
    Task<ProductDTO> GetAsync(int id);
    Task<IEnumerable<ProductDTO>> GetAllAsync(
        Expression<Func<Product, bool>> filter,
        IOrderedQueryable<Product> orderBy);
}
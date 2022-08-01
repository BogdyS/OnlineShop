using System.Linq.Expressions;
using Common.DTO;
using DataConnection.Entity;

namespace BusinessLogic.Repositories.Interfaces;

public interface IProductRepository : IDisposable
{
    Task<ProductDTO?> GetAsync(int id);
    Task<IEnumerable<ProductDTO>?> GetAllAsync(
        Expression<Func<Product, bool>>? filter,
        Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null);
    Task<IEnumerable<ProductDTO>?> GetAllAsync(
        Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null);
}
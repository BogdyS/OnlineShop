using System.Linq.Expressions;
using Common.DTO.Order;
using DataConnection.Entity;

namespace BusinessLogic.Repositories.Interfaces;

public interface IOrderRepository : IDisposable
{
    Task<OrderDTO?> GetAsync(int id);
    Task<IEnumerable<OrderDTO>?> GetAllAsync(
        Expression<Func<Order, bool>>? filter,
        Func<IQueryable<Order>, IOrderedQueryable<Order>>? orderBy = null);
    Task<IEnumerable<OrderDTO>?> GetAllAsync(
        Func<IQueryable<Order>, IOrderedQueryable<Order>>? orderBy = null);
}
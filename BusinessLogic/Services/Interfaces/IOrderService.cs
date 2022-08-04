using System.Linq.Expressions;
using Common.DTO.Order;
using DataConnection.Entity;

namespace BusinessLogic.Services.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<OrderDTO>> GetAllAsync();
    Task<OrderDTO> GetByIdAsync(int id);
    Task<IEnumerable<OrderDTO>> GetCustomAsync(Expression<Func<Order, bool>> filter,
        Func<IQueryable<Order>, IOrderedQueryable<Order>>? orderBy = null);
    Task<IEnumerable<OrderDTO>> GetCustomAsync(Func<IQueryable<Order>, IOrderedQueryable<Order>>? orderBy);
}
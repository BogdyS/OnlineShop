using System.Linq.Expressions;
using BusinessLogic.Repositories.Interfaces;
using BusinessLogic.Services.Interfaces;
using Common.DTO.Order;
using Common.Exceptions;
using DataConnection.Entity;

namespace BusinessLogic.Services.Implementations;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<OrderDTO>> GetAllAsync()
    {
        var orders = await _orderRepository.GetAllAsync();
        if (orders == null)
        {
            throw new NotFoundException("No orders exists");
        }
        return orders;
    }

    public async Task<OrderDTO> GetByIdAsync(int id)
    {
        var order = await _orderRepository.GetAsync(id);
        if (order == null)
        {
            throw new NotFoundException("Order not found");
        }
        return order;
    }

    public async Task<IEnumerable<OrderDTO>> GetCustomAsync(Expression<Func<Order, bool>> filter, Func<IQueryable<Order>, IOrderedQueryable<Order>>? orderBy = null)
    {
        if (orderBy == null)
        {
            return await _orderRepository.GetAllAsync(filter) ?? new List<OrderDTO>();
        }
        return await _orderRepository.GetAllAsync(filter, orderBy) ?? new List<OrderDTO>();
    }

    public async Task<IEnumerable<OrderDTO>> GetCustomAsync(Func<IQueryable<Order>, IOrderedQueryable<Order>>? orderBy)
    {
        return await _orderRepository.GetAllAsync(orderBy) ?? new List<OrderDTO>();
    }
}
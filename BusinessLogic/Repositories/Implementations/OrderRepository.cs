using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BusinessLogic.Repositories.Interfaces;
using Common.DTO.Order;
using DataConnection;
using DataConnection.Entity;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Repositories.Implementations;

public class OrderRepository : IOrderRepository
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    public OrderRepository(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }
    public async Task<OrderDTO?> GetAsync(int id)
    {
        return await _dataContext.Orders
            .ProjectTo<OrderDTO>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(o => o.Id == id);
    }

    public async Task<IEnumerable<OrderDTO>?> GetAllAsync(Expression<Func<Order, bool>>? filter,
                                    Func<IQueryable<Order>, IOrderedQueryable<Order>>? orderBy = null)
    {
        var query = _dataContext.Orders.AsQueryable();

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        return await query
            .ProjectTo<OrderDTO>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<IEnumerable<OrderDTO>?> GetAllAsync(Func<IQueryable<Order>, IOrderedQueryable<Order>>? orderBy = null)
    {
        var query = _dataContext.Orders.AsQueryable();

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        return await query
            .ProjectTo<OrderDTO>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
}
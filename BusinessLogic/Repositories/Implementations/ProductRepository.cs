using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BusinessLogic.Repositories.Interfaces;
using Common.DTO.Product;
using DataConnection;
using DataConnection.Entity;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Repositories.Implementations;

public class ProductRepository : IProductRepository
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    public ProductRepository(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }

    public async Task<ProductDTO?> GetAsync(int id)
    {
        return await _dataContext.Products
            .ProjectTo<ProductDTO>(_mapper.ConfigurationProvider)
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<ProductDTO>?> GetAllAsync(Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null)
    {
        var query = _dataContext.Products.AsQueryable();

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        return await query
            .ProjectTo<ProductDTO>(_mapper.ConfigurationProvider)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<ProductDTO>?> GetAllAsync(Expression<Func<Product, bool>>? filter,
                                    Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null)
    {
        var query = _dataContext.Products.AsQueryable();

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        return await query
            .ProjectTo<ProductDTO>(_mapper.ConfigurationProvider)
            .AsNoTracking()
            .ToListAsync();
    }

    public async void Dispose()
    {
        await _dataContext.DisposeAsync();
    }
}
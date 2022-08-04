using AutoMapper;
using AutoMapper.QueryableExtensions;
using BusinessLogic.Repositories.Interfaces;
using Common.DTO.Type;
using DataConnection;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Repositories.Implementations;

public class TypeRepository : ITypeRepository
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;

    public TypeRepository(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TypeDTO>> GetAllAsync()
    {
        return await _dataContext.Types
            .ProjectTo<TypeDTO>(_mapper.ConfigurationProvider)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<TypeDTO?> GetAsync(int id)
    {
        return await _dataContext.Types
            .ProjectTo<TypeDTO>(_mapper.ConfigurationProvider)
            .AsNoTracking()
            .SingleOrDefaultAsync(t => t.Id == id);
    }

    public async void Dispose()
    {
        await _dataContext.DisposeAsync();
    }
}
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BusinessLogic.Repositories.Interfaces;
using Common.DTO.Manufacturer;
using DataConnection;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Repositories.Implementations;

public class ManufacturerRepository : IManufacturerRepository
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;

    public ManufacturerRepository(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ManufacturerDTO>> GetAllAsync()
    {
        return await _dataContext.Manufacturers
            .ProjectTo<ManufacturerDTO>(_mapper.ConfigurationProvider)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<ManufacturerDTO?> GetAsync(int id)
    {
        return await _dataContext.Manufacturers
            .ProjectTo<ManufacturerDTO>(_mapper.ConfigurationProvider)
            .AsNoTracking()
            .SingleOrDefaultAsync(m => m.Id == id);
    }

    public async Task<IEnumerable<ManufacturerDTO>> GetByNameAsync(string name) //TODO: ElasticSearch
    {
        return await _dataContext.Manufacturers
            .Where(m => m.Name.ToLower().Contains(name.ToLower()))
            .ProjectTo<ManufacturerDTO>(_mapper.ConfigurationProvider)
            .AsNoTracking()
            .ToListAsync();
    }

    public async void Dispose()
    {
        await _dataContext.DisposeAsync();
    }
}
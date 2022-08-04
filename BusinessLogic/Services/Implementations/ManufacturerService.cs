using BusinessLogic.Repositories.Interfaces;
using BusinessLogic.Services.Interfaces;
using Common.DTO.Manufacturer;
using Common.Exceptions;

namespace BusinessLogic.Services.Implementations;

public class ManufacturerService : IManufacturerService
{
    private readonly IManufacturerRepository _manufacturerRepository;

    public ManufacturerService(IManufacturerRepository manufacturerRepository)
    {
        _manufacturerRepository = manufacturerRepository;
    }

    public async Task<IEnumerable<ManufacturerDTO>> GetAllAsync()
    {
        return await _manufacturerRepository.GetAllAsync();
    }

    public async Task<ManufacturerDTO> GetByIdAsync(int id)
    {
        var manufacturer = await _manufacturerRepository.GetAsync(id);

        if (manufacturer == null)
        {
            throw new NotFoundException("Manufacturer not found");
        }

        return manufacturer;
    }

    public async Task<IEnumerable<ManufacturerDTO>> GetByNameAsync(string name)
    {
        return await _manufacturerRepository.GetByNameAsync(name);
    }
}
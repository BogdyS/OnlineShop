using Common.DTO.Manufacturer;

namespace BusinessLogic.Repositories.Interfaces;

public interface IManufacturerRepository : IDisposable
{
    Task<IEnumerable<ManufacturerDTO>> GetAllAsync();
    Task<ManufacturerDTO?> GetAsync(int id);
    Task<IEnumerable<ManufacturerDTO>> GetByNameAsync(string name);
}
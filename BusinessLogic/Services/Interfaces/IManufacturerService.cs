using Common.DTO.Manufacturer;

namespace BusinessLogic.Services.Interfaces;

public interface IManufacturerService
{
    Task<IEnumerable<ManufacturerDTO>> GetAllAsync();
    Task<ManufacturerDTO> GetByIdAsync(int id);
    Task<IEnumerable<ManufacturerDTO>> GetByNameAsync(string name);
}
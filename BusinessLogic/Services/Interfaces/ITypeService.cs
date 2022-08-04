using Common.DTO.Type;

namespace BusinessLogic.Services.Interfaces;

public interface ITypeService
{
    Task<IEnumerable<TypeDTO>> GetAllAsync();
    Task<TypeDTO> GetByIdAsync(int id);
}
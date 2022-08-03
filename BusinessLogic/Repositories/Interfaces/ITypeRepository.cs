using Common.DTO.Type;

namespace BusinessLogic.Repositories.Interfaces;

public interface ITypeRepository
{
    Task<IEnumerable<TypeDTO>> GetAllAsync();
    Task<TypeDTO?> GetAsync(int id);
}